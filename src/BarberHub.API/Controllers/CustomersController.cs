using BarberHub.Application.Customers.CreateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CreateCustomerHandler _handler;

    public CustomersController(CreateCustomerHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerRequest request)
    {
        var command = new CreateCustomerCommand(
            request.FirstName,
            request.LastName,
            request.PhoneNumber,
            request.Email);

        var customer = await _handler.HandleAsync(command);

        return CreatedAtAction(
            nameof(Create),
            new { id = customer.Id },
            new
            {
                customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.PhoneNumber,
                customer.Email,
                customer.CreatedAt
            });
    }
}

public class CreateCustomerRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
}