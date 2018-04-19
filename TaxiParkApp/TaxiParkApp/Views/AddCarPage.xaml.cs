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
    public partial class AddCarPage : ContentPage
    {
        CarDetailsViewModel viewModel;

        public AddCarPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CarDetailsViewModel();

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
                Navigation.RemovePage(this);
            });
        }

        private void AddCarBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.SaveCarCommand.Execute(null);            
        }

    }
}
 