using FridgeSnitchClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using FridgeSnitchClient.Properties;

namespace FridgeSnitchClient.ViewModels
{
    public class SelectedInvasionViewModel : BindableObject
    {
        private InvasionModel _selectedInvasion;

        public InvasionModel SelectedInvasion
        {
            get => _selectedInvasion;
            set
            {
                _selectedInvasion = value;
                OnPropertyChanged(nameof(SelectedInvasion));
            }
        }

        public ICommand SaveVideo { get; }
        public ICommand DeleteVideo { get; }

        public SelectedInvasionViewModel(InvasionModel selectedInvasion)
        {
            SelectedInvasion = selectedInvasion;

            SaveVideo = new Command(OnSaveVideo);
            DeleteVideo = new Command(OnDeleteVideo);
        }

        private async void OnSaveVideo()
        {
            var result = await Application.Current.MainPage.DisplayPromptAsync(
                title: Resources.ConfirmAction,
                message: Resources.VideoFileName,
                accept: Resources.OK,
                cancel: Resources.Cancel,
                placeholder: string.Empty,
                maxLength: 255,
                keyboard: Keyboard.Default,
                initialValue: $"{SelectedInvasion.FridgeName} {SelectedInvasion.InvasionDateTime}");

            if (result is null)
            {
                //Cancel button clicked
                return;
            }

            //TODO: Perform video downloading and save to gallery or downloads
            throw new NotImplementedException();
        }

        private async void OnDeleteVideo()
        {
            var confimed = await Application.Current.MainPage.DisplayAlert(
                title: Resources.ConfirmAction,
                message: Resources.AreYouGoingToDeleteVideo,
                accept: Resources.Yes,
                cancel: Resources.No);

            if (!confimed)
            {
                return;
            }

            //TODO: Perform video deletion from the database
            throw new NotImplementedException();
        }
    }
}
