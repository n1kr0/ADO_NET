using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_HW_Linq.Entity
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DbConnection")
        {

        }

        public DbSet<Good> GoodOf { get; set; }
    }
}
