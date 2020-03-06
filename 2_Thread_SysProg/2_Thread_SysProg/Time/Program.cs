using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(Funk);
           // thread.IsBackground = true;
            thread.Start();
        }

        static void Funk()
        {
            while(true)
            {
                //Console.Clear();
                Thread.Sleep(100);
                Console.WriteLine(DateTime.Now);
            }
        }
    }
}
