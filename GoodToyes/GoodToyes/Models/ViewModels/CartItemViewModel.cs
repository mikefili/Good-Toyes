using GoodToyes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.ViewModels
{
    public class CartItemViewModel
    {
        // properties
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        [Range(0, 99, ErrorMessage = "There is a per order limit of 99")]
        public int Quantity { get; set; }
    }
}
