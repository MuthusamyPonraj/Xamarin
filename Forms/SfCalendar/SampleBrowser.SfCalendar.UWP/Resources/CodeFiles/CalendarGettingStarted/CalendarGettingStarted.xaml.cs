#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfCalendar.XForms;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfCalendar
{
	public partial class CalendarGettingStarted : SampleView
	{
		double width;

		public CalendarGettingStarted()
		{
			InitializeComponent();
			this.sampleSettings();
		}
		void sampleSettings()
		{
			width = Core.SampleBrowser.ScreenWidth;
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#F5F5F5");
			monthSettings.DateSelectionColor = Color.FromHex("#E0E0E0");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			cal.MonthViewSettings = monthSettings;
            if (Device.OS == TargetPlatform.Android)
			{
				cal.HeaderHeight = 50;
				sampleLayout.Padding = new Thickness(10, 10, 10, 10);

			}
            else if(Device.OS == TargetPlatform.Windows)
            {
				cal.HeaderHeight = 50;
				sampleLayout.Padding = new Thickness(10, 10, 10, 10);
            }
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}

			if (Device.OS == TargetPlatform.iOS)
			{
				cal.HeaderHeight = 40;
				if (Device.Idiom == TargetIdiom.Tablet)
					this.Padding = new Thickness(-20);
				sampleLayout.Padding = new Thickness(10, 10, 10, 0);
			}
			this.Padding = new Thickness(-10);
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Scale = 0.95;
			}
		}
	}
}

