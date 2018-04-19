using System;
using System.Collections.Generic;
using System.Text;
using TaxiParkApp.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using TaxiParkApp.Models;
using Xamarin.Forms.Maps;
using Plugin.Connectivity;

namespace TaxiParkApp.ViewModels
{
    public class LocationDetailsViewModel : BaseViewModel
    {
        private LocationDataAccess dataAccess = new LocationDataAccess();

        public Command SaveLocationCommand { get; set; }
        public Command UpdateLocationCommand { get; set; }
        public Command DeleteLocationCommand { get; set; }

        public Location Location { get; set; }

        public LocationDetailsViewModel(Location location)
        {            
            Location = location;        
            SaveLocationCommand = new Command(async () => await ExecuteSaveLocationCommand());
            UpdateLocationCommand = new Command(async () => await ExecuteUpdateLocationCommand());
            DeleteLocationCommand = new Command(async () => await ExecuteDeleteLocationCommand());
        }

        public LocationDetailsViewModel()
        {
            Location = new Location();

            SaveLocationCommand = new Command(async () => await ExecuteSaveLocationCommand());            
        }

        async Task ExecuteSaveLocationCommand()
        {           
            if (CrossConnectivity.Current.IsConnected)
            {
                setLatitudeLongitude(Location);
            }
            if (Location.City != null && Location.Country != null && !Location.City.Equals("") && !Location.Country.Equals("")) {
                dataAccess.SaveLocation(Location);
            } else
            {
                MessagingCenter.Send<string>("Validation failed", "SaveLocationFailed");
            }
        }

        async Task ExecuteUpdateLocationCommand()
        {
            string key = "b868d322ca3370a1cb7d05e0212b271f";
            if (Location.Latitude == null && Location.Longitude == null && CrossConnectivity.Current.IsConnected)
            {
                setLatitudeLongitude(Location);
            }
            if (Location.Latitude != null && Location.Longitude != null && CrossConnectivity.Current.IsConnected)
            {
                string queryString = "http://api.openweathermap.org/data/2.5/weather?lat=" + Location.Latitude + "&lon=" + Location.Longitude + "&appid=" + key + "&units=metric";
                if (key != "b868d322ca3370a1cb7d05e0212b271f")
                {
                    throw new ArgumentException("Get you API key from openweathermap.org/appid and assign it in the 'key' variable.");
                }

                dynamic results = await LocationService.getDataFromWeatherService(queryString).ConfigureAwait(false);

                if (results["weather"] != null)
                {                    
                    Location.Temperature = (string)results["main"]["temp"] + " С";
                    DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                    DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                    Location.Sunrise = sunrise.ToString() + " UTC";
                    Location.Sunset = sunset.ToString() + " UTC";
                    Location.Wind = (string)results["wind"]["speed"] + " kmh";
                    Location.Humidity = (string)results["main"]["humidity"] + " %";
                    dataAccess.SaveLocation(Location);
                }
            }
        }

        async Task ExecuteDeleteLocationCommand()
        {
            dataAccess.DeleteLocation(Location);
        }

        private async void setLatitudeLongitude(Location loc)
        {
            String address = loc.City + " " + loc.Country;
            Position position = await LocationService.GeoLocAsync(address);
            loc.Latitude = position.Latitude.ToString();
            loc.Longitude = position.Longitude.ToString();
        }

    }

}

