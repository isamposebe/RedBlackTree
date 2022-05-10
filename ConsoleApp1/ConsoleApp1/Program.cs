using System;
using ClassRB;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RB tree = new RB();



            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.DisplayTree();
            Console.ReadLine();
        }
        static void test1()
        {
            
        }
    }
    
}
