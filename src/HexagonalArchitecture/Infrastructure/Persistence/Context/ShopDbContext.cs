using HexagonalArchitecture.Domain.Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Infrastructure.Persistence.Context;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var shop = modelBuilder.Entity<Shop>();
        
        shop.ToTable("shops");

        shop.HasKey("Id");
        
        shop.OwnsOne(
            s => s.Name,
            na =>
            {
                na.Property(p => p.Name).HasColumnName("Name");
            }
        );
        shop.OwnsOne(
            s => s.Email,
            na =>
            {
                na.Property(p => p.Email).HasColumnName("Email");
            }
        );
        
        shop.OwnsOne(
            s => s.Created,
            na =>
            {
                na.Property(p => p.Created).HasColumnName("Created").HasColumnType("Date");
            }
        );
        
        base.OnModelCreating(modelBuilder);
    }
        
    public DbSet<Shop> Shops { get; set; }
}