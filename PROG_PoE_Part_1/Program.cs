﻿using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Runtime.InteropServices;
//new comment to test commit

namespace PROG_PoE_Part_1
{
    class Ingredient
    {
        public string sIngredient_name;
        //creates a variable called sIngredient_name of type string.
        public string Ingredient_Name
        {
            get { return sIngredient_name; }
            set { sIngredient_name = value; }
        }
        //getters and setters using automatic properties.

        //https://www.w3schools.com/cs/cs_properties.php
        //w3schools


        public double dIngredient_quantity;
        //creates a variable called dIngredient_quantity of type double.
        public double Ingredient_Quantity
        {
            get { return dIngredient_quantity; }
            set { dIngredient_quantity = value; }
        }
        //getters and setters using automatic properties.

        public string sIngredient_unit;
        //creates a variable called sIngredient_unit of type string.
        public string Ingredient_Unit
        {
            get { return sIngredient_unit; }
            set { sIngredient_unit = value; }
        }
        //getters and setters using automatic properties.
    }
    //class to store the ingredient values.


    class Recipe
    {
        public Ingredient[] ingredients;
        //creates a variable called ingredients of type Ingredient array.
        public Ingredient[] Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        //getters and setters using automatic properties.

        public string[] sSteps;
        //creates a variable called sSteps of type string array.
        public string[] steps
        {
            get { return sSteps; }
            set { sSteps = value; }
        }
        //getters and setters using automatic properties.

        public float factor;
        //creates a variable called factor of type float.
        public float ffactor
        {
            get { return factor; }
            set { factor = value; }
        }
        //getters and setters using automatic properties.

        public Boolean bScaled;

        public Boolean Scaled
        {
            get { return bScaled; }
            set { bScaled = value; }
        }
        //getters and setters using automatic properties.


        public void Create_A_Recipe()
        {
           
            ingredients = Enter_Ingredients();
            //gets the values from Enter_Ingredients() and assigns it to the variable ingredients.

            if (ingredients != null)
            {
                steps = Enter_Steps();
                //gets the steps from Enter_Steps() and assigns it to the variable steps.
            }

        }
        //creates a new recipe.

        public static string[] Enter_Steps()
        {
            Console.WriteLine("Enter the number of steps: ");
            string snum_of_Steps = Console.ReadLine();
            int num_of_Steps;
            if(!int.TryParse(snum_of_Steps, out num_of_Steps))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a numeric value.");
                return null;
            }
            //asks the user to enter the number of steps and then converts in to an integer.
            else
            {
                string[] Steps = new string[num_of_Steps];
                //calls the Steps array to store the number of steps and creates the Steps object.

                for (int i = 0; i < num_of_Steps; i++)
                {
                    Console.WriteLine($"Enter the step #{i + 1}:");
                    string steps = Console.ReadLine();
                    //asks the user to enter the step, if the user enters 3 steps then because i is = 0 it will add 1 and output the first step.

                    Steps[i] = steps;
                    //stores the step in the Step array.
                }

                return Steps;
            }

        }
        //enters the steps
        public static Ingredient[] Enter_Ingredients()
        {
            
            Console.WriteLine("Enter the number of ingredients: ");
            string snum_of_Ingredients = Console.ReadLine();
            int num_of_Ingredients;
            if (!int.TryParse(snum_of_Ingredients, out num_of_Ingredients))
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("Please enter a numeric value.");
                return null;
            }
            else
            {

                //asks the user for the number of ingredients and then converts it to an integer.

                Ingredient[] ingredients = new Ingredient[num_of_Ingredients];
                //calls the Ingredients array to store the ingredients and creates the Ingredient object.

                for (int i = 0; i < num_of_Ingredients; i++)
                {

                    Console.WriteLine("Enter the ingredient name: ");
                    string Name_of_Ingredient = Console.ReadLine();
                    //asks the user to enter the ingredients name and then converts it to a string.

                    Console.WriteLine("Enter the ingredients quantity: " + '\n' + "Please enter only the number.Example: 2 (tablespoon of sugar)");
                    double Quantity_of_Ingedient = double.Parse(Console.ReadLine());
                    //asks the user to enter the quantity of the ingredient and then converts it to a double.

                    Console.WriteLine("Enter the unit of mesurement: " + '\n' + "Example: teaspoon, tablespoon, cup, ect");
                    string Unit_of_Ingredient = Console.ReadLine();
                    //asks the user to enter the unit of measurement for the ingredient and then converts it to a string.

                    ingredients[i] = new Ingredient { Ingredient_Name = Name_of_Ingredient, Ingredient_Quantity = Quantity_of_Ingedient, Ingredient_Unit = Unit_of_Ingredient };
                    //adds the ingredient details to the igredient array.
                }
                return ingredients;

            }
            
        }
        //enters the ingredients

        public void Display_Recipe()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("The recipe is shown below:");
            Console.WriteLine("The ingredients are: ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine("The name of ingredient - " + ingredient.sIngredient_name + '\n' + "Ingredient quantity is - " + ingredient.dIngredient_quantity + " " + ingredient.sIngredient_unit);

            }
            //goes through the Ingreident array to output each ingredient name, quantity and mesurement.

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("The steps are: ");
            Console.ForegroundColor = ConsoleColor.White;
            int iStepCounter = 1;

            foreach (String steps in sSteps)
            {
                Console.WriteLine("Step " + iStepCounter + ": " + steps);
            }
            //goes through the Steps array to output step.

        }
        //displays the recipe.

        public void Conversion_Scaled(int iLoopCounter, double scaled)
        {
            switch (ingredients[iLoopCounter].sIngredient_unit.ToUpper())
            {
                case "TABLESPOON":
                    {
                        if (scaled%8 == 0 )
                        {
                            ingredients[iLoopCounter].dIngredient_quantity = scaled / 8;
                            // assign the ingredient.value to the divied (whole no) no.

                            ingredients[iLoopCounter].Ingredient_Unit = "CUPS"; 
                            // change ingreindets measurement to cups.
                        }
                        else
                        {
                            ingredients[iLoopCounter].dIngredient_quantity  = scaled;
                        }
                        
                        break;
                    }
                   default:
                    {
                        ingredients[iLoopCounter].dIngredient_quantity = scaled;
                        break;
                    }
            }
        }

        public void Conversion_Reset(int iLoopCounter, double scaled)
        {
            if (bScaled)
            {
                switch (ingredients[iLoopCounter].sIngredient_unit.ToUpper())
                {

                    case "CUPS":
                        {

                                ingredients[iLoopCounter].dIngredient_quantity = scaled * 8;
                                // assign the ingredient.value to the divied (whole no) no.

                                ingredients[iLoopCounter].Ingredient_Unit = "TABLESPOON";
                            // change ingreindets measurement to cups.
                            bScaled = false;

                            break;
                        }
                        default:
                        {
                            ingredients[iLoopCounter].dIngredient_quantity = scaled;
                            bScaled = false;
                            break;
                        }


                }
            }
        }


        public void Scale_Recipe()
        {
            double scaled = 1;
            //variable called scaled and is equal to 1.
            int iLoopCounter = 0;


            foreach (Ingredient ingredient in ingredients)
            {
                scaled = ingredient.Ingredient_Quantity * factor;
                String sMeasurement = ingredient.sIngredient_unit;

                Conversion_Scaled( iLoopCounter ,scaled );

            }
            //gets the ingredient quantity and times it by the factor to get the scaled value.

            bScaled = true;
        }
        //allows the user to scale the recipe.

        public void Reset_Quantities(double factor)
        {
            int iLoopCounter = 0;
            foreach (Ingredient ingredients in Ingredients)
            {
                double scaled = ingredients.Ingredient_Quantity / factor;
                String sMeasurement = ingredients.sIngredient_unit;

                Conversion_Reset(iLoopCounter, scaled);


                Console.WriteLine("Quantities are reset to orginal quantity.The orginal quantity is " + ingredients.Ingredient_Quantity);
            }
            //gets the scaled quantity and divides it by the factor to get the orginal quantity.
        }
        //allows the user to reset the quantites back to the orginal quantity.

    }
    //gets the recipe ingredients and steps.

    class eCookBook
    {
        static void Main(string[] args)
        {
            try
            {
                Recipe orecipe = new Recipe();
                //creates an object orecipe of type Recipe.
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                //changes the colour of the font.
                Console.Title = "eCookBook";
                Console.WriteLine("Welcome to your very own eCook-Book. Where you can create any one of your favourite recipes.");
               


                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    //https://www.tutorialspoint.com/how-to-change-the-foreground-color-of-text-in-chash-console#:~:text=To%20change%20the%20Foreground%20Color%20of%20text%2C%20use%20the%20Console,ForegroundColor%20property%20in%20C%23.
                    //AmitDiwan
                    //updated 13 November 2019

                    Console.WriteLine("Choose an option for what you want to do.");
                    Console.WriteLine("(1) Create a new recipe");
                    Console.WriteLine("(2) Display the recipe");
                    Console.WriteLine("(3) Scale the recipe");
                    Console.WriteLine("(4) Reset the ingredient quantity to its orginal value");
                    Console.WriteLine("(5) Clear the recipe");
                    Console.WriteLine("(6) Quit");

                    string choiceString = Console.ReadLine();
                    //gives the user options to choose from.

                    if (!int.TryParse(choiceString, out int choice))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid option. Please enter a number from 1 to 6.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    //if the user chooses an invalid option.

                    switch (choice)
                    {
                        case 1:
                            orecipe.Create_A_Recipe();
                            //calls the Create_A_Recipe() method from Recipe class.
                            break;
                        case 2:
                            if (orecipe == null)
                            {
                                Console.WriteLine("No recipe is created yet. Please enter a recipe.");
                                //if the user chooses an invalid option.
                            }
                            else
                            {
                                orecipe.Display_Recipe();
                                //calls the Display_Recipe() method from Recipe class.
                            }

                            break;
                        case 3:
                            Console.WriteLine("Enter the scaling factor:" + '\n' + "Choose from halfing (0,5), doubling (2) or tripling (3).");
                            //asks the user for a factor.
                            string sfactor = Console.ReadLine();
                            //converts it to a string value.

                            if (sfactor.Length < 0)
                            {

                                Console.WriteLine("Invalid scaling factor. Please enter a valid number.");
                                //if the user chooses an invalid factor.
                                continue;
                            }
                            else
                            {
                                orecipe.ffactor = float.Parse(sfactor);
                                //converts the factor to a float.
                                orecipe.Scale_Recipe();
                                //calls the Scale_Recipe() method from Recipe class.
                                foreach (Ingredient ingredient in orecipe.Ingredients)
                                {
                                    Console.WriteLine($"Recipe scaled by factor of {orecipe.ffactor}. The new quantity is " + ingredient.Ingredient_Quantity);
                                }
                            }
                            break;
                        case 4:

                            if (orecipe == null)
                            {
                                Console.WriteLine("No recipe is created yet. Please enter a recipe. ");
                            }
                            else
                            {
                                orecipe.Reset_Quantities(orecipe.factor);
                                //calls the Reset_Quantities() method and passes factor in from Recipe class.
                            }

                            break;
                        case 5:

                            Console.WriteLine("Would you like to clear the recipe. YES or NO.");
                            string sResetRecipe = Console.ReadLine();

                            if (sResetRecipe.ToUpper() == "YES")
                            {
                                orecipe = null;
                                //makes sure that the object orecipe is cleared.
                                Console.WriteLine("Recipe has been cleared.");
                            }
                            else
                            {
                                Console.WriteLine("No recipe was created to clear.");
                            }

                            break;
                        case 6:
                            Console.WriteLine("Thank you for using the eCook_Book!");
                            //allows the user to quit.
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please enter a number from 1 to 6.");
                            //user chooses an invalid option.
                            break;
                    }
                }


            }

            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restart application. Error occcured in application. ");
                Console.ReadLine();

            }

            //contains main method to output the recipe.

        }
    }
}
//namespace