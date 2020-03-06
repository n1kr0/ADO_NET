using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entities
{
    [Table("tblPersons")]
    public class Person
    {
        public Person()
        {
            PersonCourseOf = new HashSet<PersonCourse>();
            PersonOrdersOf = new HashSet<PersonOrders>();

        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DatoOfBirth { get; set; }


        public string Descripton { get; set; }

        [Required]
        public bool Gender { get; set; }

        public virtual PersonCreditInfo GetPersonCreditInfoOf { get; set; }

        public virtual ICollection <PersonOrders> PersonOrdersOf {get;set;}

        public virtual ICollection<PersonCourse> PersonCourseOf { get; set; }
    }
}
