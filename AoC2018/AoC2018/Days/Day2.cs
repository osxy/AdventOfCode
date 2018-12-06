using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Days
{

    class Day2
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
            Console.WriteLine("Start work on Day Two");
            Console.WriteLine("");
            Console.WriteLine("Day Two - Part One");
            watch.Restart();
            Console.Write("Answer:");
            PartOne();
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day Two - Part Two");
            watch.Restart();
            Console.Write("Answer:");
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

            var letters = new Dictionary<string, Int16>();
            var matchingString = new List<string>();
            var minFoundDiff = new Tuple<int, string>(0, "");


            // Loop door elke string heen
            foreach (string value in input)
            {

                letters.Clear();

                foreach (string character in value.ToCharArray().Select(c => c.ToString()).ToArray())
                {
                    if (letters.ContainsKey(character))
                    {
                        letters[character] += 1;
                    }
                    else
                    {
                        letters.Add(character, 1);
                    }
                }

                // Als er één van de letters 2 of 3 keer voorkomt toevoegen aan de matchingstring list
                if (letters.ContainsValue(3) || letters.ContainsValue(2))
                {
                    matchingString.Add(value);
                }

            }

            // Loop door elke string heen met 2x / 3x zelfde letter
            foreach (string a in matchingString)
            {

                // Loop door elke string heen met 2x / 3x zelfde letter om a te vergelijken met elke andere waarde in de array
                foreach (string b in matchingString)
                {
                    // Alleen verwerken als string niet gelijk is
                    if (a != b)
                    {
                        var diff = Helpers.StringsAndInts.CompareCharactersInStrings(a, b);
                        // Als er nog geen minFoundDiff is of de minFoundDiff is groter dan nieuwe gevonden diff
                        if (minFoundDiff.Item1 > diff.Item1 || minFoundDiff.Item1 == 0)
                        {
                            minFoundDiff = diff;
                            //Console.WriteLine(diff.Item2);
                            //Console.WriteLine(a);
                            //Console.WriteLine(b);
                        }

                    }

                }

            }
            Console.WriteLine(minFoundDiff.Item2);

        }

        static void ExecutePartOne(string[] input)
        {

            int forcount = 1;
            var letters = new Dictionary<string, int>();
            var twoCount = new Dictionary<string, int>();
            var threeCount = new Dictionary<string, int>();
            var twoTotal = new Dictionary<int, int>();
            var threeTotal = new Dictionary<int, int>();


            // Loop door elke string heen
            foreach (string value in input)
            {

                letters.Clear();
                twoCount.Clear();
                threeCount.Clear();

                foreach (string character in value.ToCharArray().Select(c => c.ToString()).ToArray())
                {


                    if (letters.ContainsKey(character))
                    {

                        letters[character] += 1;

                    }
                    else
                    {

                        letters.Add(character, 1);

                    }

                }

                // Als er een letter is gevonden welke exact 3x voorkomen tel dan 1 op bij 3xcounter
                if (letters.ContainsValue(3))
                {
                    twoTotal.Add(forcount, 0);

                }

                // Als er een letter is gevonden welke exact 2x voorkomen tel dan 1 op bij 2xcounter
                if (letters.ContainsValue(2))
                {
                    threeTotal.Add(forcount, 0);
                }
                ++forcount;

            }


            Console.WriteLine(twoTotal.Count * threeTotal.Count);

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
