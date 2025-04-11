using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _service;

    public StoreController(IStoreService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => 
        await _service.GetByIdAsync(id) is var store && store != null ? Ok(store) : NotFound();

    [HttpPost] public async Task<IActionResult> Create(Store store) => Ok(await _service.CreateAsync(store));
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, Store store)
    {
        if (id != store.Id) return BadRequest();
        var result = await _service.UpdateAsync(store);
        return result == null ? NotFound() : Ok(result);
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}