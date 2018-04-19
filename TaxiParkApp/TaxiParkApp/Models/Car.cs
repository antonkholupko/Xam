using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace TaxiParkApp.Models
{
    [Table("Cars")]
    public class Car : INotifyPropertyChanged
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

        private string _govId;
        [Unique, NotNull]
        public string GovId
        {
            get
            {
                return _govId;
            }
            set
            {
                this._govId = value;
                OnPropertyChanged(nameof(GovId));
            }
        }

        private string _mark;
        [NotNull]
        public string Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                this._mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }

        private string _model;
        [NotNull]
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                this._model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        private string _color;
        [NotNull]
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                this._color = value;
                OnPropertyChanged(nameof(Color));
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
