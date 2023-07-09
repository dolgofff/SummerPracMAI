namespace PracTask2
{

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int[] nabor = new int[] { 1, 2, 3 };
                var combinations1 = IEnumExtensions.Combinations(nabor,new MyEqualityComparer<int>(), 2 );
                foreach(var item in combinations1)
                {
                    Console.WriteLine($"[{String.Join(",",item)}]");
                }
                Console.WriteLine(Environment.NewLine);

                var subset = IEnumExtensions.Subsets(nabor,new MyEqualityComparer<int>());
                foreach(var item in subset)
                {
                    Console.WriteLine($"[{String.Join(",", item)}]");
                }
                Console.WriteLine(Environment.NewLine);

                var permutation = IEnumExtensions.Permutations(nabor,new MyEqualityComparer<int>());
                foreach( var item in permutation)
                {
                    Console.WriteLine($"[{String.Join(",", item)}]");
                }


            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }

            /*  catch(ArgumentOutOfRangeException ex)
              {
                  Console.WriteLine($"Исключение: {ex.Message}");
              }*/
        }
    }

}

