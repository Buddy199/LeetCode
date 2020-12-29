using System;
using LeetCode;

namespace NewLeetCode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                array[i] = 10000 - i;
            }

            QuickSort.QSort(array, 0, array.Length - 1);
            for (int i = 0; i < 10000; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}