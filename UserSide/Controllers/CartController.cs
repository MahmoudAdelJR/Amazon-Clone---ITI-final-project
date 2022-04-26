using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        IUnitofWork unitofWork;
        IModelRepo<Cart> cartRepo;
        public CartController(IUnitofWork _unitofWork)
        {
            unitofWork = _unitofWork;
            //cartRepo = unitofWork.GetCartRepo();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
