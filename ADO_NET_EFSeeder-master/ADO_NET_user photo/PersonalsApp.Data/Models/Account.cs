using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalsApp.Data.Models
{
    [Table("tblAccount")]
    public class Account
    {
       
        [Key,ForeignKey("UserOf")]

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [ForeignKey("UserOf")]
        public int UserId { get; set; }
        public virtual User UserOf { get; set; }

    }
}
