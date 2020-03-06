using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample.Entities
{
    [Table("tblPerconCreditInfoes")]
   public class PersonCreditInfo
    {
        [Key,ForeignKey("PersonOf")]
        public int Id { get; set; }

        public string CreditCardNumber { get; set; }

        [Range(0,100)]
        public double Percent { set; get; }
        
        [Range(0,double.MaxValue)]
        public double Ballance { set; get; }

        [Range(0,double.MaxValue)]
        public double Sum { set; get; }

        public virtual Person PersonOf { get; set; }
    }
}
