using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask4
{
    public class SimpsonAlgorithm : IIntegrate
    {
        public string AlgorithmUsed => "Simpson Algorithm";

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
            var sigma1 = 0d;
            var sigma2 = 0d;
            for(int i = 0; i <accuracy; i++)
            {
                var ix = lowerBound + (i * kef);
                if(i <= accuracy - 1)
                {
                    sigma1 += myfunc(ix);
                }
                var ix4s = lowerBound + (i - 1) * kef;
                sigma2 += myfunc((ix + ix4s) / 2);
            }
            var final = (kef / 3d) * (1d / 2d * myfunc(lowerBound) + sigma1 + 2 * sigma2 + 1d / 2d * myfunc(upperBound));
            if (bounds) { final = -final; }
            return final;
        }
    }
}
