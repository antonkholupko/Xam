using SQLite;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TaxiParkApp.Models;

namespace TaxiParkApp.Services
{
    class CarsDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Car> Cars { get; set; }

        public CarsDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Car>();
        }
    
        public void SaveCar(Car car)
        {
            if (car.Id != 0)
            {
                database.Update(car);
            }
            else
            {
                database.Insert(car);                
            }
        }

        public void DeleteCar(Car car)
        {            
            if (car.Id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete(car);
                }
            }                        
        }

        public void LoadCars()
        {
            Cars = new ObservableCollection<Car>(database.Table<Car>());
        }

    }
}
