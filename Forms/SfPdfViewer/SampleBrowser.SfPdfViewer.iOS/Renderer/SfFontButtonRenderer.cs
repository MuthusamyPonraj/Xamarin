#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using SampleBrowser.SfPdfViewer;
using SampleBrowser.SfPdfViewer.iOS;

[assembly: ExportRenderer(typeof(SfFontButton), typeof(SfFontButtonRenderer))]
namespace SampleBrowser.SfPdfViewer.iOS
{
	public class SfFontButtonRenderer : ButtonRenderer
	{


		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			double? fontSize = e.NewElement?.FontSize;
			UIFont font = UIFont.FromName("PDFViewer_IOS", (int)fontSize);
			Control.Font = font;
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName.Equals("Text"))
			{
				Label label = sender as Label;
				UIFont font = UIFont.FromName("PDFViewer_IOS", 50);
				Control.Font = font;
				Control.Font.WithSize(35);

			}
		}
	}
}