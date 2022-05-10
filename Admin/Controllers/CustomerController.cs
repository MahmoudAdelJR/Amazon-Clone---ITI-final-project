using Admin.Data;
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

namespace Admin.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class CustomerController : Controller
    {

        IUnitofWork unitofWork;
        IModelRepo<Customer> ModelRepository;
        public CustomerController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            ModelRepository = unitofWork.GetCustomerRepo();
        }
        public ActionResult Index()
        {
            var customers = ModelRepository.Read().ToList();
            return View(customers);
        }


        // GET: CustomerController1/Details/5
        public ActionResult GetByID(int id)
        {
            Customer c = ModelRepository.GetByID(id);
            return View("CustomerDetails", c);
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer c)
        {
            try
            {
                ModelRepository.Create(c);
                unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Edit/5
        public ActionResult Edit(Customer c)
        {
            return View();
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editing(Customer c)
        {
            try
            {
                ModelRepository.Update(c);
                unitofWork.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: CustomerController1/Delete/5
        public ActionResult Delete(int id)
        {
            ModelRepository.Delete(id);
            unitofWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            return View(ModelRepository.GetByID(Id));
        }
    }
}
