using System;

namespace MergeSort2
{
    class MainConsole
    {
        private const int Max = 1000;
        private const string ConsoleTitle = "MergeSort2";

        static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.Title = ConsoleTitle;

            for (int j = 0; j < Max; j++)
            {
                MergeSort.MainConsole.MainFunc();
            }

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}