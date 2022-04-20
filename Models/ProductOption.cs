using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class ProductOption
    {
        public int ProductId { get; set; }
        public int OptionId { get; set; }

        public virtual Option Option { get; set; }
        public virtual Product Product { get; set; }
    }
}
