using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBirthday
{
    public static class DrawingExtensions
    {
        private const char LineEnding = 'X';
        private static readonly string LineEndingString = 'X'.ToString();

        public static void WriteFrame(string frame)
        {
            var column = 0;
            var row = 0;

            foreach (var character in frame)
            {
                if (character == LineEnding)
                {
                    CleanRow();
                    row++;
                    column = 0;
                    continue;
                } else
                {
                    Console.SetCursorPosition(column++, row);
                    Console.Write(character);
                }
            }
        }

        private static void CleanRow()
        {
            var (row, column) = Console.GetCursorPosition();
            var width = Console.WindowWidth;

            for (int i = column; i < width; i++)
            {
                Console.SetCursorPosition(i, row);
                Console.Write(string.Empty);
            }
        }

        public static string[] ConvertFrames(string[] frames)
        {
            var convertedFrames = new string[frames.Length];
            var i = 0;

            foreach (var frame in frames)
            {
                convertedFrames[i++] = frame.Replace(Environment.NewLine, LineEndingString);
            }

            return convertedFrames;
        }
    }
}
