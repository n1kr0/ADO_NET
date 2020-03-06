using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblPersonPhone")]
    public class PersonPhone
    {
        [Key, Column(Order = 0), ForeignKey("PersonOf")]
        public int BusinessEntityId { get; set; }

        [Key, Column(Order = 1)]
        public string PhoneNumber { get; set; }

        [Key, Column(Order = 2), ForeignKey("PhoneNumberTypeOf")]
        public int PhoneNumberTypeId { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual PhoneNumberType PhoneNumberTypeOf { get; set; }

        public virtual Person PersonOf { get; set; }
    }
}
