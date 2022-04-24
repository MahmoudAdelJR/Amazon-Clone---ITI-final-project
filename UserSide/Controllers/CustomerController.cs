using Admin.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        IUnitofWork unitofWork;
        IModelRepo<Customer> ModelRepository;
        public CustomerController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            ModelRepository = unitofWork.GetCustomerRepo();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer _customer)
        {
            ModelRepository.Create(_customer);
            unitofWork.Save();
            return Ok();
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(ModelRepository.Read().ToList());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult GetByID(int id)
        {
            Customer customer = ModelRepository.GetByID(id);
            return Ok(customer);
        }

        // POST api/<CustomerController>
        //[HttpPost]
        //public ActionResult Post(Customer c)
        //{
        //    try
        //    {
        //        ModelRepository.Create(c);
        //        unitofWork.Save();
        //        return Ok(ModelRepository.Read().ToList());
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        // PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        [HttpPatch]
        [Route("Update")]
        public IEnumerable<Customer> Update(int id, [FromBody] JsonPatchDocument<Customer> jsonPatchDocument)
        {
            Customer oldCustomer = ModelRepository.GetByID(id);
            jsonPatchDocument.ApplyTo(oldCustomer);
            unitofWork.Save();
            return ModelRepository.Read();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ModelRepository.Delete(id);
            unitofWork.Save();
            return Ok(ModelRepository.Read().ToList());
        }
    }
}
