using System;
using System.IO;
using System.Threading.Tasks;

namespace AoC2020.Helpers
{
    public class General
    {

        static public string[] GetDataFromInputFileAsStringArray(string filename)
        {

            var filelocation = Path.Combine(@"Input\", filename);

            string[] lines = System.IO.File.ReadAllLines(filelocation);

            return lines;

        }

        static public string GetDataFromInputFileAsString(string filename)
        {

            var filelocation = Path.Combine(@"Input\", filename);

            string contents = System.IO.File.ReadAllText(filelocation);

            return contents;

        }



    }
}
