using AoC2020.Days;
using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day5
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day5_TestData.txt";
            _day = new Days.Day5();
        }

        [TestCase("BFFFBBFRRR", 567)]
        [TestCase("FFFBBBFRRR", 119)]
        [TestCase("BBFFBBFRLL", 820)]
        public void SeatParser(string input, int expectedResult)
        {
            var result = Days.Day5.SeatIdParser(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("820")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

    }
}