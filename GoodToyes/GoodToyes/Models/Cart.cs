using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models
{
    public class Cart
    {
        // properties
        public int ID { get; set; }

        public string UserID { get; set; }

        public bool CheckedOut { get; set; }

        // navigation property
        public List<CartItem> CartItems { get; set; }
    }
}
