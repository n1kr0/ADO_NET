using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblProductFilters")]
    public class ProductFilter
    {
        [Key,Column(Order =0)]
        public int Id { get; set; }

        [Key,ForeignKey("FilterOf"),Column(Order = 1)]
        public int FilterId { get; set; }

        [Key,ForeignKey("ProductOf"),Column(Order = 2)]
        public int ProductId { get; set; }

        public virtual FilterValue FilterOf { get; set; }
        public virtual Product ProductOf { get; set; }
    }
}
