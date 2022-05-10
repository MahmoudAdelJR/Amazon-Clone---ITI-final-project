using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Filter : BaseClass
    {
        public string slug { get; set; }
        public string display_text { get; set; }
        public virtual ICollection<FilterOption> FilterOptions { get; set; }
        public virtual ICollection<Filters_Categories> Filter_categories{ get; set; }
        //public Filter()
        //{
        //    ProductOptions = new HashSet<ProductOption>();
        //}

        //public string OptionName { get; set; }

        //public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
