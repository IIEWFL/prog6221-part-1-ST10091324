﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menuObj = new Menu();
            menuObj.displayMenu();
            
            Console.WriteLine("Press any button to close application...");
            //Preventing the console from immediately closing during runtime
            Console.ReadKey();
        }
    }
}
