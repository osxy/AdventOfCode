using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Days
{

    public class Day5 : IDays
    {

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }

        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        public string ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var parsedInput = ParseInput(input);
            var parsedInstructions = parsedInput.ParsedInstructions;
            var parsedGrid = parsedInput.StartingGrid;

            foreach(var instruction in parsedInstructions)
            {
                var cratesToMove = parsedGrid[instruction.moveFrom].Take(instruction.moveAmount);
                parsedGrid[instruction.moveTo].InsertRange(0, cratesToMove.Reverse());
                parsedGrid[instruction.moveFrom] = parsedGrid[instruction.moveFrom].TakeLast(parsedGrid[instruction.moveFrom].Count - instruction.moveAmount).ToList();
            }

            string topCrates = ""; 
            foreach(var stack in parsedGrid)
            {
                topCrates = topCrates + stack.FirstOrDefault();
            }

            return topCrates;
        }

        public string ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            var parsedInput = ParseInput(input);
            var parsedInstructions = parsedInput.ParsedInstructions;
            var parsedGrid = parsedInput.StartingGrid;

            foreach (var instruction in parsedInstructions)
            {
                var cratesToMove = parsedGrid[instruction.moveFrom].Take(instruction.moveAmount);
                parsedGrid[instruction.moveTo].InsertRange(0, cratesToMove);
                parsedGrid[instruction.moveFrom] = parsedGrid[instruction.moveFrom].TakeLast(parsedGrid[instruction.moveFrom].Count - instruction.moveAmount).ToList();
            }

            string topCrates = "";
            foreach (var stack in parsedGrid)
            {
                topCrates = topCrates + stack.FirstOrDefault();
            }

            return topCrates;
        }

        public (List<char>[] StartingGrid, List<Instructions> ParsedInstructions) ParseInput(string[] inputLines)
        {
            var Base = new List<string>();
            var rawInstructions = new List<string>();

            foreach (string line in inputLines)
            {
                if (line == "")
                    break;
                Base.Add(line);
            }

            rawInstructions.AddRange(inputLines.TakeLast(inputLines.Count() - Base.Count() - 1).ToList());

            var numOfPositions = (Base.Last().Length + 1) / 4;
            List<Char>[] StartingGrid = new List<Char>[numOfPositions];
            for(var g= 0; g < numOfPositions; g++)
            {
                StartingGrid[g] = new List<Char>();
            }

            foreach(var position in Base.Take(Base.Count - 1))
            {
                for(var x = 0; x <= numOfPositions - 1; x++)
                {
                    Char crate = char.Parse(position.Substring((x * 4) + 1, 1));
                    if (crate != ' ')
                    {
                        StartingGrid[x].Add(crate);
                    }
                }
            }

            var ParsedInstructions = new List<Instructions>();
            foreach(var instruction in rawInstructions)
            {
                var splitInstructions = instruction.Split(' ');
                ParsedInstructions.Add(
                    new Instructions { 
                        moveAmount = int.Parse(splitInstructions[1]), 
                        moveFrom =  int.Parse(splitInstructions[3]) - 1, 
                        moveTo = int.Parse(splitInstructions[5]) - 1 
                    }
                 );
            }


            return (StartingGrid, ParsedInstructions);

        }
        public class Instructions
        {
            public int moveAmount { get; set; }
            public int moveFrom { get; set; }
            public int moveTo { get; set; }
        }

    }

}
