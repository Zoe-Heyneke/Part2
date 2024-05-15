using Part2;

namespace TestCalories
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethodTotalCalories()
        {
            //assign values of ingredient's calories
            Recipes calorie_test = new Recipes();
            calorie_test.Ingredients = new List<Ingredients>
            {
                new Ingredients 
                { name = "Pasta", quantity = 100, calories = 131},
                new Ingredients 
                { name = "Cheese", quantity = 100, calories = 402},
            };

            //act
            double expectedTotal = 131 + 402;       //value to be expected
            double actualTotal = calorie_test.Calculations();       //actual return value of the method

            //assert
            Assert.AreEqual(expectedTotal, actualTotal);    //method to compare doubles (test passes when equal)

            double calorieWarning = 300;
            if(actualTotal > calorieWarning)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning! Total calories exceeds 300!" + "\n" + "** All your ingredient's calories together are more than 300 calories **" + "\n");
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}