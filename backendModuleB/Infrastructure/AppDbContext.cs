using Courier.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courier.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<CourierSettings> CourierSettings => Set<CourierSettings>();
    public DbSet<DeliveryReport> DeliveryReports => Set<DeliveryReport>();
}