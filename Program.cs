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
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(70, 52);
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
