using System;
using System.IO;
using static MyLib.PauseClass;

namespace les10
{
    class Program
    {
        static void Save(string fileName, int n)
        {
            Random rnd = new Random();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < n; i++)
            {
                bw.Write(rnd.Next(0, 100_000));
            }
            bw.Close();
            fs.Close();
        }

        static void Load(string fileName)
        {
            DateTime dt = DateTime.Now;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int[] a = new int[fs.Length / 4];
            for (int i = 0; i < fs.Length/4; i++)   //int занимает 4 байта
            {
                a[i] = br.ReadInt32();
            }
            br.Close();
            fs.Close();

            int max = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (Math.Abs(i - j) >= 8 && (long)(a[i] * a[j]) > max) max = a[i] * a[j];
                }
            }

            Console.WriteLine(max);
            Console.WriteLine(DateTime.Now - dt);
        }
        static void Main(string[] args)
        {
            const string filename = @"data.bin";

            Save(filename, 100_000);
            Load(filename);

            Pause();
        }
    }
}
