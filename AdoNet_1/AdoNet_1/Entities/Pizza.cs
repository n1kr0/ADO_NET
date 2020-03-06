using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_1.Entities
{

   public class Pizza
    { 
        public Pizza(int id,string name,float price,string type)
        {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Type = type;
        }
        public Pizza( string name, float price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
        public int Id { get; set; }
        public string Name { get; set;}
        public float Price { get; set;}
        public string Type { get; set;}
    }
}
