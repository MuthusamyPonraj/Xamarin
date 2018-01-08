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
	public partial class Configuration_Tablet : SampleView
	{
		double width;
		StackLayout view;
		Button closeButton;
		Picker selectionModePicker;
		Label selectionModeLabel;
		DatePicker minDatePicker, maxDatePicker;
		int selection = 0;
		DateTime min = new DateTime(2012, 1, 1);
		DateTime max = new DateTime(2018, 12, 1);

		public Configuration_Tablet()
		{
			InitializeComponent();
			TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
			tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
			temp.GestureRecognizers.Add(tap_Gestue_Prob);
			getPropertiesWindow();
			sampleSettings();
			getmonthSettings();
			eventsInitialization();
		}
		void eventsInitialization()
		{
			calendar.OnMonthCellLoaded += (object sender, MonthCell args) =>
			 {
				 DateTime dTime = args.Date;
				 string s = dTime.DayOfWeek.ToString();
				 if (s.Equals("Sunday", StringComparison.CurrentCultureIgnoreCase) || s.Equals("Saturday", StringComparison.CurrentCultureIgnoreCase))
				 {
					 args.TextColor = Color.FromHex("#0990e9");
				 }
			 };
			Property_Button.Clicked += Property_Button_Click;
		}
		void getmonthSettings()
		{
			MonthViewSettings monthSettings = new MonthViewSettings();
			monthSettings.DayHeight = 50;
			monthSettings.WeekEndTextColor = Color.FromHex("#009688");
            monthSettings.HeaderBackgroundColor = Color.White;
			monthSettings.InlineBackgroundColor = Color.FromHex("#EEEEEE");
			monthSettings.DateSelectionColor = Color.FromHex("#EEEEEE");
			monthSettings.TodayTextColor = Color.FromHex("#2196F3");
			monthSettings.SelectedDayTextColor = Color.Black;
			calendar.MonthViewSettings = monthSettings;
		}
		void sampleSettings()
		{
			this.Padding = new Thickness(-10);
			if (Device.OS == TargetPlatform.iOS)
			{
				calendar.HeaderHeight = 40;
				this.Padding = new Thickness(-10, -30, -10, -10);
			}
			if (Device.OS == TargetPlatform.Android)
				calendar.HeaderHeight = 60;
			width = Core.SampleBrowser.ScreenWidth;
			if (Device.Idiom == TargetIdiom.Tablet)
			{
				width /= 2;
			}
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
			emptyLayout.Padding = new Thickness(40, 10, 40, 40);

			StackLayout selectionLayout = new StackLayout();
			selectionLayout.Orientation = StackOrientation.Horizontal;
			selectionLayout.HorizontalOptions = LayoutOptions.Center;
			selectionLayout.Padding = new Thickness(10, 0, 0, 10);
			selectionLayout.HeightRequest = 70;
			selectionModeLabel = new Label();
			selectionModeLabel.Text = "Selection Mode";
			selectionModeLabel.WidthRequest = 150;
			selectionModeLabel.VerticalOptions = LayoutOptions.Center;
			selectionModeLabel.HorizontalOptions = LayoutOptions.Start;
			selectionModeLabel.FontFamily = "Helvetica";
			selectionModeLabel.FontSize = 16;

			selectionModePicker = new Picker();
			selectionModePicker.Items.Add("SingleSelection");
			selectionModePicker.Items.Add("MultiSelection");
			selectionModePicker.VerticalOptions = LayoutOptions.Center;
			selectionModePicker.HorizontalOptions = LayoutOptions.End;
			selectionModePicker.SelectedIndex = selection;
			selectionModePicker.WidthRequest = 180;
			selectionModePicker.SelectedIndexChanged += selectionModePicker_Changed;
			selectionLayout.Children.Add(selectionModeLabel);
			selectionLayout.Children.Add(selectionModePicker);

			StackLayout minLayout = new StackLayout();
			minLayout.Orientation = StackOrientation.Horizontal;
			minLayout.HorizontalOptions = LayoutOptions.Center;
			minLayout.Padding = new Thickness(10, 10, 0, 10);
			minLayout.HeightRequest = 70;
			Label mindate = new Label();
			mindate.Text = "Min Date";
			mindate.WidthRequest = 150;
			mindate.VerticalOptions = LayoutOptions.Center;
			mindate.HorizontalOptions = LayoutOptions.Start;
			mindate.FontFamily = "Helvetica";
			mindate.FontSize = 16;

			minDatePicker = new DatePicker();
			minDatePicker.WidthRequest = 180;
			minDatePicker.VerticalOptions = LayoutOptions.Center;
			minDatePicker.HorizontalOptions = LayoutOptions.End;
			minDatePicker.Date = min;
			minDatePicker.Format = "D";
			minDatePicker.DateSelected += minDatePicker_DateSelected;
			minLayout.Children.Add(mindate);
			minLayout.Children.Add(minDatePicker);


			StackLayout maxLayout = new StackLayout();
			maxLayout.Orientation = StackOrientation.Horizontal;
			maxLayout.HorizontalOptions = LayoutOptions.Center;
			maxLayout.Padding = new Thickness(10, 10, 0, 10);
			maxLayout.HeightRequest = 70;

			Label maxDate = new Label();
			maxDate.Text = "Max Date";
			maxDate.WidthRequest = 150;
			maxDate.HorizontalOptions = LayoutOptions.Start;
			maxDate.VerticalOptions = LayoutOptions.Center;
			maxDate.FontFamily = "Helvetica";
			maxDate.FontSize = 16;

			maxDatePicker = new DatePicker();
			maxDatePicker.Date = max;
			maxDatePicker.HorizontalOptions = LayoutOptions.End;
			maxDatePicker.VerticalOptions = LayoutOptions.Center;
			maxDatePicker.Format = "D";
			maxDatePicker.WidthRequest = 180;
			maxDatePicker.DateSelected += maxDate_DateSelected;


			maxLayout.Children.Add(maxDate);
			maxLayout.Children.Add(maxDatePicker);


			emptyLayout.Children.Add(selectionLayout);
			emptyLayout.Children.Add(minLayout);
			emptyLayout.Children.Add(maxLayout);

			view.Children.Add(propertyLayout);
			view.Children.Add(emptyLayout);
			Property_Windows.Children.Remove(temp);
			Property_Windows.Children.Insert(0, view);

		}
		public void Property_Button_Click(object c, EventArgs e)
		{
			getPropertiesWindow();

		}
		public void Close_Button(object c, EventArgs e)
		{
			closeAction();
		}
		public void closeAction()
		{
			//calendar.HeightRequest = 800;
			Property_Windows.HeightRequest = 200;
			view.BackgroundColor = Color.White;
			Property_Windows.Children.Add(temp);
			Property_Windows.Children.Remove(view);
		}
		public View getContent()

		{
			return this.Content;
		}
		public void maxDate_DateSelected(object c, DateChangedEventArgs e)
		{
			calendar.MaxDate = e.NewDate;
			max = e.NewDate;
		}
		public void minDatePicker_DateSelected(object c, DateChangedEventArgs e)
		{
			calendar.MinDate = e.NewDate;
			min = e.NewDate;
		}
		void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
		{
			getPropertiesWindow();
		}

		void tab_Tapped(object sender, EventArgs e)
		{
			closeAction();

		}
		public void selectionModePicker_Changed(object c, EventArgs e)
		{
			switch (selectionModePicker.SelectedIndex)
			{
				case 0:
					{

						calendar.SelectionMode = SelectionMode.SingleSelection;
						selection = 0;
					}
					break;
				case 1:
					{
						calendar.SelectionMode = SelectionMode.MultiSelection;
						selection = 1;
					}
					break;

			}
		}
	}
}



