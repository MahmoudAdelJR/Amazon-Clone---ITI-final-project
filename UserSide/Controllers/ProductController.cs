using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Side_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IUnitofWork UnitOfWork;
        IModelRepo<Product> Product;
        public ProductController(IUnitofWork _unitOfWork)
        {
            UnitOfWork = _unitOfWork;
            Product = UnitOfWork.GetProductRepo();
        }

        //create
        [HttpPost]
        public IActionResult Post(Product _product)
        {
            Product.Create(_product);
            UnitOfWork.Save();
            return Ok();
        }

        //read all
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Product.Read().ToList());
        }
        //read one product
        [HttpGet("{id}")]
        public IActionResult GetByID(int ID)
        {
            var prd = Product.GetByID(ID);
            return Ok(prd);
        }

        //update
        [HttpPatch]
        public IActionResult Update(int id, [FromBody] JsonPatchDocument<Product> jsonPatchDocument)
        {
            Product prd = Product.GetByID(id);
            jsonPatchDocument.ApplyTo(prd);
            UnitOfWork.Save();
            return Ok(Product.GetByID(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product.Delete(id);
            UnitOfWork.Save();
            return Ok();
        }

    }
}
