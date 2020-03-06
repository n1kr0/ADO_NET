using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblAddressType")]
    public class AddressType
    {
        [Key]
        public int AddressTypeId { get; set; }

        public string Name { get; set; }

        public string rowquid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddressOf { get; set; }
    }
}
