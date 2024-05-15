using System;
using System.Collections.Generic;   //namespace contains interfaces and classes that define generic collections
using System.Linq;  //to allow using method OrderBy();
using System.ComponentModel.DataAnnotations;
using static ProgramPart1;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Part2;

internal class ProgramPart1
{
    //declare and initialize variables used in program


    //declare and initialize variables used in recipes details list namespace


    //declaring and initializing variables as private static to make them accessuble by new private static void methods
    //private static Ingredients[] ingredients;
    private static List<Ingredients> ingredients;
    private static int numIng;
    //private static string[] steps;
    private static List<string> recSteps;
    private static int numSteps;
    private static double[] orgQuantities;
    private static string recName;
    private static List<Recipes> recipeDetails = new List<Recipes>();
    delegate void CalorieWarning(double number);


    //in the main method is RecipeDetails() which ensures that all operations inside RecipeDetails() will run 
    private static void Main(string[] args)
    {
        //improvement1
        //Welcome user to the app
        Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
        Console.WriteLine("***** Welcome to the Recipe Application *****");
        Console.WriteLine("Please enter the following details for any recipe");
        //RecipeDetails();
        Menu();
    }

    //expanding method RecipeDetails() by inputting operations
    public static void RecipeDetails()
    {
        Recipes newRec = new Recipes();     //create object

        //ask user to enter the name of recipe
        Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
        Console.WriteLine("Enter the name of the recipe: ");
        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
        string recName = Console.ReadLine();
        newRec.recName = recName;

        //move list at top to add ingredients to list
        ingredients = new List<Ingredients>();
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

        //(1)create array for ingredients setting the size to numIng which is the number chosen by the user
        //Ingredients[] ingredients = new Ingredients[numIng];

        //(2)fix array of ingredients that was a local declaration so that it can be accessed by the private staic void methods
        //ingredients = new Ingredients[numIng];

        //(3)generic collection: list
        //change array to generic list (creating a list and ingredients are now stored as a list)
        //ingredients = new List<Ingredients>();

        //for loop because for each number of ingredient chosen by user it must ask the name, quantity, and units of measurement, calories, food group
        for (int i = 0; i < numIng; i++)
        {
            //create object of ingredients
            Ingredients ingredient = new Ingredients();
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
            Console.WriteLine("(O) Other");

            //users input is saved as a string as the variable unitsMe
            string unitsMe = Console.ReadLine();

            //switch case
            switch (unitsMe)     //assign each option to variable of unitsMe so that it will display in the recipe   
            {
                case "C":
                    unitsMe = "cup";
                    Console.WriteLine("Unit of Measurement - cup"); //confirm with user their option
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
                case "O":
                    unitsMe = "other";
                    Console.WriteLine("Unit of Measurement - other");
                    break;
                default:
                    unitsMe = "other";
                    Console.WriteLine("Unit of Measurement - other");   //default option will be other since we don't know what the user entered
                    break;
            }

            //clear console screen
            Console.Clear();

            //calories
            Console.ForegroundColor = ConsoleColor.DarkYellow;       //change text color to white
            Console.WriteLine("*** Calories ***" + "\n" + "A calorie is a unit that measures the energy content of foods." + "\n" + "Calories and Quantities have a direct relationship (linear) : When the quantity increases the calories also increase and when the quantity decreases then the calories also decrease." + "\n");

            //ask user to enter the number of calories and store it as cals
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("Enter the number of calories of the ingredient: ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            double cals = Convert.ToDouble(Console.ReadLine());

            //clear console screen
            Console.Clear();

            //allow user to choose the food group of the ingredient by using menu system
            //ask user to choose the food group and store it as fg
            Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
            Console.WriteLine("Choose the food group of the ingredient by choosing one of the letters in brackets: ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            Console.WriteLine("(C) *** Carbohydrates *** \n Starchy foods -> Pap,Potatoes,Pasta,Bread,Rice \n");
            Console.WriteLine("(V) *** Vegetables and Fruits *** \n Healthy foods  -> Carrots,Spinach,Broccoli and Apple,Orange,Pear,Mango \n");
            Console.WriteLine("(P) *** Protein *** \n Building blocks -> Chicken,Mince,Eggs,Beans,Peas,Lentils \n");
            Console.WriteLine("(F) *** Fats and Oils *** \n -> Avocado,Olive Oil,Butter,Nuts and Seeds \n");
            Console.WriteLine("(D) *** Dairy *** \n Milk Products -> Milk,Yoghurt,Cottage cheese \n");
            Console.WriteLine("(W) *** Water *** \n Fluids -> Water,Sugar Free Drinks like Tea or Coffee \n");
            Console.WriteLine("(O) *** Other *** \n Non-healthy -> Soft Drinks,Chips,Cookies,Candy \n");

            //users input is saved as a int and converted as the variable fg
            string fg = Console.ReadLine();

            //switch case
            //assign each option to variable of fg so that it will display in the recipe
            //confirm with user their option
            switch (fg)
            {
                case "C":
                    fg = "Carbohydrates";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Carbohydrates \n Source of fibre");
                    break;
                case "V":
                    fg = "Vegetables and Fruits";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Vegetables and Fruits \n Source of vitamins and minerals");
                    break;
                case "P":
                    fg = "Protein";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Protein \n Source of amino acids");
                    break;
                case "F":
                    fg = "Fats and Oils";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Fats and Oils \n Source of fatty acids");
                    break;
                case "D":
                    fg = "Dairy";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Dairy \n Source of calcium, protein and vitamins");
                    break;
                case "W":
                    fg = "Water";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Water \n Source of hydration");
                    break;
                case "O":
                    fg = "Other";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Other \n Unhealthy foods");
                    break;
                default:
                    fg = "Other";
                    //default option is other due to unknown value entered by user
                    Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
                    Console.WriteLine("Food Group - Other");
                    break;
            }

            //(1)create new object which is Ingredients which is assigned to ingredients[i] (this will help with positioning of the array)
            //variables are set to stored values of user input to be in the array of ingredients
            //ingredients[i] = new Ingredients

            //generic collection in place of array (to add to the list of ingredients)
            Ingredients moreIngredients = new Ingredients
            {
                name = nameIng,
                quantity = quantityIng,
                unitsOfMeasurements = unitsMe,
                calories = cals,
                foodGroup = fg,
            };

            //add method to add each ingredient entered by the user to generic list
            ingredients.Add(moreIngredients);

            //add method to add ingredients to recipe details list
            //retreive from object
            newRec.Ingredients.Add(moreIngredients);

            //clear console screen
            Console.Clear();
        }

        //move list for steps at top to save as whole list
        recSteps = new List<string>();

        //ask user to enter the number of steps needed for the recipe and stored as numSteps
        Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
        Console.WriteLine("Enter the number of steps required for this recipe: ");
        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
        numSteps = Convert.ToInt32(Console.ReadLine());

        //(1)allows user to input a string of description of each step with the use of the string array which is set by the num of step entered by the user
        //ach step iterates to the next step
        //string[] steps = new string[numSteps];

        //(2)fix steps array because it is also declared as a local varaible, now it can be accessed by the private static void method
        //steps = new string[numSteps];

        //(3)generic collection: list
        //change array to generic list (creating a list and steps are now stored as a list)
        //steps = new List<string>();
        for (int i = 0; i < numSteps; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;       //change text color to dark cyan
            Console.WriteLine("Step " + (i + 1) + " : ");
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            //steps[i] = Console.ReadLine();

            //generic collection in place of array (to add to the list of ingredients)
            //retreive from object
            recSteps.Add(Console.ReadLine());
            //add method to add each step entered by user to generic list
            //steps.Add(moreSteps);
        }

        //add recipe details to list of recipes
        newRec.recSteps = recSteps;
        recipeDetails.Add(newRec);
        recipeDetails = recipeDetails.OrderBy(x => x.recName).ToList(); // Used to order recipes alphabetically

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
            Console.WriteLine("(D) Display all recipes");
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
                case "A":
                    //add new recipe
                    RecipeDetails();
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

    //public delegate void CalorieWarning(double totalCalories);
    private static void Display()
    {
        //linq    
        //using order by method to sort the names alphabetically
        //string myString = alphaNames;
        //int myInt = Int32.Parse(myString);

        //display recipe names in alphabetical order
        Console.ForegroundColor = ConsoleColor.DarkCyan;        //change text color to dark cyan
        Console.WriteLine("*** All Recipes ***");
        //int count = 0;  
        for (int i = 0; i < recipeDetails.Count; i++)
        {
            Console.WriteLine($"({i + 1}): {recipeDetails[i].recName}");
        }

        //ask user to choose which recipe to display by entering it's full name
        Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
        Console.WriteLine("Choose a number of the Recipe Name in order to display the full Recipe: ");
        Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                                                            //int enteredNum = Convert.ToInt32(Console.ReadLine());
        string enteredNum = Console.ReadLine();
        int num = Convert.ToInt32(enteredNum);

        Recipes activeRecipe = recipeDetails[num - 1];


        Console.WriteLine("\n" + "Recipe Name: " + activeRecipe.recName);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;     //change text color to purple
        Console.WriteLine("---- Ingredients: ----");
        //foreach loop to iterate over each ingredient in the array and display the values (properties of the ingredient object created) in the way of the Console.WriteLine
        foreach (var ingredient in activeRecipe.Ingredients)
        {
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            Console.WriteLine("Name: " + ingredient.name + "\n" + "Quantity: " + ingredient.quantity + "\n" + "Units of Measurements: " + ingredient.unitsOfMeasurements + "\n" + "Calories: " + ingredient.calories + "\n" + "Food Group: " + ingredient.foodGroup + "\n");
        }


        //calculate calories
        Console.ForegroundColor = ConsoleColor.DarkYellow;       //change text color to yellow
        Console.WriteLine("---- Calories: ----");
        Console.ResetColor();
        double total_calories = 0;
        foreach (var ingredient in activeRecipe.Ingredients)
        {
            total_calories += ingredient.calories;
        }

        Console.WriteLine($"Total Calories = {total_calories}" + "\n");
        CalorieWarning warning = total_calories =>
        {
            if (total_calories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning! Total calories exceeds 300!" + "\n" + "** All your ingredient's calories together are more than 300 calories **" + "\n");
                Console.ResetColor();
            }
        };
        warning(total_calories);

        Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
        Console.WriteLine("---- Steps: ----");
        //for loop to iterate through each step and display each step that the user entered
        for (int i = 0; i < activeRecipe.recSteps.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;       //change text color to white
            Console.WriteLine("Step " + (i + 1) + ": " + activeRecipe.recSteps[i]);
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
                    ingredient.calories = ingredient.calories * 0.5;
                }
                //display new scaled values of recipe ingredients to ease oprations so that user doesn't have to enter D again to display full recipe, but user can choose D again to display full recipe
                Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
                Console.WriteLine("---- Scaled recipe ----");
                foreach (var ingredient in ingredients)
                {
                    Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                    Console.WriteLine(ingredient.name + " -> " + ingredient.quantity + " " + ingredient.unitsOfMeasurements);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;       //change text color to yellow
                    Console.WriteLine("Calories -> " + ingredient.calories + "\n");
                }
                break;
            case "Double":
                //multiply the quantity of the ingredient by 2 which is double
                //foreach loop because for each ingredient the operation must be done
                foreach (var ingredient in ingredients)
                {
                    ingredient.quantity = ingredient.quantity * 2;
                    ingredient.calories = ingredient.calories * 2;
                }
                //display new scaled values of recipe ingredients to ease oprations so that user doesn't have to enter D again to display full recipe, but user can choose D again to display full recipe
                Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
                Console.WriteLine("---- Scaled recipe ----");
                foreach (var ingredient in ingredients)
                {
                    Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                    Console.WriteLine(ingredient.name + " -> " + ingredient.quantity + " " + ingredient.unitsOfMeasurements);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;       //change text color to yellow
                    Console.WriteLine("Calories -> " + ingredient.calories + "\n");
                }
                break;
            case "Triple":
                //multiply the quantity of the ingredient by 3 which is triple
                //foreach loop because for each ingredient the operation must be done
                foreach (var ingredient in ingredients)
                {
                    ingredient.quantity = ingredient.quantity * 3;
                    ingredient.calories = ingredient.calories * 3;
                }
                ////display new scaled values of recipe ingredients to ease oprations so that user doesn't have to enter D again to display full recipe, but user can choose D again to display full recipe
                Console.ForegroundColor = ConsoleColor.DarkMagenta;       //change text color to purple
                Console.WriteLine("---- Scaled recipe ----");
                foreach (var ingredient in ingredients)
                {
                    Console.ForegroundColor = ConsoleColor.White;       //change text color to white
                    Console.WriteLine(ingredient.name + " -> " + ingredient.quantity + " " + ingredient.unitsOfMeasurements);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;       //change text color to yellow
                    Console.WriteLine("Calories -> " + ingredient.calories + "\n");
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
            recSteps[i] = "";
            Console.WriteLine("Steps: " + recSteps[i]);
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