using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entities
{
    [Table("tblCoourses")]
   public class Course
    {
       [Key] 
       public int Id { get; set; }

        public string Name { get; set; }

        public int DurationInCredits { get; set; }

        public virtual ICollection <PersonCourse> PersonCourseOf { get; set; }
    }
}
