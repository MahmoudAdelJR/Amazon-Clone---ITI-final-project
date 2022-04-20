using Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Models
{
    public class Category : BaseClass
    {
        //public Category()
        //{
        //    Subcategories = new HashSet<Subcategory>();
        //}
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public int? SuppCatId { get; set; }
        public virtual Category SuppCat { get; set; }
        public virtual ICollection<Category> ParentId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
