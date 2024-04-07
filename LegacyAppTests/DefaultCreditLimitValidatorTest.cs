using LegacyApp;
using LegacyApp.CreditLimitValidator;

namespace LegacyAppTests;

public class DefaultCreditLimitValidatorTest
{
    [Fact]
    public void If_User_Has_Credit_Limit_And_Credit_Limit_Less_Than_500_Returns_False()
    {
        var validator = new DefaultCreditLimitValidator();
        var user = new User { HasCreditLimit = true, CreditLimit = 400};
        
        var result = validator.Validate(user);
        
        Assert.False(result);
    }
}