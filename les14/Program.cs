using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyLib.PauseClass;

namespace les14
{
    class Program
    {
        static void Main(string[] args)
        {
            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            long gbyte = 1024 * mbyte;
            long size = mbyte;
            //Write FileStream
            //Write BinaryStream
            //Write StreamReader/StreamWriter
            //Write BufferedStream

            Console.WriteLine($"FileStream. Milliseconds: {FileStreamSample("D:\\Temp\\bigdata0.bin", size)}");
            Console.WriteLine($"BinaryStream. Milliseconds: {BinaryStreamSample("D:\\Temp\\bigdata1.bin", size)}");
            Console.WriteLine($"StreamWriter. Milliseconds: {StreamWriterSample("D:\\Temp\\bigdata2.bin", size)}");
            Console.WriteLine($"BufferedStream. Milliseconds: {BufferedStreamSample("D:\\Temp\\bigdata3.bin", size)}");

            Pause();

        }

        private static long BufferedStreamSample(string fileName, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            int countPart = 4;  //кол-во частей
            int buffSize = (int)(size / countPart);
            byte[] buffer = new byte[size];

            BufferedStream bs = new BufferedStream(fs, buffSize);
            //bs.Write(buffer, 0, (int)size);   //Error!

            for (int i = 0; i < countPart; i++)
            {
                bs.Write(buffer, 0, (int)buffSize);
            }

            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static object StreamWriterSample(string fileName, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < size; i++)
            {
                sw.Write(0);
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static object BinaryStreamSample(string fileName, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
            {
                bw.Write((byte)0);
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static long FileStreamSample(string fileName, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            for (int i = 0; i < size; i++)
            {
                fs.WriteByte(0);
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
