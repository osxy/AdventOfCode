using AoC2022.Days;
using NUnit.Framework;

namespace AoC2022.Test
{
    public class Day2
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day2_TestData.txt";
            _day = new Days.Day2();
        }

        [TestCase("15")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("12")]
        public void Test2(string expectedResult)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}