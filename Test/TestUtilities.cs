using System;
using MergeSortDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestUtilities
    {
        [TestMethod]
        public void TestSplit1()
        {
            int[] array = new int[] { 1, 2, 3, 4};

            int[] f1 = new int[] { 1, 2 };
            int[] f2 = new int[] { 3, 4 };

            Tuple<int[], int[]> t = Utilities.Split<int>(array);

            int[] r1 = t.Item1;
            int[] r2 = t.Item2;

            Assert.IsTrue(f1.Length == r1.Length);
            Assert.IsTrue(f2.Length == r2.Length);

            Assert.IsTrue(f1[0] == r1[0]);
            Assert.IsTrue(f1[1] == r1[1]);
            Assert.IsTrue(f2[0] == r2[0]);
            Assert.IsTrue(f2[1] == r2[1]);
        }

        [TestMethod]
        public void TestSplit2()
        {
            int[] array = new int[] { 1, 2, 3 };

            int[] f1 = new int[] { 1, 2 };
            int[] f2 = new int[] { 3 };

            Tuple<int[], int[]> t = Utilities.Split<int>(array);

            int[] r1 = t.Item1;
            int[] r2 = t.Item2;

            Assert.IsTrue(f1.Length == r1.Length);
            Assert.IsTrue(f2.Length == r2.Length);

            Assert.IsTrue(f1[0] == r1[0]);
            Assert.IsTrue(f1[1] == r1[1]);
            Assert.IsTrue(f2[0] == r2[0]);
        }

        [TestMethod]
        public void TestGenerateNumbers()
        {
            long[] b = Utilities.GenerateNumbers(10);

            Assert.IsTrue(b.Length == 10);
        }
    }
}
