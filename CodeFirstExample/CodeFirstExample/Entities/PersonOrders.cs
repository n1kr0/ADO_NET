using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entities
{
    [Table("tblPersonOrders")]
    public class PersonOrders
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Number { get; set; }

        [ForeignKey("PersonOf")]
        public int PersonId { get; set; }

        public virtual Person PersonOf { get; set; }
    }
}
