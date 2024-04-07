using System;
using System.ComponentModel.DataAnnotations;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName 
        {
            get { return FirstName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Last name can't be null");
                }

                FirstName = value;
            }
        }

        public string LastName
        {
            get { return LastName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Last name can't be null");
                }

                LastName = value;
            }
        }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
    }
}