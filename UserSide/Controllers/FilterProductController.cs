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
        [Route("AllCategories")]
        public async Task<IQueryable<Category>> getAllCategories()
        {
            var result = await categoryRepo.GetAll();
            return result;
        }

        [HttpGet]
        [Route("ProductByCatID")]
        public async Task<IQueryable<Product>> GetPrdByCatID(int CatID, string brand)
        {
            var result = await productrepo.FindByCondition(i => i.categoryId == CatID );
            return result;
        }
        


        // Search for product by name
        [HttpGet]
        [Route("Search/{search}")]
        public async Task<IQueryable<Product>> Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var Search = await productrepo.FindByCondition(i => i.Name.Contains(search)
                || i.Description.Contains(search));
                var result = Search;
                if (Search.Any())
                {

                    return (IQueryable<Product>)result;
                }
            }
            return (IQueryable<Product>)await productrepo.GetAll();
        }
    }
}
