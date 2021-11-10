using System;
using Generics_practice.Classes;
using Generics_practice.Interfaces;

namespace Generics_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest obj = new Test();

            Test2 obj2 = new Test3();
            Test2 obj3 = new Test2();
            Test3 obj4= new Test3();

            TestMethod(obj2);
            TestMethod(obj3);
            TestMethod(obj4);
        }

        private static void TestMethod(Test2 obj)
        {
            System.Console.WriteLine(obj);
        }
    }
}
