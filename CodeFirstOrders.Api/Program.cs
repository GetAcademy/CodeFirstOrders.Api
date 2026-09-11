using CodeFirstOrders.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("OrdersDb");
builder.Services.AddDbContext<OrdersDbContext>(
    options => options.UseSqlServer(connectionString));
var app = builder.Build();
app.MapGet("/customers", async (OrdersDbContext context) =>
{
    var customers = await context.Customers.ToListAsync();
    return customers;
});
app.Run();