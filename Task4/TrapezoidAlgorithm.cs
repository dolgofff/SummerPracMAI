using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask4
{
    public class TrapezoidAlgorithm : IIntegrate
    {
        public string AlgorithmUsed => "Trapezoid Algorithm";

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
            var sigma = myfunc(lowerBound) + myfunc(upperBound);
            for (int i = 1; i <= accuracy -1; i++)
            {
                sigma += 2 * myfunc(lowerBound + i * kef);
            }
            var final = sigma * kef / 2;
            if (bounds) { final = -final; }
            return final;
        }
    }
}
