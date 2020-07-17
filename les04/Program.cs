using static MyLib.PauseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace les04
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                FileStream f = new FileStream("data.bin", FileMode.Open);
                BinaryReader fIn = new BinaryReader(f);
                long n = f.Length / 4;

                int a;
                for (a = 0; a < n; a++)
                {
                    a = fIn.ReadInt32();
                    Console.WriteLine(a + " ");
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
