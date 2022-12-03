namespace AoC2022.Days
{

    public class Framework : IDays
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
            return 0;
        }

        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            return 0;
        }


    }

}
