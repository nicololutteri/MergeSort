using MergeSortDLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort3
{
    class MainConsole
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            List<MergeSort<long>> l = new List<MergeSort<long>>();

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                long[] array = Utilities.GenerateNumbers(1000000);
                MergeSort<long> tmp = new MergeSort<long>(3, array);
                l.Add(tmp);
            }

            s.Start();
            Parallel.ForEach<MergeSort<long>>(l, (MergeSort<long> i) => i.Start());
            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds.ToString() + " ms");
            Console.ReadKey();
        }
    }
}
