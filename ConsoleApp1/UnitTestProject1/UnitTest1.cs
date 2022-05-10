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
        public void CheckingSpeedWhenDiveSearchSheet()
        {
            List<int> mas = new List<int>();
            int numInt = 2;
            for (int i = 0; i < 4; i++)
            {
                mas.Add(i);
            }

            bool rez = false;
            bool CheckYes = false;
            
            foreach (var item in mas)
            {
                if (item == numInt)
                {
                    CheckYes = true;
                    break;
                }                
            }
            mas.Remove(numInt);
            bool CheckNot = false;
            foreach (var item in mas)
            {
                if (item == numInt)
                {
                    CheckNot = true;
                    break;
                }
            }

            if (CheckYes && !CheckNot)
            {
                rez = true;
            }
            Assert.AreEqual(true, rez);
        }
        [TestMethod]
        public void CheckingSpeedWhenDiveSearchRB()
        {
            RB tree = new RB();

            for (int i = 0; i < 4; i++)
            {
                tree.Insert(i + 1);
            }

            bool rez = false;
            var CheckYes = tree.CheckingElement(2);
            tree.Delete(2);
            var CheckNot = tree.CheckingElement(2);
            if (CheckYes && !CheckNot)
            {
                rez = true;
            }
            Assert.AreEqual(true, rez);
        }

        [TestMethod]
        public void CheckingSpeedWhenDiveSearchSheetBid()
        {
            List<int> mas = new List<int>();
            int numInt = 999990;
            for (int i = 0; i < 1000000; i++)
            {
                mas.Add(i);
            }

            bool rez = false;
            bool CheckYes = false;

            foreach (var item in mas)
            {
                if (item == numInt)
                {
                    CheckYes = true;
                    break;
                }
            }
            mas.Remove(numInt);
            bool CheckNot = false;
            foreach (var item in mas)
            {
                if (item == numInt)
                {
                    CheckNot = true;
                    break;
                }
            }

            if (CheckYes && !CheckNot)
            {
                rez = true;
            }
            Assert.AreEqual(true, rez);
        }
        [TestMethod]
        public void CheckingSpeedWhenDiveSearchRB_Big()
        {
            RB tree = new RB();
            int numInt = 999990;
            for (int i = 0; i < 1000000; i++)
            {
                tree.Insert(i + 1);
            }

            bool rez = false;
            var CheckYes = tree.CheckingElement(numInt);
            tree.Delete(numInt);
            var CheckNot = tree.CheckingElement(numInt);
            if (CheckYes && !CheckNot)
            {
                rez = true;
            }
            Assert.AreEqual(true, rez);
        }

    }
}
