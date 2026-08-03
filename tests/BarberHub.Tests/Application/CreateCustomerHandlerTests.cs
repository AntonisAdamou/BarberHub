using BarberHub.Application.Customers.CreateCustomer;
using BarberHub.Domain.Entities;
using BarberHub.Application.Interfaces;

namespace BarberHub.Tests.Application.Customers;

public class CreateCustomerHandlerTests
{
    [Fact]
    public async Task HandleAsync_WithValidData_CreatesCustomer()
    {
        // Arrange
        var repository = new FakeCustomerRepository();
        var handler = new CreateCustomerHandler(repository);
    var command = new CreateCustomerCommand(
        "John",
        "Smith",
        "99999999",
        "john@example.com");

        // Act
        var result = await handler.HandleAsync(command);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Smith", result.LastName);
        Assert.Equal("99999999", result.PhoneNumber);
        Assert.Equal("john@example.com", result.Email);
    }

    [Fact]
    public async Task HandleAsync_WithValidData_SavesCustomerToRepository()
    {
        // Arrange
        var repository = new FakeCustomerRepository();
        var handler = new CreateCustomerHandler(repository);

        var command = new CreateCustomerCommand(
            "John",
            "Smith",
            "99999999",
            null);

        // Act
        var result = await handler.HandleAsync(command);

        // Assert
        Assert.NotNull(repository.SavedCustomer);
        Assert.Equal(result.Id, repository.SavedCustomer.Id);
    }

    [Fact]
    public async Task HandleAsync_WithInvalidFirstName_ThrowsException()
    {
        // Arrange
        var repository = new FakeCustomerRepository();
        var handler = new CreateCustomerHandler(repository);

        var command = new CreateCustomerCommand(
            "",
            "Smith",
            "99999999",
            null);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            handler.HandleAsync(command));
    }

    [Fact]
    public async Task HandleAsync_WithInvalidLastName_ThrowsException()
    {
        // Arrange
        var repository = new FakeCustomerRepository();
        var handler = new CreateCustomerHandler(repository);

        var command = new CreateCustomerCommand(
            "John",
            "",
            "99999999",
            null);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            handler.HandleAsync(command));
    }

    [Fact]
    public async Task HandleAsync_WithInvalidPhoneNumber_ThrowsException()
    {
        // Arrange
        var repository = new FakeCustomerRepository();
        var handler = new CreateCustomerHandler(repository);

        var command = new CreateCustomerCommand(
            "John",
            "Smith",
            "",
            null);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            handler.HandleAsync(command));
    }

    private class FakeCustomerRepository : ICustomerRepository
    {
        public Customer? SavedCustomer { get; private set; }

        public Task AddAsync(Customer customer)
        {
            SavedCustomer = customer;
            return Task.CompletedTask;
        }
    }
}
