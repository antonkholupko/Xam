using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiParkApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationDetailsPage : ContentPage
    {
        LocationDetailsViewModel viewModel;      

        public LocationDetailsPage(LocationDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        private async void Update_Btn(object sender, EventArgs e)
        {          
            if (CrossConnectivity.Current.IsConnected)
            {
                viewModel.UpdateLocationCommand.Execute(null);
            } else
            {
                await DisplayAlert("No Internet Connection", "Please check your internet connection", "OK");
            }
        }

        private async void Delete_Btn(object sender, EventArgs e)
        {
            viewModel.DeleteLocationCommand.Execute(null);
            await Navigation.PopAsync();
        }
    }
}