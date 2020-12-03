namespace AoC2020.Days
{

    public class Day3 : IDays
    {

        string IDays.PartTwo(string[] input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string[] input)
        {
            return ExecutePartOne(input).ToString();
        }

        public static int ExecutePartTwo(string[] input)
        {
            var slope1 = SlopeRunner(input, 1, 1);
            var slope2 = SlopeRunner(input, 3, 1);
            var slope3 = SlopeRunner(input, 5, 1);
            var slope4 = SlopeRunner(input, 7, 1);
            var slope5 = SlopeRunner(input, 1, 2);

            return slope1*slope2*slope3*slope4*slope5;
        }

        public static int ExecutePartOne(string[] input)
        {
            var trees = SlopeRunner(input, 3, 1);
            return trees;
        }

        private static int SlopeRunner(string[] input, int right, int down)
        {
            int trees = 0;
            var x = 0;
            var y = 0;

            var lineLength = input[y].Length;
            while (y < input.Length - 1)
            {
                if (x + right > lineLength - 1)
                {
                    x = right - (lineLength - x);
                }
                else
                {
                    x += right;
                }

                y += down;

                if (input[y][x] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }



    }

}
