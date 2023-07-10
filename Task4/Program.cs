namespace PracTask4
{
    class Program
    {
        public static double func(double x)
        {
            return x*x + 4;
        }
        public static void Main(string[] args)
        {
            var test = new IIntegrate[]
            {
                new LeftRectangleAlgorithm(),new CentralRectangleAlgorithm(), new RightRectangleAlgorithm(),new SimpsonAlgorithm(),new TrapezoidAlgorithm()
            };
            foreach(var item in test)
            {
                Console.WriteLine(item.AlgorithmUsed);
                Console.WriteLine(item.IntegralSolution(2,9,100000,new Func<double,double>(func)));
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}