using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DbConnection")
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
