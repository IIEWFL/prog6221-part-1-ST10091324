using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    //inherits values from base class recipe
    internal class Steps : Recipe
    {
        //creates a constructor and mutates the inherited instance field using the value passed into the constructor
        public Steps(string descriptionOfStep)
        {
            description = descriptionOfStep;
        }

        //Loops through each element in the array to displaying each ingredients
        public override void displayArrayElements(Recipe[] recipeObject)
        {
            int incrementor = 1;
            foreach (Recipe stepsElement in recipeObject)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Step " + incrementor + ": " + stepsElement.getDescription());
                incrementor++;
            }
        }
    }
}
