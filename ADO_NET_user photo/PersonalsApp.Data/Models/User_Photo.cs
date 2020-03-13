using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalsApp.Data.Models
{
    [Table("tblUserPhotos")]
   public class User_Photo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("UserOf")]
        public int User_Id { get; set; }

        public virtual User UserOf { get; set; }

    }
}
