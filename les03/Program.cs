using System;
using System.IO;
using System.Text.RegularExpressions;
using static MyLib.PauseClass;

/**
 * 
 * Символьный поток
 * поиск всех чисел в файле
 * 
 * */


namespace les03
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fileIn = new StreamReader("data.txt");
            StreamWriter fileOut = new StreamWriter("newData.txt", false);
            string text = fileIn.ReadToEnd();
            Regex r = new Regex(@"[-+]?\d+");
            Match integer = r.Match(text);
            
            while (integer.Success)
            {
                Console.WriteLine(integer);
                fileOut.WriteLine(integer);
                integer = integer.NextMatch();
            }

            fileIn.Close();
            fileOut.Close();

            Pause();
        }
    }
}
