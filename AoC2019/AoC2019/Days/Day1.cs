using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019.Days
{

    class Day1
    {

        public static void Execute()
        {

            //Input filenames
            string realInputFile = "Day1_RealData.txt";
            string test1InputFile = "Day1_TestData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);
            var test1InputValues = Helpers.General.GetDataFromInputFile(test1InputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(test1InputValues);
            PartTwo(test1InputValues);
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

        static void PartOne(string[] input)
        {

            List<int> inputInt = Helpers.ArraysAndLists.StringArrayToIntList(input);

            decimal currentAmount = 0;

            foreach (int inputMass in inputInt)
            {

                currentAmount += CalcFuel(inputMass);

            }
            Console.WriteLine(currentAmount);


        }

        static void PartTwo(string[] input)
        {

            List<int> inputInt = Helpers.ArraysAndLists.StringArrayToIntList(input);
            int FuelTotal = 0;
            foreach (int inputMass in inputInt)
            {

                int FuelCalc = CalcFuel(inputMass);
                int LineAmount = 0;
                if (FuelCalc > 0)
                {
                    LineAmount = FuelCalc;
                }

                while (FuelCalc > 0)
                {

                    FuelCalc = CalcFuel(FuelCalc);
                    if (FuelCalc > 0)
                    {
                        LineAmount += FuelCalc;
                    }

                }

                FuelTotal += LineAmount;


            }
            Console.WriteLine(FuelTotal);

        }



        static private int CalcFuel(int inputMass)
        {

            return (int)Math.Floor((decimal)inputMass / 3) - 2;

        }




    }

}
