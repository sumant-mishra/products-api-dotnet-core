using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAPI.Services;


namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private ILogger _logger;
        private IProductsService _service;

        
        public ProductsController(ILogger<ProductsController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
            
        }

        [HttpGet("/api/products")]
        public ActionResult<List<Product>> GetProducts()
        {
            return _service.GetProducts();
        }

        [HttpPost("/api/products")]
        public ActionResult<Product> AddProduct(Product product)
        {
            _service.AddProduct(product);
            return product;
        }

        [HttpPut("/api/products/{id}")]
        public ActionResult<Product> UpdateProduct(string id, Product product)
        {
            _service.UpdateProduct(id, product);
            return product;
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _service.DeleteProduct(id);
            //_logger.LogInformation("products", _products);
            return id;
        }
    }
}
