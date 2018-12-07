using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Days
{

    class Day4
    {

        public static void execute()
        {

            //Input filenames
            string realInputFile = "Day4_TestData.txt";
            string test1InputFile = "Day4_TestData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);
            var test1InputValues = Helpers.General.GetDataFromInputFile(test1InputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne();
            PartTwo();
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Start work on Day x");
            Console.WriteLine("");
            Console.WriteLine("Day x - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne();
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day x - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            PartTwo();
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window
            Program.BackToMain();

        }

        static void PartOne()
        {

            ExecutePartOne(realInputValues);

        }

        static void PartTwo()
        {

            ExecutePartTwo(realInputValues);

        }


        static void ExecutePartTwo(string[] input)
        {

            Console.WriteLine("Does not work yet.");

        }

        static void ExecutePartOne(string[] input)
        {

            Console.WriteLine("Does not work yet.");

        }


        //Inputs
        static readonly string[] inputValuesTest1 = new string[]
        {
            
        };

        static readonly string[] inputValuesTest2 = new string[]
        {
            "qwugbihrkplyzcjahefttvdzns",
            "qwugbihrkppzzcjahefttvdzns",
            "qwugbihrkppzzzjahefttvdzns",
            "qwugbihrkplyzcjaheftttdzns"
        };

        static readonly string[] realInputValues = new string[]
        {
            "qwubbihrkplymcraxefntvdzns",
            "qwugbihrkplyzcjahefttvdzns",
            "qwugbihrkplymcjoxrsotvdzns"
        };


    }

}
