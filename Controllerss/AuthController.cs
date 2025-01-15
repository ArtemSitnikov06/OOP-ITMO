using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ports;

namespace Controllerss;

#pragma warning disable CA2007
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IATMService _atmService;

    public AuthController(IATMService atmService)
    {
        _atmService = atmService;
    }

    [HttpPost("login-user")]
    public async Task<IActionResult> LoginUser([FromQuery] int bankAcc, [FromQuery] int pin)
    {
        bool bankAccount = await _atmService.AuthenticateAsync(bankAcc, pin);
        if (bankAccount)
        {
            HttpContext.Session.SetInt32("AccountNumber", bankAcc);
            HttpContext.Session.SetInt32("PinCode", pin);
            return Ok($"Login to {bankAcc} successful");
        }

        return Unauthorized("Invalid bank account number");
    }

    [HttpPost("login-admin")]
    public IActionResult LoginAdmin([FromQuery] string password)
    {
        if (_atmService.AuthenticateAdmin(password))
        {
            HttpContext.Session.SetString("AdminPassword", password);
            return Ok("Admin successful login");
        }

        return Unauthorized("Invalid Admin password");
    }
}