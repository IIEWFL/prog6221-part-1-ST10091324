using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    internal class Recipe
    {
        //instantianting and encapsulating fields
        private int quantity;
        private string name;
        private string measurement;
        private string description;

        public Recipe(string nameOfIngredient, int userQuantity, string measurementOfIngredient)
        {
            name = nameOfIngredient;
            quantity = userQuantity;
            measurement = measurementOfIngredient;
        }

        public Recipe(string descriptionOfIngredient)
        {
            description = descriptionOfIngredient;
        }

        //implementing accessor methods
        public int getQuantity()
        {
            return quantity;
        }
        
        public string getName()
        {
            return name;
        }

        public string getMeasurement()
        {
            return measurement;
        }

        public string getDescription()
        {
            return description;
        }

        public void displayRecipe()
        {
            Console.WriteLine();
        }

        //String manupulation
        public void addToArray()
        {
           
        }
    }
}
