using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Product : BaseClass
    {


        public string Name { get; set; }
        public double? Discount { get; set; }
        public string Shipping { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int categoryId { get; set; }
        public int SellerId { get; set; }

        public virtual ICollection<OrderProduct> orderproduct { get; set; }
        //public virtual ICollection<ListProduct> listproduct { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Category category { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        //public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }
        public virtual ICollection<CustomerProductsRate> CustomerProductsRates { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }


    }
}
