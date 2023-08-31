using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Get() 
        {
            return new List<Product> 
            {
                new Product{ProductId = 1,ProductName="elma" }
            };
        }
    }
}
