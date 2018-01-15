using System;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
namespace ScreenRecorder
{
    class Program
    {
        private const string EventName = "RecorderStateEvent";
        private const string StartCommand = "Start";
        private const string StopCommand = "Stop";
        static EventWaitHandle EventHandle;

        private static string fileNamePrefix;
        private static string applicationState;
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    applicationState = args[0];
                    if (applicationState == StartCommand)
                    {
                        fileNamePrefix = args[1];
                        Start();
                    }
                    else if (applicationState == StopCommand)
                    {
                        Stop();
                    }
                }
                else
                {
                    WriteError("Recording requires argumet Start/Stop. If Start, write next argument name of file, where video should be saved");
                }
            }
            catch (Exception)
            {
            }
        }
        public static void Stop()
        {
            bool Exist = FindEvent();

            if (Exist == false)
            {
                WriteError("There should be recorder");
            }
            else if (Exist == true)
            {

                EventHandle.Set();
            }
        }
        public static void Start()
        {
            bool Exist = FindEvent();

            if (Exist == false)
            {
                StartEvent();
            }
            else if (Exist == true)
            {
                WriteError("There should be only one recorder at the moment");
                return;
            }
            try
            {
                string fileName = fileNamePrefix + "_screenvideo.avi";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (Recorder recorder = new Recorder(new RecorderParameters(fileName, 5, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 30)))
                {
                    EventHandle.Reset();
                    EventHandle.WaitOne();
                }
            }
            catch (IndexOutOfRangeException)
            {
                WriteError("Start requires filename, where it should save video");
            }
        }
        public static bool FindEvent()
        {
            try
            {
                EventHandle = EventWaitHandle.OpenExisting(EventName);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                WriteError("Unauthorized access to event");
            }
            return true;
        }
        public static void StartEvent()
        {
            // The event does not exist, so create it.

            // Create an access control list (ACL) that denies the
            // current user the right to wait on or signal the 
            // event, but allows the right to read and change
            // security information for the event.
            //
            bool wasCreated;
            string user = GetUser();
            EventWaitHandleSecurity EventHandleSec = new EventWaitHandleSecurity();

            EventWaitHandleAccessRule rule = SetRule(user, EventWaitHandleRights.Synchronize | EventWaitHandleRights.Modify);
            EventHandleSec.AddAccessRule(rule);

            rule = SetRule(user, EventWaitHandleRights.ReadPermissions | EventWaitHandleRights.ChangePermissions);
            EventHandleSec.AddAccessRule(rule);

            EventHandle = new EventWaitHandle(true, EventResetMode.AutoReset, EventName, out wasCreated, EventHandleSec);

            if (wasCreated)
            {
                Console.Write("Created the named event.");
            }
            else
            {
                WriteError("Unable to create the event.");
                return;
            }
        }
        public static string GetUser()
        {
            return Environment.UserDomainName + "\\" + Environment.UserName;
        }
        public static EventWaitHandleAccessRule SetRule(string user, EventWaitHandleRights Rights, AccessControlType Access = AccessControlType.Allow)
        {
            return new EventWaitHandleAccessRule(user, Rights, Access);
        }
        public static void WriteError(string Message)
        {
            throw new Exception(Message);
        }
    }
}
