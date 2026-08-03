namespace BarberHub.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Customer(string firstName, string lastName, string phoneNumber, string? email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
