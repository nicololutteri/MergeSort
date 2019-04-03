using MergeSortDLL;
using System;
using System.Diagnostics;

namespace MergeSort
{
    public class MainConsole
    {
        private const int Dim = 10000000;
        private const string ConsoleTitle = "MergeSort1";

        static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.Title = ConsoleTitle;

            MainFunc();

#if DEBUG
            Console.ReadKey();
#endif
        }

        static public void MainFunc()
        {
            long[] array = Utilities.GenerateNumbers(Dim);
            long min = Int64.MaxValue;
            long number = 0;

            Stopwatch s = new Stopwatch();

            for (int i = 0; i < 8; i++)
            {
                try
                {
                    s.Reset();
                    s.Start();

                    MergeSort<long> c = new MergeSort<long>(i, array);
                    c.Start();

                    s.Stop();

                    if (min > s.ElapsedMilliseconds)
                    {
                        min = s.ElapsedMilliseconds;
                        number = i;
                    }

                    //Console.WriteLine(i.ToString() + " " + s.ElapsedMilliseconds.ToString() + " ms");
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine(i.ToString() + " " + "OutOfMemoryException");
                }
            }

            Console.WriteLine("Min: " + min.ToString() + " ms [" + number.ToString() + " (" + Math.Pow(2, number).ToString() + ")]");
        }
    }
}