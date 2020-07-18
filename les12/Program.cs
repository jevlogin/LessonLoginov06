using System;
using System.IO;
using System.Text.RegularExpressions;
using static MyLib.PauseClass;


namespace les12
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем список файлов в папке. AllDirectories - сканировать также и подпапки
            try
            {
                string[] fs = Directory.GetFiles("D:\\Temp", "*.*", SearchOption.AllDirectories);
                foreach (var fileName in fs)
                {
                    // Создаем регулярное выражения дя поиска почтовых адресов
                    Regex regex = new Regex(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})");
                    // Считываем файл
                    string s = File.ReadAllText(fileName);
                    Console.WriteLine(fileName);
                    // Выводим найденные адреса на экран
                    foreach (var c in regex.Matches(s))
                    {
                        Console.WriteLine($"{c}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // Просматриваем каждый файл в массиве
            

            Pause();
        }
    }
}
