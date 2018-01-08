#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfCarousel.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfCarousel
{
	public partial class Carousel_Tablet : SampleView
	{
		StackLayout view;
		Button closeButton;
		Label offsetLabel, scaleLabel, rotateAngleLabel;
		Entry offsetText, scale, rotate;
		int offset = 60, rotateValue = 45;
		float scaleValue = 0.8f;
		Picker modePicker;

		public Carousel_Tablet()
		{
			InitializeComponent();
			getPropertiesWindow();
			carousel.SelectedItemOffset = 0;
			carousel.DataSource = GetDataSource();
			DeviceChanges();
			Property_Button.Clicked += Property_Button_Click;
		}

		void DeviceChanges()
		{
			TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
			tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
			temp.GestureRecognizers.Add(tap_Gestue_Prob);
			if (Device.OS == TargetPlatform.iOS)
			{
				carousel.ItemHeight = 300;
				carousel.ItemWidth = 150;
				property.Height = 430;
			}

			if (Device.OS == TargetPlatform.Android)
			{
				//if (App.Density > 1.5)
				{
					carousel.ItemHeight = Convert.ToInt32(250);
					carousel.ItemWidth = Convert.ToInt32(180);
				}
			}
		}
		public void getPropertiesWindow()
		{
			view = new StackLayout();

			if (Device.OS == TargetPlatform.iOS)
			{
				Property_Windows.HeightRequest = 600;
			}
			view.HeightRequest = Property_Windows.HeightRequest;
			view.BackgroundColor = Color.FromRgb(250, 250, 250);

			StackLayout propertyLayout = new StackLayout();
			propertyLayout.Orientation = StackOrientation.Horizontal;
			propertyLayout.BackgroundColor = Color.FromRgb(230, 230, 230);
			propertyLayout.Padding = new Thickness(10, 0, 0, 0);

			TapGestureRecognizer tab = new TapGestureRecognizer();
			tab.Tapped += tab_Tapped;
			propertyLayout.GestureRecognizers.Add(tab);

			Label propertyLabel = new Label();
			propertyLabel.Text = "OPTIONS";
			propertyLabel.WidthRequest = 150;
			propertyLabel.VerticalOptions = LayoutOptions.Center;
			propertyLabel.HorizontalOptions = LayoutOptions.Start;
			propertyLabel.FontFamily = "Helvetica";
			propertyLabel.FontSize = 18;

			closeButton = new Button();

			if (Device.OS == TargetPlatform.iOS)
			{
				closeButton.Text = "X";
				closeButton.TextColor = Color.FromRgb(51, 153, 255);
			}
			else
				closeButton.Image = "sfclosebutton.png";
			closeButton.Clicked += Close_Button;
			closeButton.HorizontalOptions = LayoutOptions.EndAndExpand;

			propertyLayout.Children.Add(propertyLabel);
			propertyLayout.Children.Add(closeButton);

			temp.BackgroundColor = Color.FromRgb(230, 230, 230);
			closeButton.BackgroundColor = Color.FromRgb(230, 230, 230);
			Property_Button.BackgroundColor = Color.FromRgb(230, 230, 230);

			StackLayout emptyLayout = new StackLayout();
			emptyLayout.Orientation = StackOrientation.Vertical;
			emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
			emptyLayout.Padding = new Thickness(40, 20, 40, 40);

			StackLayout offsetLayout = new StackLayout();
			offsetLayout.Orientation = StackOrientation.Horizontal;
			offsetLayout.Padding = new Thickness(60, 0, 60, 0);
			offsetLayout.HeightRequest = 60;

			offsetLabel = new Label();
			offsetLabel.Text = "Offset";
			offsetLabel.WidthRequest = 300;
			offsetLabel.VerticalOptions = LayoutOptions.Center;
			offsetLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
			offsetLabel.FontFamily = "Helvetica";
			offsetLabel.FontSize = 16;

			offsetText = new Entry();
			offsetText.WidthRequest = 150;
			offsetText.Keyboard = Keyboard.Numeric;
			offsetText.VerticalOptions = LayoutOptions.Center;
			offsetText.HorizontalOptions = LayoutOptions.StartAndExpand;
			offsetText.FontFamily = "Helvetica";
			offsetText.FontSize = 16;
			offsetText.Text = offset.ToString();
			offsetText.TextChanged += offsetValue_Changed;

			offsetLayout.Children.Add(offsetLabel);
			offsetLayout.Children.Add(offsetText);

			StackLayout scaleLayout = new StackLayout();
			scaleLayout.Orientation = StackOrientation.Horizontal;
			scaleLayout.Padding = new Thickness(60, 0, 60, 0);
			scaleLayout.HeightRequest = 60;

			scaleLabel = new Label();
			scaleLabel.Text = "Scale";
			scaleLabel.WidthRequest = 300;
			scaleLabel.VerticalOptions = LayoutOptions.Center;
			scaleLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
			scaleLabel.FontFamily = "Helvetica";
			scaleLabel.FontSize = 16;

			scale = new Entry();
			scale.WidthRequest = 150;
			scale.Keyboard = Keyboard.Numeric;
			scale.VerticalOptions = LayoutOptions.Center;
			scale.HorizontalOptions = LayoutOptions.StartAndExpand;
			scale.FontFamily = "Helvetica";
			scale.FontSize = 16;
			scale.Text = scaleValue.ToString();
			scale.TextChanged += ScaleValue_Changed;

			scaleLayout.Children.Add(scaleLabel);
			scaleLayout.Children.Add(scale);

			StackLayout rotateLayout = new StackLayout();
			rotateLayout.Orientation = StackOrientation.Horizontal;
			rotateLayout.Padding = new Thickness(60, 0, 60, 0);
			rotateLayout.HeightRequest = 60;

			rotateAngleLabel = new Label();
			rotateAngleLabel.Text = "Rotate Angle";
			rotateAngleLabel.WidthRequest = 300;
			rotateAngleLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
			rotateAngleLabel.VerticalOptions = LayoutOptions.Center;
			rotateAngleLabel.FontFamily = "Helvetica";
			rotateAngleLabel.FontSize = 16;

			rotate = new Entry();
			rotate.WidthRequest = 150;
			rotate.Keyboard = Keyboard.Numeric;
			rotate.VerticalOptions = LayoutOptions.Center;
			rotate.HorizontalOptions = LayoutOptions.StartAndExpand;
			rotate.FontFamily = "Helvetica";
			rotate.FontSize = 16;
			rotate.Text = rotateValue.ToString();
			rotate.TextChanged += rotateValue_Changed;

			rotateLayout.Children.Add(rotateAngleLabel);
			rotateLayout.Children.Add(rotate);

			var viewModeLayout = new StackLayout();
			viewModeLayout.Orientation = StackOrientation.Horizontal;
			viewModeLayout.Padding = new Thickness(60, 0, 60, 0);
			viewModeLayout.HeightRequest = 60;

			Label viewModeLabel = new Label();
			viewModeLabel.Text = "View Mode";
			viewModeLabel.WidthRequest = 300;
			viewModeLabel.HorizontalOptions = LayoutOptions.Start;
			viewModeLabel.VerticalOptions = LayoutOptions.Center;
			viewModeLabel.FontFamily = "Helvetica";
			viewModeLabel.FontSize = 16;

			modePicker = new Picker();
			modePicker.WidthRequest = 150;
			modePicker.Items.Add("Default");
			modePicker.Items.Add("Linear");
			modePicker.SelectedIndex = 0;
			modePicker.SelectedIndexChanged += viewmodePicker_SelectedIndexChanged;

			viewModeLayout.Children.Add(viewModeLabel);
			viewModeLayout.Children.Add(modePicker);

			if (Device.OS == TargetPlatform.iOS)
			{
				emptyLayout.Padding = new Thickness(30, 10, 40, 0);
				viewModeLabel.WidthRequest = 250;
				viewModeLayout.Orientation = StackOrientation.Horizontal;
				viewModeLayout.Padding = new Thickness(60, 10, 0, 20);
				modePicker.WidthRequest = 250;
				modePicker.HorizontalOptions = LayoutOptions.StartAndExpand;
				modePicker.VerticalOptions = LayoutOptions.Center;
				viewModeLayout.HorizontalOptions = LayoutOptions.Center;
				viewModeLayout.VerticalOptions = LayoutOptions.Center;
				emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
			}
			emptyLayout.Children.Add(offsetLayout);
			emptyLayout.Children.Add(scaleLayout);
			emptyLayout.Children.Add(rotateLayout);
			emptyLayout.Children.Add(viewModeLayout);

			view.Children.Add(propertyLayout);
			view.Children.Add(emptyLayout);
			Property_Windows.Children.Remove(temp);
			Property_Windows.Children.Insert(0, view);
		}

		void viewmodePicker_SelectedIndexChanged(object sender, EventArgs e)
		{

			switch (modePicker.SelectedIndex)
			{
				case 0:
					carousel.ViewMode = ViewMode.Default;
					break;
				case 1:
					carousel.ViewMode = ViewMode.Linear;
					break;
			}
		}
		void tab_Tapped(object sender, EventArgs e)
		{
			closeAction();
		}
		public void closeAction()
		{
			view.BackgroundColor = Color.White;
			if (Device.OS == TargetPlatform.iOS)
			{
				Property_Windows.HeightRequest = 90;
			}
			Property_Windows.Children.Add(temp);
			Property_Windows.Children.Remove(view);
		}
		void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
		{
			getPropertiesWindow();
		}
		public void Property_Button_Click(object c, EventArgs e)
		{
			getPropertiesWindow();
		}
		public void offsetValue_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				carousel.Offset = int.Parse(e.NewTextValue);
				offset = int.Parse(e.NewTextValue);
			}
		}
		public void ScaleValue_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				if (float.Parse(e.NewTextValue) <= 1)
				{
					carousel.ScaleOffset = float.Parse(e.NewTextValue);
					scaleValue = float.Parse(e.NewTextValue);
				}
				else
				{
					carousel.ScaleOffset = 0.8f;
					scaleValue = float.Parse(e.NewTextValue);

				}
			}
		}

		#region DataSource
		List<CarouselModel> GetDataSource()
		{
			List<CarouselModel> list = new List<CarouselModel>();
			list.Add(new CarouselModel("image1.png"));
			list.Add(new CarouselModel("image2.png"));
			list.Add(new CarouselModel("image3.png"));
			list.Add(new CarouselModel("image4.png"));
			list.Add(new CarouselModel("image5.png"));
			return list;
		}
		#endregion

		public void rotateValue_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				if (float.Parse(e.NewTextValue) > 0 && float.Parse(e.NewTextValue) <= 360)
				{

					carousel.RotationAngle = int.Parse(e.NewTextValue);
					rotateValue = int.Parse(e.NewTextValue);
				}
				else
				{
					carousel.RotationAngle = 45;
					rotateValue = int.Parse(e.NewTextValue);

				}
			}
		}
		public void Close_Button(object c, EventArgs e)
		{
			closeAction();
		}
		public View getContent()
		{
			return this.Content;

		}

	}
}


