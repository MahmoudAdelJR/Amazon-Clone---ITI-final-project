using Admin.Data;
using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModel;
using Microsoft.AspNetCore.Hosting;
//using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using SixLabors.ImageSharp;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {

        IUnitofWork unitofWork;
        IModelRepo<Category> ModelRepository;
        private IWebHostEnvironment Environment;
        public CategoryController(IUnitofWork _unitofWork, IWebHostEnvironment _environment)
        {
            unitofWork = _unitofWork;
            ModelRepository = unitofWork.GetCategoryRepo();
            Environment = _environment;
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
        public ActionResult Create(CategoryViewModel CVM )
        {
            CVM.categories = ModelRepository.Read();
            return View(CVM);
        }

        // POST: ProductController1/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel c , IFormFile ImageData)
        {
            
           // var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
            //ImageData.Add(filePath);
            var path = Path.Combine(Environment.ContentRootPath, "wwwroot/pics");
            //using (var stream = new FileStream(path, FileMode.Create))
            //{
                var e = Image.Load(ImageData.OpenReadStream());
                e.SaveAsJpeg(path);
            
        //        await ImageData.CopyToAsync(stream);
        //}
            //Image
            //var image = ImageData.OpenReadStream();

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