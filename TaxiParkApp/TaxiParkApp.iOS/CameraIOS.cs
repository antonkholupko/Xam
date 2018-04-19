using System;
using AVFoundation;
using Foundation;
using UIKit;
using Xamarin.Forms;
using CoreGraphics;
using TaxiParkApp.Services;

[assembly: Dependency(typeof(TaxiParkApp.iOS.CameraIOS))]
namespace TaxiParkApp.iOS
{
    public class CameraIOS : GalleryInterface
    {
        public CameraIOS()
        {
        }

        public void BringUpPhotoGallery()
        {
            var imagePicker = new UIImagePickerController {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            imagePicker.AllowsEditing = true;

            //Make sure we have the root view controller which will launch the photo gallery 
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }

            //Show the image gallery
            vc.PresentViewController(imagePicker, true, null);

            //call back for when a picture is selected and finished editing
            imagePicker.FinishedPickingMedia += (sender, e) =>
            {
                ///string url = e.Info[UIImagePickerController.ImageUrl] as NSString;
                var url = e.Info[UIImagePickerController.ImageUrl] as NSUrl;                
                if (url != null)
                {
                    MessagingCenter.Send<string>(url.Path, "ImageSelected"); // url.Relative

                }

                /* UIImage originalImage = e.Info[UIImagePickerController.EditedImage] as UIImage;
                 if (originalImage != null)
                 {
                     //Got the image now, convert it to byte array to send back up to the forms project
                     var pngImage = originalImage.AsPNG();

                     MessagingCenter.Send<string>(url, "ImageSelected");

                 }*/

                //Close the image gallery on the UI thread
                Device.BeginInvokeOnMainThread(() =>
                {
                    vc.DismissViewController(true, null);
                });
            };

            //Cancel button callback from the image gallery
            imagePicker.Canceled += (sender, e) => vc.DismissViewController(true, null);
        }
    }
}