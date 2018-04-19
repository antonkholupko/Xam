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
    public partial class EditCarPage : ContentPage
    {   
        CarDetailsViewModel viewModel;

        public EditCarPage(CarDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            MessagingCenter.Subscribe<string>(this, "GovIdCarValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill government id field", "OK");
            });

            MessagingCenter.Subscribe<string>(this, "MarkCarValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill mark field", "OK");
            });

            MessagingCenter.Subscribe<string>(this, "ModelCarValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill model field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "ColorCarValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill color field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "SuccessfulCarValidation", (args) =>
            {
                //Navigation.PopAsync();                
                Navigation.RemovePage(this);
            });

        }

        private async void EditCarBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.SaveCarCommand.Execute(null);                       
        }
    }
}