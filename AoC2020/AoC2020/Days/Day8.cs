using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{

    public class Day8 : IDays
    {
        
        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }


        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var replaceList = new string[] { "nop", "jmp" };
            var replace = (from i in input
                       where replaceList.Contains(i[0..3])
                       select Array.IndexOf(input,i)).ToList();
            var replaceIndex = 0;
            var repeated = false;
            Tuple<int, bool> solved;

            do
            {
                var replaceItem = 0;
                var replacedList = input.ToList();
                replaceItem = replace[replaceIndex];
                switch (replacedList[replaceItem][0..3])
                {
                    case "nop":
                        replacedList[replaceItem] = replacedList[replaceItem].Replace("nop", "jmp");
                        break;
                    case "jmp":
                        replacedList[replaceItem] = replacedList[replaceItem].Replace("jmp", "nop");
                        break;
                }
                replaceIndex++;
                solved = Solver(replacedList.ToArray());
                repeated = solved.Item2;

            } while (repeated == true);


            return solved.Item1;
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            return Solver(input).Item1;
        }

        private Tuple<int,bool> Solver(string[] input)
        {
            decimal acc = 0;
            var index = 0;
            var processed = new List<int>();
            var repeated = false;

            try
            {
                do
                {
                    processed.Add(index);
                    switch (input[index][0..3])
                    {
                        case "acc":
                            acc += decimal.Parse(input[index][4..^0], System.Globalization.NumberStyles.AllowLeadingSign);
                            index++;
                            break;
                        case "nop":
                            index++;
                            break;
                        case "jmp":
                            index = decimal.ToInt32(index + decimal.Parse(input[index][4..^0], System.Globalization.NumberStyles.AllowLeadingSign));
                            break;
                    }
                    repeated = processed.Any(x => x.Equals(index));

                } while (!repeated && index <= input.Length-1);

                return new Tuple<int, bool>(decimal.ToInt32(acc), repeated);
            } catch
            {
                return new Tuple<int, bool>(0, true);
            }
        }


    }

}
