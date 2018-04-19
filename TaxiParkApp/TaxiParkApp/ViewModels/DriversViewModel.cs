using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TaxiParkApp.Models;
using TaxiParkApp.Services;
using Xamarin.Forms;

namespace TaxiParkApp.ViewModels
{
    class DriversViewModel : BaseViewModel
    {

        public ObservableCollection<Driver> Drivers { get; set; }
        public Command LoadDriversCommand { get; set; }
        public Command AddDriverCommand { get; set; }

        public Driver Driver{ get; set; }

        private DriversDataAccess dataAccess = new DriversDataAccess();

        public DriversViewModel()
        {
            Title = "Drivers";
            Drivers = new ObservableCollection<Driver>();
            LoadDriversCommand = new Command(async () => await ExecuteLoadDriversCommand());            

            Driver = new Driver();
        }

        async Task ExecuteLoadDriversCommand()
        {
            if (IsBusy)
                return;
        
            dataAccess.LoadDrivers();

            IsBusy = true;

            try
            {                
                Drivers.Clear();
                foreach (var driver in dataAccess.Drivers)
                {
                    Drivers.Add(driver);
                }
                /*
                var dr = dataAccess.GetFilteredCustomers();
                IEnumerator<Driver> en =  dr.GetEnumerator();
                while (en.MoveNext())
                {
                    Drivers.Add(en.Current);
                }*/
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
