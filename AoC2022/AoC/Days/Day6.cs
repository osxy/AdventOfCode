using System;
using System.Linq;

namespace AoC2022.Days
{

    public class Day6 : IDays
    {

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }

        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsString(inputFile);
            return MarkerPosition(input, 4);
        }

        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsString(inputFile);
            return MarkerPosition(input, 14);
        }

        public static int MarkerPosition(string message, int markerLength)
        {
            var characters = message.ToCharArray();
            int markerPos = -1;
            int x = 0;

            do
            {

                if(characters[x ..(x + markerLength)].Distinct().Count() == markerLength)
                {
                    markerPos = x + markerLength;
                    break;
                }

            } while (markerPos == -1 && x++ <= characters.Count());


            return markerPos;
        }
    }

}
