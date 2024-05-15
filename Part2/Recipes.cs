using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProgramPart1;

namespace Part2
{
    public class Recipes
    {
        public Recipes()
        {
            this.Ingredients = new List<Ingredients>();
            this.recSteps = new List<string>();
        }
        public string recName //property
        { get; set; }  //get and set method to access value of private
        public List<Ingredients> Ingredients //property
        { get; set; }   //get and set method to access value of private
        public List<string> recSteps //property
        { get; set; }   //get and set method to access value of private

        delegate void CalorieWarning(double number);

        public double Calculations()
        {
            //calculate calories
            Console.ForegroundColor = ConsoleColor.DarkYellow;       //change text color to yellow
            Console.WriteLine("---- Calories: ----");
            Console.ResetColor();
            double total_calories = 0;
            foreach (var ingredient in this.Ingredients)
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
            return total_calories;
        }
    }
}
