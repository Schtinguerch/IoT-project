using System;
using System.Collections.Generic;
using System.Text;

namespace FridgeSnitchClient
{
    public class Validator
    {
        //TODO: Ensure from the DB engineer, the userName and password limitations
        private const int MinLength = 3;
        private const int MaxLength = 36;

        public bool? IsLoginValid { get; private set; }
        public bool? IsPasswordValid { get; private set; }

        public bool ValidateCredentials(ref string userName, string password)
        {
            IsLoginValid = IsUserNameValid(ref userName);
            IsPasswordValid = IsPassWordValid(password);

            //Ensured, the fields are not null
            return (bool) IsLoginValid && (bool) IsPasswordValid;
        }

        private bool IsUserNameValid(ref string userName)
        {
            userName = userName.Trim();

            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (userName.Length < MinLength || userName.Length > MaxLength)
            {
                return false;
            }

            return true;
        }

        private bool IsPassWordValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (password.Length < MinLength || password.Length > MaxLength)
            {
                return false;
            }

            return true;
        }
    }
}
