using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IUnitofWork UnitOfWork;
        IModelRepo<Admins> AdminRepo;
        IModelRepo<Customer> CustomerRepo;
        IModelRepo<Category> CategoryRepo;
        IModelRepo<Product> ProductRepo;
        IModelRepo<Seller> SellerRepo;

        public HomeController(ILogger<HomeController> logger , IUnitofWork _UnitOfWork)
        {
            _logger = logger;
            UnitOfWork = _UnitOfWork;
            AdminRepo = UnitOfWork.GetAdminRepo();
            CustomerRepo = UnitOfWork.GetCustomerRepo();
            CategoryRepo = UnitOfWork.GetCategoryRepo();
            ProductRepo = UnitOfWork.GetProductRepo();
            SellerRepo = UnitOfWork.GetSellerRepo();
        }

        public IActionResult Index()
        {
            var CustomersCount = CustomerRepo.Read().Count();
            var CategoriesCount = CategoryRepo.Read().Count();
            var ProductsCount = ProductRepo.Read().Count();
            var ProductSamples = ProductRepo.Read().OrderByDescending(e => e.Price).ToList();
            var SellersCount = SellerRepo.Read().Count();
            HomeViewModel m = new HomeViewModel();
            HomeViewModel MyModel = m.ConvertToHomeViewModel( CustomersCount, CategoriesCount, ProductsCount, SellersCount , ProductSamples);
            return View("index" , MyModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
