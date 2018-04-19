using System;
using System.Collections.Generic;
using System.Text;
using TaxiParkApp.Models;
using TaxiParkApp.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using TaxiParkApp.Services;
using System.Diagnostics;

namespace TaxiParkApp.ViewModels
{
    class LocationsViewModel : BaseViewModel
    {

        public ObservableCollection<Location> Locations { get; set; }
        public Command LoadLocationsCommand { get; set; }

        public Location Location { get; set; }

        private LocationDataAccess dataAccess = new LocationDataAccess();

        public LocationsViewModel()
        {
            Title = "Locations";
            Locations = new ObservableCollection<Location>();
            LoadLocationsCommand = new Command(async () => await ExecuteLoadLocationsCommand());                       

        }

        public async Task ExecuteLoadLocationsCommand()
        {
            if (IsBusy)
                return;

            dataAccess.LoadLocations();

            IsBusy = true;

            try
            {
                Locations.Clear();
                foreach (var location in dataAccess.Locations)
                {
                    Locations.Add(location);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
