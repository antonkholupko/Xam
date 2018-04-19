using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaxiParkApp.ViewModels;
using TaxiParkApp.Models;
using TaxiParkApp.Services;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriversPage : ContentPage
    {        
        DriversViewModel viewModel;        

        public DriversPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DriversViewModel();
        }

        void OnDriverSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var driver = args.SelectedItem as Driver;
            if (driver == null)
            {
                return;
            }

            Navigation.PushAsync(new DriverDetailsPage(new DriverDetailsViewModel(driver)));

            // Manually deselect item.
            DriversListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadDriversCommand.Execute(null);
        }

        private void To_Add_Driver(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDriverPage());
        }
    }
}



/*
        private DriversDataAccess dataAccess;

        public DriversPage()
        {
            InitializeComponent();
            // An instance of the CustomersDataAccessClass
            // that is used for data-binding and data access
            this.dataAccess = new DriversDataAccess();
        }
        // An event that is raised when the page is shown
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // The instance of CustomersDataAccess
            // is the data binding source
            this.BindingContext = this.dataAccess;
        }
        // Save any pending changes
        private void OnSaveClick(object sender, EventArgs e)
        {
            this.dataAccess.SaveAllCustomers();
        }
        // Add a new customer to the Customers collection
        private void OnAddClick(object sender, EventArgs e)
        {
            this.dataAccess.AddNewCustomer();
        }
        // Remove the current customer
        // If it exist in the database, it will be removed
        // from there too
        private void OnRemoveClick(object sender, EventArgs e)
        {
            var currentCustomer =
              this.DriversView.SelectedItem as Driver;
            if (currentCustomer != null)
            {
                this.dataAccess.DeleteCustomer(currentCustomer);
            }
        }
        // Remove all customers
        // Use a DisplayAlert object to ask the user's confirmation
        private async void OnRemoveAllClick(object sender, EventArgs e)
        {
            if (this.dataAccess.Drivers.Any())
            {
                var result =
                  await DisplayAlert("Confirmation",
                  "Are you sure? This cannot be undone",
                  "OK", "Cancel");
                if (result == true)
                {
                    this.dataAccess.DeleteAllCustomers();
                    this.BindingContext = this.dataAccess;
                }
            }
        }

        */
