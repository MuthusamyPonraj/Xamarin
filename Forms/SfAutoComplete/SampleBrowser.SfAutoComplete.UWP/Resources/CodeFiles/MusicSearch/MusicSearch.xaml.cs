#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public partial class MusicSearch
	{
		public MusicSearch()
		{
			InitializeComponent();

			this.BindingContext = new MusicViewModel();

            if (Device.OS == TargetPlatform.iOS)
            {
                MusicICon_B.VerticalTextAlignment = TextAlignment.Center;
                SearchedItem.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_F.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_M.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_R.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_E.VerticalTextAlignment = TextAlignment.Center;
                MusicIcon_V.VerticalTextAlignment = TextAlignment.Center;

            }

		}
	}
}
