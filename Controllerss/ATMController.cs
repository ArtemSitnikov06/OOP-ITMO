using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ports;

namespace Controllerss;

#pragma warning disable CA2007
[Route("api/[controller]")]
[ApiController]
public class ATMController : ControllerBase
{
    private readonly IATMService _atmService;

    public ATMController(IATMService atmService)
    {
        _atmService = atmService;
    }

    [HttpPost("create-account")]
    public async Task<IActionResult> CreateAccount([FromQuery] int bankAcc, [FromQuery] int pinCode)
    {
        await _atmService.CreateAccountAsync(bankAcc, pinCode);
        return Ok();
    }

    [HttpGet("balance")]
    public async Task<IActionResult> GetBalance()
    {
        int? bankAcc = HttpContext.Session.GetInt32("AccountNumber");
        int? pinCode = HttpContext.Session.GetInt32("PinCode");
        if (bankAcc != null && pinCode.HasValue)
        {
            decimal balance = await _atmService.CheckBalanceAsync(bankAcc.Value, pinCode.Value);
            return Ok($"Balance for account {bankAcc}: {balance}");
        }

        return Unauthorized("User is not login");
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromQuery] decimal amount)
    {
        int? bankAcc = HttpContext.Session.GetInt32("AccountNumber");
        int? pinCode = HttpContext.Session.GetInt32("PinCode");
        bool result = false;
        if (bankAcc != null && pinCode.HasValue)
        {
            result = await _atmService.WithdrawAsync(bankAcc.Value, amount, pinCode.Value);
        }
        else
        {
            return Unauthorized("User is not login");
        }

        if (!result)
        {
            return BadRequest("You havent much money");
        }

        return Ok($"Withdraw account {bankAcc}: {amount}");
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromQuery] decimal amount)
    {
        int? bankAcc = HttpContext.Session.GetInt32("AccountNumber");
        int? pinCode = HttpContext.Session.GetInt32("PinCode");
        if (bankAcc != null && pinCode.HasValue)
        {
            await _atmService.DepositAsync(bankAcc.Value, amount, pinCode.Value);
            return Ok($"Deposit to account {bankAcc}: {amount}");
        }

        return Unauthorized("User is not login");
    }

    [HttpGet("transaction-history")]
    public async Task<IActionResult> GetTransactionHistory()
    {
        int? bankAcc = HttpContext.Session.GetInt32("AccountNumber");
        int? pinCode = HttpContext.Session.GetInt32("PinCode");
        if (bankAcc != null && pinCode.HasValue)
        {
            IReadOnlyList<TransactionDTO> history = await _atmService.GetTransactionHistoryAsync(bankAcc.Value, pinCode.Value);
            return Ok(history);
        }

        return Unauthorized("User is not login");
    }
}