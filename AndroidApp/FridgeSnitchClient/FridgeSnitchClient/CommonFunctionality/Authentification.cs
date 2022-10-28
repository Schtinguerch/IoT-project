using System;
using System.Collections.Generic;
using System.Text;

namespace FridgeSnitchClient
{
    public class Authentification
    {
        public bool IsAuthentificated { get; private set; } = false;
        public bool HasConnectionTroubles { get; private set; } = false;

        public readonly Validator Validator = new Validator();

        public bool TryAuthentificate(string userName, string password)
        {
            var areDataValid = Validator.ValidateCredentials(ref userName, password);
            if (!areDataValid)
            {
                IsAuthentificated = false;
                return false;
            }

            //TODO: perform the request to the server
            //Now returns true as a plug

            var isAuthentificationSucceed = true;

            IsAuthentificated = isAuthentificationSucceed;
            return IsAuthentificated;
        }
    }
}
