using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class Helper
    {
        private IUnitofWork unitofWork;
        private  IModelRepo<Product> productRepo;
        public Helper(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            productRepo = unitofWork.GetProductRepo();
        }
        public  response checkProducts(List<OrderProduct> list)
        {
            response res = new response();
            foreach(var item in list)
            {
               // var ps = productRepo.Read().ToList();
                Product p = productRepo.Read().Where(p => p.Id == item.ProductId).FirstOrDefault();
                if(p is null)
                {
                    res.message += $"no product with id {item.ProductId}\n";
                    res.errors++;
                    continue;
                }
                if (item.Quantity > p.Stock)
                {
                    res.message += $"{p.Name}'s quantity isn't enough for the request\n";
                    res.errors++;
                }
            }
            return res;
        }
        public void decreaseProducts(List<OrderProduct> list)
        {
            foreach (var item in list)
            {
                Product p = productRepo.Read().Where(p => p.Id == item.ProductId).FirstOrDefault();
                p.Stock -= item.Quantity;
            }
        }
        public int getTotalPrice(List<OrderProduct> list)
        {
            int total = 0;
            foreach (var item in list)
            {
                Product p = productRepo.Read().Where(p => p.Id == item.ProductId).FirstOrDefault();
                total += (p.Price * item.Quantity);
            }
            return total;
        }
    }
    public class response
    {
        public string message { get; set; }
        public int errors { get; set; }
    }
}
