using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyLib.PauseClass;

namespace les05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // изменение данных в двоичном потоке
                FileStream f = new FileStream("..\\..\\data.dat", FileMode.Open);
                BinaryWriter fOut = new BinaryWriter(f);
                long n = f.Length; // определяем количество байт в байтовом потоке
                int a;
                for (int i = 0; i < n; i += 8) // сдвиг на две позиции, т.к. тип int занимает 4 байта
                {
                    fOut.Seek(i, SeekOrigin.Begin);
                    fOut.Write(0);
                }
                fOut.Close();

                // чтение данных из двоичного потока
                f = new FileStream("..\\..\\data.dat", FileMode.Open);
                BinaryReader fIn = new BinaryReader(f);
                n = f.Length / 4; // определяем количество чисел в двоичном потоке

                for (int i = 0; i < n; i++)
                {
                    a = fIn.ReadInt32();
                    Console.WriteLine($"{a} ");
                }

                fIn.Close();
                f.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Pause();
        }
    }
}
