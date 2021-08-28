using System;

namespace ClassLibrary3
{
    public class Rooter
    {
        public double SquareRoot(double input)
        {
            if (input < 0)
                throw new ArgumentOutOfRangeException();

            double result = input;
            double previousResult = -input;
            while (Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = result - (result * result - input) / (2 * result);
                //  result = (result + input / result) / 2; // next step
            }
            return result;
        }
    }
}