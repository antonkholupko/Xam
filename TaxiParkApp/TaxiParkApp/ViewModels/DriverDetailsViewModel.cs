using System;
using System.Collections.Generic;
using System.Text;
using TaxiParkApp.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using TaxiParkApp.Models;

namespace TaxiParkApp.ViewModels
{
    public class DriverDetailsViewModel : BaseViewModel
    {

        private DriversDataAccess dataAccess = new DriversDataAccess();

        public Command SaveDriverCommand { get; set; }
        public Command DeleteDriverCommand { get; set; }

        public Driver Driver { get; set; }

        public DriverDetailsViewModel(Driver driver=null)
        {
            Title = driver?.FirstName;
            Driver = driver == null ? new Driver() : driver;           

            SaveDriverCommand = new Command(async () => await ExecuteSaveDriverCommand());
            DeleteDriverCommand = new Command(async () => await ExecuteDeleteDriverCommand());
        }

        async Task ExecuteSaveDriverCommand()
        {           
            if (Validator.ValidateDriver(Driver))
            {
                dataAccess.SaveDriver(Driver);
            }            
        }

        async Task ExecuteDeleteDriverCommand()
        {
            dataAccess.DeleteDriver(Driver);
        }

    }
}
