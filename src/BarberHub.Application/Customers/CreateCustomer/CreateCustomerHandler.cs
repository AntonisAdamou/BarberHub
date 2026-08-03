

using BarberHub.Application.Interfaces;
using BarberHub.Domain.Entities;

namespace BarberHub.Application.Customers.CreateCustomer
{
    public class CreateCustomerHandler
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> HandleAsync(CreateCustomerCommand command)
        {
            var customer = new Customer(
                command.FirstName,
                command.LastName,
                command.PhoneNumber,
                command.Email);

            await _customerRepository.AddAsync(customer);

            return customer;
        }
    }
}
