using AoC2020.Days;
using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day2
    {
        private string[] testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = Helpers.General.GetDataFromInputFile("Day2_TestData.txt");
            _day = new Days.Day2();
        }

        [TestCase("2")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1")]
        public void Test2(string expectedResult)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}