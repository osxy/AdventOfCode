using AoC2022.Days;
using NUnit.Framework;

namespace AoC2022.Test
{
    public class Day6
    {
        private string testData;
        private IDays _day;

        [SetUp]
        public void Setup()
        {
            testData = "Day6_TestData.txt";
            _day = new Days.Day6();
        }

        [TestCase("CMZ")]
        public void Test1(string expectedResult)
        {
            var result = _day.PartOne(testData);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("MCD")]
        public void Test2(string expectedResult)
        {
            var result = _day.PartTwo(testData);
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestCase(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
        [TestCase(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
        [TestCase(6, "nppdvjthqldpwncqszvftbrmjlhg")]
        [TestCase(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
        [TestCase(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
        public void MarkerPos(int expectedResult, string data)
        {
            var result = Days.Day6.MarkerPosition(data);
            Assert.AreEqual(expectedResult, result);
        }
    }
}