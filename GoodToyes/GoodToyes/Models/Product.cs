using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Number { get; set; }

        public string ImageUrl { get; set; }
    }
}
