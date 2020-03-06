using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Copy
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(Funk);
            foreach (var file in Directory.GetFiles(@"C:\Users\HP\Desktop\"))
            {
                Thread thread = new Thread(threadStart);
                thread.Start(file);
            }
        }
        static void Funk(object a)
        {
            string aw = (string)a;
            File.Copy(aw, Path.Combine(@"C:\Users\HP\Desktop\copy\",
                Path.GetFileName(aw)), true);
        }
    }
}
