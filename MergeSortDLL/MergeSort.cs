using System;

namespace MergeSortDLL
{
    public class MergeSort<T> where T : IComparable<T>
    {
        readonly int deep;
        readonly T[] numbers;

        public MergeSort(int deep, T[] numbers)
        {
            this.deep = deep;
            this.numbers = numbers ?? throw new ArgumentNullException(nameof(numbers));
        }

        private T[] MergeSortHelp(T[] array, bool useThread, int actualdeep)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                return array;
            }
            else
            {
                actualdeep += 1;

                T[] array1;
                T[] array2;

                Tuple<T[], T[]> t = Utilities.Split(array);

                if (useThread)
                {
                    bool nextUseThread = !(actualdeep >= deep);

                    ThreadWithResult<T[]> t1 = new ThreadWithResult<T[]>(() => MergeSortHelp(t.Item1,
                                                                                             nextUseThread,
                                                                                             actualdeep));
                    ThreadWithResult<T[]> t2 = new ThreadWithResult<T[]>(() => MergeSortHelp(t.Item2,
                                                                                             nextUseThread,
                                                                                             actualdeep));

                    t1.Start();
                    t2.Start();

                    array1 = t1.Wait();
                    array2 = t2.Wait();
                }
                else
                {
                    array1 = MergeSortHelp(t.Item1, false, actualdeep);
                    array2 = MergeSortHelp(t.Item2, false, actualdeep);
                }

                return RealMerge(array, array1, array2);
            }
        }

        private T[] RealMerge(T[] array, T[] array1, T[] array2)
        {
            int dimfirst = 0;
            int dimsecond = 0;
            int dimarray = 0;

            while (true)
            {
                if (dimfirst >= array1.Length)
                {
                    Array.Copy(array2, dimsecond, array, dimarray, array2.Length - dimsecond);
                    break;
                }
                else if (dimsecond >= array2.Length)
                {
                    Array.Copy(array1, dimfirst, array, dimarray, array1.Length - dimfirst);
                    break;
                }
                else
                {
                    array[dimarray] = array1[dimfirst].CompareTo(array2[dimsecond]) == -1 ?
                        array1[dimfirst++] : array[dimarray] = array2[dimsecond++];
                }

                dimarray += 1;
            }

            return array;
        }

        public T[] Start()
        {
            // TODO Continue here
            return Block();
        }

        private T[] Block()
        {
            return MergeSortHelp(numbers, !(deep == 0), 0);
        }
    }
}
