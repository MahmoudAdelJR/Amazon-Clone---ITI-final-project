using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Admin.Models
{
    public class Customer : BaseClass
    {
        //public Customer()
        //{
        //    CustomerAddresses = new HashSet<CustomerAddress>();
        //    CustomerContacts = new HashSet<CustomerContact>();
        //    CustomerProducts = new HashSet<CustomerProduct>();
        //    CustomerProductsRates = new HashSet<CustomerProductsRate>();
        //    Lists = new HashSet<List>();
        //    Orders = new HashSet<Order>();
        //}

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(5, ErrorMessage = "minlegth is 5 char")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "PhoneNumber is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        [MaxLength(1, ErrorMessage = "Maxlegth is 1 char  M / F")]
        public string Gender { get; set; }

        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? CartId { get; set; }
        [ForeignKey("profile")]
        public string profileID { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }
        public virtual ICollection<CustomerProductsRate> CustomerProductsRates { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual IdentityUser profile { get; set; }
    }
}
