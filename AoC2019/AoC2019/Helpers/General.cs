using System;
using System.IO;
using System.Threading.Tasks;

namespace AoC2019.Helpers
{
    class General
    {

        static public string[] GetDataFromInputFile(string filename)
        {

            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var filelocation = Path.Combine(projectFolder, @"Input\", filename);


            string[] lines = System.IO.File.ReadAllLines(filelocation);


            return lines;

        }

        static public string GetDataFromInputFileAsString(string filename)
        {

            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var filelocation = Path.Combine(projectFolder, @"Input\", filename);


            string contents = System.IO.File.ReadAllText(filelocation);


            return contents;

        }



    }
}
