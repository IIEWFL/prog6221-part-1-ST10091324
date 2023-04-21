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
            string ingredientName;
            string unitsOfMeasurement;
            string stepDescription = "";

            printSymbols('=', 15, " Recipe Maker ");
            Console.Write("Enter number of ingredients: ");
            numberOfIngredients = Convert.ToInt32(Console.ReadLine());

            Ingredients ingredientsObj = null;
            Steps stepsObj = null;

            Ingredients[] ingredientsArray = new Ingredients[numberOfIngredients];
            Steps[] stepsArray = null;

            int iIncrementor = 1;
            for (int i = 0; i < numberOfIngredients; i++)
            {
                Console.Write("Enter ingredient " + iIncrementor + " name: ");
                ingredientName = Console.ReadLine();

                Console.Write("Enter ingredient " + iIncrementor + " quantity: ");
                ingredientQuantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter ingredient " + iIncrementor + " unit of measurement: ");
                unitsOfMeasurement = Console.ReadLine();

                ingredientsObj = new Ingredients(ingredientName, ingredientQuantity, unitsOfMeasurement);
                ingredientsArray[i] = ingredientsObj;

                iIncrementor++;
                printSymbols('=', 60);
            }

            Console.Write("Enter number of steps: ");
            numberOfSteps = Convert.ToInt32(Console.ReadLine());

            stepsArray = new Steps[numberOfSteps];
            int jIncrementor = 1;

            
            for (int j = 0; j < numberOfSteps; j++)
            {
                Console.Write("Enter description of step " + jIncrementor + ": ");
                stepDescription = Console.ReadLine();
                jIncrementor++;

                stepsObj = new Steps(stepDescription);
                stepsArray[j] = stepsObj;

            }
            printSymbols('=', 15, " Recipe captured ");

            try
            {
                ingredientsObj.displayArrayElements(ingredientsArray);
                stepsObj.displayArrayElements(stepsArray);
            }
            catch (NullReferenceException nre)
            {
                if(nre)
                {

                }
                Console.WriteLine("Steps or ingredients missing, please add");
            }
            

            Console.WriteLine("Press any button to close application...");
            //Preventing the console from immediately closing during runtime
            Console.ReadKey();
        }

        //printing a specific symbol n times for format purposes
        public static void printSymbols(char printCharacter, int printAmount)
        {
            for(int i=0; i<printAmount; i++)
            {
                Console.Write(printCharacter);
            }
            Console.WriteLine();
        }

        //Overloading the method above to display, the symbols as well as the string in between
        public static void printSymbols(char printCharacter, int printAmount, string word)
        {
            for (int i = 0; i < printAmount; i++)
            {
                Console.Write(printCharacter);
            }

            Console.Write(word);

            for(int j = 0; j < printAmount; j++)
            { 
                Console.Write(printCharacter);
            }

            Console.WriteLine();
        }
    }
}
