using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaxiParkApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarDetailsPage : ContentPage
    {
        CarDetailsViewModel viewModel;

        public CarDetailsPage(CarDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        private void ToEditCarBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditCarPage(viewModel));
        }

        private async void DeleteCarBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.DeleteCarCommand.Execute(null);            
            await Navigation.PopAsync();
        }
    }
}