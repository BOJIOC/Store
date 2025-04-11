using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;
    public ClientController(IClientService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> Get(int id) =>
        await _service.GetByIdAsync(id) is var client && client != null ? Ok(client) : NotFound();

    [HttpPost] public async Task<IActionResult> Create(Client client) => Ok(await _service.CreateAsync(client));
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, Client client)
    {
        if (id != client.Id) return BadRequest();
        var result = await _service.UpdateAsync(client);
        return result == null ? NotFound() : Ok(result);
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? Ok() : NotFound();
}