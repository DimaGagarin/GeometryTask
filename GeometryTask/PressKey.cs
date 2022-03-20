using System;

namespace GeometryTask
{
    static class PressKey
    {
        public static void Enter()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}
