namespace BarberHub.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public TimeSpan Duration { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Service(string name, string? description, decimal price, TimeSpan duration)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Service name cannot be null or empty.", nameof(name));

            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be zero or negative.");

            if (duration <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be greater than zero.");

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Duration = duration;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
