using System;

namespace GeometryTask
{
    internal class Dice
    {
        private const string UpperLine = " _____   _____";
        private const string PreUpperLine = "|     | |     |";
        private const string BottomLine = "|_____| |_____|";

        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public void PrintDice()
        {
            Random rnd = new();

            this.Value1 = rnd.Next(1, 7);
            this.Value2 = rnd.Next(1, 7);

            Console.WriteLine(UpperLine);
            Console.WriteLine(PreUpperLine);
            Console.WriteLine($"|  {Value1}  | |  {Value2}  |");
            Console.WriteLine(BottomLine);
        }
    }
}
