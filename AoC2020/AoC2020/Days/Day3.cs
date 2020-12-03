using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days
{

    public class Day3
    {

        public static void Execute()
        {

            var day = 3;

            //Input filenames
            string realInputFile = $"Day{day}_RealData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(realInputValues);
            PartTwo(realInputValues);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine($"Start work on Day {day}");
            Console.WriteLine("");
            Console.WriteLine($"Day {day} - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine($"Day {day} - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            PartTwo(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window
            Program.BackToMain();

        }

        public static void PartOne(string[] input)
        {

            Console.WriteLine(ExecutePartOne(input));

        }

        public static void PartTwo(string[] input)
        {

            Console.WriteLine(ExecutePartTwo(input));

        }

        public static int ExecutePartTwo(string[] input)
        {
            var slope1 = SlopeRunner(input, 1, 1);
            var slope2 = SlopeRunner(input, 3, 1);
            var slope3 = SlopeRunner(input, 5, 1);
            var slope4 = SlopeRunner(input, 7, 1);
            var slope5 = SlopeRunner(input, 1, 2);

            return slope1*slope2*slope3*slope4*slope5;
        }

        public static int ExecutePartOne(string[] input)
        {
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
                if (x + right > lineLength - 1)
                {
                    x = right - (lineLength - x);
                }
                else
                {
                    x += right;
                }

                y += down;

                if (input[y][x] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }



    }

}
