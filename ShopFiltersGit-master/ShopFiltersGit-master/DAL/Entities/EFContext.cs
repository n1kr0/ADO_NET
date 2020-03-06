using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EFContext:DbContext
    {
        public EFContext():base("BuchokConnection")
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Filter> Filters { get; set; }

        public virtual DbSet<FilterValue> FilterValues { get; set; }

        public virtual DbSet<ProductFilter> ProductFilters { get; set; }

        public virtual DbSet<CategoryFilter> CategoryFilters { get; set; }




    }
}
