using Courier.Application.Interfaces;
using Courier.SharedModels;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetailProxyController : ControllerBase
{
    private readonly IRetailApiClient _retail;

    public RetailProxyController(IRetailApiClient retail) => _retail = retail;

    [HttpGet("products")]
    public async Task<ActionResult<List<ProductDto>>> GetProducts() =>
        Ok(await _retail.GetProductsAsync());

    [HttpGet("employees")]
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployees() =>
        Ok(await _retail.GetEmployeesAsync());

    [HttpGet("stores")]
    public async Task<ActionResult<List<StoreDto>>> GetStores() =>
        Ok(await _retail.GetStoresAsync());
}