using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask4
{
    public class CentralRectangleAlgorithm : IIntegrate
    {
        public string AlgorithmUsed => "Central Rectangle Algorithm";

        public double IntegralSolution(double lowerBound, double upperBound, double accuracy, Func<double, double>? myfunc)
        {
            if (accuracy <= 0) { throw new ArgumentException(nameof(accuracy), "Your accuracy should be >= 0"); }
            if (myfunc == null) { throw new ArgumentNullException(nameof(myfunc), "Bro,where's your method?"); }

            bool bounds = false;
            if (lowerBound.CompareTo(upperBound) > 0)
            {
                bounds = true;
                (lowerBound, upperBound) = (upperBound, lowerBound);
            }

            var kef = (upperBound - lowerBound) / accuracy;
            var sigma = (myfunc(lowerBound) + myfunc(upperBound))/2;
            for (int i = 1; i < accuracy ; i++)
            {
                var x = lowerBound + (i * kef);
                sigma += myfunc(x);
            }
            var final = kef * sigma;
            if (bounds) { final = -final; }
            return final;
        }
    }
}
