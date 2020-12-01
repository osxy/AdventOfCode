using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days
{

    public class Day1
    {

        public static void Execute()
        {

            //Input filenames
            string realInputFile = "Day1_RealData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(realInputValues);
            PartTwo(realInputValues);
            Console.Clear();

            // Run part one
            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Start work on Day 1");
            Console.WriteLine("");
            Console.WriteLine("Day 1 - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            // Run Part two
            Console.WriteLine("Day 1 - Part Two");
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
            var array = Helpers.ArraysAndLists.StringArrayToIntArray(input);
            foreach (int current in array)
            {
                foreach (int i in array)
                {
                    foreach (int j in array)
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

        public static int ExecutePartOne(string[] input)
        {
            var array = Helpers.ArraysAndLists.StringArrayToIntArray(input);
            foreach(int current in array)
            {
                foreach(int i in array)
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
