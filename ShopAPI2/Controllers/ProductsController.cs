using Microsoft.AspNetCore.Mvc;
using ShopAPI2.Data;
using ShopAPI2.Models;
using ShopAPI2.Repository;
using System.Threading.Tasks;

namespace ShopAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IProductRepository _productRepository;

        public ProductsController(ShopContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fields = await _productRepository.GetAll();
            return Ok(fields);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var field = await _productRepository.GetById(id);
            if(field == null)
            {
                return NotFound();
            }
            return Ok(field);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProductModel pmodel)
        {
            var id = await _productRepository.Add(pmodel);
            return CreatedAtAction(nameof(GetById), new {id = id, Controller="products"}, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] ProductModel pmodel, [FromRoute] int id)
        {
            await _productRepository.Update(id, pmodel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }


    }
}
