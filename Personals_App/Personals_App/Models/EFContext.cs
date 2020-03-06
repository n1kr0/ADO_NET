using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Personals_App.Models
{

    public class EFContext : DbContext
    {
        public EFContext() : base("DbConnection")
        {

        }

        public DbSet<Role> Roles { get; set; }



        public DbSet<User> Users { get; set; }
    }

}
