using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Admin.Models
{
    public enum Sort
    {
        ASC,
        DESC
    }
    public class FilterOption:BaseClass
    {
        public string url_slug { get; set; }
        public string display_text { get; set; }
        public Sort sort { get; set; }
        [ForeignKey("filter")]
        public int filter_id { get; set; }
        public Filter filter { get; set; }
        public virtual ICollection<Filter_Options_Products> Filter_Options_Products { get; set; }
        //public int ProductId { get; set; }
        //public int OptionId { get; set; }

        //public virtual Option Option { get; set; }
        //public virtual Product Product { get; set; }
    }
}
