using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.CSharp;
using TaxiParkApp.ViewModels;
using TaxiParkApp.Models;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {
        LocationsViewModel viewModel;

        public LocationsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LocationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();           
            viewModel.LoadLocationsCommand.Execute(null);
        }

        private void To_Add_Location(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddLocationPage());
        }

        void OnLocationSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var location = args.SelectedItem as Location;
            if (location == null)
            {
                return;
            }

            Navigation.PushAsync(new LocationDetailsPage(new LocationDetailsViewModel(location)));

            // Manually deselect item.
            LocationsListView.SelectedItem = null;
        }

        /*private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(entPinCode.Text))
            {
                Weather weather = await GetWeather(entPinCode.Text);
                if (weather != null)
                {
                    txtLocation.Text = weather.Title;
                    txtTemperature.Text = weather.Temperature;
                    txtWind.Text = weather.Wind;
                    txtHumidity.Text = weather.Humidity;
                    txtSunrise.Text = weather.Sunrise;
                    txtSunset.Text = weather.Sunset;
                    btnGetWeather.Text = "Search Again";
                }
            }
        }

        


        public static async Task<Weather> GetWeather(string pinCode)
        {
            string key = "b868d322ca3370a1cb7d05e0212b271f";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + pinCode + ",by&appid=" + key + "&units=metric";
            if (key != "b868d322ca3370a1cb7d05e0212b271f")
            {
                throw new ArgumentException("Get you API key from openweathermap.org/appid and assign it in the 'key' variable.");
            }
            dynamic results = await getDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                return weather;
            }
            else
            {
                return null;
            }
        }

        public static async Task<dynamic> getDataFromService(string pQueryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(pQueryString);
            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }

    }

    //TODO: Replace to the models
    public class Weather
    {
        public string Title
        {
            get;
            set;
        }
        public string Temperature
        {
            get;
            set;
        }
        public string Wind
        {
            get;
            set;
        }
        public string Humidity
        {
            get;
            set;
        }
        public string Visibility
        {
            get;
            set;
        }
        public string Sunrise
        {
            get;
            set;
        }
        public string Sunset
        {
            get;
            set;
        }
        public Weather()
        {
            this.Title = " ";
            this.Temperature = " ";
            this.Wind = " ";
            this.Humidity = " ";
            this.Visibility = " ";
            this.Sunrise = " ";
            this.Sunset = " ";
        }
    }*/

    }
}