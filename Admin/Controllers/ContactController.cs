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
        IModelRepo<Contact> ContactRepository;
        public ContactController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            ContactRepository = unitofWork.GetContactRepo();
        }
        public IActionResult Index()
        {
            return View(ContactRepository.Read().ToList());
        }
        public ActionResult Delete(int id)
        {
            ContactRepository.Delete(id);
            unitofWork.Save();
            return RedirectToAction("index");
        }
    }
}
