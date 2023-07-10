using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask4
{
    public class LeftRectangleAlgorithm : IIntegrate
    {
        public string AlgorithmUsed => "Left Rectangle Algorithm";

        public double IntegralSolution(double lowerBound, double upperBound, double accuracy, Func<double, double>? myfunc)
        {   
            if(accuracy <= 0) { throw new ArgumentException(nameof(accuracy), "Your accuracy should be >= 0"); }
            if(myfunc == null) { throw new ArgumentNullException(nameof(myfunc),"Bro,where's your method?"); }

            bool bounds = false;
            if(lowerBound.CompareTo(upperBound) > 0)
            {
                bounds = true;
                (lowerBound, upperBound) = (upperBound, lowerBound);
            }
            
            var kef = (upperBound - lowerBound) / accuracy;
            var sigma = 0d;
            for(var i = 0; i < accuracy-1; i++)
            {
                var x = lowerBound + (i* kef);
                sigma += myfunc(x);
            }
            var final = kef * sigma;
            if (bounds) { final = -final; }
            return final;
        }
    }
}
