using AoC2022.Days;
using NUnit.Framework;

namespace AoC2022.Test
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
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}