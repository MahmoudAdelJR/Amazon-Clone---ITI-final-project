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
        IModelRepo<Order> OrderRepo;
        IModelRepo<Contact> ContactRepo;
        IModelRepo<SellerContact> SellerContactRepo;
        IModelRepo<CustomerContact> CustomerContactRepo;
        IModelRepo<Cart> CartRepo;
        public UnitofWork(DbContext _Context,
            IModelRepo<Customer> _customerRepo, 
            IModelRepo<Admins> _adminRepo , 
            IModelRepo<Category> _categoryRepo , 
            IModelRepo<Product> _productRepo , 
            IModelRepo<Seller> _sellerRepo,
            IModelRepo<Order> _orderRepo,
            IModelRepo<Contact> _contactRepo,
            IModelRepo<SellerContact> _sellerContactRepo,
            IModelRepo<CustomerContact> _customerContactRepo
            //CartRepository _cartRepo
            )
        {
            context = _Context;
            CustomerRepo = _customerRepo;
            AdminRepo = _adminRepo;
            CategoryRepo = _categoryRepo;
            ProductRepo = _productRepo;
            SellerRepo = _sellerRepo;
            OrderRepo = _orderRepo;
            ContactRepo = _contactRepo;
            SellerContactRepo = _sellerContactRepo;
            CustomerContactRepo = _customerContactRepo;
           // CartRepo = _cartRepo;
        }

        public IModelRepo<Customer> GetCustomerRepo()
        {
            return CustomerRepo;
        }
        //public IModelRepo<Cart> GetCartRepo()
        //{
        //    return CartRepo;
        //}
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
        public IModelRepo<Order> GetOrderRepo()
        {
            return OrderRepo;
        }

        public IModelRepo<Contact> GetContactRepo()
        {
            return ContactRepo;
        }
        public IModelRepo<SellerContact> GetSellerContactRepo()
        {
            return SellerContactRepo;
        }
        public IModelRepo<CustomerContact> GetCustomerContactRepo()
        {
            return CustomerContactRepo;
        }
    }
}
