using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entities
{
    [Table("tblPersonCourses")]
    public class PersonCourse
    {
        [Key, ForeignKey("PersonOf"), Column (Order =0)]
        public int IdPerson { get; set; }

        [Key, ForeignKey("CourseOf"), Column (Order =1)]
        public int IdCourse { get; set; }

        public virtual Person PersonOf {get;set;}

        public virtual Course CourseOf {get;set;}

    }
}
