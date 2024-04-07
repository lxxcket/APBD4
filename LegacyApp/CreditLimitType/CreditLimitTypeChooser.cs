namespace LegacyApp;

public static class CreditLimitTypeChooser
{
    public static ICreditLimit CreditLimitType(Client client)
    {
        switch (client.Type)
        {
            case "VeryImportantClient":
                return new NoCreditLimit();
            case "ImportantClient":
                return new DoubleCreditLimit();
            default:
                return new DefaultCreditLimit();
        }
    }
}