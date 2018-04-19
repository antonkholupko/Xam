using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace TaxiParkApp.Models
{
    [Table("Drivers")]
    public class Driver: INotifyPropertyChanged
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

        private string _firstName;
        [NotNull]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                this._firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        [NotNull]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                this._lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _photo;
        public string Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                this._photo = value;
                OnPropertyChanged(nameof(Photo));
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

        private string _city;
        [NotNull]
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

        private string _address;
        [NotNull]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                this._address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _phone;
        [NotNull]
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                this._phone = value;
                OnPropertyChanged(nameof(Phone));
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
