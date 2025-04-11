using Courier.Application.Interfaces;
using Courier.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetAll() => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> Get(int id)
    {
        var order = await _service.GetByIdAsync(id);
        if (order == null) return NotFound();
        return order;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Order order)
    {
        if (id != order.Id) return BadRequest();
        await _service.UpdateAsync(order);
        return NoContent();
    }
}