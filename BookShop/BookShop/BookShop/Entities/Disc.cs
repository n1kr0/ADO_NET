using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Entities
{
    [Table("tblDiscs")]

    public class Disc
    {
        [Key]
        public int Id { get; set; }
        public string NameDisc { get; set; }
        [ForeignKey ("GroupOf")]
        public int GroupId { get; set; }
        [ForeignKey("ProducerOf")]
        public int ProduserId { get; set; }
        [ForeignKey("GenreOf")]
        public int GenreId { get; set; }
        public int Traks { get; set; }
        public decimal Cost_Price { get; set; }
        public decimal Retail_Price { get; set; }
        public virtual Group GroupOf { get; set; }
        public virtual Producer ProducerOf { get; set; }
        public virtual Genre GenreOf { get; set; }

    }
}
