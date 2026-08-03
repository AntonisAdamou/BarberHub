using BarberHub.Application.Interfaces;
using BarberHub.Domain.Entities;
using BarberHub.Infrastructure.Persistence;

namespace BarberHub.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly BarberHubDbContext _context;

    public CustomerRepository(BarberHubDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }
}