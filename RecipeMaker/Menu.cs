using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    internal class Menu
    {
        //instantianting and encapsulating fields
        private int numberOfIngredients;
        private double ingredientQuantity;
        private int numberOfSteps;
        private double increaseQuantityBy;
        private string ingredientName;
        private string unitsOfMeasurement;
        private string stepDescription = "";
        private Ingredients ingredientsObj;
        private Steps stepsObj;
        private Ingredients[] ingredientsArray;
        private Steps[] stepsArray;

        //prints a specific symbol n times for format purposes
        public void printSymbols(char printCharacter, int printAmount)
        {
            for (int i = 0; i < printAmount; i++)
            {
                Console.Write(printCharacter);
            }
            Console.WriteLine();
        }

        //Overloads the method above to display the symbols as well as the string in between
        public void printSymbols(char printCharacter, int printAmount, string word)
        {
            for (int i = 0; i < printAmount; i++)
            {
                Console.Write(printCharacter);
            }

            Console.Write(" " + word + " ");

            for (int j = 0; j < printAmount; j++)
            {
                Console.Write(printCharacter);
            }

            Console.WriteLine();
        }

        private void getIngredientsFromUser()
        {
            ingredientsArray = new Ingredients[numberOfIngredients];
            int iIncrementor = 1;

            for (int i = 0; i < numberOfIngredients; i++)
            {
                Console.Write("Enter ingredient " + iIncrementor + " name: ");
                ingredientName = Console.ReadLine();

                Console.Write("Enter ingredient " + iIncrementor + " quantity: ");
                ingredientQuantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter ingredient " + iIncrementor + " unit of measurement: ");
                unitsOfMeasurement = Console.ReadLine();

                //passes the user input into the constructor and assigns their values to their instance fields
                ingredientsObj = new Ingredients(ingredientName, ingredientQuantity, unitsOfMeasurement);
                //assigns the recipe object with all the information to the ingredient array
                ingredientsArray[i] = ingredientsObj;

                iIncrementor++;
                printSymbols('=', 46);
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
            Console.WriteLine("RECIPE CAPTURED");
        }

        private void scaleQuantities()
        {
            if (ingredientsObj == null)
            {
                Console.WriteLine("No quantities available to modify");
            }
            else
            {
                double tempQuantity;
                Console.Write("Increase Quantity by: ");
                increaseQuantityBy = Convert.ToDouble(Console.ReadLine());

                if (increaseQuantityBy > 3)
                {
                    Console.WriteLine("Increase factor cannot exceed 3");
                }
                else
                {
                    foreach (Recipe quantity in ingredientsArray)
                    {
                        tempQuantity = (quantity.getQuantity() * increaseQuantityBy);
                        quantity.setQuantity(tempQuantity);
                    }
                    Console.WriteLine("QUANTITIES INCREASED");
                }
            }
            
        }

        private void resetQuantities()
        {
            if (ingredientsObj == null)
            {
                Console.WriteLine("No quantities available to modify");
            }
            else if (increaseQuantityBy == 0)
            {
                Console.WriteLine("Original quantities were never changed");
            }
            else
            {
                int tempQuantity;

                foreach (Recipe quantity in ingredientsArray)
                {
                    tempQuantity = (int)(quantity.getQuantity() / increaseQuantityBy);
                    quantity.setQuantity(tempQuantity);
                }
                Console.WriteLine("QUANTITIES RESET");
            }
        }

        /*
            * Resizing the arrays and seting their values to default values. "Clears" the arrays in a way
            * This is not necessarry since the getIngredientsFromUser and getDescriptionsFromUser methods already
            * resize and initialize the arrays everytime during runtime when they are called, this is just to fulfill the PoE requirement
            * of having an option in the menu to clear the array
        */
        private void clearArrayData()
        {
            /*
                * Checks if the arrays have elements in them
                * if there are no elements, nothing happens and a message is displayed to the user
                * if there are elements, they will be "cleared"
            */
            if(ingredientsArray == null && stepsArray == null)
            {
                Console.WriteLine("NOTHING TO CLEAR");
            }
            else
            {
                ingredientsArray = new Ingredients[0];
                stepsArray = new Steps [0];
                Console.WriteLine("RECIPE CLEARED");
            }
            
        }

        private void addNewRecipe()
        {
            //Further handling incorrect inputs entered
            try
            {
                printSymbols('=', 15, "Capturing Recipe");
                Console.Write("Enter number of ingredients: ");
                numberOfIngredients = Convert.ToInt32(Console.ReadLine());
                getIngredientsFromUser();
                getDescriptionsFromUser();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input entered, no recipe saved");
            }
        }
        //prints every recipe object
        private void printRecipe()
        {
            /*
                * if one or all of the instance objects are null the program does even have to attempt to display the recipe data 
                * because recipe data was not saved due to an error or the user did not add a recipe 
                * it also prevents null reference exceptions from occuring
            */
            if (ingredientsObj == null && stepsObj == null)
            {
                Console.WriteLine("No ingredients or steps available to display, no recipe data saved"); 
            }
            else if (ingredientsObj == null)
            {
                Console.WriteLine("No ingredients available to display, no recipe data saved");
            }
            else if (stepsObj == null)
            {
                Console.WriteLine("No steps available to display, no recipe data saved");
            }
            else 
            {
                printSymbols('=', 15, "Displaying Recipe");
                ingredientsObj.displayArrayElements(ingredientsArray);
                stepsObj.displayArrayElements(stepsArray);
            }
        }
        public void displayMenu()
        {
            int userChoice = 0;
            //Running the application until the user decides to close it
            while (userChoice != 6)
            {
                printSymbols('=', 15, " Recipe Maker ");
                Console.WriteLine("Enter 1 to add new recipe\n" +
                                    "Enter 2 to display added recipe\n" +
                                    "Enter 3 to increase ingredient quantities by either 0.5, 2 or 3\n" +
                                    "Enter 4 to reset ingredient quantities\n" +
                                    "Enter 5 to delete added recipe\n" +
                                    "Enter 6 to exit system");

                Console.Write("Enter choice: ");
                userChoice = Convert.ToInt32(Console.ReadLine());

                //Depending on the number the user enters, a specific action will be performed
                switch (userChoice)
                {
                    case 1:
                        addNewRecipe();
                        break;
                    case 2:
                        printRecipe();
                        break;
                    case 3:
                        scaleQuantities();
                        break;
                    case 4:
                        resetQuantities();
                        break;
                    case 5:
                        clearArrayData();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid number choice entered, please enter correct option");
                        break;
                }
            }
        }
    }
}
