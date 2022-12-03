using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Days
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


        public int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            List<char> badges = new List<char>();
            int rucksackNumber = 0;

            List<char> uniqueLetters = new List<char>();
            foreach (var rucksack in input) {
                uniqueLetters.AddRange(rucksack.ToCharArray().Distinct());

                rucksackNumber++;
                if (rucksackNumber == 3)
                {
                    badges.AddRange(uniqueLetters.GroupBy(x => x).Select(x => new { Letter = x.Key, Count = x.Count() }).Where(x => x.Count == 3).Select(x => x.Letter));
                    uniqueLetters = new List<char>();
                    rucksackNumber = 0;
                }
            }

            return badges.Where(x => x.ToString() == x.ToString().ToUpper()).Sum(x => (int)x % 32 + 26) + badges.Where(x => x.ToString() == x.ToString().ToLower()).Sum(x => (int)x % 32);
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            List<char> duplicateItemsList = new List<char>();

            foreach(var rucksack in input)
            {
                var totalItemCount = rucksack.Length;
                var firstLargeCompartment = rucksack.Substring(0,totalItemCount/2).ToCharArray();
                var secondLargeCompartment = rucksack.Substring(totalItemCount/2).ToCharArray();
                var duplicateItems = firstLargeCompartment.Where(x => secondLargeCompartment.Contains(x));
                duplicateItemsList.AddRange(duplicateItems.Distinct());
            }

            return duplicateItemsList.Where(x => x.ToString() == x.ToString().ToUpper()).Sum(x => (int)x % 32 + 26) + duplicateItemsList.Where(x => x.ToString() == x.ToString().ToLower()).Sum(x => (int)x % 32);
        }

    }

}
