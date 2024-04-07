using LegacyApp;

namespace LegacyAppTests;

public class DoubleCreditLimitTest
{
    [Fact]
    public void SetCreditLimit()
    {
        var doubleCreditLimit = new DoubleCreditLimit();
        doubleCreditLimit.SetCreditLimit(new User
        {
            LastName = "Kowalski",
            DateOfBirth = new DateTime(2000,10,10)
        });
    }
}