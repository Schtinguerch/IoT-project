using FridgeSnitchClient.CommonFunctionality;
using FridgeSnitchClient.Models;
using FridgeSnitchClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FridgeSnitchClient.ViewModels
{
    public class InvasionsViewModel : BindableObject
    {
        private InvasionModel _selectedInvasion;

        public ObservableCollection<InvasionModel> Invasions { get; set; }
        public INavigation Navigation { get; }

        public InvasionModel SelectedInvasion
        {
            get => _selectedInvasion;
            set
            {
                _selectedInvasion = value;
                OnPropertyChanged(nameof(SelectedInvasion));

                if (value is null)
                {
                    return;
                }

                Navigation.PushModalAsync(new SelectedInvasionView(value));
            }
        }

        public InvasionsViewModel(INavigation navigation)
        {
            Navigation = navigation;

            //TEST data to check the MVVM interaction
            Invasions = TestDataSet.Invasions;
        }
    }
}
