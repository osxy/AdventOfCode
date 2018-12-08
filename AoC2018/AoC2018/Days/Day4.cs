using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Days
{

    class Day4
    {

        public static void execute()
        {

            //Input filenames
            string realInputFile = "Day4_RealData.txt";
            string test1InputFile = "Day4_TestData.txt";

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

        static void PartOne(string [] input)
        {

            ExecutePartOne(input);

        }

        static void PartTwo(string[] input)
        {

            ExecutePartTwo(input);

        }


        static void ExecutePartTwo(string[] input)
        {
            //Create helper variables
            int guardId = 0;
            int minAsleep = 0;
            int minAwake = 0;
            Match timestampMatches;
            var guardLog = new Dictionary<DateTime, GuardLog>();
            var guardLogEntry = new GuardLog();


            // Parse input and create guardLog
            foreach (string line in input)
            {
                Regex getTimestamp = new Regex(@"\[(.{16})\].*(#([0-9]*)|falls|wakes)");
                timestampMatches = getTimestamp.Match(line);
                guardLogEntry = new GuardLog
                {
                    matchType = timestampMatches.Groups[2].Value,
                    guardID = Helpers.StringsAndInts.ConvertStringToInt(timestampMatches.Groups[3].Value)
                };
                guardLog.Add(DateTime.Parse(timestampMatches.Groups[1].Value), guardLogEntry);
            }

            // Order input by datetime
            var orderedGuardLog = new SortedDictionary<DateTime, GuardLog>(guardLog);


            //Create "sleepy" array with guardID, minute he fell asleep and how many times he was asleep in that minute
            var sleepy = new List<SleepyList>();

            //Loop trough input
            var kvp = orderedGuardLog.ToList();
            for (int c = 1; c < kvp.Count; c++)
            {

                //If start of shift place GuardID in var
                if (kvp[c].Value.guardID != 0)
                {

                    guardId = kvp[c].Value.guardID;
                    c++;
                    minAsleep = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));
                    c++;
                    minAwake = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));

                }


                //If falls asleep then place starting minute in var
                if (kvp[c].Value.matchType == "falls")
                {

                    minAsleep = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));
                    c++;
                    minAwake = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));
                }



                //If both asleep and wakeup var are not NULL then create a entry or add 1 to times asleep
                //in the "sleepy" array for every minute from asleep untill awake (asleep minute counts, awake minute does not count)
                if (guardId != 0 && minAsleep != 0 && minAwake != 0)
                {

                    for (int i = minAsleep; i < minAwake; i++)
                    {

                        // Zoek naar een record voor deze guard op deze minuut
                        var rec = sleepy.FirstOrDefault(x => x.guardId == guardId && x.minuteId == i);

                        // Als record gevonden is update deze dan.
                        if (rec != null) {
                            rec.repeats++;
                        }

                        // Als geen record gevonden is maak deze dan aan
                        if (rec == null)
                        {

                            var newData = new SleepyList
                            {
                                guardId = guardId,
                                minuteId = i,
                                repeats = 1
                            };
                            sleepy.Add(newData);
                        }


                    }

                    //Reset vars
                    minAsleep = 0;
                    minAwake = 0;

                }


            }


            //Get the minute with highest value
            var sleepySorted = sleepy.OrderByDescending(x => x.repeats).First();

            // Return the sum
            Console.WriteLine("Guard " + sleepySorted.guardId + " * Minute " + sleepySorted.minuteId + " = " + sleepySorted.guardId * sleepySorted.minuteId);

        }

        public class SleepyList
        {
            public int guardId { get; set; }
            public int minuteId { get; set; }
            public int repeats { get; set; }

        }

        public class GuardLog
        {
            public string matchType { get; set; }
            public int guardID { get; set; }

        }

        static void ExecutePartOne(string[] input)
        {
            //Create helper variables
            int guardId = 0;
            int minAsleep = 0;
            int minAwake = 0;
            bool actionDone = false;
            Match timestampMatches;
            var guardLog = new Dictionary<DateTime, GuardLog>();
            var guardLogEntry = new GuardLog();


            // Parse input and create guardLog
            foreach (string line in input)
            {
                Regex getTimestamp = new Regex(@"\[(.{16})\].*(#([0-9]*)|falls|wakes)");
                timestampMatches = getTimestamp.Match(line);
                guardLogEntry = new GuardLog
                {
                    matchType = timestampMatches.Groups[2].Value,
                    guardID = Helpers.StringsAndInts.ConvertStringToInt(timestampMatches.Groups[3].Value)
                };
                guardLog.Add(DateTime.Parse(timestampMatches.Groups[1].Value), guardLogEntry);
            }

            // Order input by datetime
            var orderedGuardLog = new SortedDictionary<DateTime, GuardLog>(guardLog);


            //Create "sleepy" array with guardID, minute he fell asleep and how many times he was asleep in that hour
            var sleepy = new Dictionary<int, Dictionary<int, int>>();
            // GuardId and number of minutes slept
            var guards = new Dictionary<int, int>();


            //Loop trough input
            var kvp = orderedGuardLog.ToList();
            for (int c = 1; c < kvp.Count; c++)
            {

                //If start of shift place GuardID in var
                if (kvp[c].Value.guardID != 0)
                {

                    guardId = kvp[c].Value.guardID;
                    c++;
                    minAsleep = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));
                    c++;
                    minAwake = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));

                }


                //If falls asleep then place starting minute in var
                if (kvp[c].Value.matchType == "falls")
                {

                    minAsleep = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));
                    c++;
                    minAwake = Helpers.StringsAndInts.ConvertStringToInt(kvp[c].Key.ToString("mm"));
                }




                //If both asleep and wakeup var are not NULL then create a entry or add 1 to times asleep
                //in the "sleepy" array for every minute from asleep untill awake (asleep minute counts, awake minute does not count)
                if (guardId != 0 && minAsleep != 0 && minAwake != 0)
                {

                    // if entry for this guard does not exist create one
                    if (!sleepy.ContainsKey(guardId))
                    {

                        sleepy.Add(guardId, new Dictionary<int, int>());

                    }

                    // if entry for this guard does not exist create one
                    if (!guards.ContainsKey(guardId))
                    {

                        guards.Add(guardId, 0);

                    }

                    for (int i = minAsleep; i < minAwake; i++)
                    {

                        // if entry for this minute exists add one to value
                        if (sleepy[guardId].ContainsKey(i))
                        {

                            sleepy[guardId][i]++;

                        }
                        else // create entry
                        {

                            sleepy[guardId].Add(i, 1);

                        }

                        // Add a minute slept to the guard
                        guards[guardId]++;

                    }

                    //Reset vars
                    minAsleep = 0;
                    minAwake = 0;

                }


            }

            //After loop completed get total minute slept per guard and select guard with highest amount
            var guardsordered = guards.OrderByDescending(x => x.Value).First();

            //Get the minute with highest value for this guard and return this value
            var sleepySorted = sleepy[guardsordered.Key].OrderByDescending(x => x.Value).First();

            // Return the sum
            Console.WriteLine("Guard " + guardsordered.Key + " * Minute " + sleepySorted.Key + " = " + guardsordered.Key* sleepySorted.Key);

        }


    }

}
