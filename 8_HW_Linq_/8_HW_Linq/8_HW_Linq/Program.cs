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

             
            }
        }
    }
}
