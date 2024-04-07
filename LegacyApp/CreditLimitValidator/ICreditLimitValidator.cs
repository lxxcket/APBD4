namespace LegacyApp.CreditLimitValidator;

public interface ICreditLimitValidator
{
    bool Validate(User user);
}