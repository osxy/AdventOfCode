using AoC2020.Days;
using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day4
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day4_TestData.txt";
            _day = new Days.Day4();
        }

        [TestCase("2")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("4")]
        public void Test2(string expectedResult)
        {
            testData = "Day4_TestData2.txt";
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1920", 1920 ,2002, true)]
        [TestCase("2002", 1920, 2002, true)]
        [TestCase("2000", 1920, 2002, true)]
        [TestCase("1919", 1920, 2002, false)]
        [TestCase("2003", 1920, 2002, false)]
        [TestCase(null, 1920, 2002, false)]
        public void StringNotNullAndBetweenValues(string input, int from, int to, bool expectedResult)
        {
            var result = Days.Day4.StringNotNullAndBetweenValues(input, from, to);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("150cm", true)]
        [TestCase("193cm", true)]
        [TestCase("160cm", true)]
        [TestCase("149cm", false)]
        [TestCase("194cm", false)]
        [TestCase("59in", true)]
        [TestCase("76in", true)]
        [TestCase("70in", true)]
        [TestCase("58in", false)]
        [TestCase("77in", false)]
        [TestCase("7in", false)]
        [TestCase(null, false)]
        public void CheckHeight(string input, bool expectedResult)
        {
            var result = Days.Day4.CheckHeight(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("#123456", true)]
        [TestCase("#789000", true)]
        [TestCase("#abcdef", true)]
        [TestCase("#123abc", true)]
        [TestCase("#abc123", true)]
        [TestCase("abc123", false)]
        [TestCase("#gabcde", false)]
        [TestCase("#78900", false)]
        [TestCase("#abcde", false)]
        [TestCase(null, false)]
        public void CheckHairColor(string input, bool expectedResult)
        {
            var result = Days.Day4.CheckHairColor(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("amb", true)]
        [TestCase("blu", true)]
        [TestCase("brn", true)]
        [TestCase("gry", true)]
        [TestCase("grn", true)]
        [TestCase("hzl", true)]
        [TestCase("oth", true)]
        [TestCase("red", false)]
        [TestCase(null, false)]
        public void CheckEyeColor(string input, bool expectedResult)
        {
            var result = Days.Day4.CheckEyeColor(input);
            Assert.AreEqual(expectedResult, result);
        }


        [TestCase("000000000", 9,true)]
        [TestCase("123456789", 9, true)]
        [TestCase("00000000", 9, false)]
        [TestCase("0000000000", 9, false)]
        [TestCase(null, 9, false)]
        public void CorrectNumberOfDigits(string input, int expectedNumber,bool expectedResult)
        {
            var result = Days.Day4.CorrectNumberOfDigits(input, expectedNumber);
            Assert.AreEqual(expectedResult, result);
        }
    }
}