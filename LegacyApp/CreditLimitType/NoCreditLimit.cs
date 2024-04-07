namespace LegacyApp;

public class NoCreditLimit : ICreditLimit
{
    public void SetCreditLimit(User user)
    {
        user.HasCreditLimit = false;
    }
}