using _8_HW_Linq.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_HW_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFContext con = new EFContext())
            {
                //#region Temp
                //List<Good> goods1 = new List<Good>()
                //{
                //new Good()
                //{ Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
                //new Good()
                //{ Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
                //new Good()
                //{ Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
                //new Good()
                //{ Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
                //new Good()
                //{ Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" }
                //};

                //List<Good> goods2 = new List<Good>()
                //{
                //new Good()
                //{ Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
                //new Good()
                //{ Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
                //new Good()
                //{ Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
                //new Good()
                //{ Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
                //new Good()
                //{ Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
                //};
                //con.GoodOf.AddRange(goods1);
                //con.GoodOf.AddRange(goods2);
                //con.SaveChanges();
                //#endregion

                #region Mobile>1000
                var item = from good in con.GoodOf
                           where good.Category == "Mobile" &&
                           good.Price > 1000
                           select good;
                foreach (var meti in item)//reverse item(name) // item = meti
                    Console.WriteLine(meti.Title);
                #endregion

                #region !Kitchen
                var item2 = from good in con.GoodOf
                            where good.Category != "Kitchen" &&
                            good.Price > 1000
                            select good;
                foreach (var meti2 in item2)
                {
                    Console.WriteLine(meti2.Title);
                    Console.WriteLine(meti2.Price.ToString());
                }
                #endregion

                #region MaxPrice
                Console.WriteLine(con.GoodOf.Select(t => t.Price).Max());
                #endregion

                #region Average
                Console.WriteLine(con.GoodOf.Select(t => t.Price).Average());
                #endregion

                #region Categories
                var item5 = con.GoodOf.Select(t => t.Category).Distinct();
                foreach (var meti5 in item5)
                    Console.WriteLine(meti5);
                #endregion

                #region Price==Price
                foreach (var meti6 in con.GoodOf.Where(t => con.GoodOf.FirstOrDefault(g => g.Price == t.Price && t != g) != null))
                    Console.WriteLine(meti6.Title);
                #endregion

                #region MaxPrice
                Console.WriteLine(con.GoodOf.Select(t => t.Price).Max());
                #endregion

                #region AlphabetSort
                foreach (var meti7 in con.GoodOf.OrderBy(t => t.Title))
                    Console.WriteLine(meti7);
                #endregion

                #region CheckCar
                Console.WriteLine(con.GoodOf.Any(t => t.Price >= 1000 && t.Price <= 2000));
                #endregion

                #region Sum
                Console.WriteLine(con.GoodOf.Count(t => t.Category == "Car" || t.Category == "Mobile"));
                #endregion

                #region List
                var item9 = con.GoodOf.GroupBy(t => t.Category).Select(t => new { name = t.Key, count = t.Count() });
                foreach (var meti9 in item9)
                    Console.WriteLine(meti9.name + " " + meti9.count);
                #endregion

                //TASK2

                int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
                int[] values2 = new int[5] { 19, 1, 4, 9, 8 };

                Console.WriteLine(values1.Concat(values2).Select(t => t % 2 == 0 && t >= 10).Count());

                foreach (var item1 in values1.Union(values2))
                    Console.WriteLine(item1);

                Console.WriteLine(values1.Where(t => t == values2.FirstOrDefault(g => g == t)).Max());

                Console.WriteLine(values1.Concat(values2).Where(t => t < 15 && t > 5).Sum());

                foreach (var el in values1.OrderBy(t => t))
                    Console.WriteLine(el);
                Console.WriteLine();
                foreach (var item3 in values2.OrderBy(t => t))
                    Console.WriteLine(item3);
            }
        }
    }
}
