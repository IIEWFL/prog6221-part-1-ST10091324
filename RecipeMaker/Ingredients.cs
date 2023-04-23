using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    internal class Ingredients: Recipe
    {
        //creates a constructor and mutates the inherited instance fields using the values being passed into the constructor
        public Ingredients(string nameOfIngredient, double userQuantity, string measurementOfIngredient)
        {
            name = nameOfIngredient;
            quantity = userQuantity;
            measurement = measurementOfIngredient;
        }

        //Loops through each element in the array to displaying each ingredients
        public override void displayArrayElements(Recipe[] recipeObject)
        {
            int incrementor = 1;
            foreach (Recipe recipeElement in recipeObject)
            {
                Console.WriteLine("Ingredient " + incrementor + ": " + recipeElement.getQuantity()+ " " + recipeElement.getMeasurement() + 
                                    " of " + recipeElement.getName());
                incrementor++;
            }
        }
    }
}
