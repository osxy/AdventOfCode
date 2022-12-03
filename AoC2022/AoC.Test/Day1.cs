using AoC2022.Days;
using NUnit.Framework;

namespace AoC2022.Test
{
    public class Day1
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day1_TestData.txt";
            _day = new Days.Day1();
        }

        [TestCase("24000")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("45000")]
        public void Test2(string expectedResult)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}