using System;
using LegacyApp.CreditLimitValidator;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IValidator<User> _validator;
        private readonly ICreditLimitValidator _creditLimitValidator;

        public UserService()
        {
            _validator = new UserValidator();
            _creditLimitValidator = new DefaultCreditLimitValidator();
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (!_validator.Validate(user))
                return false;

            var userCreditLimit = CreditLimitTypeChooser.CreditLimitType(client);
            userCreditLimit.SetCreditLimit(user);

            if (!_creditLimitValidator.Validate(user))
                return false;

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
