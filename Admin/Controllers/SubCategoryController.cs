using Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.AuthenticationClasses;
using Newtonsoft.Json;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;
namespace Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class SubCategoryController : Controller
    {
        IUnitofWork unitofWork;
        IModelRepo<Category> ModelRepository;
        public SubCategoryController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            ModelRepository = unitofWork.GetCategoryRepo();
        }
        public IActionResult Index()
        {
            var categories = ModelRepository.Read().ToList();
            return View(categories);
        }
        public ActionResult GetByID(int id)
        {
            Category c = ModelRepository.GetByID(id);
            return View("CategoryDetails", c);
        }
        public ActionResult Create(SubCategoryViewModel sCVM)
        {
            sCVM.categories = ModelRepository.Read();
            return View(sCVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategoryViewModel c, byte[] ImageData)
        {
            
            try
            {
                ModelRepository.Create(c.ToModel());
                unitofWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(Category c)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editing(Category c)
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

        public ActionResult Delete(int id)
        {
            ModelRepository.Delete(id);
            unitofWork.Save();
            return RedirectToAction("Index");
        }
    }
}
