using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Entities
{
   public class EFContext: DbContext
    {
        public EFContext() : base("MyConnection")
        {

        }

        public DbSet<Good> Goods { get; set; }
    }
}
