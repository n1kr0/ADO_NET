using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab3.Entities
{
   [Table("tblGoods")]
   public class Good
    {
   
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public string Category { get; set; }
        
    }

}
