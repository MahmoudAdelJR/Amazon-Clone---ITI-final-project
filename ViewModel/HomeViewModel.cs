using Admin.Models;
using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class HomeViewModel
    {
        public int CustomersCount { get; set; }
        public int CategoriesCount { get; set; }
        public int ProductsCount { get; set; }
        public int SellersCount { get; set; }
        public List<Product> ProductSamples { get; set; }
    }

    public static class ToHomeViewModel 
    {
        public static HomeViewModel ConvertToHomeViewModel(this HomeViewModel hvm , int _custCount , int _catCount , int _prodCount , int _selCount , List<Product> _prods)
        {
            return new HomeViewModel
            {
                CustomersCount = _custCount,
                CategoriesCount = _catCount,
                ProductsCount = _prodCount,
                SellersCount = _selCount , 
                ProductSamples = _prods
            };
        }
    }
}
