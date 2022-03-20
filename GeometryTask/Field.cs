using System;

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

            PrintHorizontalBorder();

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
                        default:
                            //cannot be here
                            break;
                    }
                }

                Console.Write(Space + i + "\n");
            }

            PrintHorizontalBorder();
        }

        private void PrintHorizontalBorder()
        {
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

        public bool InsertShape(int horizontalX, int verticalY, int length, int height, int identifaer)
        {
            if (!IsRectanglePossibleInsert(horizontalX - 1, verticalY - 1, length, height))
            {
                return false;
            }

            while (height > 0)
            {
                int tempLength = length;
                int tempX = horizontalX;

                while (tempLength > 0)
                {
                    Board[verticalY - 1, tempX - 1] = identifaer;
                    tempLength--;
                    tempX++;
                }

                verticalY++;
                height--;
            }

            return true;
        }

        public bool IsRectanglePossibleInsert(int horizontalX, int verticalY, int length, int height)
        {
            if ((horizontalX + length) > Board.GetLength(1) || (verticalY + height) > Board.GetLength(0))
            {
                return false;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (Board[verticalY + j, horizontalX + i] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //complexity 2n^2
        public bool IsRectangleFit(int length, int height)
        {
            int[,] tempBoard = new int[Board.GetLength(0), Board.GetLength(1)];

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    counter = Board[i, j] == 0 ? ++counter : 0;
                    tempBoard[i, j] = counter;
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
    }
}
