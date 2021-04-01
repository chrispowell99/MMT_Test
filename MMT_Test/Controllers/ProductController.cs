using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMT_Test.Common.Domain;
using MMT_Test.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT_Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("featured")]
        public List<Product> GetFeaturedProducts()
        {
            return _productService.GetProducts(featured:true);
        }

        
    }
}
