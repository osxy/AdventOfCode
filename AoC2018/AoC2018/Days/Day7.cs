using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Days
{

    class Day7
    {

        public static void execute()
        {

            //Input filenames
            string realInputFile = "Day7_RealData.txt";
            string test1InputFile = "Day7_TestData.txt";

            //Get input contents
            var realInputValues = Helpers.General.GetDataFromInputFile(realInputFile);
            var test1InputValues = Helpers.General.GetDataFromInputFile(test1InputFile);


            // Do JIT compilation
            Console.Clear();
            Console.WriteLine("Start JIT compilation");
            PartOne(test1InputValues);
            PartTwo(test1InputValues,2 , 0);
            Console.Clear();

            Stopwatch watch = Stopwatch.StartNew();
            Console.WriteLine("Start work on Day 7");
            Console.WriteLine("");
            Console.WriteLine("Day 7 - Part One");
            watch.Restart();
            Console.Write("Answer: ");
            PartOne(realInputValues);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            Console.WriteLine("");

            Console.WriteLine("Day 7 - Part Two");
            watch.Restart();
            Console.Write("Answer: ");
            PartTwo(realInputValues, 5, 60);
            watch.Stop();
            Console.WriteLine($"Done in: {watch.Elapsed.TotalMilliseconds}ms");

            //Present back to main window
            Program.BackToMain();

        }

        static void PartOne(string[] input)
        {

            ExecutePartOne(input);

        }

        static void PartTwo(string[] input, int numworkers, int timePerStepExtra)
        {

            ExecutePartTwo(input, numworkers, timePerStepExtra);

        }


        static void ExecutePartTwo(string[] input, int numWorkers, int timePerStepExtra)
        {
            Dictionary<string, bool> steps = new Dictionary<string, bool>();
            List<PreReq> Prerequisits = new List<PreReq>();
            char highestLetter = new char();

            //Create worker List
            List<Workers> Workers = new List<Workers>();
            for (int w = 0; w < numWorkers; w++)
            {
                Workers WorkerItem = new Workers
                {
                    Worker = w + 1,
                    WorkingOn = "",
                    CompletesAt = -1
                };
                Workers.Add(WorkerItem);

            }
            // Create a predefined Linq query for all available workers.
            IEnumerable<Workers> availableWorkers = Workers.Where(x => x.WorkingOn == "");

            foreach (string line in input)
            {

                char PreReqID = line[5];
                char StepId = line[36];

                // Check if new step is higher then previous highest
                if (StepId > highestLetter)
                {
                    highestLetter = StepId;
                }

                // Add this Prerequisit
                PreReq PreReqItem = new PreReq
                {
                    Step = StepId.ToString(),
                    PrerequisitStep = PreReqID.ToString()
                };
                Prerequisits.Add(PreReqItem);

            }

            // Add all steps to step Dict.
            for (int s = 65; s <= highestLetter; s++)
            {
                steps.Add((Convert.ToChar(s)).ToString(), false);
            }

            // Order the steps by Key
            SortedDictionary<string, bool> orderedsteps = new SortedDictionary<string, bool>(steps);

            // To lazy to figure out exact loops will just break out of loop when done ... 
            var loops = highestLetter - 64 + 60 * orderedsteps.Count;

            // Every loop is a second
            for (int c = 1; c < loops; c++)
            {
                // Complete all steps that are finished this second
                foreach (Workers completed in Workers.Where(x => x.CompletesAt == c))
                {
                    //Complete step
                    orderedsteps[completed.WorkingOn] = true;

                    //Clear workload
                    completed.CompletesAt = -1;
                    completed.WorkingOn = "";
                }

                // Check if any worker is available, if non are available go to next second
                if (availableWorkers.Count() == 0) { continue; }


                // Find all completed steps
                var completedSteps = orderedsteps.Where(x => x.Value == true).Select(x => x.Key).ToArray();

                // If all steps are completed write second everything completed
                if (completedSteps.Count() >= orderedsteps.Count) {
                    Console.WriteLine(c - 1);  break;
                }

                // Find all steps that are blocked by unforfilled prerequisits
                var blockedSteps = Prerequisits.Where(x => !completedSteps.Contains(x.PrerequisitStep)).Select(x => x.Step).ToArray();
                // Get all steps that are being worked on
                var workingOnSteps = Workers.Where(x => x.CompletesAt != -1).Select(x => x.WorkingOn).ToArray();
                //Find all available steps which are not completed yet and not being worked on
                var availableStep = orderedsteps.Where(x => !blockedSteps.Contains(x.Key) && x.Value == false && !workingOnSteps.Contains(x.Key));

                foreach (KeyValuePair<string,bool> kvp in availableStep)
                {

                    //Check if there is still an available worker
                    if (availableWorkers.Count() > 0)
                    {
                        // Get First available worker
                        var firstAvailableWorker = availableWorkers.First();
                        // Set workers work
                        firstAvailableWorker.WorkingOn = kvp.Key;
                        firstAvailableWorker.CompletesAt = c + timePerStepExtra + kvp.Key[0] - 64;
                    }
                }

            }

        }

        public class PreReq
        {
            public string Step { get; set; }
            public string PrerequisitStep { get; set; }

        }

        public class Workers
        {
            public int Worker { get; set; }
            public string WorkingOn { get; set; }
            public int CompletesAt { get; set; }

        }

        static void ExecutePartOne(string[] input)
        {

            Dictionary<string, bool> steps = new Dictionary<string, bool>();
            List<PreReq> Prerequisits = new List<PreReq>();
            char highestLetter = new char();
            string orderOfOperation = "";

            foreach (string line in input)
            {

                char PreReqID = line[5];
                char StepId = line[36];

                // Check if new step is higher then previous highest
                if(StepId > highestLetter)
                {
                    highestLetter = StepId;
                }

                // Add this Prerequisit
                PreReq PreReqItem = new PreReq
                {
                    Step = StepId.ToString(),
                    PrerequisitStep = PreReqID.ToString()
                };
                Prerequisits.Add(PreReqItem);

            }
            
            // Add all steps to step Dict.
            for (int s = 65; s <= highestLetter; s++)
            {
                steps.Add((Convert.ToChar(s)).ToString(), false);
            }

            // Order the steps by Key
            SortedDictionary<string, bool> orderedsteps = new SortedDictionary<string, bool>(steps);

            for (int c = 0; c < orderedsteps.Count; c++)
            {
                // Find all completed steps
                var completedSteps = orderedsteps.Where(x => x.Value == true).Select(x => x.Key).ToArray();
                // Find all steps that are blocked by unforfilled prerequisits
                var blockedSteps = Prerequisits.Where(x => !completedSteps.Contains(x.PrerequisitStep)).Select(x => x.Step).ToArray();
                //Find all first step which are not completed yet
                var firstAvailableStep = orderedsteps.Where(x => !blockedSteps.Contains(x.Key) && x.Value == false).First();

                // Do step
                orderOfOperation = orderOfOperation + firstAvailableStep.Key;
                orderedsteps[firstAvailableStep.Key] = true;

            }



            Console.WriteLine(orderOfOperation);

        }



    }

}
