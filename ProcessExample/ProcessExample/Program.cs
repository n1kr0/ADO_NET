using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть що шукаєте: ");
            string str=Console.ReadLine();
            Process notepadProcess = new Process();
            notepadProcess.StartInfo = new ProcessStartInfo("chrome.exe",str ) ;
            notepadProcess.Start();
           
        }
    }
}
