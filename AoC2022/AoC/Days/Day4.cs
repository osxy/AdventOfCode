using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Days
{

    public class Day4 : IDays
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
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var fullyContained = 0;


            foreach(var assignmentPair in input)
            {

                var elfAssignment = assignmentPair.Split(',');

                var elfOneAssigmentIds = getElfAssignmentIds(elfAssignment[0]);
                var elfTwoAssigmentIds = getElfAssignmentIds(elfAssignment[1]);

                var allOneInTwo = elfOneAssigmentIds.Intersect(elfTwoAssigmentIds).Count() == elfOneAssigmentIds.Count;
                var allTwoInOne = elfTwoAssigmentIds.Intersect(elfOneAssigmentIds).Count() == elfTwoAssigmentIds.Count;

                if(allOneInTwo || allTwoInOne)
                    fullyContained++;

            }

            return fullyContained;
        }

        private static List<int> getElfAssignmentIds(string elfAssignment)
        {
            var elfAssignmentIdRange = elfAssignment.Split("-");
            var elfAssignmentIds = Enumerable.Range(int.Parse(elfAssignmentIdRange[0]), int.Parse(elfAssignmentIdRange[1]) - int.Parse(elfAssignmentIdRange[0]) + 1).Select(x => (int)x).ToList();
            return elfAssignmentIds;
        }

        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var anyContained = 0;


            foreach (var assignmentPair in input)
            {

                var elfAssignment = assignmentPair.Split(',');

                var elfOneAssigmentIds = getElfAssignmentIds(elfAssignment[0]);
                var elfTwoAssigmentIds = getElfAssignmentIds(elfAssignment[1]);

                var intersection = elfOneAssigmentIds.Intersect(elfTwoAssigmentIds).Count();

                if (intersection > 0)
                    anyContained++;

            }

            return anyContained;
        }


    }

}
