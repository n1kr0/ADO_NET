using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderShop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (KinderShopEntities context = new KinderShopEntities())
            {
                Products products = new Products()
                {
                    Name = "Кіндер Джой",
                    Price = 50,
                    IsShow = true,
                    DateOfCreate = DateTime.Now
                };
                context.Products.Add(products);
                context.SaveChanges();
            }
        }
    }
}
