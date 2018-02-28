#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SampleBrowser.SfImageEditor.iOS.ImageEditorService))]
namespace SampleBrowser.SfImageEditor.iOS
{
    public class ImageEditorService : IImageEditorDependencyService
    {
        UIImagePickerController imagePicker;

        void IImageEditorDependencyService.UploadFromCamera(ImageModel editor)
        {
            imagePicker = new UIImagePickerController();

            imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;

            imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);

            imagePicker.FinishedPickingMedia += (object sender, UIImagePickerMediaPickedEventArgs e) =>
            {
                imagePicker.DismissModalViewController(true);
                editor.SwitchView(e.OriginalImage.AsPNG().AsStream(), Navigation);
            };

            imagePicker.Canceled += (sender, evt) =>
            {
                imagePicker.DismissModalViewController(true);
            };

            var topController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (topController.PresentedViewController != null)
            {
                topController = topController.PresentedViewController;
            }
            topController.PresentViewController(imagePicker, true, null);
        }


        void IImageEditorDependencyService.UploadFromGallery(ImageModel editor)
        {
            imagePicker = new UIImagePickerController();

            imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

            imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

            imagePicker.FinishedPickingMedia += (object sender, UIImagePickerMediaPickedEventArgs e) =>
            {
                imagePicker.DismissModalViewController(true);
                editor.SwitchView(e.OriginalImage.AsPNG().AsStream(), Navigation);
            };
            imagePicker.Canceled += (sender, evt) =>
            {
                imagePicker.DismissModalViewController(true);
            };

            var topController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (topController.PresentedViewController != null)
            {
                topController = topController.PresentedViewController;
            }
            topController.PresentViewController(imagePicker, true, null);
        }
        public INavigation Navigation { get; set; }
    }
}