using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020.Days
{

    public class Day4 : IDays
    {

        string IDays.PartTwo(string input)
        {
            return ExecutePartTwo(input).ToString();
        }

        string IDays.PartOne(string input)
        {
            return ExecutePartOne(input).ToString();
        }


        public int ExecutePartTwo(string input)
        {
            var parsedPassportArray = ParsePassports(input);
            return parsedPassportArray.Count(p => p.ValidFull == true);
        }

        public int ExecutePartOne(string input)
        {
            var parsedPassportArray = ParsePassports(input);
            return parsedPassportArray.Count(p => p.Valid == true);
        }

        private List<Passport> ParsePassports(string input)
        {
            string inputString = Helpers.General.GetDataFromInputFileAsString(input);
            var passportArray = inputString.Split("\r\n\r\n", StringSplitOptions.TrimEntries);
            var passpordParser = new Regex("(?<key>\\w*):(?<value>.*?)([\\r\\n ]|$)", RegexOptions.Compiled);
            var parsedPassportArray = new List<Passport>();

            foreach (var passportString in passportArray)
            {
                var passport = new Passport();
                var parsedPassportCollection = passpordParser.Matches(passportString);
                foreach (Match parsedPassport in parsedPassportCollection)
                {
                    var key = parsedPassport.Groups["key"].Value.ToString().Trim();
                    var value = parsedPassport.Groups["value"].Value.ToString().Trim();

                    var propertyInfo = passport.GetType().GetProperty(key);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(passport, value, null);
                    }
                }
                parsedPassportArray.Add(passport);
            }

            return parsedPassportArray;
        }


        public class Passport
        {
            public string byr { get; set; }
            public string iyr { get; set; }
            public string eyr { get; set; }
            public string hgt { get; set; }
            public string hcl { get; set; }
            public string ecl { get; set; }
            public string pid { get; set; }
            public string cid { get; set; }
            public bool Valid =>
                    (byr != null && iyr != null && eyr != null && hgt != null && hcl != null && ecl != null && pid != null);
            public bool ValidFull =>
                (StringNotNullAndBetweenValues(byr, 1920, 2002) &&
                 StringNotNullAndBetweenValues(iyr, 2010, 2020) &&
                 StringNotNullAndBetweenValues(eyr, 2020, 2030) &&
                 CheckHeight(hgt) && 
                 CheckHairColor(hcl) &&
                 CheckEyeColor(ecl) &&
                 CorrectNumberOfDigits(pid, 9));
        }

        public static bool StringNotNullAndBetweenValues(string input, int from, int to)
        {
            return int.TryParse(input, out int number) && number >= from && number <= to;
        }

        public static bool CheckHeight(string input)
        {
            if (input == null || input.Length < 4) return false;

            switch (input[^2..])
            {
                case "cm":
                {
                    return int.TryParse(input[0..^2], out int height) && height >= 150 && height <= 193;
                }
                case "in":
                {
                    return int.TryParse(input[0..^2], out int height) && height >= 59 && height <= 76;
                }
                default:
                    return false;
            }
        }

        public static bool CheckHairColor(string input)
        {
            var hairColorParser = new Regex("(\\#[0-9a-f]{6})", RegexOptions.Compiled);
            return input != null && input.Length == 7 && hairColorParser.Match(input).Success;
        }

        public static bool CheckEyeColor(string input)
        {
            string[] validColors = { "amb", "blu", "brn", "grn", "hzl", "oth", "gry"};
            if (input == null || input.Length != 3)
            {
                return false;
            }
            return validColors.Contains(input);
        }

        public static bool CorrectNumberOfDigits(string input, int correctNumber)
        {
            return input != null && input.Length == 9 && input.Count(char.IsDigit) == correctNumber;
        }
    }


}
