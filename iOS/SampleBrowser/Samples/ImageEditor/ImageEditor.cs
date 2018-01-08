#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfImageEditor.iOS;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;

namespace SampleBrowser
{
    public partial class ImageEditor : SampleView
	{
		UIButton broImageBtn;
		UIButton cameraImageBtn;
		//SfImageEditor sfImageEditor;

        public ImageEditor()
        {
			broImageBtn = new UIButton(RectangleF.Empty)
			{
				BackgroundColor = UIColor.Clear,
			};
			broImageBtn.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;

			broImageBtn.SetTitle("Choose from photos", UIControlState.Normal);
            broImageBtn.SetTitleColor(UIColor.Black,UIControlState.Normal);

			broImageBtn.TouchUpInside += (sender, e) =>
			{
				UploadFromGallery();
			};

			cameraImageBtn = new UIButton(RectangleF.Empty)
			{
				BackgroundColor = UIColor.Clear,
			};


			cameraImageBtn.SetTitle("Take a photo", UIControlState.Normal);
			cameraImageBtn.SetTitleColor(UIColor.Black, UIControlState.Normal);
			cameraImageBtn.TouchUpInside += (sender, e) =>
			{
				UploadFromCamera();
			};


			//sfImageEditor = new SfImageEditor(new CGRect(Frame.Location.X, 60, Frame.Size.Width - 6, Frame.Size.Height - 60));
			//sfImageEditor.BackgroundColor = UIColor.Gray;

			//AddSubview(sfImageEditor);

			AddSubview(cameraImageBtn);
			AddSubview(broImageBtn);
        }

		UINavigationController navigationController;

		public override void MovedToSuperview()
		{
			base.MovedToSuperview();
			var view = Superview;
			var window = UIApplication.SharedApplication.KeyWindow;
			navigationController = window.RootViewController as UINavigationController;
		}
		
		public override void LayoutSubviews()
		{

            broImageBtn.Frame = new CGRect(Bounds.GetMidX() - 100, Bounds.GetMidY() - 41, 200, 41);

            cameraImageBtn.Frame = new CGRect(Bounds.GetMidX() - 100, Bounds.GetMidY(), 200, 41);

		}

		UIImagePickerController imagePicker;

		void UploadFromCamera()
		{
			imagePicker = new UIImagePickerController();

			imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;

			imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);

			imagePicker.FinishedPickingMedia += ImagePicker_FinishedPickingMedia; ;
			imagePicker.Canceled += (sender, evt) =>
			{
				imagePicker.DismissModalViewController(true);
			};



            navigationController.PresentViewController(imagePicker, true, null);
		}

		void UploadFromGallery()
		{
			imagePicker = new UIImagePickerController();

			imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

			imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

			imagePicker.FinishedPickingMedia += ImagePicker_FinishedPickingMedia; ;
			imagePicker.Canceled += (sender, evt) =>
			{
				imagePicker.DismissModalViewController(true);
			};

             navigationController.PresentViewController(imagePicker, true, null);
		}


		void ImagePicker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			imagePicker.DismissModalViewController(true);
			navigationController.PushViewController(new ImageEditorViewController(e.OriginalImage), false);
		}

	}

	public class ImageEditorViewController: UIViewController
	{
		UIImage _image;
		
		public ImageEditorViewController(UIImage image)
		{
			_image = image;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			SfImageEditor sfImageEditor = new SfImageEditor(new CGRect(View.Frame.Location.X, 60, View.Frame.Size.Width, View.Frame.Size.Height - 60));
			sfImageEditor.Image = _image;

			this.View.AddSubview(sfImageEditor);
		}
	}
}