using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Parameteres
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(Funk);

            Thread thread = new Thread(threadStart);
            thread.Start((object)"1");

            Thread thread1 = new Thread(threadStart);
            thread1.Start((object)"\t2");

            Thread thread2 = new Thread(threadStart);
            thread2.Start((object)"\t\t3");
        }

        static void Funk(object a)
        {
            string id = (string)a;
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(0);
                Console.WriteLine(id);
            }
        }
    }
}
