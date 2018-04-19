using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using TaxiParkApp.Services;
using TaxiParkApp.Models;

namespace TaxiParkApp.ViewModels
{
    public class CarDetailsViewModel : BaseViewModel
    {
        private CarsDataAccess dataAccess = new CarsDataAccess();

        public Command SaveCarCommand { get; set; }
        public Command DeleteCarCommand { get; set; }
        public Car Car { get; set; }               

        public CarDetailsViewModel()
        {
            Car = new Car();

            SaveCarCommand = new Command(async () => await ExecuteSaveCarCommand());
            DeleteCarCommand = new Command(async () => await ExecuteDeleteCarCommand());
        }

        public CarDetailsViewModel(Car car)
        {
            Car = car;

            SaveCarCommand = new Command(async () => await ExecuteSaveCarCommand());
            DeleteCarCommand = new Command(async () => await ExecuteDeleteCarCommand());
        }

        async Task ExecuteSaveCarCommand()
        {
            if (Validator.ValidateCar(Car))
            {
                dataAccess.SaveCar(Car);
            }            
        }

        async Task ExecuteDeleteCarCommand()
        {
            dataAccess.DeleteCar(Car);
        }               

    }
}
