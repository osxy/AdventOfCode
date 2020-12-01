using NUnit.Framework;

namespace AoC2020.Test
{
    public class Day1
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Day1_TestData.txt",514579)]
        public void Test1(string testDataFile, int expectedResult)
        {
            var testData = Helpers.General.GetDataFromInputFile(testDataFile);
            var result = Days.Day1.ExecutePartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("Day1_TestData.txt", 241861950)]
        public void Test2(string testDataFile, int expectedResult)
        {
            var testData = Helpers.General.GetDataFromInputFile(testDataFile);
            var result = Days.Day1.ExecutePartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
    }
}