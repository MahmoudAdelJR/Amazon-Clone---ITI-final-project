using Admin.Data;
using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {

        IUnitofWork unitofWork;
        IModelRepo<Category> ModelRepository;
        public CategoryController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            ModelRepository = unitofWork.GetCategoryRepo();
        }

        public ActionResult Index()
        {
            var categories = ModelRepository.Read().ToList();
            return View(categories);
        }

        // GET: ProductController1/Details/5
        public ActionResult GetByID(int id)
        {
            Category c = ModelRepository.GetByID(id);
            return View("CategoryDetails", c);
        }

        // GET: ProductController1/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
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

        // GET: ProductController1/Edit/5
        public ActionResult Edit(Category c)
        {
            return View();
        }

        // POST: ProductController1/Edit/5
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

        // GET: ProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            ModelRepository.Delete(id);
            unitofWork.Save();
            return RedirectToAction("Index");
        }
    }
}