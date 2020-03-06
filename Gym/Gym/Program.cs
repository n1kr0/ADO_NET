using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Gym
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t [System Gym]");
            Console.WriteLine("1). Show clients.");
            Console.WriteLine("2). Show coachs.");
            Console.WriteLine("3). Add client.");
            Console.WriteLine("4). Add coach.");
            Console.WriteLine("5). Delete client.");
            Console.WriteLine("6). Delete coach.");
            Console.WriteLine("7). Edit client.");
            Console.WriteLine("7). Edit coach.");
            Console.WriteLine("Enter choice :");
            string str;
            int choise=Console.ReadLine(Int32.Parse(str));
        }
    }
}
