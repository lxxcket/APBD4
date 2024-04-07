using System;

namespace LegacyApp;

public class DoubleCreditLimit : ICreditLimit
{
    public void SetCreditLimit(User user)
    {
        using (var userCreditService = new UserCreditService())
        {
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            creditLimit *= 2;
            user.CreditLimit = creditLimit;
        }
    }
}