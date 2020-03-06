using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Entities
{
    [Table("tblProdesers")]

    public class Producer
    {
        [Key, ForeignKey("DiscOf")]
        public int Id { get; set; }

        public string NameGroup { get; set; }

        public virtual ICollection<Disc> DiscOf { get; set; }
    }
}
