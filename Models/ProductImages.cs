using Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductImages : BaseClass
    {
        public string ImgUrl { get; set; }
        [ForeignKey("Product")]
        public int prodId { get; set; }
        public virtual Product Product { get; set; }

    }
}
