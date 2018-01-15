using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ExampleApplication.UiTests
{
    public class Screenshot
    {
        public static Bitmap Take()
        {
            Bitmap screenshot = new Bitmap(SystemInformation.VirtualScreen.Width,
                                           SystemInformation.VirtualScreen.Height,
                                           PixelFormat.Format32bppArgb);

            Graphics screenGraph = Graphics.FromImage(screenshot);
            screenGraph.CopyFromScreen(SystemInformation.VirtualScreen.X,
                                       SystemInformation.VirtualScreen.Y,
                                       0,
                                       0,
                                       SystemInformation.VirtualScreen.Size,
                                       CopyPixelOperation.SourceCopy);
            return screenshot;
        }
        public static void Save(Bitmap screenshot, string screenshotPath)
        {
            try
            {
                if (File.Exists(screenshotPath))
                {
                    File.Delete(screenshotPath);
                }
                screenshot.Save(screenshotPath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception)
            {
                Console.WriteLine($"Failed to save screenshot to {screenshotPath}");
            }
        }
    }
}
