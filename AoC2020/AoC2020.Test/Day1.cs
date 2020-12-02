using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day1
    {
        private string[] testData;

        [SetUp]
        public void Setup()
        {
            testData = Helpers.General.GetDataFromInputFile("Day1_TestData.txt");
        }

        [TestCase(514579)]
        public void Test1(int expectedResult)
        {
            var result = Days.Day1.ExecutePartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(241861950)]
        public void Test2(int expectedResult)
        {
            var result = Days.Day1.ExecutePartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}