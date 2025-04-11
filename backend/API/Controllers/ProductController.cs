using Courier.Application.Interfaces;
using Courier.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // Получение всех продуктов
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        // Получение продукта по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // Добавление нового продукта
        [HttpPost]
        public async Task<ActionResult> Add(Product product)
        {
            await _service.AddAsync(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // Обновление информации о продукте
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();
            await _service.UpdateAsync(product);
            return NoContent();
        }

        // Удаление продукта
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
