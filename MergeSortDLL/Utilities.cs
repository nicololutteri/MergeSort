using System;
using System.Threading.Tasks;

namespace MergeSortDLL
{
    public class Utilities
    {
        public static Tuple<T[], T[]> Split<T>(T[] array) where T : IComparable<T>
        {
            T[] array1 = new T[(array.Length / 2) + ((array.Length % 2 == 0) ? 0 : 1)];
            T[] array2 = new T[array.Length / 2];

            Array.Copy(array, array1, array1.Length);
            Array.Copy(array, array1.Length, array2, 0, array2.Length);

            return new Tuple<T[], T[]>(array1, array2);
        }

        public static long[] GenerateNumbers(long dim)
        {
            long[] tmp = new long[dim];
            Random ran = new Random();

            Parallel.For(0, tmp.Length, (i) => tmp[i] = ran.Next(Int32.MinValue, Int32.MaxValue));

            return tmp;
        }

        public static bool CheckSort<T>(T[] tmp) where T : IComparable<T>
        {
            for (int i = 0; i + 1 < tmp.Length; i += 2)
            {
                switch (tmp[i].CompareTo(tmp[i + 1]))
                {
                    case -1:
                    case 0:
                        break;
                    case 1:
                        return false;
                }
            }

            return true;
        }
    }
}
