using AoC2022.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Days
{

    public class Day1 : IDays
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
            List<int> elvesList = GenerateElvesCaloryList(input);

            return elvesList.OrderDescending().Take(3).Sum();
        }

        public static int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            List<int> elvesList = GenerateElvesCaloryList(input);

            return elvesList.Max();
        }

        private static List<int> GenerateElvesCaloryList(string[] input)
        {
            var elvesList = new List<int>();
            var nextElf = true;
            var listId = 0;

            foreach (var record in input)
            {

                if (record == "")
                {
                    nextElf = true;
                    listId++;
                    continue;
                }

                if (nextElf)
                {
                    elvesList.Add(int.Parse(record));
                }
                else
                {
                    elvesList[listId] = elvesList[listId] + int.Parse(record);
                }

                nextElf = false;
            }

            return elvesList;
        }
    }

}
