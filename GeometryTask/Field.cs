using System;
using System.Collections.Generic;

namespace GeometryTask
{
    internal class Field
    {
        private const string Space = " ";
        private const string SpaceTwice = "  ";
        private const int FirstPlayerID = 1;
        private const int LastPlayerID = 2;

        public int[,] Board { get; }

        public Field(int height, int length)
        {
            this.Board = new int[height, length];
        }

        public void PrintField()
        {
            Console.Clear();
            Console.Write(SpaceTwice);

            for (int i = 1; i <= Board.GetLength(1); i++)
            {
                if (i > 10)
                {
                    Console.Write(Space + i);
                }
                else
                {
                    Console.Write(SpaceTwice + i);
                }
            }

            Console.WriteLine();

            for (int i = 1; i <= Board.GetLength(0); i++)
            {
                Console.Write(i);
                if (i < 10)
                {
                    Console.Write(Space);
                }

                for (int j = 1; j <= Board.GetLength(1); j++)
                {
                    switch (Board[i - 1, j - 1])
                    {
                        case 0:
                            Print(ConsoleColor.Gray);
                            break;
                        case FirstPlayerID:
                            Print(ConsoleColor.DarkRed);
                            break;
                        case LastPlayerID:
                            Print(ConsoleColor.DarkBlue);
                            break;
                    }
                }

                Console.Write(Space + i + "\n");
            }

            Console.Write(SpaceTwice);

            for (int i = 1; i <= Board.GetLength(1); i++)
            {
                if (i > 10)
                {
                    Console.Write(Space + i);
                }
                else
                {
                    Console.Write(SpaceTwice + i);
                }
            }

            Console.WriteLine();
        }

        private static void Print(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(SpaceTwice + "\u25A0");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public bool InsertShape(int x, int y, int length, int height, int identifaer)
        {
            if (!CheakRectangle(x - 1, y - 1, length, height))
            {
                return false;
            }

            while (height > 0)
            {
                int tempLength = length;
                int tempX = x;

                while (tempLength > 0)
                {
                    Board[y - 1, tempX - 1] = identifaer;
                    tempLength--;
                    tempX++;
                }

                y++;
                height--;
            }

            return true;
        }

        public bool CheakRectangle(int x, int y, int length, int height)
        {
            if ((x + length) > Board.GetLength(1) || (y + height) > Board.GetLength(0))
            {
                return false;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (Board[y + j, x + i] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsRectangleFit(int length, int height)
        {
            int[,] tempBoard = new int[Board.GetLength(0), Board.GetLength(1)];

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == 0)
                    {
                        counter++;
                        tempBoard[i, j] = counter;
                    }
                    else
                    {
                        counter = 0;
                    }
                }
            }

            for (int i = length - 1; i < Board.GetLength(1); i++)
            {
                int counter = 0;
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (tempBoard[j, i] >= length)
                    {
                        counter++;
                        if (counter == height)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
            }
            return false;
        }

        public bool IsClearSpace()
        {
            List<int> list = new();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    list.Add(Board[i, j]);
                }

                if (list.Contains(0))
                {
                    return true;
                }

                list.Clear();
            }

            return false;
        }
    }
}
