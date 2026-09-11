using CodeFirstOrders.Api.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstOrders.Api.Infrastructure;

public class OrdersDbContext(DbContextOptions<OrdersDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Order>()
            .HasOne(order => order.Customer)
            .WithMany(customer => customer.Orders)
            .HasForeignKey(order => order.CustomerId);
        modelBuilder
            .Entity<Order>()
            .Property(order => order.TotalAmount)
            .HasPrecision(18, 2);
        modelBuilder
            .Entity<Customer>()
            .HasIndex(customer => customer.Email)
            .IsUnique();
    }
}