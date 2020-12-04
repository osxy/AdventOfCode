using AoC2020.Helpers;
using System.Linq;

namespace AoC2020.Days
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
            var array = ArraysAndLists.StringArrayToIntArray(input);

            foreach (int current in array)
            {
                var smallerList = array.Where(x => x <= 2020 - current).Select(x => x);
                foreach (int i in smallerList)
                {
                    var smallestList = array.Where(x => x <= 2020 - current - i).Select(x => x);
                    foreach (int j in smallestList)
                    {
                        if (current + i + j == 2020)
                        {
                            return current * i * j;
                        }
                    }
                }
            }
            return 0;
        }

        public static int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var array = Helpers.ArraysAndLists.StringArrayToIntArray(input);
            foreach(int current in array)
            {
                var smallerList = array.Where(x => x <= 2020 - current).Select(x => x);
                foreach (int i in smallerList)
                {
                    if (current + i == 2020)
                    {
                        return current * i;
                    }
                }
            }
            return 0;
        }
    }

}
