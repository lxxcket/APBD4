using LegacyApp;

namespace LegacyAppTests;

public class FakeClientRepository
{
    public Client GetById(int clientId)
    {
        return new Client
        {
            Name = "Test",
            ClientId = clientId,
            Email = "test@example.com",
            Address = "strasse 1",
            Type = "NormalClient"
        };
    }
}