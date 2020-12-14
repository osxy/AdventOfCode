using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2020.Days;
using EasyConsoleCore;
using TextCopy;

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
                .Add("Day 3", () => program.ExecuteDay(new Day3(), 3))
                .Add("Day 4", () => program.ExecuteDay(new Day4(), 4))
                .Add("Day 5", () => program.ExecuteDay(new Day5(), 5))
                .Add("Day 6", () => program.ExecuteDay(new Day6(), 6))
                .Add("Day 7", () => program.ExecuteDay(new Day7(), 7))
                .Add("Day 8", () => program.ExecuteDay(new Day8(), 8))
                .Add("Day 9", () => program.ExecuteDay(new Day9(), 9))
                .Add("Day 10", () => program.ExecuteDay(new Day10(), 10))
                .Add("Exit", () => Environment.Exit(0));
            menu.Display();
        }

        public void ExecuteDay(IDays day, int daynr)
        {
            var realInputFile = $"Day{daynr}_RealData.txt";
            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            day.PartOne(realInputFile);
            day.PartTwo(realInputFile);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine($"Start work on Day {daynr}");
            Console.WriteLine("");
            Console.WriteLine($"Day {daynr} - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            var partOne = day.PartOne(realInputFile);
            Output.WriteLine(ConsoleColor.Red, partOne);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine($"Day {daynr} - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            var partTwo = day.PartTwo(realInputFile);
            Output.WriteLine(ConsoleColor.Red, partTwo);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window

            //Keep console open untill any value is returned
            Console.WriteLine("");
            Console.WriteLine("");

            ShowMenu();

            void ShowMenu()
            {
                var menu = new Menu()
                    .Add("Copy part one", () => CopyAndMenu(partOne))
                    .Add("Copy part two", () => CopyAndMenu(partTwo))
                    .Add("Back to main", () => Main());
                menu.Display();
            }

            void CopyAndMenu(string copy)
            {
                Console.WriteLine("");
                Console.WriteLine($"Writing {copy} to clipboard.");
                Console.WriteLine("");
                ClipboardService.SetText(copy);
                ShowMenu();
            }
        }
        
    }
}
