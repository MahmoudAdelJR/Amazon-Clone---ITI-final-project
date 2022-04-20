using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Cart : BaseClass
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProduct>();
            Customers = new HashSet<Customer>();
        }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
