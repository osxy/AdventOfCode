using AoC2021.Days;
using NUnit.Framework;

namespace AoC2021.Test
{
    public class Day3
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day3_TestData.txt";
            _day = new Days.Day3();
        }

        [TestCase("198")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("230")]
        public void Test2(string expectedResult)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}