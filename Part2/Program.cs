﻿using System;
using System.ComponentModel.DataAnnotations;
using static ProgramPart1;

internal class ProgramPart1
{
    //declare and initialize variables used in program
    public class Ingredients
    {
        public string name;
        public double quantity;
        public string unitsOfMeasurements;
        public double calories;
    }

    //declaring and initializing variables as private static to make them accessuble by new private static void methods
    private static Ingredients[] ingredients;
    private static int numIng;
    private static string[] steps;
    private static int numSteps;
    private static double[] orgQuantities;


    //in the main method is RecipeDetails() which ensures that all operations inside RecipeDetails() will run 
    private static void Main(string[] args)
    {
        //improvement1
        //Welcome user to the app
        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
        Console.WriteLine("***** Welcome to the Recipe Application *****");
        Console.WriteLine("Please enter the following details for a single recipe");
        RecipeDetails();
    }

    //expanding method RecipeDetails() by inputting operations
    public static void RecipeDetails()
    {
        //ask user to enter the name of recipe
        Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
        Console.WriteLine("Enter the name of the recipe: ");
        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
        string name = Console.ReadLine();

        //Ask the user the number of ingredients and read user's input stored as numIng
        Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
        Console.WriteLine("Enter the number of ingredients: ");
        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
        int numIng = Convert.ToInt32(Console.ReadLine());

        //error handling
        /*
        while(true)
        {
            string input = Console.ReadLine();

            if(int.TryParse(input, out numIng))
            {
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
                Console.WriteLine("Invalid option entered, try again and enter a number from 1 to however many steps are required.");
                Console.WriteLine("Enter the number of ingredients: ");
                Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            }
        }
        */

        //Confirm with the user the number of ingredients entered
        Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
        Console.WriteLine("Note: The number of ingredients chosen are: " + numIng);

        //clear console screen
        Console.Clear();

        //create array for ingredients setting the size to numIng which is the number chosen by the user
        //Ingredients[] ingredients = new Ingredients[numIng];
        //fix array of ingredients that was a local declaration so that it can be accessed by the private staic void methods
        ingredients = new Ingredients[numIng];

        //for loop because for each number of ingredient chosen by user it must ask the name, quantity, and units of measurement
        for (int i = 0; i < numIng; i++)
        {
            //ask user to enter the name of the ingredient and store it as nameIng
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("Enter the name of ingredient " + (i + 1) + ": ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            string nameIng = Console.ReadLine();

            //ask user to enter te quantity of the ingredient and store it as quantityIng
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("Enter the quantity (amount in numbers) of the ingredient: ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            double quantityIng = Convert.ToDouble(Console.ReadLine());

            //improvement2
            //allow user to choose the unit of measurement by using menu system
            //ask user to enter the unit of measurement and store it as unitsMe
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("Enter the unit of measurement of the ingredient by choosing one of the letters in brackets: ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            Console.WriteLine("(C) Cup");
            Console.WriteLine("(T) Tablespoon");
            Console.WriteLine("(S) Teaspoon");
            Console.WriteLine("(G) Gram");
            Console.WriteLine("(K) Kilogram");
            Console.WriteLine("(L) Litres");
            Console.WriteLine("(M) Millilitres");

            //users input is saved as a string as the variable unitsMe
            string unitsMe = Console.ReadLine();

            //switch case
            //assign each option to variable of unitsMe so that it will display in the recipe
            //confirm with user their option
            switch (unitsMe)
            {
                case "C":
                    unitsMe = "cup";
                    Console.WriteLine("Unit of Measurement - cup");
                    break;
                case "T":
                    unitsMe = "tablespoon";
                    Console.WriteLine("Unit of Measurement - tablespoon");
                    break;
                case "S":
                    unitsMe = "teaspoon";
                    Console.WriteLine("Unit of Measurement - teaspoon");
                    break;
                case "G":
                    unitsMe = "gram";
                    Console.WriteLine("Unit of Measurement - gram");
                    break;
                case "K":
                    unitsMe = "kilogram";
                    Console.WriteLine("Unit of Measurement - kilogram");
                    break;
                case "L":
                    unitsMe = "litres";
                    Console.WriteLine("Unit of Measurement - litres");
                    break;
                case "M":
                    unitsMe = "millilitres";
                    Console.WriteLine("Unit of Measurement - millilitres");
                    break;
                default:
                    //default option will be cup when user enters no choice
                    unitsMe = "cup";
                    Console.WriteLine("Unit of Measurement - Cup");
                    break;
            }

            //ask user to enter the number of calories and store it as cals
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("Enter the number of calories of the ingredient: ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            double cals = Convert.ToDouble(Console.ReadLine());

            //create new object which is Ingredients which is assigned to ingredients[i] (this will help with positioning of the array)
            //variables are set to stored values of user input to be in the array of ingredients
            ingredients[i] = new Ingredients
            {
                name = nameIng,
                quantity = quantityIng,
                unitsOfMeasurements = unitsMe,
                calories = cals,
            };

            //clear console screen
            Console.Clear();
        }

        //ask user to enter the number of steps needed for the recipe and stored as numSteps
        Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
        Console.WriteLine("Enter the number of steps required for this recipe: ");
        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
        numSteps = Convert.ToInt32(Console.ReadLine());

        //allows user to input a string of description of each step with the use of the string array which is set by the num of step entered by the user
        //ach step iterates to the next step
        //string[] steps = new string[numSteps];
        //fix steps array because it is also declared as a local varaible, now it can be accessed by the private static void method
        steps = new string[numSteps];
        for (int i = 0; i < numSteps; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
            Console.WriteLine("Step " + (i + 1) + " : ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            steps[i] = Console.ReadLine();
        }

        //clear console screen
        Console.Clear();

        //create a new array to store original data entered by user
        //new array of original ingredients is set to equally assign to the array of ingredients stored by the user's input (user data stored as original values to refer back to reset reipe to original values)
        //double[] orgQuantities = new double[numIng];
        //fix orgQuantities array that is also a local variable to now make the method access the original quanitites stored
        orgQuantities = new double[numIng];
        for (int i = 0; i < numIng; i++)
        {
            orgQuantities[i] = ingredients[i].quantity;
        }
        Menu();
    }

    private static void Menu()
    {
        //men is set to boolean value to ensure running menu
        //true = yes it will and false = stop running
        bool continueMenu = true;

        //while loop to ensure menu will loop while it is true until false it will stop looping
        while (continueMenu)
        {
            //display menu options to user
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            Console.WriteLine("Choose a menu option (in the brackets) that you want to perform on the recipe ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;        //change text color to dark cyan
            Console.WriteLine("(A) Add new recipe");
            Console.WriteLine("(D) Display full recipe");
            Console.WriteLine("(S) Scale recipe");
            Console.WriteLine("(R) Reset recipe");
            Console.WriteLine("(C) Clear data to enter a new recipe");
            Console.WriteLine("(E) Exit");

            //capture user input which is a string value
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            string menu = Console.ReadLine();

            //clear console screen
            Console.Clear();

            //switch case menu to perform each option chosen
            switch (menu)
            {
                case "N":
                    //add new recipe
                    break;
                case "D":
                    Display();
                    break;
                case "S":
                    Scale();
                    break;
                case "R":
                    Reset();
                    break;
                case "C":
                    Clear();
                    break;
                case "E":
                    //exit main menu
                    continueMenu = false;
                    break;
                default:
                    //output message to user for inputting a wrong option
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
                    Console.WriteLine("Invalid option entered, try again");
                    break;
            }
        }
    }


        private static void Display()
        {
            //display recipe
            Console.ForegroundColor = ConsoleColor.DarkCyan;        //change text color to dark cyan
            Console.WriteLine("******** Recipe details ********");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("---- Ingredients: ----");
            //foreach loop to iterate over each ingredient in the array and display the values (properties of the ingredient object created) in the way of the Console.WriteLine
            foreach (var ingredient in ingredients)
            {
                Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                Console.WriteLine(ingredient.name + " -> " + ingredient.quantity + " " + ingredient.unitsOfMeasurements);
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
            Console.WriteLine("---- Steps: ----");
            //for loop to iterate through each step and display each step that the user entered
            for (int i = 0; i < numSteps; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                Console.WriteLine("Step " + (i + 1) + ": " + steps[i]);
            }

            //clear console screen n/a
            //Console.Clear();
        }

        private static void Scale()
        {
            //incorporate menu system for user to choose  scaling factor
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            Console.WriteLine("Choose a scaling factor (enter the following scaling words in the brackets)");
            Console.ForegroundColor = ConsoleColor.DarkCyan;        //change text color to dark cyan
            Console.WriteLine("(Half) = 0.5");
            Console.WriteLine("(Double) = 2");
            Console.WriteLine("(Triple) = 3");
            Console.WriteLine("(B) Go back");

            //capture user input which is a string value
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            string scalingFactor = Console.ReadLine();

            ////switch case menu to perform each option chosen
            switch (scalingFactor)
            {
                case "Half":
                    //multiply the quantity of the ingredient by 0.5 which is half
                    //foreach loop because for each ingredient the operation must be done
                    foreach (var ingredient in ingredients)
                    {
                        ingredient.quantity = ingredient.quantity * 0.5;
                    }
                    //display new scaled values of recipe ingredients to ease oprations so that user doesn't have to enter D again to display full recipe, but user can choose D again to display full recipe
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
                    Console.WriteLine("---- Scaled recipe ----");
                    foreach (var ingredient in ingredients)
                    {
                        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                        Console.WriteLine(ingredient.name + " -> " + ingredient.quantity + " " + ingredient.unitsOfMeasurements);
                    }
                    break;
                case "Double":
                    //multiply the quantity of the ingredient by 2 which is double
                    //foreach loop because for each ingredient the operation must be done
                    foreach (var ingredient in ingredients)
                    {
                        ingredient.quantity = ingredient.quantity * 2;
                    }
                    //display new scaled values of recipe ingredients to ease oprations so that user doesn't have to enter D again to display full recipe, but user can choose D again to display full recipe
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
                    Console.WriteLine("---- Scaled recipe ----");
                    foreach (var ingredient in ingredients)
                    {
                        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                        Console.WriteLine(ingredient.name + " -> " + ingredient.quantity + " " + ingredient.unitsOfMeasurements);
                    }
                    break;
                case "Triple":
                    //multiply the quantity of the ingredient by 3 which is triple
                    //foreach loop because for each ingredient the operation must be done
                    foreach (var ingredient in ingredients)
                    {
                        ingredient.quantity = ingredient.quantity * 3;
                    }
                    ////display new scaled values of recipe ingredients to ease oprations so that user doesn't have to enter D again to display full recipe, but user can choose D again to display full recipe
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
                    Console.WriteLine("---- Scaled recipe ----");
                    foreach (var ingredient in ingredients)
                    {
                        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                        Console.WriteLine(ingredient.name + " -> " + ingredient.quantity + " " + ingredient.unitsOfMeasurements);
                    }

                    //clear console screen n/a
                    //Console.Clear();
                    break;
                case "B":
                //go back to main menu
                Menu();
                    break;
                default:
                    //output message to user for inputting a wrong option
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
                    Console.WriteLine("Invalid option entered, try again");
                    break;
            }
        }

        private static void Reset()
        {
            //reset recipe
            //for loop because for each ingredient's quantity changed by the scaling factor, it has to be reset to the original quantity values entered by the user that has been stored in the orgQuantities 
            for (int i = 0; i < numIng; i++)
            {
                ingredients[i].quantity = orgQuantities[i];
            }
            //confirm the user that recipe has been reset
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("___ Recipe has been reset to original values ___");

            //clear console screen n/a
            //Console.Clear();
        }

        private static void Clear()
        {
            //clear data
            //for loop because for each ingredient in the array, the quantity must be cleared therefore equal to 0
            for (int i = 0; i < numIng; i++)
            {
                ingredients[i].name = "";
                ingredients[i].quantity = 0;
                ingredients[i].unitsOfMeasurements = "";
                Console.WriteLine("Ingredients: " + ingredients[i].name + ingredients[i].quantity + ingredients[i].unitsOfMeasurements);

            }
            //for loop because for each step in the array, the description of the step must be cleared therefore "" creating empty values
            for (int i = 0; i < numSteps; i++)
            {
                steps[i] = "";
                Console.WriteLine("Steps: " + steps[i]);
            }
            //confirm the user hat data has been cleared and can now enter a new recipe's details
            Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
            Console.WriteLine("___ Data has been cleared. Enter new recipe details ___");

            //clear console screen n/a
            //Console.Clear();

            //call method so that user can begin again to follow the steps again to enter a new recpe
            RecipeDetails();
        }

    }
