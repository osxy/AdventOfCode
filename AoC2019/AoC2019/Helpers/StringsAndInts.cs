using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019.Helpers
{
    class StringsAndInts
    {

        // Vergelijk van 2 strings per character positie de characters. 
        //Output: Aantal afwijkende characters en een string van alle characters welke wel overeenkomen
        public static Tuple<int, string> CompareCharactersInStrings(string a, string b)
        {
            int diff = 0;
            string remainingString = "";

            // Zet a om in een Char Array
            var ArrayA = new string[0];
            ArrayA = a.ToCharArray().Select(c => c.ToString()).ToArray();

            // Zet b om in een Char Array
            var ArrayB = new string[0];
            ArrayB = b.ToCharArray().Select(c => c.ToString()).ToArray();

            for (int i = 0; i < ArrayA.Count(); i++)
            {

                // Als character op positie i in a en b niet gelijk is tel dan 1 op bij de diff counter
                if (ArrayA[i] != ArrayB[i])
                {
                    diff += 1;

                }
                else
                { // Als het character op positie i in a en b gelijk is bouw dan de nieuwe return string op

                    remainingString = remainingString + ArrayA[i];

                }
            }

            return Tuple.Create(diff, remainingString);
        }


        static public int ConvertStringToInt(string intString)
        {
            int i = 0;
            return (Int32.TryParse(intString, out i) ? i : (int)0);
        }
    }
}
