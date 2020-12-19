using System;
using System.Threading.Tasks;

namespace ConsoleBirthday
{
    class Program
    {
        private const int FrameRatePerSecond = 24;

        static async Task Main(string[] args)
        {
            var frameCounter = 0;
            var frameCount = AsciiArt.BirthdayCake.Length;
            var drawableFrames = DrawingExtensions.ConvertFrames(AsciiArt.BirthdayCake);
            Console.SetWindowSize(70, 40);
            Console.Clear();
            Console.CursorVisible = false;

            do
            {
                DrawingExtensions.WriteFrame(drawableFrames[frameCounter]);

                if (++frameCounter == frameCount)
                {
                    frameCounter = 0;
                }

                await Task.Delay(1000 / FrameRatePerSecond);
            } while (true);
        }
    }
}
