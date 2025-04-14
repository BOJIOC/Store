using backendModuleG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace backendModuleG.Infrastructure.Data;

public class ModuleGDbContext : DbContext
{
    public ModuleGDbContext(DbContextOptions<ModuleGDbContext> options) : base(options) { }

    public DbSet<Promotion> Promotions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Promotion>()
    .Property(p => p.ProductIds)
    .HasConversion(
        v => string.Join(',', v),
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
    )
    .Metadata.SetValueComparer(
        new ValueComparer<List<int>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList()
        )
    );
    }
}