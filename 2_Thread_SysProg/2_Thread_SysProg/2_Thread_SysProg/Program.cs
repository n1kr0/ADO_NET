using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_Thread_SysProg
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = Methode;
            Thread thread = new Thread(threadStart);
            thread.Start();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{i}Main");
            }
        }
        static readonly object _lock = new object();
        static void Methode()
        {
            lock (_lock)
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"\t\t\t {i} Hello from Hell");
                }
        }
    }
}
