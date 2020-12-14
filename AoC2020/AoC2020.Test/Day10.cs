using AoC2020.Days;
using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day10
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day10_TestData1.txt";
            _day = new Days.Day10();
        }

        [TestCase("35", "Day10_TestData1.txt")]
        [TestCase("220", "Day10_TestData2.txt")]
        public void Test1(string expectedResult, string testData)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("8", "Day10_TestData1.txt")]
        [TestCase("19208", "Day10_TestData2.txt")]
        public void Test2(string expectedResult, string testData)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }

    }
}