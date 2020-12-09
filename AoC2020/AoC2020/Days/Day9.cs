using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AoC2020.Helpers;

namespace AoC2020.Days
{

    public class Day9 : IDays
    {
        
        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }

        public long ExecutePartTwo(string inputFile, int index = 25)
        {
            var input = ArraysAndLists.StringArrayToLongArray(General.GetDataFromInputFileAsStringArray(inputFile));
            var lookForNumber = ExecutePartOne(inputFile, index);
            var validNumbers = input.Where(x => x < lookForNumber).Reverse();

            for (int from = 0; from < validNumbers.Count(); from++)
            {
                var numberOfRecords = 1;
                var list = validNumbers.Skip(from);
                do
                {
                    var sum = list.Take(numberOfRecords).Sum();
                    if (sum == lookForNumber)
                    {
                        return list.Take(numberOfRecords).OrderBy(x=>x).Take(1).Single() + list.Take(numberOfRecords).OrderBy(x => x).TakeLast(1).Single();
                    } else if (sum > lookForNumber)
                    {
                        break;
                    }
                    
                    numberOfRecords++;
                }
                while (numberOfRecords+from < validNumbers.Count());
            }
            
            return 0;
        }

        public long ExecutePartOne(string inputFile, int index = 25)
        {
            var input = ArraysAndLists.StringArrayToLongArray(General.GetDataFromInputFileAsStringArray(inputFile));
            var currentIndex = index; // skip first 
            long checkingNumber;

            foreach (var line in input.Skip(index))
            {
                var foundSum = false;
                checkingNumber = line;
                var preamble = input.Skip(currentIndex-index).Take(index);
                foreach (var calc in preamble.Distinct())
                {
                    var lookForNumber = checkingNumber - calc;
                    if (preamble.Any(x => x == lookForNumber))
                    {
                        foundSum = true;
                        break;
                    };
                }

                if (!foundSum)
                {
                    return checkingNumber;
                }

                currentIndex++;
            }


            return 0;
        }

    }

}
