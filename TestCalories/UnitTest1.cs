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
            calorie_test.Ingredients = new()
            {
                { "Pasta", 200},
                { "Cheese", 402},
            };

            double expectedTotal = 200 + 402;
            double actualTotal = calorie_test.Calculations();
            Assert.AreEqual(expectedTotoal, actualTotal);
        }
    }
}