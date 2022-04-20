using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class SellerContact
    {
        public int ContactId { get; set; }
        public int SellerId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
