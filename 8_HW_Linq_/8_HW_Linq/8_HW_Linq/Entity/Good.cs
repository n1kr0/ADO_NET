using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_HW_Linq.Entity
{
    public class Good
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public double? Price { get; set; }

        public string Category { get; set; }
    }
}
