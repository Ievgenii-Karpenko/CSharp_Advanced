using ClassLibrary3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BasicRooterTest()
        {
            // Create an instance to test:
            Rooter rooter = new Rooter();
            // Define a test input and output value:
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            // Run the method under test:
            double actualResult = rooter.SquareRoot(input);
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        #region Extend input values
        [TestMethod]
        public void RooterValueRange()
        {
            // Create an instance to test.
            Rooter rooter = new Rooter();

            // Try a range of values.
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }
        #endregion

        #region Edge cases
        [TestMethod]
        public void RooterTestNegativeInputx()
        {
            Rooter rooter = new Rooter();
            try
            {
                rooter.SquareRoot(-10);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
        #endregion
    }

    #region Sqrt 
    //public double SquareRoot(double input)
    //{
    //    double result = input;
    //    double previousResult = -input;
    //    while (Math.Abs(previousResult - result) > result / 1000)
    //    {
    //        previousResult = result;
    //        result = result - (result * result - input) / (2 * result);
    //        //  result = (result + input / result) / 2; // next step
    //    }
    //    return result;
    //}
    #endregion
}
