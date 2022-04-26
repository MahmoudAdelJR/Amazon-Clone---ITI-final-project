using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class List : BaseClass
    {
        public string Name { get; set; }
        public string Privacy { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ListProduct> listproduct { get; set; }
    }
}
