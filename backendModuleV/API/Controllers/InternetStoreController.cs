using backendModuleV.Core.DTO.Store;
using backendModuleV.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backendModuleV.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InternetStoreController : ControllerBase
{
    private readonly IInternetStoreService _service;
    public InternetStoreController(IInternetStoreService service) => _service = service;

    [HttpGet("products")]
    public async Task<ActionResult<List<ProductForOnlineDto>>> GetProducts()
    {
        var data = await _service.GetOnlineProductsAsync();
        return Ok(data);
    }

    [HttpGet("stocks")]
    public async Task<ActionResult<List<StockInfoDto>>> GetStocks([FromQuery] string? storeCode, [FromQuery] string? article)
    {
        var data = await _service.GetStocksAsync(storeCode, article);
        return Ok(data);
    }

    [HttpPost("orders")]
    public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOnlineOrderRequest req)
    {
        var orderId = await _service.CreateOnlineOrderAsync(req);
        return Ok(orderId);
    }

    [HttpGet("orders/{orderId}")]
    public async Task<ActionResult<OrderStatusResponse>> GetOrderStatus(int orderId)
    {
        var info = await _service.GetOrderStatusAsync(orderId);
        if (info == null) return NotFound();
        return Ok(info);
    }
}