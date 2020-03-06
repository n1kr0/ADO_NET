using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostExample.Entities
{
    [Table("tblPosts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        
        public DateTime DataEndUpdate { get; set; }

        [Required]
        public DateTime DataOfCreate { get; set; }

        [RegularExpression(@"http(s)?:\/\/.+\..+")]
        public string Link { get; set; }


    }
}
