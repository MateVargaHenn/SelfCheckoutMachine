using Microsoft.EntityFrameworkCore;
using SelfCheckoutMachine.Domain.Models;
namespace SelfCheckoutMachine.Infrastructure;

public class SelfCheckoutMachineDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Stock>(entity =>
        {
            entity.ToTable("Stocks");
        });
    }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Stock> Stocks { get; set; }
}
