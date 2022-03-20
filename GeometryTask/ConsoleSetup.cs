using System;
using System.Runtime.InteropServices;

namespace GeometryTask
{
    static class ConsoleSetup
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        public static void Setup()
        {
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void SetupMidle(string text, int top = 20)
        {
            string[] lines = text.Split("\n");

            int center = Console.WindowWidth / 2;

            for (int i = 0; i < lines.Length; i++)
            {
                int left = center - (lines[i].Length / 2);

                Console.SetCursorPosition(left, top);
                Console.WriteLine(lines[i]);

                top = Console.CursorTop;
            }
        }
    }
}
