using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models
{
    public class Order
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        [Display(Name = "Grand Total")]
        public decimal GrandTotal { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }


    }
}
