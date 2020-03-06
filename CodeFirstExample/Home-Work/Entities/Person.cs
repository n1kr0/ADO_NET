using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    [Table("tblPerson")]
    public class Person
    {
        [Key, ForeignKey("BusinessEntityContactOf")]
        public int BusinessEntityId { get; set; }

        public string PersonType { get; set; }

        public string NameStyle { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string EmailConnection { get; set; }

        public string AdditionalContactInfo { get; set; }

        public string Demographics { get; set; }

        public string Rowquid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContactOf { get; set; }

        public virtual BusinessEntity BusinessEntityOf { get; set; }
    }
}
