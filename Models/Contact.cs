using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Contact : BaseClass
    {
        public Contact()
        {
            CustomerContacts = new HashSet<CustomerContact>();
            SellerContacts = new HashSet<SellerContact>();
        }

        public string Phone { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
        //public int? AdminId { get; set; }

        //public virtual Admins Admin { get; set; }
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
        public virtual ICollection<SellerContact> SellerContacts { get; set; }
    }
}
