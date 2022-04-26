using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string Name_AR { get; set; }
        public string Description { get; set; }
        public string Description_AR { get; set; }
        public string Picture { get; set; }

        public IQueryable<Category> categories { get; set; }
    }

    public static class CategoryVMExtension
    {

        public static Category ToModel(this CategoryViewModel cat)
        {
            return new Category
            {
                Name = cat.Name,
                Description = cat.Description,
                Picture = cat.Picture,
                parentId = null,
                Name_AR = cat.Name_AR,
                Description_AR = cat.Description_AR
            };
        }


    }
}
