﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    internal abstract class Recipe
    {
        //instantianting and encapsulating fields
        protected int quantity;
        protected string name;
        protected string measurement;
        protected string description;

        //declaring accessor methods
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

        //method to be implemented by derived class to display elements in the array
        public abstract void displayArrayElements(Recipe[] recipeObject);
    }
}
