using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using TaxiParkApp.Services;

using TaxiParkApp.Models;

namespace TaxiParkApp.ViewModels
{
    class CarsViewModel : BaseViewModel
    {

        public ObservableCollection<Car> Cars { get; set; }
        public Command LoadCarsCommand { get; set; }        
        public Car Car { get; set; }

        private CarsDataAccess dataAccess = new CarsDataAccess();

        public CarsViewModel()
        {
            Title = "Cars";
            Cars = new ObservableCollection<Car>();
            LoadCarsCommand = new Command(async () => await ExecuteLoadCarsCommand());

            Car = new Car();           

        }

        async Task ExecuteLoadCarsCommand()
        {
            if (IsBusy)
                return;

            dataAccess.LoadCars();

            IsBusy = true;

            try
            {
                Cars.Clear();                
                foreach (var car in dataAccess.Cars)
                {
                    Cars.Add(car);
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
