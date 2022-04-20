using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Option : BaseClass
    {
        public Option()
        {
            ProductOptions = new HashSet<ProductOption>();
        }

        public string OptionName { get; set; }

        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
