using BarberHub.Application.Customers.CreateCustomer;
using BarberHub.Application.Interfaces;
using BarberHub.Infrastructure.Persistence;
using BarberHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BarberHubDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<CreateCustomerHandler>();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();