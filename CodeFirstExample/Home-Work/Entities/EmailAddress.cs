using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblEmailAddress")]
    public class EmailAddress
    {
        [Key, Column(Order = 0), ForeignKey("PersonOf")]
        public int BusinessEntityId { get; set; }

        [Key, Column(Order = 1)]
        public int EmailAddressId { get; set; }

        public string EmailAddressString { get; set; }

        public string rowquid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Person PersonOf { get; set; }
    }
}
