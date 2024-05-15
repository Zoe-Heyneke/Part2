using Part2;

namespace TestCalories
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodTotalCalories()
        {
            Recipes calorie_test = new Recipes();
            calorie_test.CalorieWarning = new()
            {
                { "Pasta", 200},
                { "Cheese", 402},
            };

            double expectedTotal = 200 + 402;
            double actualTotal = calorie_test.Calculations();
            Assert.AreEqual(expectedTotoal, actualTotal);

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