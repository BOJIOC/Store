using backendModuleA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backendModuleA.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<PurchaseItem> PurchaseItems => Set<PurchaseItem>();
    public DbSet<Movement> Movements => Set<Movement>();
    public DbSet<MovementItem> MovementItems => Set<MovementItem>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<PriceHistory> PriceHistories => Set<PriceHistory>();
    public DbSet<DiscountRule> DiscountRules => Set<DiscountRule>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Уникальность кода товара
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Code)
            .IsUnique();

        // Один сотрудник -> один магазин
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Store)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связи между складами при перемещении
        modelBuilder.Entity<Movement>()
            .HasOne(m => m.FromWarehouse)
            .WithMany(w => w.MovementsFrom)
            .HasForeignKey(m => m.FromWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Movement>()
            .HasOne(m => m.ToWarehouse)
            .WithMany(w => w.MovementsTo)
            .HasForeignKey(m => m.ToWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}