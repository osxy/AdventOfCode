using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019.Days
{

    class Day3
    {

        public static void Execute()
        {

            //Input filenames
            string realInputFile = "Day3_RealData.txt";
            string test1InputFile = "Day3_TestData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);
            var test1InputValues = Helpers.General.GetDataFromInputFile(test1InputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(test1InputValues);
            PartTwo(test1InputValues);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Start work on Day x");
            Console.WriteLine("");
            Console.WriteLine("Day 3 - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day 3 - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            PartTwo(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window
            Program.BackToMain();

        }

        static void PartOne(string[] input)
        {

            Console.WriteLine(ExecutePartOne(input));

        }

        static void PartTwo(string[] input)
        {

            ExecutePartTwo(input);

        }


        static void ExecutePartTwo(string[] input)
        {

            Console.WriteLine("Does not work yet.");

        }

        static int ExecutePartOne(string[] input)
        {
            Dictionary<string, bool> locations = new Dictionary<string, bool>();
            char delimiter = ',';
            int startCoordinate = 9999;
            // Add inition location to visited locations
            locations.Add(startCoordinate + "," + startCoordinate, false);

            VisitedLocations(locations,input[0], startCoordinate);
            VisitedLocations(locations, input[1], startCoordinate);
            var collisions = locations.Where(x => x.Value).Select(x => x.Key);
            int lowestDistance = 0;

            foreach(string x in collisions)
            {

                int[] coordinates = Helpers.ArraysAndLists.StringToIntArray(x,delimiter);
                int x1 = coordinates[0];
                int y1 = coordinates[1];
                int distance = CalculateManhattanDistance(x1, startCoordinate, y1, startCoordinate);
                if (distance < lowestDistance || lowestDistance == 0)
                {

                    lowestDistance = distance;

                }

            }

            

            return lowestDistance;

        }

        static Dictionary<string, bool> VisitedLocations(Dictionary<string,bool> locations, string input, int startCoordinate)
        {

            
            char delimiter = ',';
            string[] inputArray = Helpers.ArraysAndLists.StringToStringArray(input, delimiter);


            int currentX = startCoordinate;
            int currentY = startCoordinate;


            foreach (string x in inputArray)
            {

                string direction = x.Substring(0, 1);
                int steps = Int32.Parse(x.Substring(1, (x.Length - 1)));
                int takenSteps = 0;

                switch (direction)
                {

                    case "U":
                        while (steps > takenSteps)
                        {

                            currentX--;
                            
                            if(locations.ContainsKey(currentX + "," + currentY)){
                                locations[currentX + "," + currentY] = true;
                            } else
                            {
                                locations.Add(currentX + "," + currentY, false);
                            }

                            takenSteps++;

                        }
                        break;

                    case "D":
                        while (steps > takenSteps)
                        {

                            currentX++;

                            if (locations.ContainsKey(currentX + "," + currentY))
                            {
                                locations[currentX + "," + currentY] = true;
                            }
                            else
                            {
                                locations.Add(currentX + "," + currentY, false);
                            }

                            takenSteps++;

                        }
                        break;

                    case "L":
                        while (steps > takenSteps)
                        {

                            currentY--;

                            if (locations.ContainsKey(currentX + "," + currentY))
                            {
                                locations[currentX + "," + currentY] = true;
                            }
                            else
                            {
                                locations.Add(currentX + "," + currentY, false);
                            }

                            takenSteps++;

                        }
                        break;

                    case "R":
                        while (steps > takenSteps)
                        {

                            currentY++;

                            if (locations.ContainsKey(currentX + "," + currentY))
                            {
                                locations[currentX + "," + currentY] = true;
                            }
                            else
                            {
                                locations.Add(currentX + "," + currentY, false);
                            }

                            takenSteps++;

                        }
                        break;

                }


            }



            return locations;

        }


        public static int CalculateManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }


    }

}
