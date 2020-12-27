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

            var savedBackgroundColor = Console.BackgroundColor;
            var savedForegroundColor = Console.ForegroundColor;

            try
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Title = "Boldog Szüetésnapot!";
                try
                {
                    Console.SetWindowPosition(0, 3);
                    Console.SetWindowSize(80, Console.LargestWindowHeight);
                }
                catch { }
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
            finally
            {
                Console.BackgroundColor = savedBackgroundColor;
                Console.ForegroundColor = savedForegroundColor;
            }
        }
    }
}
