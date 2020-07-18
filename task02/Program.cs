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
 * а) Сделать меню с различными функциями и представить пользователю выбор, 
 * для какой функции 
 * и на каком отрезке находить минимум. 
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
        public static double F1(double x)
        {
            return (x * x) - (50 * x) + 10;
        }
        public static double F2(double x)
        {
            return x * x;
        }
        public static double F3(double x)
        {
            return x * x * x;
        }

        public static void Save(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            double x = a;
            while (x <= b)
            {
                bw.Write(F1(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static void SaveFunc(string fileName, Fun DF, double a, double b, double h)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void LoadOut(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            min = double.MaxValue;
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
        }


        public static double Load(string fileName)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        static void Main(string[] args)
        {
            const string fileName = @"data.bin";
            byte numFun = 0;

            Fun[] funs = new Fun[3];
            for (int i = 0; i < funs.Length; i++)
            {
                if (i == 0)
                {
                    funs[i] = F1;
                }
                else if (i == 1)
                {
                    funs[i] = F2;
                }
                else if (i == 2)
                {
                    funs[i] = F3;
                }
            }
            Console.WriteLine("Привет! Это тупая программа. Выбери число от 1 до 3, в соответствии будет вызвана функция F1, F2 или F3");
            Console.WriteLine($"1) F1 = (x * x) - (50 * x) + 10;");
            Console.WriteLine($"2) F2 = (x * x);");
            Console.WriteLine($"3) F3 = (x * x * x);");

            numFun = byte.Parse(Console.ReadLine());

            SaveFunc(fileName, funs[numFun - 1], -100, 100, 0.5);

            double min;
            //Console.WriteLine(Load(fileName));

            LoadOut(fileName, out min);
            Console.WriteLine(min);

            Pause();
        }

    }
}
