using backendModuleA.API.Interfaces;
using backendModuleA.Domain.Entities;
using backendModuleA.Infrastructure;
using backendModuleA.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IMovementService, MovementService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// ========== ТЕСТОВЫЕ ДАННЫЕ ==========
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    if (!context.Stores.Any())
    {
        var store = new Store { Code = "ST001", Name = "Центральный магазин", Address = "ул. Ленина, 1" };
        context.Stores.Add(store);

        var warehouse = new Warehouse { Code = "WH001", Name = "Склад №1", Address = "ул. Складская, 10" };
        context.Warehouses.Add(warehouse);

        var supplier = new Supplier { Code = "SUP001", Name = "ООО Поставщик", ContactInfo = "sup1@mail.ru" };
        context.Suppliers.Add(supplier);

        var client = new Client { Code = "CL001", Name = "Иван Иванов", ContactInfo = "ivan@example.com" };
        context.Clients.Add(client);

        var product = new Product
        {
            Code = "P001",
            Name = "Ноутбук Acer",
            Brand = "Acer",
            Group = "Электроника",
            ImageUrl = null,
            PriceHistory = new List<PriceHistory>
            {
                new PriceHistory { Price = 50000, StartDate = DateTime.UtcNow }
            }
        };
        context.Products.Add(product);

        var employee = new Employee { FullName = "Петров Петр", Position = "Продавец", Store = store };
        context.Employees.Add(employee);

        var purchase = new Purchase
        {
            Supplier = supplier,
            Warehouse = warehouse,
            Date = DateTime.UtcNow,
            Items = new List<PurchaseItem>
            {
                new PurchaseItem { Product = product, Quantity = 10, Price = 45000 }
            }
        };
        context.Purchases.Add(purchase);

        var sale = new Sale
        {
            Store = store,
            Client = client,
            Employee = employee,
            Date = DateTime.UtcNow,
            DiscountPercent = 5,
            TotalAmount = 47500,
            Items = new List<SaleItem>
            {
                new SaleItem { Product = product, Quantity = 1, Price = 50000 }
            }
        };
        context.Sales.Add(sale);

        var inventory = new Inventory
        {
            Warehouse = warehouse,
            Status = "Завершено",
            Date = DateTime.UtcNow,
            Items = new List<InventoryItem>
            {
                new InventoryItem { Product = product, ExpectedQuantity = 10, ActualQuantity = 10 }
            }
        };
        context.Inventories.Add(inventory);

        var movement = new Movement
        {
            FromWarehouse = warehouse,
            ToWarehouse = warehouse,
            Date = DateTime.UtcNow,
            Items = new List<MovementItem>
            {
                new MovementItem { Product = product, Quantity = 5 }
            }
        };
        context.Movements.Add(movement);

        await context.SaveChangesAsync();
    }
}
// ========== КОНЕЦ СИДЕРА ==========

app.Run();
