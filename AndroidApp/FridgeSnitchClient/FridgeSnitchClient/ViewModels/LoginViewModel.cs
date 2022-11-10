using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using FridgeSnitchClient.Properties;
using FridgeSnitchClient.Views;

namespace FridgeSnitchClient.ViewModels
{
    public class LoginViewModel : BindableObject
    {
        public ICommand PerformAuthentification { get; }
        public Authentification Authentification { get; }
        public INavigation Navigation { get; }

        private string _username, _password, _errorMessage;
        private bool _isErrorMessageVisible;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsErrorMessageVisible
        {
            get => _isErrorMessageVisible;
            set
            {
                _isErrorMessageVisible = value;
                OnPropertyChanged(nameof(IsErrorMessageVisible));
            }
        }

        public LoginViewModel(INavigation navigation)
        {
            PerformAuthentification = new Command(OnPerformAuthentification);
            Authentification = new Authentification();
            Navigation = navigation;
        }

        private void OnPerformAuthentification()
        {
            var isAuthentificated = Authentification.TryAuthentificate(Username, Password);

            if (isAuthentificated)
            {
                Navigation.PushModalAsync(new AppTabbedView());

                IsErrorMessageVisible = false;
                return;
            }

            IsErrorMessageVisible = true;
            if (Authentification.Validator.IsLoginValid != true)
            {
                ErrorMessage = $"{Resources.Error}: {Resources.LoginInvalidMessage}";
                return;
            }

            if (Authentification.Validator.IsPasswordValid != true)
            {
                ErrorMessage = $"{Resources.Error}: {Resources.PasswordInvalidMessage}";
                return;
            }

            if (Authentification.HasConnectionTroubles)
            {
                ErrorMessage = $"{Resources.Error}: {Resources.ConnectionTroubleMessage}";
                return;
            }

            ErrorMessage = $"{Resources.Error}: {Resources.LoginOrPasswordIncorrectMessage}";
        }
    }
}
