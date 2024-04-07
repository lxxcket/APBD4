using System.Reflection;
using LegacyApp;

namespace LegacyAppTests;

public class UserValidatorTests
{
    [Fact]
    public void Email_Not_Containing_At_Sign_Returns_False()
    {
        Type type = typeof(UserValidator);
        var userValidator = Activator.CreateInstance(type);
        MethodInfo method = type.GetMethod("ValidateEmail", BindingFlags.NonPublic | BindingFlags.Instance);

        object[] parameters = new[] { "testexamole.com" };
        bool result = (bool)method.Invoke(userValidator, parameters);
        Assert.False(result);
    }
    [Fact]
    public void Validate_User_With_Null_First_Name_Returns_False()
    {
        var clientRepository = new FakeClientRepository();
        var client = clientRepository.GetById(1);

        var user = new User
        {
            Client = client,
            DateOfBirth = new DateTime(2000, 10, 20),
            EmailAddress = "example@test.com",
            FirstName = "",
            LastName = "LastName"
        };
        var userValidator = new UserValidator();
        bool result = userValidator.Validate(user);
        Assert.False(result);
    }

    [Fact]
    public void Validate_User_With_Null_Last_Name_Returns_False()
    {
        var clientRepository = new FakeClientRepository();
        var client = clientRepository.GetById(1);

        var user = new User
        {
            Client = client,
            DateOfBirth = new DateTime(2000, 10, 20),
            EmailAddress = "example@test.com",
            FirstName = "FirstName",
            LastName = ""
        };
        var userValidator = new UserValidator();
        bool result = userValidator.Validate(user);
        Assert.False(result);
    }

    [Fact]
    public void Validate_User_With_Email_Not_Containing_At_Returns_False()
    {
        var clientRepository = new FakeClientRepository();
        var client = clientRepository.GetById(1);

        var user = new User
        {
            Client = client,
            DateOfBirth = new DateTime(2000, 10, 20),
            EmailAddress = "exampletest.com",
            FirstName = "FirstName",
            LastName = "LastName"
        };
        var userValidator = new UserValidator();
        bool result = userValidator.Validate(user);
        Assert.False(result);
    }
    [Fact]
    public void Validate_User_With_Email_Not_Containing_Dot_Returns_False()
    {
        var clientRepository = new FakeClientRepository();
        var client = clientRepository.GetById(1);

        var user = new User
        {
            Client = client,
            DateOfBirth = new DateTime(2000, 10, 20),
            EmailAddress = "example@testcom",
            FirstName = "FirstName",
            LastName = "LastName"
        };
        var userValidator = new UserValidator();
        bool result = userValidator.Validate(user);
        Assert.False(result);
    }
    
    [Fact]
    public void Validate_User_With_Age_Under_21_Returns_False()
    {
        var clientRepository = new FakeClientRepository();
        var client = clientRepository.GetById(1);

        var user = new User
        {
            Client = client,
            DateOfBirth = new DateTime(2003, 10, 20),
            EmailAddress = "example@test.com",
            FirstName = "FirstName",
            LastName = "LastName"
        };
        var userValidator = new UserValidator();
        bool result = userValidator.Validate(user);
        Assert.False(result);
    }
}