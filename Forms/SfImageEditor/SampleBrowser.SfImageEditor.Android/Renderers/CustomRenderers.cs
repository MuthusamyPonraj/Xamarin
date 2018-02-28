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

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomControls = SampleBrowser.SfImageEditor.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(CustomControls.CustomEditor), typeof(SampleBrowser.SfImageEditor.Droid.Renderers.CustomEditorRenderer))]
[assembly:ExportRenderer(typeof(CustomControls.RoundedColorButton), typeof(SampleBrowser.SfImageEditor.Droid.Renderers.ColorButtonRenderer))]
[assembly: ExportRenderer(typeof(CustomControls.CustomButton), typeof(SampleBrowser.SfImageEditor.Droid.Renderers.CustomButtonRenderer))]

namespace SampleBrowser.SfImageEditor.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var element = (CustomControls.CustomEditor)e.NewElement;
                Control.Hint = element.WatermarkText;
                Control.SetHintTextColor(Color.White.ToAndroid());
				int density = (int)Context.Resources.DisplayMetrics.Density;
                Control.SetPadding(10 * density, 10 * density, 0, 0);
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(60);
                gd.SetStroke(2, Color.LightGray.ToAndroid());
                this.Control.SetBackground(gd);
            }
        }
    }

    public class ColorButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var element = (CustomControls.RoundedColorButton)e.NewElement;
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(30);
                gd.SetColor(element.BackgroundColor.ToAndroid());
                this.Control.SetBackground(gd);
            }
        }
    }


    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var element = (CustomControls.CustomButton)e.NewElement;
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(0);
                gd.SetColor(element.BackgroundColor.ToAndroid());
                this.Control.SetBackground(gd);
            }
        }
    }


}