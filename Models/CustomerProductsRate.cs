using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class CustomerProductsRate
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int? RateNumber { get; set; }
        public string Feedback { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
