using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.AuthenticationClasses;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
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
