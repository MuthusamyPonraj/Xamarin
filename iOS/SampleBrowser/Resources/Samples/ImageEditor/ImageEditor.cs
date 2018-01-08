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

namespace SampleBrowser
{
	public class ImageEditor: SampleView
	{
		
        SfImageEditor editor;
		public override void LayoutSubviews ()
		{
            editor = new SfImageEditor(new CGRect(Frame.Location.X, 60, Frame.Size.Width - 6, Frame.Size.Height - 60));
            AddSubview(editor);
        }
		public ImageEditor() 
		{

		}
	}


}

