using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MergeSortDLL
{
    public class ThreadWithResult<T>
    {
        Thread work;
        T result;

        public ThreadWithResult(Func<T> func)
        {
            work = new Thread(() =>
            {
                result = func();
            });
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
