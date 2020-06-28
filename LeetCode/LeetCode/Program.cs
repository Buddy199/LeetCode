using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var a  = new A();
            var ty = a.GetType();
            var b = (int) ty.GetField("B").GetValue(a);
            var c = (string) ty.GetField("C").GetValue(a);
            var d = ty.GetField("D")?.GetValue(a);
            Console.WriteLine(a);
        }
    }

    class A
    {
        public int B;
        public string C;
    }
}