using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TaxiParkApp.Models;

namespace TaxiParkApp.Services
{
    public class Validator
    {

        public static bool ValidateCar(Car car)
        {
            if (string.IsNullOrWhiteSpace(car.GovId))
            {
                MessagingCenter.Send<string>("Validation failed", "GovIdCarValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(car.Mark))
            {
                MessagingCenter.Send<string>("Validation failed", "MarkCarValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(car.Model))
            {
                MessagingCenter.Send<string>("Validation failed", "ModelCarValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(car.Color))
            {
                MessagingCenter.Send<string>("Validation failed", "ColorCarValidationFailed");
                return false;
            }

            MessagingCenter.Send<string>("Validation failed", "SuccessfulCarValidation");

            return true;
        }
        
        public static bool ValidateDriver(Driver driver)
        {
            if (string.IsNullOrWhiteSpace(driver.FirstName))
            {
                MessagingCenter.Send<string>("Validation failed", "FirstNameDriverValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(driver.LastName))
            {
                MessagingCenter.Send<string>("Validation failed", "LastNameDriverValidationFailed");
                return false;
            }           

            if (string.IsNullOrWhiteSpace(driver.Country))
            {
                MessagingCenter.Send<string>("Validation failed", "CountryDriverValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(driver.City))
            {
                MessagingCenter.Send<string>("Validation failed", "CityDriverValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(driver.Address))
            {
                MessagingCenter.Send<string>("Validation failed", "AddressDriverValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(driver.Phone))
            {
                MessagingCenter.Send<string>("Validation failed", "PhoneDriverValidationFailed");
                return false;
            }

            MessagingCenter.Send<string>("Validation failed", "SuccessfulDriverValidation");

            return true;
        }

        public static bool ValidateLocation(Location location)
        {
            if (string.IsNullOrWhiteSpace(location.City))
            {
                MessagingCenter.Send<string>("Validation failed", "CityLocationValidationFailed");
                return false;
            }

            if (string.IsNullOrWhiteSpace(location.Country))
            {
                MessagingCenter.Send<string>("Validation failed", "CountryLocationValidationFailed");
                return false;
            }

            MessagingCenter.Send<string>("Validation failed", "SuccessfulLocationValidation");

            return true;
        }

    }
}
