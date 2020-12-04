using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020.Days
{

    public class Day2 : IDays
    {


        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }


        public static int ExecutePartTwo(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            int validPasswords = 0;
            var passwordMatch = new Regex("(?<positionOne>\\d+)-(?<positionTwo>\\d+) (?<mandatoryLetter>.): (?<password>.*)", RegexOptions.Compiled);
            foreach (string i in input)
            {
                var match = passwordMatch.Match(i);
                int positionOne = int.Parse(match.Groups["positionOne"].Value);
                int positionTwo = int.Parse(match.Groups["positionTwo"].Value);
                char mandatoryLetter = Convert.ToChar(match.Groups["mandatoryLetter"].Value);
                var password = match.Groups["password"].Value;

                if ((password[positionOne - 1] == mandatoryLetter) ^ (password[positionTwo - 1] == mandatoryLetter))
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        public static int ExecutePartOne(string inputFile)
        {
            var input = Helpers.General.GetDataFromInputFileAsStringArray(inputFile);
            int validPasswords = 0;
            var passwordMatch = new Regex("(?<positionOne>\\d+)-(?<positionTwo>\\d+) (?<mandatoryLetter>.): (?<password>.*)", RegexOptions.Compiled);
            foreach (string i in input)
            {
                var match = passwordMatch.Match(i);
                int count = match.Groups["password"].Value.Count(c => c == Convert.ToChar(match.Groups["mandatoryLetter"].Value));
                if(count >= int.Parse(match.Groups["positionOne"].Value) && count <= int.Parse(match.Groups["positionTwo"].Value))
                {
                    validPasswords++;
                }
            }
            
            return validPasswords;
        }
    }



}

