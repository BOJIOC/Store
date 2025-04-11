using Courier.Application.Interfaces;
using Courier.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _service.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Order order)
    {
        if (id != order.Id) return BadRequest();
        await _service.UpdateAsync(order);
        return Ok();
    }
}