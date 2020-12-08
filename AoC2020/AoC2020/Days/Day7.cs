using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AoC2020.Helpers;
using Microsoft.VisualBasic.FileIO;

namespace AoC2020.Days
{

    public class Day7 : IDays
    {
        private List<Bags> _bagList;

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
            var bagRules = GenerateBagList(input);
            var searchForBag = "shiny gold";

            var total = CountAmountOfChildBags(bagRules.Where(b => b.Container == searchForBag).ToList());


            return total;
        }

        private int CountAmountOfChildBags(List<Bags> bags)
        {
            var count = 0;
            
            foreach (var bag in bags)
            {
                count += bag.NumberOfBags;
                count += CountAmountOfChildBags(_bagList.Where(c=>c.Container == bag.Bag).ToList()) * bag.NumberOfBags;
            }

            return count;
        }

        public int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var bagRules = GenerateBagList(input);
            var searchForBag = "shiny gold";

            // Lookup all bags that can contain the searched bag 
            var matchedBags = bagRules.Where(v => v.Bag.StartsWith(searchForBag));
            var totalList = matchedBags.ToList();

            List<Bags> recursive;
            var searchForBags = matchedBags;
            do
            {
                recursive = bagRules.Join(
                    searchForBags.ToList(),
                    x => x.Bag,
                    y => y.Container,
                    (x, y) => x
                ).ToList();
                totalList.AddRange(recursive);
                searchForBags = recursive;
            }
            while (recursive.Count > 0);

            return totalList.Select(x => x.Container).Distinct().Count();
        }

        private List<Bags> GenerateBagList(string[] input = null)
        {
            if(input == null && _bagList != null) return _bagList;
            var bagRules = new List<Bags>();
            var bagRuleParser = new Regex("(?:(.*) bags(?: contain ))?( ?(\\d) ?([a-z ]*)(?: bags| bag))", RegexOptions.Compiled);

            // All bags in array with their name and a list of what they can contain
            foreach (var bag in input)
            {
                var bags = bagRuleParser.Matches(bag);
                if (bags.Count > 0)
                {
                    var container = bags[0].Groups[1].Value;
                    foreach (Match bagParsed in bags)
                    {
                        var bagInRule = new Bags()
                        {
                            Container = container,
                            Bag = bagParsed.Groups[4].Value,
                            NumberOfBags = StringsAndInts.ConvertStringToInt(bagParsed.Groups[3].Value)
                        };
                        bagRules.Add(bagInRule);
                    }
                }
            }

            _bagList = bagRules;
            return bagRules;
        }

        private class Bags
        {
            public string Container { get; set; }
            public string Bag { get; set; }
            public int NumberOfBags { get; set; }
        }

    }

}
