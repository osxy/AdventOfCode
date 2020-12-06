using System;
using System.Linq;

namespace AoC2020.Days
{

    public class Day6 : IDays
    {
        
        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }


        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsString(inputFile); 
            var customsFormArray = input.Split("\r\n\r\n", StringSplitOptions.TrimEntries);

            int sum = 0;

            foreach (string customForm in customsFormArray)
            {
                var distinctChars = customForm.Replace("\r\n", "").Distinct();
                var numberOfPersons = customForm.Split("\r\n").Count();

                foreach (char character in distinctChars)
                {
                    if(customForm.Count(c => c == character) == numberOfPersons){
                        sum += 1;
                    }
                }
            }

            return sum;
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsString(inputFile);
            var customsFormArray = input.Split("\r\n\r\n", StringSplitOptions.TrimEntries);

            int sum = 0;

            foreach(string customForm in customsFormArray)
            {
                sum += customForm.Replace("\r\n", "").Distinct().Count();
            }

            return sum;
        }

    }

}
