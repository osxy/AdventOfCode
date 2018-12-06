using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Days
{

    class Framework
    {

        public static void execute()
        {
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
            Console.WriteLine("Does not work yet.");
            PartOne();
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day x - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            Console.WriteLine("Does not work yet.");
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


        }

        static void ExecutePartOne(string[] input)
        {


        }


        //Inputs
        static readonly string[] inputValuesTest1 = new string[]
        {
            "abcdabcabbqq", // 2x q, 3x a, 2x c
            "abccc", // 3x c
            "abbaab", //3x a, 3x b
            "abcdefg", // geen
            "abcdabcabbqq", // 2x q, 3x a, 2x c
            "abccc", // 3x c
            "abcdefg" // geen
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
