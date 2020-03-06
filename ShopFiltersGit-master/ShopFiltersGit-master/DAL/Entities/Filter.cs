﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblFilters")]
    public class Filter
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(maximumLength:250)]
        public string Name { get; set; }

        public virtual ICollection<CategoryFilter> Categories { get; set; }
        public virtual ICollection<FilterValue> FilterValues { get; set; }

    }
}
