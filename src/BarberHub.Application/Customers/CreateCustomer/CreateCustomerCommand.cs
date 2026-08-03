
namespace BarberHub.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string? Email { get; }

        public CreateCustomerCommand(
            string firstName,
            string lastName,
            string phoneNumber,
            string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
