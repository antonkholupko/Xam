using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TaxiParkApp.Models;
using TaxiParkApp.ViewModels;
using TaxiParkApp.Views;

namespace TaxiParkApp.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            
		}

        void OpenDriversListPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DriversPage());
        }

        void OpenCarsListPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CarsPage());
        }

        private void OpenWeatherPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationsPage());
        }
    }
}
