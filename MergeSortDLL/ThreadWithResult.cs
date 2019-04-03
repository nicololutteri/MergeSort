using System;
using System.Threading;

namespace MergeSortDLL
{
    public class ThreadWithResult<T>
    {
        readonly Thread work;
        T result;

        public ThreadWithResult(Func<T> func)
        {
            work = new Thread(() => result = func());
        }

        public void Start()
        {
            work.Start();
        }

        public T Wait()
        {
            work.Join();
            return result;
        }

        public void Stop()
        {
            work.Abort();
        }
    }
}
