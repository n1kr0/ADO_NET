using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblCategoryFilters")]
    public class CategoryFilter
    {
        [Key,Column(Order = 0)]
        public int Id { get; set; }

        [Key,Column(Order =1),ForeignKey("FilterOf")]
        public int FilterId { get; set; }

        [Key,Column(Order = 2),ForeignKey("CategoryOf")]
        public int CategoryId { get; set; }

        public virtual Category CategoryOf { get; set; }
        public virtual Filter FilterOf { get; set; }

    }
}
