using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostExample.Entities
{
    [Table("tblUsers")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [RegularExpression(@"\+38\(\d{3,3}\)\d{3,3}-\d{2,2}-\d{2,2}")]
        public String Phone { get; set; }

        [Range(15,100)]
        public int Age { get; set; }

        [EmailAddress]
        public  string Email { get; set; }
    }
}

