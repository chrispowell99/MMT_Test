using Microsoft.AspNetCore.Mvc;
using MMT_Test.Common.Domain;
using MMT_Test.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT_Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService,IProductService productService)
        {
            this._categoryService = categoryService;
            this._productService = productService;
        }

        [HttpGet]
        public List<Category> Get()
        {
            return _categoryService.GetCategories();
        }

        [HttpGet("{Id}/Products")]
        public List<Product> GetProductsForCategory(int Id)
        {
            var category = _categoryService.GetCategoryById(Id);

            if (category != null)
            {
                return _productService.GetProducts(category:category);
            }

            return new List<Product>();
        }
    }
}
