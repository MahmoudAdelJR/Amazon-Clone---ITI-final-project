using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Admin.Models
{
    public class ListProduct
    {
        [ForeignKey("lists")]
        public int ListId { get; set; }
        [ForeignKey("products")]
        public int ProductId { get; set; }

        public virtual Product products { get; set; }
        public virtual List lists { get; set; }
    }
}
