using Courier.Application.Interfaces;
using Courier.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _service;

        public StoreController(IStoreService service)
        {
            _service = service;
        }

        // Получение всех магазинов
        [HttpGet]
        public async Task<ActionResult<List<Store>>> GetAll()
        {
            var stores = await _service.GetAllAsync();
            return Ok(stores);
        }

        // Получение магазина по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> Get(int id)
        {
            var store = await _service.GetByIdAsync(id);
            if (store == null)
                return NotFound();
            return Ok(store);
        }

        // Добавление нового магазина
        [HttpPost]
        public async Task<ActionResult> Add(Store store)
        {
            await _service.AddAsync(store);
            return CreatedAtAction(nameof(Get), new { id = store.Id }, store);
        }

        // Обновление информации о магазине
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Store store)
        {
            if (id != store.Id)
                return BadRequest();
            await _service.UpdateAsync(store);
            return NoContent();
        }

        // Удаление магазина
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
