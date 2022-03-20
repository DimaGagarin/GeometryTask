using System;

namespace GeometryTask
{
    static class CheckInput
    {
        private const string ErrorInput = "\nIncorect input. Try again:";

        public static int Input(string line, int min, int max, bool error = false)
        {
            Console.WriteLine(line);
            int temp;

            while (!int.TryParse(Console.ReadLine(), out temp))
            {
                Console.WriteLine(ErrorInput);
            }

            if (temp < min || temp > max)
            {
                if (!error)
                {
                    temp = Input(line + $"(more then {min} and less then {max})", min, max, true);
                }
                else
                {
                    temp = Input(line, min, max, true);
                }
            }

            return temp;
        }
    }
}
