using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{

    public class Day10 : IDays
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
            var input = Helpers.ArraysAndLists.StringArrayToIntArray(Helpers.General.GetDataFromInputFileAsStringArray(inputFile));
            input = input.OrderBy(x => x).ToArray();
            List<adapters> adapters = new List<adapters>();
            var result = 1;
            foreach (var adapter in input)
            {
                var adaptersWithinThree = 0;
                if (input.Count(x => x > adapter && x <= adapter + 3) == 3)
                {
                    adaptersWithinThree = 2;
                }
                else
                {
                    adaptersWithinThree = input.Count(x => x > adapter && x <= adapter + 3);
                }

                if (adaptersWithinThree == 0) adaptersWithinThree = 1;
                result *= adaptersWithinThree;
                adapters.Add(
                    new adapters { baseJolt = adapter, adaptersWithinThree = adaptersWithinThree }
                );
            }

            return result;
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.ArraysAndLists.StringArrayToIntArray(Helpers.General.GetDataFromInputFileAsStringArray(inputFile));
            var oneDifference = 0;
            var threeDifference = 1;
            input = input.OrderBy(x => x).ToArray();
            

            for (int i = 0; i < input.Length; i++)
            {
                int difference;
                if (i == 0)
                {
                    difference = input[i];
                }
                else
                {
                    difference = input[i] - input[i - 1];
                }

                switch (difference)
                {
                    case 1:
                        oneDifference++;
                        break;
                    case 3:
                        threeDifference++;
                        break;
                }

            }

            return oneDifference * threeDifference;
        }

        public class adapters
        {
            public int baseJolt { get; set; }
            public int adaptersWithinThree { get; set; }
        }

    }

}
