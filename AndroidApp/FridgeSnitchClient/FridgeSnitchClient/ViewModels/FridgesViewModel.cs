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
    public class FridgesViewModel : BindableObject
    {
        private FridgeModel _selectedFridge;

        public ObservableCollection<FridgeModel> Fridges { get; set; }
        public INavigation Navigation { get; }

        public FridgeModel SelectedFridge
        {
            get => _selectedFridge;
            set
            {
                _selectedFridge = value;
                OnPropertyChanged(nameof(SelectedFridge));

                if (value is null)
                {
                    return;
                }

                Navigation.PushModalAsync(new SelectedFridgeView(value));
            }
        }

        public FridgesViewModel(INavigation navigation)
        {
            Navigation = navigation;

            //TEST data to check the MVVM interaction
            Fridges = TestDataSet.Fridges;
        }
    }
}
