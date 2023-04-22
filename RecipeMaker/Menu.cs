using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    internal class Menu
    {
        private int numberOfIngredients;
        private int ingredientQuantity;
        private int numberOfSteps;
        private string ingredientName;
        private string unitsOfMeasurement;
        private string stepDescription = "";
        private Steps stepsObj;
        private Ingredients ingredientsObj;
        private Ingredients[] ingredientsArray;
        private Steps[] stepsArray;
        private int[] arrayOfQuantities;

        //printing a specific symbol n times for format purposes
        private void printSymbols(char printCharacter, int printAmount)
        {
            for (int i = 0; i < printAmount; i++)
            {
                Console.Write(printCharacter);
            }
            Console.WriteLine();
        }

        //Overloading the method above to display, the symbols as well as the string in between
        private void printSymbols(char printCharacter, int printAmount, string word)
        {
            for (int i = 0; i < printAmount; i++)
            {
                Console.Write(printCharacter);
            }

            Console.Write(word);

            for (int j = 0; j < printAmount; j++)
            {
                Console.Write(printCharacter);
            }

            Console.WriteLine();
        }

        private void getIngredientsFromUser()
        {
            ingredientsArray = new Ingredients[numberOfIngredients];
            arrayOfQuantities = new int[numberOfIngredients];
            int iIncrementor = 1;

            for (int i = 0; i < numberOfIngredients; i++)
            {
                Console.Write("Enter ingredient " + iIncrementor + " name: ");
                ingredientName = Console.ReadLine();

                Console.Write("Enter ingredient " + iIncrementor + " quantity: ");
                ingredientQuantity = Convert.ToInt32(Console.ReadLine());
                arrayOfQuantities[i] = ingredientQuantity;

                Console.Write("Enter ingredient " + iIncrementor + " unit of measurement: ");
                unitsOfMeasurement = Console.ReadLine();

                ingredientsObj = new Ingredients(ingredientName, ingredientQuantity, unitsOfMeasurement);
                ingredientsArray[i] = ingredientsObj;

                iIncrementor++;
                printSymbols('=', 45);
            }
        }

        private void getDescriptionsFromUser()
        {
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
        }

        private void scaleQuantities()
        {
            int increaseQuantityBy;
            int tempQuantity;
            Console.Write("Increase Quantity by: ");
            increaseQuantityBy = Convert.ToInt32(Console.ReadLine());

            if(increaseQuantityBy > 3)
            {
                Console.WriteLine("Increase factor cannot exceed 3");
            }
            else
            {
                foreach(Recipe quantity in ingredientsArray)
                {    
                    tempQuantity = quantity.getQuantity() * increaseQuantityBy;
                }
            }
        }

        private void resetQuantities()
        {

        }

        private void clearArrayData(Recipe[] objectRecipe)
        {
            var recipeList = objectRecipe.ToList();
            recipeList.Clear();

            objectRecipe = recipeList.ToArray();
        }

        private void addNewRecipe()
        {
            try
            {
                Console.Write("Enter number of ingredients: ");
                numberOfIngredients = Convert.ToInt32(Console.ReadLine());
                getIngredientsFromUser();
                getDescriptionsFromUser();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input entered, no recipe saved");
            }
            ingredientsObj.displayArrayElements(ingredientsArray);
            stepsObj.displayArrayElements(stepsArray);
        }

        private void exitMenu()
        {
            Console.WriteLine("Press any button to close application...");
            //Preventing the console from immediately closing during runtime
            Console.ReadKey();
        }

        public void displayMenu()
        {
            int userChoice = 0;
            while (userChoice != 5)
            {
                printSymbols('=', 15, " Recipe Maker ");
                Console.WriteLine("Enter 1 to add new recipe\n" +
                                  "Enter 2 to increase ingredient quantities\n" +
                                  "Enter 3 to reset ingredient quantities\n" +
                                  "Enter 4 to delete added recipe\n" +
                                  "Enter 5 to exit system");

                Console.Write("Enter choice: ");
                userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        addNewRecipe();
                        break;
                    case 2:
                        scaleQuantities();
                        break;
                    case 3:
                        resetQuantities();
                        break;
                    case 4:
                        clearArrayData(ingredientsArray);
                        clearArrayData(stepsArray);
                        break;
                    case 5:
                        exitMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid number choice entered");
                        break;
                }
            }
        }
    }
}
