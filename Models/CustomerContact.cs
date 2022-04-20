using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class CustomerContact
    {
        public int ContactId { get; set; }
        public int CustomerId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
