using System;
using System.Text;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using TaxiParkApp.Models;

namespace TaxiParkApp.Services
{
    class DriversDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Driver> Drivers { get; set; }

        public DriversDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Driver>();            
        }

        public void SaveDriver(Driver driver)
        {
            if (driver.Id != 0)
            {
                database.Update(driver);
            }
            else
            {
                database.Insert(driver);
            }
        }      

        public void DeleteDriver(Driver driver)
        {
            if (driver.Id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete(driver);
                }
            }            
        }

        public void LoadDrivers()
        {
            Drivers = new ObservableCollection<Driver>(database.Table<Driver>());
        }       
    }
}
