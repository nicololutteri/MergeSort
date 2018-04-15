using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort2
{
    class MainConsole
    {
        static void Main(string[] args)
        {
            for (int j = 0; j < 1000; j++)
            {
                MergeSort.MainConsole.MainFunc();
            }

            Console.ReadKey();
        }
    }
}