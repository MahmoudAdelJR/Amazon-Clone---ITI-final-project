using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Order : BaseClass
    {
        public DateTime? OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public string OrderAddress { get; set; }
        public int TotalPrice { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> orderproduct { get; set; }
    }
}
