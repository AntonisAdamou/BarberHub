using BarberHub.Domain.Entities;
using BarberHub.Domain.Enums;

namespace BarberHub.Tests.Domain;

public class AppointmentTests
{
    [Fact]
    public void CreateAppointment_WithValidData_CreatesAppointment()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var serviceId = Guid.NewGuid();
        var startTime = DateTime.UtcNow.AddDays(1);

    // Act
    var appointment = new Appointment(
        customerId,
        serviceId,
        startTime);

        // Assert
        Assert.NotEqual(Guid.Empty, appointment.Id);
        Assert.Equal(customerId, appointment.CustomerId);
        Assert.Equal(serviceId, appointment.ServiceId);
        Assert.Equal(startTime, appointment.StartTime);
        Assert.Equal(AppointmentStatus.Scheduled, appointment.Status);
        Assert.NotEqual(default, appointment.CreatedAt);
    }

    [Fact]
    public void CreateAppointment_WithEmptyCustomerId_ThrowsException()
    {
        // Arrange
        var serviceId = Guid.NewGuid();
        var startTime = DateTime.UtcNow.AddDays(1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Appointment(
                Guid.Empty,
                serviceId,
                startTime));
    }

    [Fact]
    public void CreateAppointment_WithEmptyServiceId_ThrowsException()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var startTime = DateTime.UtcNow.AddDays(1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Appointment(
                customerId,
                Guid.Empty,
                startTime));
    }

    [Fact]
    public void CreateAppointment_WithPastStartTime_IsAllowed()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var serviceId = Guid.NewGuid();
        var startTime = DateTime.UtcNow.AddDays(-1);

        // Act
        var appointment = new Appointment(
            customerId,
            serviceId,
            startTime);

        // Assert
        Assert.Equal(startTime, appointment.StartTime);
    }

    [Fact]
    public void CreateAppointment_StartsAsScheduled()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var serviceId = Guid.NewGuid();
        var startTime = DateTime.UtcNow.AddDays(1);

        // Act
        var appointment = new Appointment(
            customerId,
            serviceId,
            startTime);

        // Assert
        Assert.Equal(AppointmentStatus.Scheduled, appointment.Status);
    }

}
