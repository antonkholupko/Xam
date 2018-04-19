using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace TaxiParkApp.Models
{
    [Table("Locations")]
    public class Location : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _city;
        [Unique, NotNull]
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                this._city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string _country;
        [NotNull]
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                this._country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        private string _latitude;
        public string Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                this._latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }
        private string _longitude;
        public string Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                this._longitude = value;
                OnPropertyChanged(nameof(Longitude));
            }
        }
        private string _temperature;
         
        public string Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                this._temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }

        private string _sunrise;
        
        public string Sunrise
        {
            get
            {
                return _sunrise;
            }
            set
            {
                this._sunrise = value;
                OnPropertyChanged(nameof(Sunrise));
            }
        }

        private string _sunset;
        
        public string Sunset
        {
            get
            {
                return _sunset;
            }
            set
            {
                this._sunset = value;
                OnPropertyChanged(nameof(Sunset));
            }
        }

        private string _wind;
        
        public string Wind
        {
            get
            {
                return _wind;
            }
            set
            {
                this._wind = value;
                OnPropertyChanged(nameof(Wind));
            }
        }

        private string _humidity;
        
        public string Humidity
        {
            get
            {
                return _humidity;
            }
            set
            {
                this._humidity = value;
                OnPropertyChanged(nameof(Humidity));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }

    }
}
