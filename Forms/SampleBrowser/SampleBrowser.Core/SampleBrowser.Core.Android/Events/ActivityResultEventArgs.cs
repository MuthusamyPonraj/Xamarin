#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;

namespace SampleBrowser.Core.Android
{
    public class ActivityResultEventArgs : EventArgs
    {
        public Intent Intent
        {
            get;
            set;
        }
    }
}