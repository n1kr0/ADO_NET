using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalsApp.Data.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DbConnection")
        {

        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
