using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostExample.Entities
{
    public class PEContext : DbContext
    {
        public PEContext() : base("PostExampleConnection")
        {

        }
        public DbSet<User> Users { set; get; }
        public DbSet<Post> Posts { set; get; }
    }
}
