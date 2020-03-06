using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblBusinessEntityAddress")]
   public class BusinessEntityAddress
    {
        [Key, Column(Order = 0), ForeignKey("BusinessEntityOf")]
        public int BusinessEntityId { get; set; }

        [Key, Column(Order = 1), ForeignKey("AddressOf")]
        public int AddressId { get; set; }

        [Key, Column(Order = 2), ForeignKey("AddressTypeOf")]
        public int AdderssTypeId { get; set; }

        public string rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntityOf { get; set; }
        public virtual AddressType AddressTypeOf { get; set; }
        public virtual Address AddressOf { get; set; }
    }
}
