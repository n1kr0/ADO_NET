using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionExample.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 250)]
        public string Password { get; set; }
    }
}
