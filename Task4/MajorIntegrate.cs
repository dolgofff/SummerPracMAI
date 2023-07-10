using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask4
{
    public interface IIntegrate
    {
        public double IntegralSolution(double lowerBound, double upperBound, double accuracy, Func<double, double> myfunc);

        public string AlgorithmUsed
        {
            get;
        }

    }
}
