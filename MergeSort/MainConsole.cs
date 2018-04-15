using MergeSortDLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public class MainConsole
    {
        static void Main(string[] args)
        {
            MainFunc();
            Console.ReadKey();
        }

        static public void MainFunc()
        {
            long[] array = Utilities.GenerateNumbers(10000000);
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
                    long[] f = c.Start();

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