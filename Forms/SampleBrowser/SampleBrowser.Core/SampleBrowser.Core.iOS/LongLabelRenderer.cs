#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using SampleBrowser.Core.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LongLabel), typeof(LongLabelRenderer))]

namespace SampleBrowser.Core.iOS
{
	public class LongLabelRenderer : LabelRenderer
	{
		public LongLabelRenderer()
		{
		}
         
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				UILabel label = Control;
                label.TextColor = UIColor.Red;
				label.Lines = 10000;
			}
		}
	}
}