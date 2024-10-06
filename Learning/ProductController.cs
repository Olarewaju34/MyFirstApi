using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Learning
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost("")]
        public IActionResult AddProduct([FromBody] Product model)
        {
            _productRepository.AddProduct(model);
            var products =
                _productRepository.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("")]
        public IActionResult GetName()
        {

            var name = _productRepository.GetName();
            return Ok(name);
        }
    }
}
