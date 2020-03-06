using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblPassword")]
    public class Password
    {
        [Key, ForeignKey("PersonOf")]
        public int BusinessEntityId { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public string rowquid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Person PersonOf { get; set; }
    }
}
