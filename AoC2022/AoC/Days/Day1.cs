using AoC2022.Helpers;
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
            var array = Helpers.ArraysAndLists.StringArrayToIntArray(input);

            var higherThenPrevious = array.Take(array.Length-2).Select((item, index) => new { index, item }).Select(x => new {item = x.item, index = x.index, sum = (x.item + array[x.index +1] + array[x.index + 2])}).ToArray();

            return higherThenPrevious.Skip(1).Where(x => x.sum > higherThenPrevious[x.index - 1].sum).Count();
        }

        public static int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var array = Helpers.ArraysAndLists.StringArrayToIntArray(input);

            var higherThenPrevious = array.Skip(1).Select((item, index) => new { index, item }).Where(x => x.item > array[x.index]);

            return higherThenPrevious.Count();
        }
    }

}
