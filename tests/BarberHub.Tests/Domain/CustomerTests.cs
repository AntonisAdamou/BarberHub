using BarberHub.Domain.Entities;

namespace BarberHub.Tests.Domain;

public class CustomerTests
{
    [Fact]
    public void CreateCustomer_WithValidData_CreatesCustomer()
    {
        // Arrange
        var firstName = "John";
        var lastName = "Smith";
        var phoneNumber = "99999999";
        string? email = null;

        // Act
        var customer = new Customer(
            firstName,
            lastName,
            phoneNumber,
            email);

        // Assert
        Assert.NotEqual(Guid.Empty, customer.Id);
        Assert.Equal(firstName, customer.FirstName);
        Assert.Equal(lastName, customer.LastName);
        Assert.Equal(phoneNumber, customer.PhoneNumber);
        Assert.Null(customer.Email);
        Assert.NotEqual(default, customer.CreatedAt);
    }

    [Fact]
    public void CreateCustomer_WithEmptyFirstName_ThrowsException()
    {
        // Arrange
        var firstName = "";
        var lastName = "Smith";
        var phoneNumber = "99999999";

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Customer(firstName, lastName, phoneNumber, null));
    }

    [Fact]
    public void CreateCustomer_WithEmptyLastName_ThrowsException()
    {
        // Arrange
        var firstName = "John";
        var lastName = "";
        var phoneNumber = "99999999";

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Customer(firstName, lastName, phoneNumber, null));
    }

    [Fact]
    public void CreateCustomer_WithEmptyPhoneNumber_ThrowsException()
    {
        // Arrange
        var firstName = "John";
        var lastName = "Smith";
        var phoneNumber = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Customer(firstName, lastName, phoneNumber, null));
    }

    [Fact]
    public void CreateCustomer_WithoutEmail_CreatesCustomer()
    {
        // Act
        var customer = new Customer(
            "John",
            "Smith",
            "99999999",
            null);

        // Assert
        Assert.Null(customer.Email);
    }
}