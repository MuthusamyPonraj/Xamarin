#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Xamarin.Forms.Platform.Android;

namespace SampleBrowser.Core.Android
{
    public class SampleBrowserActivity : FormsAppCompatActivity
    {
        public event EventHandler<ActivityResultEventArgs> ActivityResult;

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                if (ActivityResult != null)
                    ActivityResult(this, new ActivityResultEventArgs { Intent = data });
            }
        }
    }
}