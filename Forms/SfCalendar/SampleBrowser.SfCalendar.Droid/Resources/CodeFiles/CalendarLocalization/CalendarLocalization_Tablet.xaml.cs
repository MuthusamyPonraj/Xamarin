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
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfCalendar
{
	public partial class CalendarLocalization_Tablet : SampleView
	{
		double width;
		StackLayout view;
		Label localeLabel;
		Picker localePicker;
		StackLayout mainStack;
		int local = 0;
		Button closeButton;
		public CalendarLocalization_Tablet()
		{
			InitializeComponent();
			TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
			tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
			temp.GestureRecognizers.Add(tap_Gestue_Prob);

			getPropertiesWindow();
			this.sampleSettings();
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
			monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			monthSettings.SelectedDayTextColor = Color.Black;
			calendar.MonthViewSettings = monthSettings;
			calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
			Property_Button.Clicked += Property_Button_Click;
		}

		void sampleSettings()
		{
			width = Core.SampleBrowser.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}
			if (Device.OS == TargetPlatform.Android)
				calendar.HeaderHeight = 60;
			this.Padding = new Thickness(-10);
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				sampleLayout.Padding = new Thickness(0, 0, 0, 90);
			}

			if (localeLabel != null && mainStack != null)
			{
				localeLabel.WidthRequest = width / 2;
				mainStack.Spacing = Device.OnPlatform(iOS: 10, Android: 0, WinPhone: 50);
				mainStack.Padding = Device.OnPlatform(iOS: 10, Android: 0, WinPhone: 10);
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Scale = 0.95;
			}
		}
		public void Property_Button_Click(object c, EventArgs e)
		{
			getPropertiesWindow();
		}
		public void localeLabel_SelectionIndexChanged(object c, EventArgs e)
		{
			switch (localePicker.SelectedIndex)
			{
				case 0:
					{
						calendar.Locale = new System.Globalization.CultureInfo("zh-CN");
						local = 0;
					}
					break;
				case 1:
					{
						calendar.Locale = new System.Globalization.CultureInfo("es-AR");
						local = 1;
					}
					break;
				case 2:
					{
						calendar.Locale = new System.Globalization.CultureInfo("en-US");
						local = 2;
					}
					break;
				case 3:
					{
						calendar.Locale = new System.Globalization.CultureInfo("fr-CA");
						local = 3;
					}
					break;
			}
		}
		void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
		{
			getPropertiesWindow();
		}

		public View getContent()
		{
			return this.Content;
		}
		public void Close_Button(object c, EventArgs e)
		{
			closeAction();
		}
		public void getPropertiesWindow()
		{

			view = new StackLayout();
			view.BackgroundColor = Color.FromRgb(250, 250, 250);
			view.HeightRequest = Property_Windows.HeightRequest;

			StackLayout propertyLayout = new StackLayout();
			propertyLayout.Orientation = StackOrientation.Horizontal;
			propertyLayout.Padding = new Thickness(10, 0, 0, 0);
			propertyLayout.BackgroundColor = Color.FromRgb(230, 230, 230);
			TapGestureRecognizer tab = new TapGestureRecognizer();
			tab.Tapped += tab_Tapped;
			propertyLayout.GestureRecognizers.Add(tab);
			Label propertyLabel = new Label();
			propertyLabel.Text = "OPTIONS";
			propertyLabel.WidthRequest = 150;
			propertyLabel.VerticalOptions = LayoutOptions.Center;
			propertyLabel.HorizontalOptions = LayoutOptions.Start;
			propertyLabel.FontFamily = "Helvetica";
			propertyLabel.FontSize = 20;

			closeButton = new Button();

			if (Device.OS == TargetPlatform.iOS)
			{
				closeButton.Text = "X";
				closeButton.TextColor = Color.FromRgb(51, 153, 255);
			}
			else
				closeButton.Image = "sfclosebutton.png";
			closeButton.Clicked += Close_Button;

			temp.BackgroundColor = Color.FromRgb(230, 230, 230);
			closeButton.BackgroundColor = Color.FromRgb(230, 230, 230);
			Property_Button.BackgroundColor = Color.FromRgb(230, 230, 230);

			closeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
			propertyLayout.Children.Add(propertyLabel);
			propertyLayout.Children.Add(closeButton);

			StackLayout emptyLayout = new StackLayout();
			emptyLayout.Orientation = StackOrientation.Vertical;
			emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
			emptyLayout.Padding = new Thickness(40, 20, 40, 40);

			mainStack = new StackLayout();
			mainStack.Orientation = StackOrientation.Horizontal;
			mainStack.HorizontalOptions = LayoutOptions.Center;

			localeLabel = new Label();
			localeLabel.Text = "Locale";
			localeLabel.WidthRequest = 150;
			localeLabel.VerticalOptions = LayoutOptions.Center;
			localeLabel.HorizontalOptions = LayoutOptions.Start;
			localeLabel.FontFamily = "Helvetica";
			localeLabel.FontSize = 18;

			localePicker = new Picker();
			localePicker.HorizontalOptions = LayoutOptions.End;
			localePicker.VerticalOptions = LayoutOptions.Center;
			localePicker.WidthRequest = 150;
			localePicker.Items.Add("Chinese");
			localePicker.Items.Add("Spanish");
			localePicker.Items.Add("English");
			localePicker.Items.Add("French");
			localePicker.SelectedIndex = local;
			localePicker.SelectedIndexChanged += localeLabel_SelectionIndexChanged;

			mainStack.Children.Add(localeLabel);
			mainStack.Children.Add(localePicker);
			emptyLayout.Children.Add(mainStack);

			view.Children.Add(propertyLayout);
			view.Children.Add(emptyLayout);

			Property_Windows.Children.Insert(0, view);
			Property_Windows.Children.Remove(temp);


		}


		void tab_Tapped(object sender, EventArgs e)
		{
			closeAction();

		}
		public void closeAction()
		{
			view.BackgroundColor = Color.White;
			Property_Windows.Children.Add(temp);
			Property_Windows.Children.Remove(view);

		}
	}
}



