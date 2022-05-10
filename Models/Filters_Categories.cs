using Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Filters_Categories
    {
        [ForeignKey("filter")]
        public int filter_id { get; set; }
        [ForeignKey("category")]
        public int category_id { get; set; }
        public Sort sort { get; set; }
        public Filter filter { get; set; }
        public Category category { get; set; }
    }
}
