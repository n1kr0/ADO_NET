using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblCountryRegion")]
   public class CountryRegion
    {
        [Key]
        public int CountryRegionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime ModifieDate { get; set; }

        public virtual StateProvince StateProvinceOf { get; set; }
        //<>
    }
}
