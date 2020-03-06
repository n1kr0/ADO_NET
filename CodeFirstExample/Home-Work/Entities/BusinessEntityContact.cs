using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblBusinessEntityContact")]
    public class BusinessEntityContact
    {
        [Key, Column(Order = 0), ForeignKey("BusinessEntityOf")]
        public int BusinessEntityId { get; set; }

        [Key, Column(Order = 1), ForeignKey("PersonOf")]
        public int PersonId { get; set; }

        [Key, Column(Order = 2), ForeignKey("ContactTypeOf")]
        public int ContactTypeId { get; set; }

        public string rowquid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ContactType ContactTypeOf { get; set; }

        public virtual Person PersonOf { get; set; }

        public virtual BusinessEntity BusinessEntityOf { get; set; }
    }
}
