using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTask2
{
    public static class IEnumExtensions
    {
        private static bool MyEqualityCheck<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            //Используем динамическую коллекцию,хранящую только уникальные элементы
            //Вида HashSet<T>(IEqualityComparer<T>) - использующий функцию сравнения для типа набораю
            comparer = EqualityComparer<T>.Default;
            var USet = new HashSet<T>(comparer);

            foreach(var item in collection)
            {
                if (USet.Contains(item))
                {
                    throw new ArgumentException(nameof(collection), "sry,u have identical items in your collection");
                }
                else
                {
                    USet.Add(item);
                }
            }
            return true;
        }

        private static void CombinationAlgorithm<T>(List<T> items, int k, int first, List<T> instant, List<List<T>> final)
        {
            if (k == instant.Count)
            {
                final.Add(instant.ToList());
                return;
            }

            int capacity = items.Count;

            for (int i = first; i < capacity; i++)
            {
                instant.Add(items[i]);
                CombinationAlgorithm(items, k, i, instant, final);
                instant.RemoveAt(instant.Count - 1);
            }
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer, int k)                                                           
        {
            if(collection == null) { throw new ArgumentNullException(nameof(collection)); }
            if(comparer == null) { throw new ArgumentNullException(nameof(comparer)); }
            if(k < 0) { throw new ArgumentOutOfRangeException(nameof(k),"k<allowed"); }

            collection.MyEqualityCheck(comparer);
            var items = collection.ToList();
            if(k > items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(k),"k>allowed");
            }

            var instant = new List<T>();
            var final = new List<List<T>>();

            CombinationAlgorithm(items, k, 0, instant, final);
            return final;
        }

        public static IEnumerable<IEnumerable<T>> Subsets<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (collection == null) { throw new ArgumentNullException(nameof(collection)); }
            if (comparer == null) { throw new ArgumentNullException(nameof(comparer)); }
            collection.MyEqualityCheck(comparer);

            var items = collection.ToList();
            var final = new List<List<T>>();
            int capacity  = items.Count;
            for(int mask = 0;mask < (1 << capacity); mask++)
            {
                final.Add(new List<T>());
                for(int j = 0; j < capacity; j++)
                {
                    if((mask & (1 << j)) != 0)
                    {
                        final.Last().Add(items[j]);
                    }
                }
            }
            return final;
        }

        private static void PermutationsAlgorithm<T>(List<T> buf, List<T> instant, List<List<T>> final)
        {
            int capacity = buf.Count;
            if(capacity == 0)
            {
                final.Add(instant);
                return;
            }
            for(int i = 0; i < buf.Count; i++)
            {
                var temp = new List<T>(buf);
                temp.RemoveAt(i);
                var next = new List<T>(instant) { buf[i] };
                PermutationsAlgorithm(temp, next, final);
            }
        }
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> collection,IEqualityComparer<T> comparer)
        {
            if (collection == null) { throw new ArgumentNullException(nameof(collection)); }
            if (comparer == null) { throw new ArgumentNullException(nameof(comparer)); }
            collection.MyEqualityCheck(comparer);

            var items = collection.ToList();
            var final = new List<List<T>>();
            PermutationsAlgorithm(items, new List<T>(), final);
            return final;
        }

        




    }

}
 