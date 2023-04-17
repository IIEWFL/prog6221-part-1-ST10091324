using System;
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
            int numberOfIngredients;
            int ingredientQuantity;
            int numberOfSteps;
            String ingredientName;
            string unitsOfMeasurement;
            String instructionDescription;


            Console.WriteLine("==========\tRecipe Maker\t==========\n");
            Console.Write("Enter number of ingredients: ");
            numberOfIngredients = Convert.ToInt32(Console.ReadLine());

            for(int i=0; i<numberOfIngredients; i++)
            {
                Console.Write("Enter ingredient name: ");
                ingredientName = Console.ReadLine();

                Console.Write("Enter ingredient quantity: ");
                ingredientQuantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter ingredient unit of measurement: ");
                unitsOfMeasurement = Console.ReadLine();

                Console.WriteLine("\n==========\tIngredient information captured\t==========");
            }

            Console.Write("Enter number of steps: ");
            numberOfSteps = Convert.ToInt32(Console.ReadLine());

            for(int j=0; j<numberOfSteps; j++)
            {
                Console.Write("Enter description of steps: ");
                instructionDescription = Console.ReadLine();
            }

            Console.ReadKey();
        }
    }
}
