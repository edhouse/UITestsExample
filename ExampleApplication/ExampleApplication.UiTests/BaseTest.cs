using ExampleApplication.Model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;


namespace ExampleApplication.UiTests
{
    public class BaseTest : IDisposable
    {
        private const ApplicationPlatform Platform = ApplicationPlatform.WinForms;

        private const string Start = "Start ";
        private const string Stop = "Stop ";
        private const string RecorderName = "ExampleApplication.ScreenRecorder.exe";

        private const int ExitProcessWaitTime = 2000;

        private Process recorder;

        public void Run()
        {
            string applicationArguments = Start + RunningTest;

            recorder = Process.Start(RecorderName, applicationArguments);
            ProcessStartInfo startInfo = new ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory + $"/{ProcessName}.exe")
            {
                UseShellExecute = false
            };
            var application = TestStack.White.Application.Launch(startInfo);
            Application = new ApplicationModel(application);
        }

        protected void Close()
        {
            Application.MainWindow.Close.Click();
        }

        public ApplicationModel Application { get; private set; }

        private void StopRecording()
        {
            Process.Start(RecorderName, Stop);
            recorder.WaitForExit(ExitProcessWaitTime);
            if (!recorder.HasExited)
            {
                recorder.Kill();
            }
        }

        public void Dispose()
        {
            bool killed = KillApplication();
            StopRecording();

            if (!killed)
            {
                DeleteFile(ScreenvideoName);
                DeleteFile(ScreenshotName);
            }
        }

        private string RunningTest => GetType().Name;

        private string ProcessName => "ExampleApplication." + Platform;

        private string ScreenshotName => RunningTest + "_screenshot.jpg";

        private string ScreenvideoName => RunningTest + "_screenvideo.avi";

        private void TakePicture()
        {
            Bitmap screenshot = Screenshot.Take();
            Screenshot.Save(screenshot, ScreenshotName);
        }

        private bool KillApplication()
        {
            Application.Process.WaitForExit(ExitProcessWaitTime);
            if (!Application.Process.HasExited)
            {
                TakePicture();
                Application.Process.Kill();
                return true;
            }
            return false;
        }

        private void DeleteFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                else
                {
                    Console.WriteLine($"File {filename} does not exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
