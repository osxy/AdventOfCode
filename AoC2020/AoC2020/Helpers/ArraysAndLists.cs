using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Helpers
{
   public  class ArraysAndLists
    {

        // Zet String[] om in een IntList
        // Output: List<int>
        public static List<int> StringArrayToIntList(string[] values)
        {
            return Array.ConvertAll(values, int.Parse).ToList();
        }

        // Zet String om in String[]
        // Output: String[]
        public static String[] StringToStringArray(string value, char delimiter)
        {
            return value.Split(delimiter);
        }

        // Zet String om in String[]
        // Output: String[]
        public static int[] StringToIntArray(string value, char delimiter)
        {
            return Array.ConvertAll(StringToStringArray(value, delimiter), int.Parse);
        }

        // Zet String[] om in int[]
        // Output: String[]
        public static int[] StringArrayToIntArray(string[] values)
        {
            return Array.ConvertAll(values, int.Parse);
        }


    }
}
