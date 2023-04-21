﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    internal class Steps : Recipe
    {
        public Steps(string descriptionOfStep)
        {
            description = descriptionOfStep;
        }

        //Looping through each element in the array
        //to displaying each ingredients
        public override void displayArrayElements(Recipe[] recipeObject)
        {
            int incrementor = 1;
            foreach (Recipe stepsElement in recipeObject)
            {
                Console.WriteLine("Step " + incrementor + ": " + stepsElement.getDescription());
                incrementor++;
            }
            Console.WriteLine();
        }
    }
}