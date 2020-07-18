using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyLib.PauseClass;


/**
 * Логинов Е.
 * 
 * 1. Изменить программу вывода таблицы функции так, 
 * чтобы можно было передавать функции типа double (double, double). 
 * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
 * 
 * */

namespace task01
{
    public delegate double Fun(double x);
    public delegate double FunTwo(double a, double x);

    class Program
    {
        public static void Table(FunTwo F, double a, double x)
        {
            Console.WriteLine("------ X ----- Y ----");
            while (a <= x)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000 |}", a, F(a, x));
                a += 1;
            }
            Console.WriteLine("---------------------\n");
        }
        public static double MyFunc(double a, double x)
        {
            return a * Math.Pow(x, 2);
        }

        static void Main(string[] args)
        {
            //  a*x^2
            Table(MyFunc, -2, 2);

            //  a*sin(x)
            Table(MyFunc2, -2, 2);

            Pause();
        }

        private static double MyFunc2(double a, double x)
        {
            return a * Math.Sin(x);
        }
    }
}
