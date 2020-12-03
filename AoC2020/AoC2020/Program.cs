using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2020.Days;
using EasyConsoleCore;

namespace AoC2020
{
    class Program
    {

        public static void Main()
        {
            Program program = new Program();

            Console.Clear();

            Console.WriteLine("Advent Of Code 2020");
            Console.WriteLine("by André K.");
            Console.WriteLine("");

            var menu = new Menu()
                .Add("Day 1", () => program.ExecuteDay(new Day1(), 1))
                .Add("Day 2", () => program.ExecuteDay(new Day2(), 2))
                .Add("Day 3", () => program.ExecuteDay(new Day3(), 3));
            menu.Display();

        }

        public static void BackToMain()
        {

            //Keep console open untill any value is returned
            Console.WriteLine("");
            Console.WriteLine("");
            
            Input.ReadString("To go to main menu press enter");
            Main();

        }

        public void ExecuteDay(IDays day, int daynr)
        {
            var realInputFile = $"Day{daynr}_RealData.txt";
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);
            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            day.PartOne(realInputValues);
            day.PartTwo(realInputValues);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine($"Start work on Day {daynr}");
            Console.WriteLine("");
            Console.WriteLine($"Day {daynr} - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            Console.WriteLine(day.PartOne(realInputValues));
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine($"Day {daynr} - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            Console.WriteLine(day.PartTwo(realInputValues));
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window
            Program.BackToMain();
        }
        
    }
}
