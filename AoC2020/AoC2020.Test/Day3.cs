using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day3
    {
        private string[] testData;

        [SetUp]
        public void Setup()
        {
            testData = Helpers.General.GetDataFromInputFile("Day3_TestData.txt");
        }

        [TestCase(7)]
        public void Test1(int expectedResult)
        {
            var result = Days.Day3.ExecutePartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(336)]
        public void Test2(int expectedResult)
        {
            var result = Days.Day3.ExecutePartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}