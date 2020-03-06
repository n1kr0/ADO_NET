using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblStateProvince")]
    public class StateProvince
    {
        [Key]
        public int StateProvinceId { get; set; }

        [Required]
        public int StateProvinceCode { get; set; }

        [ForeignKey("CountryRegionOf")]
        public int CountryRegionCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int TeritoryId { get; set; }

        public string rowguid { get; set; }


        [Required]
        public DateTime ModifieDate { get; set; }


        public virtual CountryRegion CountryRegionOf { get; set; }

        public virtual ICollection<Address> AddressOf { get; set; }
    }
}
