using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018.Helpers
{
    class ArraysAndLists
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


    }
}
