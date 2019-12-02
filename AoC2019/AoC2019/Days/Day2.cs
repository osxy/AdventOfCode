using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019.Days
{

    class Day2
    {

        public static void Execute()
        {

            //Input filenames
            string realInputFile = "Day2_RealData.txt";
            string test1InputFile = "Day2_TestData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);
            var test1InputValues = Helpers.General.GetDataFromInputFile(test1InputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(test1InputValues, true);
            //PartTwo(test1InputValues);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Start work on Day 2");
            Console.WriteLine("");
            Console.WriteLine("Day 2 - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne(realInputValues, false);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day 2 - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            PartTwo(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window
            Program.BackToMain();

        }

        static void PartOne(string[] input, bool testRun)
        {

            Console.WriteLine(ExecuteCalculation(input, testRun, 12, 2));

        }

        static void PartTwo(string[] input)
        {

            Console.WriteLine(ExecutePartTwo(input));

        }


        private static int ExecutePartTwo(string[] input)
        {

            int noun = 0;
            int verb = 0;

            while(noun <= 99)
            {

                while(verb <= 99)
                {

                    int calcResult = ExecuteCalculation(input, false, noun, verb);
                    if (calcResult == 19690720)
                    {
                        return 100 * noun + verb;
                    }

                    verb++;
                }

                noun++;
                verb = 0;

            }

            return 0;

        }

        private static int ExecuteCalculation(string[] input, bool TestRun, int noun, int verb)
        {

            char delimiter = ',';
            int[] intArray = Helpers.ArraysAndLists.StringToIntArray(input[0], delimiter);
            int startRow = 0;

            if (!TestRun)
            {
                // Do Initial Replaces
                intArray[1] = noun;
                intArray[2] = verb;
            }

            while (startRow < intArray.Length && intArray[startRow] != 99)
            {

                switch (intArray[startRow])
                {

                    case 1:
                        intArray[intArray[startRow + 3]] = intArray[intArray[startRow + 1]] + intArray[intArray[startRow + 2]];
                        break;
                    case 2:
                        intArray[intArray[startRow + 3]] = intArray[intArray[startRow + 1]] * intArray[intArray[startRow + 2]];
                        break;
                    default:
                        break;

                }

                startRow += 4;

            }

            return intArray[0];

        }



    }

}
