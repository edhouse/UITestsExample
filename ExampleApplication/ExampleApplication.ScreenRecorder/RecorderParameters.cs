using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System.Windows.Forms;


namespace ScreenRecorder
{
    public class RecorderParameters
    {
        private string fileName;
        public RecorderParameters(string filename, int frameRate, FourCC encoder, int quality)
        {
            this.fileName = filename;
            framesPerSecond = frameRate;
            codec = encoder;
            this.quality = quality;

            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        public int framesPerSecond, quality;
        FourCC codec;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public AviWriter CreateAviWriter()
        {
            return new AviWriter(fileName)
            {
                FramesPerSecond = framesPerSecond,
                EmitIndex1 = true,
            };
        }

        public IAviVideoStream CreateVideoStream(AviWriter writer)
        {
            // Select encoder type based on FOURCC of codec
            if (codec == KnownFourCCs.Codecs.Uncompressed)
                return writer.AddUncompressedVideoStream(Width, Height);
            else if (codec == KnownFourCCs.Codecs.MotionJpeg)
                return writer.AddMotionJpegVideoStream(Width, Height, quality);
            else
            {
                return writer.AddMpeg4VideoStream(Width, Height, (double)writer.FramesPerSecond,
                    // It seems that all tested MPEG-4 VfW codecs ignore the quality affecting parameters passed through VfW API
                    // They only respect the settings from their own configuration dialogs, and Mpeg4VideoEncoder currently has no support for this
                    quality: quality,
                    codec: codec,
                    // Most of VfW codecs expect single-threaded use, so we wrap this encoder to special wrapper
                    // Thus all calls to the encoder (including its instantiation) will be invoked on a single thread although encoding (and writing) is performed asynchronously
                    forceSingleThreadedAccess: true);
            }
        }
    }
}
