using System;

namespace AoC2020.Days
{

    public class Day3 : IDays
    {

        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }

        public static long ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            long result = 1;
            result *= SlopeRunner(input, 1, 1);
            result *= SlopeRunner(input, 3, 1);
            result *= SlopeRunner(input, 5, 1);
            result *= SlopeRunner(input, 7, 1);
            result *= SlopeRunner(input, 1, 2);

            return result;
        }

        public static int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var trees = SlopeRunner(input, 3, 1);
            return trees;
        }

        private static int SlopeRunner(string[] input, int right, int down)
        {
            int trees = 0;
            var x = 0;
            var y = 0;

            var lineLength = input[y].Length;
            while (y < input.Length - 1)
            {
                x += right;
                y += down;

                if (input[y][x % lineLength] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }



    }

}
