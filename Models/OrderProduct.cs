using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Admin.Models
{
    public class OrderProduct
    {
        [ForeignKey("orders")]
        public int OrderId { get; set; }

        [ForeignKey("products")]
        public int ProductId { get; set; }
        public virtual Product products { get; set; }
        public virtual Order orders { get; set; }
        public int Quantity { get; set; }
    }
}
