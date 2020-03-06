using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblPhoneNumberType")]
    public class PhoneNumberType
    {
        [Key]
        public int PhoneNumberTypeId { get; set; }

        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<PersonPhone> PersonPhoneOf { get; set; }
    }
}
