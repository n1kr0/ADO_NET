using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_1.Entities
{
    public class Flower
    {
        public Flower(int id, string name, float price, int seasonId)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.SeasonId = seasonId;
        }
        public Flower(string name, float price, int seasonId)
        {
            this.Name = name;
            this.Price = price;
            this.SeasonId = seasonId;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public int SeasonId { get; set; }
    }
}
