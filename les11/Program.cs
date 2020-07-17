using System.IO;
using static MyLib.PauseClass;

namespace les11
{
    class Program
    {
        public static double F(double x)
        {
            return (x * x) - (50 * x) + 10;
        }

        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
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

            SaveFunc(fileName, -100, 100, 0.5);
            System.Console.WriteLine(Load(fileName));

            Pause();
        }
    }
}
