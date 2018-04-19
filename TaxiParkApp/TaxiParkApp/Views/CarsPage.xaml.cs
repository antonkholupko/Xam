using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaxiParkApp.ViewModels;
using TaxiParkApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxiParkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsPage : ContentPage
    {
        CarsViewModel viewModel;

        public CarsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CarsViewModel();            
        }

        void OnCarSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var car = args.SelectedItem as Car;
            if (car == null)
            {
                return;
            }

            Navigation.PushAsync(new CarDetailsPage(new CarDetailsViewModel(car)));

            // Manually deselect item.
            CarsListView.SelectedItem = null;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Cars.Count == 0)
            viewModel.LoadCarsCommand.Execute(null);
        }

        private void To_Add_Car(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCarPage());            
        }
    }
}