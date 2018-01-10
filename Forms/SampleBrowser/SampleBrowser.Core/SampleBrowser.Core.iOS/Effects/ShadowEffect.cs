#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using SampleBrowser.Core.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Effects")]
[assembly: ExportEffect(typeof(ImageShadowEffect), "ImageShadowEffect")]
namespace SampleBrowser.Core.iOS
{
	public class ImageShadowEffect : PlatformEffect
	{
		public ImageShadowEffect()
		{
		}
		protected override void OnAttached()
		{
			var imageView = Control as UIImageView;
			if (imageView != null)
			{
				imageView.Layer.ShadowColor = UIColor.Black.CGColor;
				imageView.Layer.ShadowOffset = new CGSize(2, 7);
				imageView.Layer.ShadowOpacity = 0.3f;
				imageView.Layer.ShadowRadius = (nfloat)2.0;
				imageView.ClipsToBounds = false;

				//UIBezierPath shadowPath = UIBezierPath.FromRect(new CoreGraphics.CGRect(0, 0, 0, imageView.Bounds.Height));
				//imageView.Layer.ShadowColor = UIColor.Black.CGColor;
				//imageView.Layer.ShadowOffset = new CoreGraphics.CGSize(0f, 0f);
				//imageView.Layer.ShadowOpacity = 0.6f;
				//imageView.Layer.ShadowRadius = 7.0f;
				//imageView.Layer.ShadowPath = shadowPath.CGPath;
				//imageView.Layer.BorderWidth = 2.0f;
			}
		}

		protected override void OnDetached()
		{
			// Use this method if you wish to reset the control to original state
		}
	}
}
