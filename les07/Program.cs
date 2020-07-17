using System;
using System.Collections;
using System.IO;
using System.Linq;
using static MyLib.PauseClass;

namespace les07
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfBachelors = 0;
            int numOfMasters = 0;
            // Создадим необобщенный список
            ArrayList list = new ArrayList();
            // Запомним время в начале обработки данных
            DateTime dt = DateTime.Now;
            //StreamReader sr = new StreamReader("data.csv");
            StreamReader sr = new StreamReader("..\\..\\students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(',');

                    list.Add(s[1] + " " + s[0]);    // Добавляем склееные имя и фамилию
                    if (int.Parse(s[6]) < 5)
                    {
                        numOfBachelors++;
                    }
                    else
                    {
                        numOfMasters++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();
            list.Sort();

            Console.WriteLine($"Всего студентов: {list.Count}");
            Console.WriteLine($"Магистров: {numOfMasters}");
            Console.WriteLine($"Бакалавров: {numOfBachelors}");
            Console.WriteLine("\n");


            foreach (var e in list)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\n");
            Console.WriteLine(DateTime.Now - dt);

            Pause();
        }
    }
}
