using System;

namespace GeometryTask
{
    internal class Player
    {
        private const string IncorrectChoice = "\nIt is not possible to place a figure here";

        public int Moves { get; set; }
        public int Score { get; set; } = 0;
        public int Id { get; }

        public Player(int moves, int id)
        {
            this.Moves = moves;
            this.Id = id;
        }

        public void MakeRoll(Dice dice)
        {
            Console.WriteLine($"\nPlayer {Id} roll the dices. Press Enter.");
            PressKey.Enter();
            dice.PrintDice();
        }


        public void MakeChoice(Field field, int length, int height, bool error = false)
        {
            string inputX;
            string inputY;

            if (!error)
            {
                Console.WriteLine($"\nPlayer {Id} chose where to insert the shape.");
                inputX = "Enter X:";
                inputY = "Enter Y:";
            }
            else
            {
                Console.WriteLine(IncorrectChoice);
                inputX = "Enter correct X:";
                inputY = "Enter correct Y:";
            }

            if (!field.InsertShape(CheckInput.Input(inputX, 1, field.Board.GetLength(1)), CheckInput.Input(inputY, 1, field.Board.GetLength(0)), length, height, this.Id))
            {
                MakeChoice(field, length, height, true);
            }

            this.Score += length * height;
        }
    }
}
