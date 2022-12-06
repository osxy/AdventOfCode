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
        
        [TestCase(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4)]
        [TestCase(5, "bvwbjplbgvbhsrlpgdmjqwftvncz", 4)]
        [TestCase(6, "nppdvjthqldpwncqszvftbrmjlhg", 4)]
        [TestCase(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4)]
        [TestCase(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4)]
        [TestCase(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14)]
        [TestCase(23, "bvwbjplbgvbhsrlpgdmjqwftvncz", 14)]
        [TestCase(23, "nppdvjthqldpwncqszvftbrmjlhg", 14)]
        [TestCase(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14)]
        [TestCase(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14)]
        public void MarkerPos(int expectedResult, string data, int markerLength)
        {
            var result = Days.Day6.MarkerPosition(data, markerLength);
            Assert.AreEqual(expectedResult, result);
        }
    }
}