using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class ContactController : Controller
    {
        IUnitofWork unitofWork;
        IModelRepo<CustomerContact> customerContactRepository;
        IModelRepo<SellerContact> sellerContactRepository;
        public ContactController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            customerContactRepository = unitofWork.GetCustomerContactRepo();
            sellerContactRepository = unitofWork.GetSellerContactRepo();
        }
        //public IActionResult Index()
        //{
        //    return View();// ContactRepository.Read().ToList());
        //}
        //public ActionResult Delete(int id)
        //{
        //    ContactRepository.Delete(id);
        //    unitofWork.Save();
        //    return RedirectToAction("index");
        //}
        [HttpGet]
        public IActionResult getCustomerContacts()
        {
            return View("customerContact", customerContactRepository.Read().ToList());
        }
        [HttpGet]
        public IActionResult getSellerContacts()
        {
            return View("sellerContact", sellerContactRepository.Read().ToList());
        }
    }
}
