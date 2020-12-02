using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days
{

    public class Framework
    {

        public static void Execute()
        {

            var day = 2;

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
            return 0;
        }

        public static int ExecutePartOne(string[] input)
        {

            return 0;
        }



    }

}
