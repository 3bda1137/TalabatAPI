using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> genericRepository;

        public ProductsController(IGenericRepository<Product> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task< ActionResult<IEnumerable<Product>>> Get()
        {
            var products= await genericRepository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await genericRepository.GetAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}
