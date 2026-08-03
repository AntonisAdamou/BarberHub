using BarberHub.Domain.Enums;

namespace BarberHub.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ServiceId { get; private set; }
        public DateTime StartTime { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Appointment(Guid customerId, Guid serviceId, DateTime startTime)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException("Customer ID cannot be empty.", nameof(customerId));

            if (serviceId == Guid.Empty)
                throw new ArgumentException("Service ID cannot be empty.", nameof(serviceId));

            Id = Guid.NewGuid();
            CustomerId = customerId;
            ServiceId = serviceId;
            StartTime = startTime;
            Status = AppointmentStatus.Scheduled;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
