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

            List<int> intValues = new List<int>();

            foreach (string input in values)
            {

                intValues.Add(Convert.ToInt32(input));

            }

            return intValues;


        }

        // Zet String om in String[]
        // Output: String[]
        public static String[] StringToStringArray(string value, char delimiter)
        {

            string[] outputArray = value.Split(delimiter);
            return outputArray;

        }

        // Zet String om in String[]
        // Output: String[]
        public static int[] StringToIntArray(string value, char delimiter)
        {

            string[] inputArray = value.Split(delimiter);
            List<int> outputList = new List<int>();
            foreach (string x in inputArray)
            {

                outputList.Add(Convert.ToInt32(x));

            }
            int[] outputArray = outputList.ToArray();
            return outputArray;

        }

        // Zet String[] om in int[]
        // Output: String[]
        public static int[] StringArrayToIntArray(string[] values)
        {

            List<int> outputList = new List<int>();
            foreach (string x in values)
            {

                outputList.Add(Convert.ToInt32(x));

            }
            int[] outputArray = outputList.ToArray();
            return outputArray;

        }


    }
}
