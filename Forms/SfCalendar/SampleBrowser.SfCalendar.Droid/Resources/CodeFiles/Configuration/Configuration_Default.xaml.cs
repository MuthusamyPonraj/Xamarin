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
	public partial class Configuration_Default : SampleView
	{
		double width;
		public Configuration_Default()
		{
			InitializeComponent();

			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
			monthSettings.WeekEndTextColor = Color.FromHex("#009688");
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
			monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			monthSettings.SelectedDayTextColor = Color.Black;
			calendar.MonthViewSettings = monthSettings;
			if (Device.OS == TargetPlatform.Android)
			{
				calendar.HeaderHeight = 50;
				sampleLayout.Padding = new Thickness(10, 10, 10, 10);

			}
			else if (Device.OS == TargetPlatform.Windows)
			{
				calendar.HeaderHeight = 50;
				sampleLayout.Padding = new Thickness(10, 10, 10, 10);
			}
			if (Device.OS == TargetPlatform.Windows)
			{
				mainStack.Children.Remove(selectionmodeLayout);
			}
			//monthViewSettings();
			this.sampleSettings();
			eventsInitialization();
		}
		void eventsInitialization()
		{
			calendar.OnMonthCellLoaded += (object sender, MonthCell args) =>
			 {
				 DateTime dTime = args.Date;
				 string s = dTime.DayOfWeek.ToString();
				// if (s.Equals("Sunday", StringComparison.CurrentCultureIgnoreCase) || s.Equals("Saturday", StringComparison.CurrentCultureIgnoreCase))
				// {
				//	 args.TextColor = Color.FromHex("#0990e9");
				// }
			 };

			selectionModePicker.Items.Add("Single Selection");
			selectionModePicker.Items.Add("Multi Selection");
			selectionModePicker.SelectedIndex = 0;
			selectionModePicker.SelectedIndexChanged += (object sender, EventArgs e) =>
			 {
				 switch (selectionModePicker.SelectedIndex)
				 {
					 case 0:
						 {

							 calendar.SelectionMode = SelectionMode.SingleSelection;
						 }
						 break;
					 case 1:
						 {
							 calendar.SelectionMode = SelectionMode.MultiSelection;
						 }
						 break;

				 }
			 };
			minDatePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
			 {
				 calendar.MinDate = e.NewDate;
			 };
			maxDatePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
			 {
				 calendar.MaxDate = e.NewDate;
			 };
		}
		void monthViewSettings()
		{
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DateSelectionColor = Color.FromRgb(161, 161, 161);
			calendar.MonthViewSettings = monthSettings;
		}
		void sampleSettings()
		{
			width = Core.SampleBrowser.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}
			if (Device.OS == TargetPlatform.Android || Device.OS==TargetPlatform.Windows)
			{
				calendar.HeaderHeight = 50;
				sampleLayout.Padding = new Thickness(10, 10, 10, 10);
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Scale = 0.95;
			}
			mainStack.Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50);
			mainStack.Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10);
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				sampleLayout.Padding = new Thickness(10, 10, 10, 0);
			}
			this.Padding = new Thickness(-10);
			selectionModeLabel.WidthRequest = width / 2;
		}
		public View getContent()
		{
			return this.Content;
		}
		public View getPropertyView()
		{
			return this.PropertyView;
		}
	}
}
