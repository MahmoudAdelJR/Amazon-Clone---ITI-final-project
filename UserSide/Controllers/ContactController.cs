using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthenticationClasses;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IUnitofWork unitofWork;
        IModelRepo<CustomerContact> cContactRepo;
        IModelRepo<SellerContact> sContactRepo;
        public ContactController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            cContactRepo = unitofWork.GetCustomerContactRepo();
            sContactRepo = unitofWork.GetSellerContactRepo();
        }
        [HttpPost("sellerContact")]
        [Authorize(Roles =UserRoles.Seller)]
        public IActionResult addSellerContact(SellerContact contact)
        {
            try
            {
                sContactRepo.Create(contact);
               // sContactRepo.
                unitofWork.Save();
                return Ok(contact);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("customerContact")]
        [Authorize(Roles = UserRoles.Customer)]
        public IActionResult addCustomerContact(CustomerContact contact)
        {
            try
            {
                contact.Date = DateTime.Now;
                cContactRepo.Create(contact);
                unitofWork.Save();
                return Ok(contact);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
