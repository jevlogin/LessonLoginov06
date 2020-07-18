using System;
using static MyLib.PauseClass;

namespace les13
{
    class Program
    {
        static int Compare(int a, int b)
        {
            if (a % 10 > b % 10)
            {
                return 1;
            }
            if (a % 10 < b % 10)
            {
                return -1;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            int[] a = new int[20];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }
            Array.Sort(a, Compare);
            foreach (var e in a)
            {
                Console.WriteLine($"{e,4}");
            }

            Pause();
        }
    }
}
