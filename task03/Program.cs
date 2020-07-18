using System;
using System.Collections.Generic;
using System.IO;
using static MyLib.PauseClass;

namespace task03
{

    class Program
    {
        static int MyDelegate(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);
        }
        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();

            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("..\\..\\students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(',');

                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[6]) < 5)
                    {
                        bakalavr++;
                    }
                    else if (int.Parse(s[6]) >= 5)
                    {
                        magistr++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                }
            }
            sr.Close();

            list.Sort(new Comparison<Student>(MyDelegate));
            Console.WriteLine($"Всего студентов: {list.Count}");
            Console.WriteLine($"Магистров: {magistr}");
            Console.WriteLine($"Бакалавров: {bakalavr}");
            Console.WriteLine();

            Console.WriteLine($"Итого Магистров {magistr}: ");
            int numberOfStudent = 0;
            foreach (var e in list)
            {
                if (e.course >= 5)
                {
                    Console.WriteLine($"{++numberOfStudent} {e.firstName} {e.lastName}");
                }
            }

            Console.WriteLine();
            Console.WriteLine(DateTime.Now - dt);

            Pause();
        }
    }
}
