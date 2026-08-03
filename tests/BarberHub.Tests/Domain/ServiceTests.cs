using BarberHub.Domain.Entities;

namespace BarberHub.Tests.Domain;

public class ServiceTests
{
    [Fact]
    public void CreateService_WithValidData_CreatesService()
    {
        // Arrange
        var name = "Haircut";
        var description = "Classic men's haircut";
        var price = 15.00m;
        var duration = TimeSpan.FromMinutes(30);

    // Act
    var service = new Service(
        name,
        description,
        price,
        duration);

        // Assert
        Assert.NotEqual(Guid.Empty, service.Id);
        Assert.Equal(name, service.Name);
        Assert.Equal(description, service.Description);
        Assert.Equal(price, service.Price);
        Assert.Equal(duration, service.Duration);
        Assert.True(service.IsActive);
        Assert.NotEqual(default, service.CreatedAt);
    }

    [Fact]
    public void CreateService_WithEmptyName_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Service(
                "",
                null,
                15.00m,
                TimeSpan.FromMinutes(30)));
    }

    [Fact]
    public void CreateService_WithNegativePrice_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Service(
                "Haircut",
                null,
                -10.00m,
                TimeSpan.FromMinutes(30)));
    }

    [Fact]
    public void CreateService_WithZeroPrice_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Service(
                "Haircut",
                null,
                0m,
                TimeSpan.FromMinutes(30)));
    }

    [Fact]
    public void CreateService_WithZeroDuration_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Service(
                "Haircut",
                null,
                15.00m,
                TimeSpan.Zero));
    }

    [Fact]
    public void CreateService_WithNegativeDuration_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Service(
                "Haircut",
                null,
                15.00m,
                TimeSpan.FromMinutes(-30)));
    }

    [Fact]
    public void CreateService_WithoutDescription_CreatesService()
    {
        // Act
        var service = new Service(
            "Haircut",
            null,
            15.00m,
            TimeSpan.FromMinutes(30));

        // Assert
        Assert.Null(service.Description);
    }

    [Fact]
    public void CreateService_StartsAsActive()
    {
        // Act
        var service = new Service(
            "Haircut",
            null,
            15.00m,
            TimeSpan.FromMinutes(30));

        // Assert
        Assert.True(service.IsActive);
    }

}
