using AoC2022.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Days
{

    public class Day2 : IDays
    {


        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }

        public static int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            int totalPoints = 0;

            foreach (var rounds in input)
            {
                char[] picks = rounds.ToCharArray();
                var roundRes = roundResult(picks[0], picks[2]);
                int score = ((int)roundRes*3) + picks[2] - 64 - 23;
                totalPoints += score;
            }

            return totalPoints;
        }

        public static int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            int totalPoints = 0;

            foreach (var rounds in input)
            {
                char[] details = rounds.ToCharArray();
                Result result = (Result)((int)details[2] - 64 - 24);
                Picks opponentPick = convertToPick(details[0]);

                Picks myPick = new Picks();
                switch (result)
                {
                    // draw
                    case Result.Draw:
                        myPick = opponentPick;
                        break;
                    // win
                    case Result.Win:
                        myPick = opponentPick == Picks.Scissors ? Picks.Rock : (Picks)(opponentPick + 1);
                        break;
                    // lose
                    case Result.Loss:
                        myPick = opponentPick == Picks.Rock ? Picks.Scissors : (Picks)(opponentPick - 1);
                        break;

                }
                totalPoints += (int)myPick + ((int)result * 3);
            }

            return totalPoints;
        }

        private static Picks convertToPick(char pick)
        {
            return (Picks)(int)pick - 64;
        }

        private static Result roundResult(char opponentPick, char myPick) 
        {
            var result = Result.Loss;
            switch (opponentPick) {
                case 'A': 
                    if(myPick == 'X')
                        result = Result.Draw;
                    else if(myPick == 'Y')
                        result = Result.Win;
                    break;
                case 'B':
                    if (myPick == 'Y')
                        result = Result.Draw;
                    else if (myPick == 'Z')
                        result = Result.Win;
                    break;
                case 'C':
                    if (myPick == 'Z')
                        result = Result.Draw;
                    else if (myPick == 'X')
                        result = Result.Win;
                    break;
                default : break;
             }


            return result;
        }

        private enum Picks
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        private enum Result
        {
            Loss = 0,
            Draw = 1,
            Win = 2
        }
    }
}
