using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Xamarin.Forms;

using TaxiParkApp.Services;

[assembly: Dependency(typeof(TaxiParkApp.Droid.CameraAndroid))]
namespace TaxiParkApp.Droid
{
    class CameraAndroid : GalleryInterface
    {
        public CameraAndroid()
        {
        }        

        public void BringUpPhotoGallery()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);

            ((Activity)Forms.Context).StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 1);                       
            
        }
    }
}