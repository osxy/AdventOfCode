using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2020.Days
{

    public class Day2
    {

        public static void Execute()
        {

            //Input filenames
            string realInputFile = "Day2_RealData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(realInputValues);
            PartTwo(realInputValues);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Start work on Day x");
            Console.WriteLine("");
            Console.WriteLine("Day x - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day x - Part Two");
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

            int validPasswords = 0;
            var passwordMatch = new Regex("(\\d+)-(\\d+) (.): (.*)", RegexOptions.Compiled);
            foreach (string i in input)
            {
                var match = passwordMatch.Match(i);
                int positionOne = int.Parse(match.Groups[1].Value);
                int positionTwo = int.Parse(match.Groups[2].Value);
                char mandatoryLetter = Convert.ToChar(match.Groups[3].Value);
                var password = match.Groups[4].Value;

                bool ruleOne = password[positionOne - 1] == mandatoryLetter && password[positionTwo - 1] != mandatoryLetter;
                bool ruleTwo = password[positionOne - 1] != mandatoryLetter && password[positionTwo - 1] == mandatoryLetter;
                if (ruleOne != ruleTwo && (ruleOne || ruleTwo))
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        public static int ExecutePartOne(string[] input)
        {
            int validPasswords = 0;
            var passwordMatch = new Regex("(\\d+)-(\\d+) (.): (.*)", RegexOptions.Compiled);
            foreach (string i in input)
            {
                var match = passwordMatch.Match(i);
                int count = match.Groups[4].Value.Count(c => c == Convert.ToChar(match.Groups[3].Value));
                if(count >= int.Parse(match.Groups[1].Value) && count <= int.Parse(match.Groups[2].Value))
                {
                    validPasswords++;
                }
            }
            
            return validPasswords;
        }
    }



}

