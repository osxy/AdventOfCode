using AoC2022.Days;
using NUnit.Framework;

namespace AoC2022.Test
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

        [TestCase("CMZ")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("4")]
        public void Test2(string expectedResult)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}