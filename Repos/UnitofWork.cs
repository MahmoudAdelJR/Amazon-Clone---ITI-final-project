using Admin.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class UnitofWork : IUnitofWork
    {         
        DbContext context;
        IModelRepo<Customer> CustomerRepo;
        IModelRepo<Admins> AdminRepo;
        IModelRepo<Category> CategoryRepo;
        IModelRepo<Product> ProductRepo;
        IModelRepo<Seller> SellerRepo;

        public UnitofWork(DbContext _Context,
            IModelRepo<Customer> _customerRepo, 
            IModelRepo<Admins> _adminRepo , 
            IModelRepo<Category> _categoryRepo , 
            IModelRepo<Product> _productRepo , 
            IModelRepo<Seller> _sellerRepo)
        {
            context = _Context;
            CustomerRepo = _customerRepo;
            AdminRepo = _adminRepo;
            CategoryRepo = _categoryRepo;
            ProductRepo = _productRepo;
            SellerRepo = _sellerRepo;
        }

        public IModelRepo<Customer> GetCustomerRepo()
        {
            return CustomerRepo;
        }
        public IModelRepo<Admins> GetAdminRepo()
        {
            return AdminRepo;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IModelRepo<Category> GetCategoryRepo()
        {
            return CategoryRepo;
        }

        public IModelRepo<Product> GetProductRepo()
        {
            return ProductRepo;
        }

        public IModelRepo<Seller> GetSellerRepo()
        {
            return SellerRepo;
        }
    }
}
