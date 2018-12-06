using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;

namespace AoC2018
{
    class Program
    {
        public static void Main()
        {
            Console.Clear();


            var menu = new EasyConsole.Menu()
              .Add("Day 1", () => Days.Day1.execute())
              .Add("Day 2", () => Days.Day2.execute());
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
