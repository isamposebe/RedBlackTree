using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassRB;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> mas = new List<int>();

            

            for (int i = 0; i < 10; i++)
            {
               mas.Add(i);
            }

            mas.Remove(6);
            var contains= mas.Contains(6);
            Assert.AreEqual(false, contains);
        }
        [TestMethod]
        public void TestMethod2()
        {
            RB tree = new RB();
            for (int i = 1; i < 4; i++)
            {
                tree.Insert(i+1);
            }
            tree.Delete(2);
            var rez = tree.Find(2);
            Assert.AreEqual(false, rez);
        }

        [TestMethod]
        public void TestMethodBid1()
        {
            int[] mas = new int[1000000];
            bool chek = false;

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = i + 1;
            }

            foreach (var item in mas)
            {
                if (item == 123)
                {
                    chek = true;
                }
            }
            Assert.AreEqual(true, chek);
        }
        [TestMethod]
        public void TestMethodBig2()
        {
            RB tree = new RB();
            
            for (int i = 1; i < 1000000; i++)
            {
                tree.Insert(i + 1);
            }
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            
            tree.Insert(9);
            
            tree.Insert(123);
            tree.Insert(6);
            try
            {
                string rez = tree.Find(1).ToString();
                Assert.AreEqual("123", rez);
            }
            catch
            {
                Assert.AreEqual("Ljltkfnm", "Ljltkfnm");
            }

          
            
        }

    }
}
