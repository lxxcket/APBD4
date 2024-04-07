namespace LegacyApp;

public class DefaultCreditLimit : ICreditLimit
{
    public void SetCreditLimit(User user)
    {
        user.HasCreditLimit = true;
        using (var userCreditService = new UserCreditService())
        {
            int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit;
        }
    }
}