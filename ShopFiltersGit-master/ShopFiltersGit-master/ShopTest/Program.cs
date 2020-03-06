using DAL.Entities;
using System;
using System.Linq;
using System.Data.Entity;

namespace ShopTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using(EFContext context=new EFContext())
            {
                Console.WriteLine("Show product by category");
                int id = int.Parse(Console.ReadLine());
                var query = context.Categories.FirstOrDefault(t => t.Id == id).Products;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
