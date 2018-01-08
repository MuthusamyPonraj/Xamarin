#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms;
using System.ComponentModel;
using Android.Graphics;
using SampleBrowser.SfPdfViewer.Droid;
using SampleBrowser.SfPdfViewer;

[assembly: ExportRenderer(typeof(SfFontButton), typeof(SfFontButtonRenderer))]
namespace SampleBrowser.SfPdfViewer.Droid
{
    public class SfFontButtonRenderer : ButtonRenderer
    {
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            Control.TextChanged += Control_TextChanged;
        }

        private void Control_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            Control.TextChanged -= Control_TextChanged;            
            Typeface font = Typeface.CreateFromAsset(Context.Assets, "PDFViewer_Android.ttf");
            Control.Typeface = font;
            Control.TextSize = 25;
        }
    }
}