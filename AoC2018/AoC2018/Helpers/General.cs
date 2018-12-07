using System;
using System.IO;
using System.Threading.Tasks;

namespace AoC2018.Helpers
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



    }
}
