

using BarberHub.Domain.Entities;

namespace BarberHub.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
    }
}
