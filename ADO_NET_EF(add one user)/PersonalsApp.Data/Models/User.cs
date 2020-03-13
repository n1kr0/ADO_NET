using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalsApp.Data.Models
{
    [Table("tblUsers")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, RegularExpression(@"^\+38\(\d{3,3}\)\d{3,3}-\d{2,2}-\d{2,2}$")]
        public string Phone { get; set; }

        [Required, StringLength(100)]
        public string Image { get; set; }

        [ForeignKey("RoleOf")]
        public int RoleId { get; set; }

        public virtual Account AccountOf { get; set; }
        public virtual Role RoleOf { get; set; }
    }
}
