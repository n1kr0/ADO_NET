using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tblProduct")]
    public class Product
    {
        public Product()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("CategoryOf")]
        public int Category { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public virtual Category CategoryOf { get; set; }
    }
}
