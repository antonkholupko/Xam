using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaxiParkApp.ViewModels;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLocationPage : ContentPage
    {

        LocationDetailsViewModel viewModel;

        public AddLocationPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LocationDetailsViewModel();

            MessagingCenter.Subscribe<string>(this, "CityLocationValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill city field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "CountryLocationValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill color field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "SuccessfulLocationValidation", (args) =>
            {
                Navigation.RemovePage(this);
            });
        }

        private async void AddLocationBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.SaveLocationCommand.Execute(null);
            await Navigation.PopAsync();
        }

    }
}