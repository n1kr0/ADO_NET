using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblAddress")]
   public class Address
    {
        public Address()
        {
            BusinessEntityAddressOf = new HashSet<BusinessEntityAddress>();
        }

        [Key]
        public int AddressId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        [ForeignKey("StateProvinceOf")]
        public int StateProvinceId { get; set; }

        public int PostalCode { get; set; }

        public string SpatialLocation { get; set; }

        public string rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddressOf { get; set; }

        public virtual StateProvince StateProvinceOf { get; set; }
    }
}
