using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(maximumLength:250)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime DateCreate { get; set; }

        [ForeignKey("CategoryOf")]
        public int CategoryId { get; set; }

        public virtual Category CategoryOf { get; set; }

        public virtual ICollection<ProductFilter> ProductFilters { get; set; }
    }
}
