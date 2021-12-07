using AoC2021.Helpers;
using System;
using System.Linq;

namespace AoC2021.Days
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


        public static int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);

            return 0;
        }

        public static decimal ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var lengthOfInput = input[0].Length;
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < lengthOfInput; i++)
            {
                var subCalc = input.Select(x => x[i]).GroupBy(x => x).Select(x => new { value = x.Key, count = x.Count() });
                gamma = gamma + subCalc.OrderByDescending(x => x.count).First().value.ToString();
                epsilon = epsilon + subCalc.OrderBy(x => x.count).First().value.ToString();
            }


            return Convert.ToInt64(gamma, 2) * Convert.ToInt64(epsilon, 2);
        }

    }

}
