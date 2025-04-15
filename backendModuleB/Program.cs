using Courier.Application.Interfaces;
using Courier.Domain.Entities;
using Courier.Infrastructure;
using Courier.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IRetailApiClient, RetailApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5027");
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.MapControllers();

// ========== ТЕСТОВЫЕ ДАННЫЕ ==========
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    if (!context.Orders.Any())
    {
        // Тестовая настройка курьера
        var courierSettings = new CourierSettings
        {
            CurrentEmployeeId = 101
        };
        context.CourierSettings.Add(courierSettings);

        // Заказ #1
        var order1 = new Order
        {
            StoreId = 1,
            CourierId = 101,
            CollectorId = 102,
            ClientName = "Сергей Смирнов",
            Address = "г. Москва, ул. Пушкина, д. 10",
            Comment = "Позвонить за 10 минут",
            Status = "Новый",
            DeliveryDate = DateTime.UtcNow.AddDays(1),
            Items = new List<OrderItem>
            {
                new OrderItem { ProductId = 1, ProductName = "Молоко", Quantity = 2 },
                new OrderItem { ProductId = 2, ProductName = "Хлеб", Quantity = 1 }
            }
        };

        // Заказ #2
        var order2 = new Order
        {
            StoreId = 1,
            CourierId = 101,
            CollectorId = 103,
            ClientName = "Анна Кузнецова",
            Address = "г. Москва, пр. Мира, д. 5",
            Comment = "",
            Status = "Собран",
            DeliveryDate = DateTime.UtcNow,
            Items = new List<OrderItem>
            {
                new OrderItem { ProductId = 3, ProductName = "Яблоки", Quantity = 5 }
            }
        };

        context.Orders.AddRange(order1, order2);

        // Отчёт по доставке
        var report = new DeliveryReport
        {
            EmployeeId = 101,
            Type = "Доставка",
            Date = DateTime.UtcNow,
            OrderCount = 2
        };
        context.DeliveryReports.Add(report);

        await context.SaveChangesAsync();
    }
}
// ========== КОНЕЦ СИДЕРА ==========

app.Run();
