using FridgeSnitchClient.Models;
using FridgeSnitchClient.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FridgeSnitchClient.ViewModels
{
    public class SelectedFridgeViewModel : BindableObject
    {
        private FridgeModel _selectedFridge;
        private FridgeModel _defaultFridge;

        public FridgeModel SelectedFridge
        {
            get => _selectedFridge;
            set
            {
                _selectedFridge = value;
                _defaultFridge = value.Clone();

                OnPropertyChanged(nameof(SelectedFridge));
            }
        }

        public ICommand SaveSettings { get; }
        public ICommand DiscardSettings { get; }

        public SelectedFridgeViewModel(FridgeModel selectedFridge)
        {
            SelectedFridge = selectedFridge;

            SaveSettings = new Command(OnSaveSettings);
            DiscardSettings = new Command(OnDiscardSettings);
        }

        private async void OnSaveSettings()
        {
            //TODO: send request to the server to update the fridge data
            throw new NotImplementedException();
        }

        private async void OnDiscardSettings()
        {
            var confimed = await Application.Current.MainPage.DisplayAlert(
                title: Resources.ConfirmAction,
                message: Resources.AreYouGoingToDiscardSettings,
                accept: Resources.Yes,
                cancel: Resources.No);

            if (!confimed)
            {
                return;
            }

            SelectedFridge = _defaultFridge;
        }
    }
}
