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
using CoreGraphics;
using Foundation;
using SampleBrowser.SfImageEditor.iOS.Renderers;
using CustomControls = SampleBrowser.SfImageEditor.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(CustomControls.CustomEditor), typeof(CustomEditorRenderer))]
namespace SampleBrowser.SfImageEditor.iOS.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        UITextView replacingControl;
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
			if (Control != null)
            {
                var element = e.NewElement as CustomControls.CustomEditor;
                replacingControl = new UITextView(Control.Bounds);
                replacingControl.Layer.BorderColor = Color.Gray.ToCGColor();
                replacingControl.Layer.CornerRadius = 20;
                replacingControl.Layer.BorderWidth = 3;
                replacingControl.TextContainerInset = new UIEdgeInsets(15, 20, 0, 20);
			    replacingControl.ResignFirstResponder();
                if (element == null)
                    return;
                replacingControl.Text = element.WatermarkText;


                replacingControl.ClearsOnInsertion = false;

                if (replacingControl.Text == element.WatermarkText)
                {
                    replacingControl.TextColor = UIColor.LightGray;
                    replacingControl.ClearsOnInsertion = true;
                }
                else{
                    replacingControl.TextColor = UIColor.Black;
                }

                replacingControl.Changed += (sender, ev) => {
                    replacingControl.TextColor = UIColor.Black;
                };
                this.SetNativeControl(replacingControl);
            }
        }
    }
}