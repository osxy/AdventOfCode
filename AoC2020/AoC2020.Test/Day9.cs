using AoC2020.Days;
using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day9
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day9_TestData.txt";
            _day = new Days.Day9();
        }

        [TestCase(127)]
        public void Test1(int expectedResult)
        {
            var result = new Days.Day9().ExecutePartOne(testData, 5);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(62)]
        public void Test2(int expectedResult)
        {
            var result = new Days.Day9().ExecutePartTwo(testData, 5);
            Assert.AreEqual(expectedResult, result);
        }

    }
}