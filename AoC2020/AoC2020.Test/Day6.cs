using AoC2020.Days;
using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day6
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day6_TestData.txt";
            _day = new Days.Day6();
        }

        [TestCase("11")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("6")]
        public void Test2(string expectedResult)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }

    }
}