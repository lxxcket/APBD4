namespace LegacyApp.CreditLimitValidator;

public class DefaultCreditLimitValidator : ICreditLimitValidator
{
    public bool Validate(User user)
    {
        return !(user.HasCreditLimit && user.CreditLimit < 500);
    }
}