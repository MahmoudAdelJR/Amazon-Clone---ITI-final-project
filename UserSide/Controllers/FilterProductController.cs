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
    public class FilterProductController : ControllerBase
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IModelRepo<Product> productrepo;

        private readonly IModelRepo<Category> categoryRepo;
        public FilterProductController(IUnitofWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            productrepo = unitOfWork.GetProductRepo();
            categoryRepo = unitOfWork.GetCategoryRepo();
        }
        [HttpGet]
        [Route("ProductByCatID")]
        public async Task<IQueryable<Product>> GetPrdByCatID(int CatID, string brand)
        {
            var result = await productrepo.FindByCondition(i => i.categoryId == CatID );
            return result;
        }
    }
}
