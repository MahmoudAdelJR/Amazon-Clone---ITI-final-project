using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class OrderController : Controller
    {
        IUnitofWork unitofWork;
        IModelRepo<Order> OrderRepository;
        public OrderController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            OrderRepository = unitofWork.GetOrderRepo();
        }
        public IActionResult Index()
        {
            return View(OrderRepository.Read().ToList());
        }
        public ActionResult update(int id)
        {
            Order order = OrderRepository.GetByID(id);
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult update(Order o)
        {
            try
            {
                OrderRepository.Update(o);
                unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            OrderRepository.Delete(id);
            unitofWork.Save();
            return RedirectToAction("index");
        }

        public ActionResult Details(int Id)
        {
            return View(OrderRepository.GetByID(Id));
        }
    }
}
