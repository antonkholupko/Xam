using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiParkApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaxiParkApp.Services;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDriverPage : ContentPage
    {
        DriverDetailsViewModel viewModel;

        public EditDriverPage(DriverDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            MessagingCenter.Subscribe<string>(this, "ImageSelected", (args) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    viewModel.Driver.Photo = args;
                });
            });

            MessagingCenter.Subscribe<string>(this, "FirstNameDriverValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill first name field", "OK");
            });

            MessagingCenter.Subscribe<string>(this, "LastNameDriverValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill last name field", "OK");
            });

            MessagingCenter.Subscribe<string>(this, "CountryDriverValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill country field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "CityDriverValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill city field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "AddressDriverValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill address field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "PhoneDriverValidationFailed", (args) =>
            {
                DisplayAlert("Validation faild", "Please fill phone field", "OK");
            });
            MessagingCenter.Subscribe<string>(this, "SuccessfulDriverValidation", (args) =>
            {
                Navigation.RemovePage(this);
            });

        }

        private async void EditDriverBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.SaveDriverCommand.Execute(null);            
        }

        public void AddPhotoBtn_Clicked(object sender, EventArgs args)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //Open photo picker from galery

                DependencyService.Get<GalleryInterface>().BringUpPhotoGallery();
            });
        }

    }
}