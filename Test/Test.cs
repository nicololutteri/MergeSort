using System;
using System.Threading.Tasks;
using MergeSortDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Test
    {
        private const int Max = 999999;
        readonly long[] a = new long[] { 2, 4, 10, 1 };
        readonly long[] f1 = new long[] { 1, 2, 4, 10 };

        [TestMethod]
        public void Test1()
        {
            MergeSort<long> c = new MergeSort<long>(0, a);
            c.Start();

            Assert.IsTrue(a[0] == f1[0]);
            Assert.IsTrue(a[1] == f1[1]);
            Assert.IsTrue(a[2] == f1[2]);
            Assert.IsTrue(a[3] == f1[3]);
        }

        [TestMethod]
        public void Test2()
        {
            MergeSort<long> c = new MergeSort<long>(3, a);
            c.Start();

            Assert.IsTrue(a[0] == f1[0]);
            Assert.IsTrue(a[1] == f1[1]);
            Assert.IsTrue(a[2] == f1[2]);
            Assert.IsTrue(a[3] == f1[3]);
        }

        [TestMethod]
        public void Test3()
        {
            long[] a = new long[] { 2, 4, 10, 1, 5, 6, 3, 2 };
            long[] f1 = new long[] { 1, 2, 2, 3, 4, 5, 6, 10 };

            MergeSort<long> c = new MergeSort<long>(3, a);
            c.Start();

            Assert.IsTrue(a[0] == f1[0]);
            Assert.IsTrue(a[1] == f1[1]);
            Assert.IsTrue(a[2] == f1[2]);
            Assert.IsTrue(a[3] == f1[3]);
            Assert.IsTrue(a[4] == f1[4]);
            Assert.IsTrue(a[5] == f1[5]);
            Assert.IsTrue(a[6] == f1[6]);
            Assert.IsTrue(a[7] == f1[7]);
        }

        [TestMethod]
        public void Test4()
        {
            int[] array = new int[Max];

            Random r = new Random();
            Parallel.For(0, array.Length, (i) => array[i] = r.Next());

            MergeSort<int> c = new MergeSort<int>(3, array);
            int[] tmp = c.Start();

            Assert.IsTrue(Utilities.CheckSort(tmp));
        }
    }
}
