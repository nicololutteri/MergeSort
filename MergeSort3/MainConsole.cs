using MergeSortDLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MergeSort3
{
    class MainConsole
    {
        private const int Dim = 1000000;
        private const int Deep = 3;
        private const string ConsoleTitle = "MergeSort3";

        static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.Title = ConsoleTitle;

            Stopwatch s = new Stopwatch();
            List<MergeSort<long>> l = new List<MergeSort<long>>();

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                long[] array = Utilities.GenerateNumbers(Dim);
                MergeSort<long> tmp = new MergeSort<long>(Deep, array);
                l.Add(tmp);
            }

            s.Start();
            Parallel.ForEach<MergeSort<long>>(l, (MergeSort<long> i) => i.Start());
            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds.ToString() + " ms");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
