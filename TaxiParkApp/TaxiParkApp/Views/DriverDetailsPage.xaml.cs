using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

using TaxiParkApp.ViewModels;
using TaxiParkApp.Services;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverDetailsPage : ContentPage
    {
        //Maps
        //public Map StockistMap;

        DriverDetailsViewModel viewModel;        

        public DriverDetailsPage(DriverDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;            

        }

        private async void UploadMap(object sender, EventArgs e)
        {
            String fullAddress = viewModel.Driver.Country + " " + viewModel.Driver.City + " " + viewModel.Driver.Address;
            if (CrossConnectivity.Current.IsConnected)
            {
                Position position = await LocationService.GeoLocAsync(fullAddress);

                var pin = new Pin()
                {
                    Position = position,
                    Label = "Driver's address"
                };

                MyMap.MoveToRegion(
                    MapSpan.FromCenterAndRadius(position, Distance.FromMeters(400)));
                MyMap.Pins.Add(pin);                
            } else
            {
                await DisplayAlert("Locations are disabled", "To show locations, please enable internet connection", "OK");
            }
        }

        private void ToEditDriverBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditDriverPage(viewModel)); 
        }

        private async void DeleteDriverBtn_Clicked(object sender, EventArgs e)
        {
            viewModel.DeleteDriverCommand.Execute(null);
            await Navigation.PopAsync(); 
        }

    }
}