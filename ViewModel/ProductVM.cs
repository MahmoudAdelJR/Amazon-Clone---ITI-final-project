using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProductVM
    {
        public string Name { get; set; }
        public double? Discount { get; set; }
        public string Shipping { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int categoryId { get; set; }
        public int SellerId { get; set; }

        public IQueryable<Category> categories { get; set; }

        public IQueryable<Seller> sellers { get; set; }
    }
    public static class ProductVMExtention
    {

        public static Product ToModel(this ProductVM PVM)
        {
            return new Product
            {
                Name = PVM.Name,
                Discount = PVM.Discount,
                Shipping = PVM.Shipping,
                Price = PVM.Price,
                Picture = PVM.Picture,
                Stock = PVM.Stock,
                Brand = PVM.Brand,
                Description = PVM.Description,
                categoryId = PVM.categoryId,
                SellerId = PVM.SellerId
            };
        }

        //public static ProductVM ToViewModel(this Product PVM)
        //{
        //    return new ProductVM
        //    {
        //        Id = PVM.Id,
        //        ProdName = PVM.ProdName,
        //        ProdPrice = PVM.ProdPrice,
        //        ProdPieceCount = PVM.ProdPieceCount,
        //        ProdAge = PVM.ProdAge,
        //        ProdStock = PVM.ProdStock,
        //        ProdDescreption = PVM.ProdDescreption,
        //        CatId = PVM.CatId
        //    };
        //}
    }
}
