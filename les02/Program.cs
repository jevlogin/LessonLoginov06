using static MyLib.PauseClass;
using System;
using System.IO;


namespace les02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileStream fileIn = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
                FileStream fileOut = new FileStream("newData.txt", FileMode.Create, FileAccess.Write);
                int i;
                while((i = fileIn.ReadByte()) != -1)
                {
                    //  запись очередного байта в поток, связанный с файлом fileOut
                    fileOut.WriteByte((byte)i);
                }
                fileIn.Close();
                fileOut.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Файл успешно скопирован");

            Pause();
        }
    }
}
