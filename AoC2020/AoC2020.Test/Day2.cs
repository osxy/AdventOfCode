using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day2
    {
        private string[] testData;

        [SetUp]
        public void Setup()
        {
            testData = Helpers.General.GetDataFromInputFile("Day2_TestData.txt");
        }

        [TestCase(2)]
        public void Test1(int expectedResult)
        {
            var result = Days.Day2.ExecutePartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1)]
        public void Test2(int expectedResult)
        {
            var result = Days.Day2.ExecutePartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}