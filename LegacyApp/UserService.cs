using System;
using LegacyApp.CreditLimitValidator;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IValidator<User> _validator;
        private readonly ICreditLimitValidator _creditLimitValidator;
        private readonly IClientRepository _clientRepository;

        public UserService()
        {
            _validator = new UserValidator();
            _creditLimitValidator = new DefaultCreditLimitValidator();
            _clientRepository = new ClientRepository();
        }

        public UserService(UserValidator validator, DefaultCreditLimitValidator creditLimitValidator, IClientRepository clientRepository)
        {
            _validator = validator;
            _creditLimitValidator = creditLimitValidator;
            _clientRepository = clientRepository;
        }

        

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var client = _clientRepository.GetById(clientId);

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
