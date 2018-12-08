using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Days
{

    class Day5
    {

        public static void execute()
        {

            //Input filenames
            string realInputFile = "Day5_RealData.txt";
            string test1InputFile = "Day5_TestData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFileAsString(realInputFile);
            var test1InputValues = Helpers.General.GetDataFromInputFileAsString(test1InputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(test1InputValues);
            PartTwo(test1InputValues);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Start work on Day 5");
            Console.WriteLine("");
            Console.WriteLine("Day 5 - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day 5 - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            PartTwo(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window
            Program.BackToMain();

        }

        static void PartOne(string input)
        {

            ExecutePartOne(input);

        }

        static void PartTwo(string input)
        {

            ExecutePartTwo(input);

        }


        static void ExecutePartTwo(string input)
        {
            string modifiedInput = "";
            int shortest = -1;

            //ASCII - A-Z = 65-90, A-Z = 97-122
            for (int ASCII = 65; ASCII <= 90; ASCII++)
            {
                // Replace both lower and upper version of letter
                modifiedInput = input.Replace((Convert.ToChar(ASCII)).ToString(), "");
                modifiedInput = modifiedInput.Replace((Convert.ToChar(ASCII+32)).ToString(), "");

                // Get reacted version
                var reactedInput = ReactPolymer(modifiedInput);
                
                // if the new value is lower then current shortest var OR shortest has not been set yet set shortest
                if (shortest > reactedInput.Length || shortest == -1)
                {
                    shortest = reactedInput.Length;
                }

            }

            Console.WriteLine(shortest);

        }

        static void ExecutePartOne(string input)
        {


            var reacted = ReactPolymer(input);


            Console.WriteLine(reacted.Length);


        }


        static private string ReactPolymer(string input)
        {

            // Check every index
            for (var index = 0; index < input.Length - 1; index++)
            {
                var currentChar = input[index];
                var nextChar = input[index + 1];

                // ASCII letter codes of small and capital letters are 32 apart. So if the nextchar is neighter 32 id's higher or lower go to next index
                if (currentChar + 32 != nextChar && currentChar - 32 != nextChar)
                {
                    continue;
                }

                // Delete current index + next letter
                input = input.Remove(index, 2);

                // If index is below 2 set index to -1 so in next for loop its set to 0 again and first character is checked.
                if (index < 2)
                {
                    index = -1;
                }
                else
                {
                    index = index - 2;
                }

            }

            return input;

        }

        

    }

}
