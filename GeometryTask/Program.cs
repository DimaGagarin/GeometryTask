using System;
using System.Collections.Generic;

namespace GeometryTask
{
    public static class Program
    {
        private const string EnterText = "Geometry Game\nEnter the width and length of the field as well as the number of moves";
        private const string InputText = "Enter height:\nEnter length:\nEnter moves:";
        private const string TextForOneMoreStep = "\nA rectangle with such dimensions cannot be placed on the field. Try your luck one more time";
        private const string TextForNoMoreSteps = "\nBad luck.You miss a turn. Press Enter to continue.";

        private const int PlayerIdFirst = 1;
        private const int PlayerIdLast = 2;
        private const int MinMoves = 20;
        private const int MinHeight = 20;
        private const int MaxHeight = 60;//or int.MaxValue
        private const int MinLength = 30;
        private const int MaxLength = 70;//or int.MaxValue
        private const bool Chance = true;

        static void Main()
        {
            ConsoleSetup.Setup();
            ConsoleSetup.SetupMidle(EnterText);

            string[] options = InputText.Split("\n");

            Field field = new(CheckInput.Input(options[0], MinHeight, MaxHeight), CheckInput.Input(options[1], MinLength, MaxLength));

            int moves = CheckInput.Input(options[2], MinMoves, int.MaxValue);

            Player player1 = new(moves, PlayerIdFirst);
            Player player2 = new(moves, PlayerIdLast);
            List<Player> players = new() { player1, player2 };

            Dice dice = new();

            while (player1.Moves > 0)
            {
                foreach (Player player in players)
                {
                    field.PrintField();

                    Console.WriteLine($"\nPlayer {player.Id} you have {player.Moves} moves left.");

                    MakeStep(field, dice, player, Chance);
                }
                if ((player1.Score + player2.Score) == field.Board.GetLength(0) * field.Board.GetLength(1))
                {
                    break;
                }                   
            }

            field.PrintField();
            EndGame(players, field);
        }

        static void MakeStep(Field field, Dice dice, Player player, bool chance)
        {
            player.MakeRoll(dice);

            if (field.IsRectangleFit(dice.Value1, dice.Value2))
            {
                player.MakeChoice(field, dice.Value1, dice.Value2);
                player.Moves--;
            }
            else
            {
                if (chance)
                {
                    Console.WriteLine(TextForOneMoreStep);
                    MakeStep(field, dice, player, false);
                }
                else
                {
                    Console.WriteLine(TextForNoMoreSteps);
                    PressKey.Enter();
                    player.Moves--;
                }
            }
        }

        static void EndGame(List<Player> players, Field field)
        {

            string endGameText;

            if (players[0].Score == players[1].Score)
            {
                endGameText = new string($"End Game\nDraw. Both players have the same score {players[0].Score}\nPress Enter to close the game");
            }
            else
            {
                Player winner = players[0].Score < players[1].Score ? players[1] : players[0];
                Player loser = players[0].Score < players[1].Score ? players[0] : players[1];

                endGameText = new string($"End Game\n Player {winner.Id} won with a score {winner.Score}\nPlayer {loser.Id} lost by score {loser.Score}\nPress Enter to close the game");
            }

            ConsoleSetup.SetupMidle(endGameText, field.Board.GetLength(0) + 3);
            PressKey.Enter();
        }
    }
}
