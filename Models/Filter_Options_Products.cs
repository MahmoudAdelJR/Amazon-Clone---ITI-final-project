using Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Filter_Options_Products
    {
        [ForeignKey("option")]
        public int filter_option_id { get; set; }
        [ForeignKey("product")]
        public int product_id { get; set; }
        public FilterOption option { get; set; }
        public Product product { get; set; }
    }
}
