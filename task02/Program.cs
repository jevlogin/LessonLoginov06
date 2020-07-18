using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyLib.PauseClass;


/**
 * 
 * Логинов Е.
 * 
 * 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
 * а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. 
 * Использовать массив (или список) делегатов, в котором хранятся различные функции.
 * б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
 * Пусть она возвращает минимум через параметр (с использованием модификатора out). 
 * 
 * */


namespace task02
{
    public delegate double Fun(double x);
    class Program
    {
        public static double F(double x)
        {
            return (x * x) - (50 * x) + 10;
        }

        public static void SaveFunc(string fileName, Fun DF, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(DF(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            double min = double.MaxValue;
            double d;

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = br.ReadDouble();
                if (d < min)
                {
                    min = d;
                }
            }
            br.Close();
            fs.Close();

            return min;
        }
        static void Main(string[] args)
        {
            const string fileName = @"data.bin";

            SaveFunc(fileName, F, -100, 100, 0.5);
            System.Console.WriteLine(Load(fileName));

            Pause();
        }
    }
}
