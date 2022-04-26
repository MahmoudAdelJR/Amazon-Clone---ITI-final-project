using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IUnitofWork
    {
        IModelRepo<Customer> GetCustomerRepo();
        IModelRepo<Admins> GetAdminRepo();
        IModelRepo<Category> GetCategoryRepo();
        IModelRepo<Product> GetProductRepo();
        IModelRepo<Seller> GetSellerRepo();
        IModelRepo<Order> GetOrderRepo();
        IModelRepo<Contact> GetContactRepo();
        IModelRepo<SellerContact> GetSellerContactRepo();
        IModelRepo<CustomerContact> GetCustomerContactRepo();
        //IModelRepo<Cart> GetCartRepo();

        void Save();
    }
}
