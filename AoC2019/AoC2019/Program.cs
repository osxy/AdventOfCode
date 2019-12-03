using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;

namespace AoC2019
{
    class Program
    {
        public static void Main()
        {
            Console.Clear();

            Console.WriteLine("Advent Of Code 2019");
            Console.WriteLine("by André K.");
            Console.WriteLine("");

            var menu = new EasyConsole.Menu()
                .Add("Day 1", () => Days.Day1.Execute())
                .Add("Day 2", () => Days.Day2.Execute())
                .Add("Day 3", () => Days.Day3.Execute());
            menu.Display();

        }

        public static void BackToMain()
        {

            //Keep console open untill any value is returned
            Console.WriteLine("");
            Console.WriteLine("");
            
            Input.ReadString("To go to main menu press enter");
            Main();

        }
        
    }
}
