using AoC2021.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021.Days
{

    public class Day3 : IDays
    {


        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }


        public static decimal ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var lengthOfInput = input[0].Length;

            var oxygen = getValue(Type.oxygen);
            var co2 = getValue(Type.co2);

            return Convert.ToInt64(co2, 2) * Convert.ToInt64(oxygen, 2); ;

            string getValue(Type orderDirection)
            {
                string startsWith = "";
                for (int i = 0; i < lengthOfInput; i++)
                {
                    var subCalc = input.Where(x => x.StartsWith(startsWith)).Select(x => x[i]).GroupBy(x => x).Select(x => new { value = x.Key, count = x.Count() });
                    switch (orderDirection)
                    {
                        // cO2 - most common - ASC on equal return 0
                        case Type.co2:
                            subCalc = subCalc.OrderBy(x => x.count);
                            subCalc = bothEqual(subCalc) ? subCalc.Where(x => x.value == '0') : subCalc ;
                            break;

                        // Oxygen - most common - DESC on equal return 1
                        case Type.oxygen:
                            subCalc = subCalc.OrderByDescending(x => x.count);
                            subCalc = bothEqual(subCalc) ? subCalc.Where(x => x.value == '1') : subCalc;
                            break;
                    }

                    startsWith = startsWith + subCalc.First().value.ToString();

                }
                return startsWith;
            }

            bool bothEqual(IEnumerable<dynamic> sub)
            {
                return sub.ToArray().Length > 1 && sub.ToArray()[0].count == sub.ToArray()[1].count;
            }
        }


        private enum Type
        {
            co2,
            oxygen
        }

        public static decimal ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var lengthOfInput = input[0].Length;
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < lengthOfInput; i++)
            {
                var subCalc = input.Select(x => x[i]).GroupBy(x => x).Select(x => new { value = x.Key, count = x.Count() });
                gamma = gamma + subCalc.OrderByDescending(x => x.count).First().value.ToString();
                epsilon = epsilon + subCalc.OrderBy(x => x.count).First().value.ToString();
            }


            return Convert.ToInt64(gamma, 2) * Convert.ToInt64(epsilon, 2);
        }

    }

}
