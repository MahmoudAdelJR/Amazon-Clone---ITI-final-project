using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Seller : BaseClass
    {
        //public Seller()
        //{
        //    Products = new HashSet<Product>();
        //    SellerContacts = new HashSet<SellerContact>();
        //}

        public string Name { get; set; }
        public string Email { get; set; }
        public int? PostalCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SellerContact> SellerContacts { get; set; }
    }
}
