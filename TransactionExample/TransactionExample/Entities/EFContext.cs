using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionExample.Entities
{
   public class EFContext:DbContext
    {
        public EFContext():base("DbConnection")
       {

        }
        public DbSet <User> Users { get; set; }
    }
}
