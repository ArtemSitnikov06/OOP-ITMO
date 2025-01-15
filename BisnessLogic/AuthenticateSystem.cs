using Ports;

namespace BisnessLogic;

#pragma warning disable CA2007
public class AuthenticateSystem
{
    private readonly IBankDatabase _bankDatabase;

    public string AdminPassword { get;  } = "admin";

    public AuthenticateSystem(IBankDatabase bankDatabase)
    {
        _bankDatabase = bankDatabase;
    }

    public async Task<bool> AuthenticateUser(int bankAccount, int pin)
    {
        BankAccountDTO? accountDto = await _bankDatabase.GetAccountAsync(bankAccount, pin);
        if (accountDto != null)
        {
            return true;
        }

        return false;
    }

    public bool AuthenticateAdmin(string password)
    {
        return AdminPassword == password;
    }
}