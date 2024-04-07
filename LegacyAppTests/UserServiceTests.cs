using LegacyApp;
using LegacyApp.CreditLimitValidator;

namespace LegacyAppTests;
using System;

public class UserServiceTests{

        [Fact]
        public void Add_New_User_Valid_Returns_True()
        {
                var userService = new UserService(new UserValidator(), new DefaultCreditLimitValidator(), new FakeClientRepository());
                bool result = userService.AddUser("John", "Doe", "example@gmail.com", new DateTime(2000, 10, 10), 1);
                Assert.True(result);
        }

        [Fact]
        public void Add_New_User_With_Not_Valid_Email_Returns_False()
        {
                var userService = new UserService(new UserValidator(), new DefaultCreditLimitValidator(), new FakeClientRepository());
                bool result = userService.AddUser("John", "Doe", "examplegmail.com", new DateTime(2000, 10, 10), 1);
                Assert.False(result);
        }

        [Fact]
        public void Add_New_User_Under_Age_Of_21_Returns_False()
        {
                var userService = new UserService(new UserValidator(), new DefaultCreditLimitValidator(), new FakeClientRepository());
                bool result = userService.AddUser("John", "Doe", "example@gmail.com", new DateTime(2005, 10, 10), 1);
                Assert.False(result);
        }
        
}