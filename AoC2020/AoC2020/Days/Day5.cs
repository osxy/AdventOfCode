using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{

    public class Day5 : IDays
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
            var seatList = CreateSeatList(input);

            var sumOfList = seatList.Sum();
            var max = seatList.Max();
            var min = seatList.Min();
            var sumOfAll = max * (max + 1) / 2 - min * (min - 1) / 2;

            return sumOfAll - sumOfList;
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var seatList = CreateSeatList(input);
            return seatList.Max(s => s);
        }

        private static List<int> CreateSeatList(string[] input)
        {
            var seatList = new List<int>();
            foreach (string boardingPass in input)
            {
                seatList.Add(SeatIdParser(boardingPass));
            }

            return seatList;
        }

        public static int SeatIdParser(string seatString)
        {
            seatString = seatString.ToUpper();
            var rowBinary = seatString[..^3].Replace("F", "0").Replace("B", "1");
            var columnBinary = seatString[^3..].Replace("L", "0").Replace("R", "1");
            var row = Convert.ToInt32(rowBinary, 2);
            var column = Convert.ToInt32(columnBinary, 2);

            return row * 8 + column;
        }

    }

}
