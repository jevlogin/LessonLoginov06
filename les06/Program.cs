using static MyLib.PauseClass;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace les06
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Temp");
            PrintDirectoryInfo(dir);

            DirectoryInfo[] subDirects = dir.GetDirectories();

            Console.WriteLine($"Найдено {subDirects.Length} подкаталогов");

            foreach (var e in subDirects)
            {
                PrintDirectoryInfo(e);
                Console.WriteLine();
            }

            Pause();
        }

        private static void PrintDirectoryInfo(DirectoryInfo dir)
        {
            Console.WriteLine("***** " + dir.Name + " ****");
            Console.WriteLine($"Полное имя (FullName): {dir.FullName}");
            Console.WriteLine($"Имя (Name): {dir.Name}");
            Console.WriteLine($"Родительская директория (Parent): {dir.Parent}");
            Console.WriteLine($"Время создания: {dir.CreationTime}");
            Console.WriteLine($"Атрибуты: {dir.Attributes.ToString()}");
            Console.WriteLine($"Корневая часть каталога (Root): {dir.Root}");
            Console.WriteLine();
        }
    }
}
