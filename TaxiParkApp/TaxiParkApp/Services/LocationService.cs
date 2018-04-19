using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using System.Net.Http;
using Microsoft.CSharp;
using Newtonsoft.Json;

namespace TaxiParkApp.Services
{
    class LocationService
    {

        public async static Task<Position> GeoLocAsync(String address)
        {           
            if (address == null || address.Length == 0)
            {
                address = "Anneessens 1000 Brussels, Belgium";
            }
            IEnumerable<Position> approximateLocation = await new Geocoder().GetPositionsForAddressAsync(address);

            foreach (var pos in approximateLocation)
            {
                return pos;
            }

            return new Position();
        }

        public static async Task<dynamic> getDataFromWeatherService(string pQueryString)
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
}
