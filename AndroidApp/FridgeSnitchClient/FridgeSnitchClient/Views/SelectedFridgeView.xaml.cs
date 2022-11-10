using FridgeSnitchClient.Models;
using FridgeSnitchClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FridgeSnitchClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedFridgeView : ContentPage
    {
        public SelectedFridgeView(FridgeModel selectedFridge)
        {
            InitializeComponent();
            BindingContext = new SelectedFridgeViewModel(selectedFridge);
        }
    }
}