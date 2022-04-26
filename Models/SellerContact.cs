using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class SellerContact : BaseClass
    {
        //public int ContactId { get; set; }
        public int SellerId { get; set; }
        public string Phone { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }

        //public virtual Contact Contact { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
