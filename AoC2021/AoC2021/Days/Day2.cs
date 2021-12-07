using AoC2021.Helpers;
using System.Linq;

namespace AoC2021.Days
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


        public static int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var array = input.Select(x => x.Split(" ")).Select(x => new { command = x[0], amount = int.Parse(x[1]) });
            int aim = 0;
            int depth = 0;
            int horizontal = 0;
            foreach(var item in array)
            {

                switch (item.command)
                {
                    case "forward":
                        horizontal += item.amount;
                        depth += aim * item.amount;
                        break;
                    case "down":
                        aim += item.amount;
                        break;
                    case "up":
                        aim -= item.amount;
                        break;
                }

            }


            return depth*horizontal;
        }

        public static int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var array = input.Select(x => x.Split(" ")).Select(x => new { direction = x[0], amount = x[1] });
            var totalHorizontal = array.Where(x => x.direction == "forward").Sum(x => int.Parse(x.amount)) - array.Where(x => x.direction == "backward").Sum(x => int.Parse(x.amount));
            var totalDepth = array.Where(x => x.direction == "down").Sum(x => int.Parse(x.amount)) - array.Where(x => x.direction == "up").Sum(x => int.Parse(x.amount));

            return totalDepth*totalHorizontal;
        }
    }

}
