using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using TaxiParkApp.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TaxiParkApp.Services
{
    class LocationDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Location> Locations { get; set; }

        public LocationDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Location>();           
        }

        public void SaveLocation(Location location)
        {
            if (location.Id != 0)
            {
                database.Update(location);
            }
            else
            {
                database.Insert(location);
            }
        }

        public void DeleteLocation(Location location)
        {
            if (location.Id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete(location);
                }
            }            
        }

        public void LoadLocations()
        {
            Locations = new ObservableCollection<Location>(database.Table<Location>());
        }

    }
}
