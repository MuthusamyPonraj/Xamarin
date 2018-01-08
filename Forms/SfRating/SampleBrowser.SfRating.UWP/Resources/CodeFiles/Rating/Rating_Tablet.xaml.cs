#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfRating.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfRating
{
	public partial class Rating_Tablet : SampleView
	{
		SfRatingSettings sfRatingSettings, sfsecondRatingSettings;
		int ratingItemCount;
		String ratingValue, ratingCount, ratingResult;
		Button closeButton;
		Label itemCountLabel, toolTipLabel;
		StackLayout view;

		Entry itemCountEntry;
		Picker precisionPicker;
		Switch toolTipPlacementOption;
		int minpref = 5, precision = 0;
		bool tooltip = false;

		public Rating_Tablet()
		{
			InitializeComponent();

			getPropertiesWindow();

			sfRatingSettings = new SfRatingSettings();
			sfRatingSettings.RatedFill = Color.FromHex("#fbd10a");
			sfRatingSettings.UnRatedFill = Color.White;
			sfRatingSettings.RatedStroke = Color.FromHex("#fbd10a");
			sfRatingSettings.RatedStrokeWidth = 1;
			sfRatingSettings.UnRatedStrokeWidth = 1;
			sfRating1.RatingSettings = sfRatingSettings;

			sfsecondRatingSettings = new SfRatingSettings();
			sfsecondRatingSettings.UnRatedFill = Color.White;
			sfsecondRatingSettings.RatedStrokeWidth = 1;
			sfsecondRatingSettings.UnRatedStrokeWidth = 1;
			sfRating2.RatingSettings = sfsecondRatingSettings;

			sfRating1.TooltipPlacement = TooltipPlacement.None;
			sfRating2.TooltipPlacement = TooltipPlacement.None;
			if (Device.OS == TargetPlatform.Android)
			{
				sfRating2.TooltipPrecision = 1;
			}
			sfRating2.ValueChanged += ValueChanged;

			optionView();
		}

		void ValueChanged(object sender, ValueEventArgs e)
		{
			ratingValue = Convert.ToString(Math.Round(e.Value, 1));
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}

		void optionView()
		{
			TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
			tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
			temp.GestureRecognizers.Add(tap_Gestue_Prob);

			if (Device.OS == TargetPlatform.iOS)
			{
				moviePic.BackgroundColor = Color.Aqua;
				column1.Width = 300;
				column2.Width = 350;
				movieImage.HeightRequest = 4 * 960 / 10;
				movieImage.WidthRequest = 300;
				imageHeight.Height = 4 * 960 / 10;
				toolTipPlacementOption.VerticalOptions = LayoutOptions.Start;
				if (itemCountLabel != null && toolTipLabel != null)
				{
					itemCountLabel.VerticalOptions = LayoutOptions.Center;
					toolTipLabel.VerticalOptions = LayoutOptions.End;
				}
			}
			if (Device.OS == TargetPlatform.Windows)
			{
				if (Device.Idiom == TargetIdiom.Tablet)
				{
					if (itemCountEntry != null)
						itemCountEntry.WidthRequest = 118;
				}
			}
			else if (Device.OS == TargetPlatform.WinPhone)
			{
				sampleLayout.Padding = new Thickness(10, 0, 10, 0);
				descStack.Padding = new Thickness(0, 0, 10, 0);
			}
			if (Device.RuntimePlatform == "UWP" && (Device.Idiom == TargetIdiom.Phone))
			{
				if (precisionPicker != null)
					precisionPicker.HeightRequest = 40;
			}
			Property_Button.Clicked += Property_Button_Click;
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

		void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
		{
			getPropertiesWindow();
		}

		public void getPropertiesWindow()
		{
			view = new StackLayout();
			if (Device.OS == TargetPlatform.iOS)
				Property_Windows.HeightRequest = 250;

			view.HeightRequest = Property_Windows.HeightRequest;
			view.BackgroundColor = Color.FromRgb(250, 250, 250);

			//Sub Layouts added 
			StackLayout propertyLayout = new StackLayout();
			propertyLayout.Orientation = StackOrientation.Horizontal;
			propertyLayout.BackgroundColor = Color.FromRgb(230, 230, 230);
			propertyLayout.Padding = new Thickness(10, 0, 0, 0);

			StackLayout emptyLayout = new StackLayout();
			emptyLayout.Orientation = StackOrientation.Vertical;
			emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
			emptyLayout.Padding = new Thickness(40, 20, 40, 40);

			StackLayout precisionLayout = new StackLayout();
			precisionLayout.HeightRequest = 60;
			precisionLayout.Orientation = StackOrientation.Horizontal;

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
			closeButton.Clicked += Close_Button;

			if (Device.OS == TargetPlatform.iOS)
			{
				closeButton.Text = "X";
				closeButton.TextColor = Color.FromRgb(51, 153, 255);
			}
			else
				closeButton.Image = "sfclosebutton.png";

			closeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
			propertyLayout.Children.Add(propertyLabel);
			propertyLayout.Children.Add(closeButton);
			temp.BackgroundColor = Color.FromRgb(230, 230, 230);
			closeButton.BackgroundColor = Color.FromRgb(230, 230, 230);
			Property_Button.BackgroundColor = Color.FromRgb(230, 230, 230);

			Label precisionLabel = new Label();
			precisionLabel.Text = "Precision";
			precisionLabel.WidthRequest = 200;
			precisionLabel.VerticalOptions = LayoutOptions.Center;
			precisionLabel.HorizontalOptions = LayoutOptions.End;
			precisionLabel.FontFamily = "Helvetica";
			precisionLabel.FontSize = 16;
			precisionPicker = new Picker();
			precisionPicker.WidthRequest = 150;
			precisionPicker.Items.Add("Standard");
			precisionPicker.Items.Add("Half");
			precisionPicker.Items.Add("Exact");
			precisionPicker.SelectedIndex = precision;
			precisionPicker.HorizontalOptions = LayoutOptions.Start;
			precisionPicker.VerticalOptions = LayoutOptions.Center;
			precisionPicker.SelectedIndexChanged += precisionPicker_SelectedIndexChanged;
			precisionLayout.Children.Add(precisionLabel);
			precisionLayout.Children.Add(precisionPicker);

			StackLayout toolTipLayout = new StackLayout();
			toolTipLayout.HeightRequest = 60;
			toolTipLayout.Padding = new Thickness(80, 0, 0, 0);
			toolTipLayout.Orientation = StackOrientation.Horizontal;
			toolTipLabel = new Label();
			toolTipLabel.WidthRequest = 200;
			toolTipLabel.Text = "Show Tooltip";
			toolTipLabel.VerticalOptions = LayoutOptions.Center;
			toolTipLabel.HorizontalOptions = LayoutOptions.End;
			toolTipLabel.FontFamily = "Helvetica";
			toolTipLabel.FontSize = 16;

			toolTipPlacementOption = new Switch();
			toolTipPlacementOption.Toggled += toggleStateChanged;
			toolTipPlacementOption.IsToggled = tooltip;
			toolTipPlacementOption.HorizontalOptions = LayoutOptions.Start;
			toolTipPlacementOption.VerticalOptions = LayoutOptions.Center;
			toolTipLayout.Children.Add(toolTipLabel);
			toolTipLayout.Children.Add(toolTipPlacementOption);

			StackLayout itemCountLayout = new StackLayout();
			itemCountLayout.HeightRequest = 60;
			itemCountLayout.Orientation = StackOrientation.Horizontal;
			itemCountLabel = new Label();
			itemCountLabel.WidthRequest = 200;
			itemCountLabel.Text = "Items Count";
			itemCountLabel.HorizontalOptions = LayoutOptions.End;
			itemCountLabel.VerticalOptions = LayoutOptions.Center;
			itemCountLabel.FontFamily = "Helvetica";
			itemCountLabel.FontSize = 16;
			itemCountEntry = new Entry();
			itemCountEntry.WidthRequest = 150;
			itemCountEntry.Keyboard = Keyboard.Numeric;
			itemCountEntry.VerticalOptions = LayoutOptions.Center;
			itemCountEntry.HorizontalOptions = LayoutOptions.Start;

			itemCountEntry.FontFamily = "Helvetica";
			itemCountEntry.Text = minpref.ToString();
			itemCountEntry.TextChanged += itemCountEntry_Changed;
			itemCountLayout.Children.Add(itemCountLabel);
			itemCountLayout.Children.Add(itemCountEntry);

			emptyLayout.Children.Add(precisionLayout);
			emptyLayout.Children.Add(toolTipLayout);
			emptyLayout.Children.Add(itemCountLayout);
			view.Children.Add(propertyLayout);
			view.Children.Add(emptyLayout);
			Property_Windows.Children.Remove(temp);
			Property_Windows.Children.Insert(0, view);

			if (Device.OS == TargetPlatform.Android)
			{
				sfRating1.ItemSize = 17;
				sfRating2.ItemSize = 40;
				sfRating2.ItemSpacing = 7;
				toolTipLayout.Padding = new Thickness(60, 0, 0, 0);
				itemCountLayout.Padding = new Thickness(60, 0, 0, 0);
				precisionLayout.Padding = new Thickness(60, 0, 0, 0);
			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				itemCountEntry.HorizontalTextAlignment = TextAlignment.Center;
				closeButton.Text = "X";
				closeButton.TextColor = Color.FromRgb(51, 153, 255);
				precisionLayout.Padding = new Thickness(150, 20, 0, 20);
				precisionLabel.WidthRequest = 150;
				precisionPicker.WidthRequest = 200;
				itemCountLabel.WidthRequest = 150;
				itemCountLayout.Padding = new Thickness(150, 20, 0, 20);
				toolTipLabel.WidthRequest = 150;
				toolTipLayout.HeightRequest = 30;
				toolTipLayout.Padding = new Thickness(150, 20, 0, 20);
			}
			else
			{
				closeButton.Image = "sfclosebutton.png";
				precisionLayout.Padding = new Thickness(80, 0, 0, 0);
				precisionPicker.WidthRequest = 150;
				precisionLabel.WidthRequest = 195;
				itemCountLabel.WidthRequest = 195;
				itemCountLayout.Padding = new Thickness(80, 0, 0, 0);
				toolTipLabel.WidthRequest = 195;
				toolTipLayout.HeightRequest = 70;
			}

		}

		public void Property_Button_Click(object e, EventArgs arg)
		{
			getPropertiesWindow();
		}

		public void toggleStateChanged(object e, ToggledEventArgs eve)
		{
			if (eve.Value)
			{
				sfRating2.TooltipPlacement = TooltipPlacement.TopLeft;
				tooltip = eve.Value;
			}
			else
			{
				sfRating2.TooltipPlacement = TooltipPlacement.None;
				tooltip = eve.Value;
			}
		}

		public View getContent()
		{
			return this.Content;
		}

		public void Close_Button(object c, EventArgs e)
		{
			closeAction();
		}

		public void precisionPicker_SelectedIndexChanged(object c, EventArgs e)
		{
			switch (precisionPicker.SelectedIndex)
			{
				case 0:
					{
						sfRating2.Precision = Precision.Standard;
						precision = 0;
						break;
					}
				case 1:
					{
						sfRating2.Precision = Precision.Half;
						precision = 1;
						break;
					}
				case 2:
					{
						sfRating2.Precision = Precision.Exact;
						precision = 2;
						break;
					}
			}
			ratingValue = Convert.ToString(sfRating2.Value);
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}


		public void itemCountEntry_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				sfRating2.ItemCount = int.Parse(e.NewTextValue);
				minpref = int.Parse(e.NewTextValue);
			}
			ratingItemCount = sfRating2.ItemCount;
			ratingCount = Convert.ToString(ratingItemCount);

			if (sfRating2.Value > ratingItemCount)
			{
				ratingValue = "0";
			}
			else
			{
				ratingValue = Convert.ToString(sfRating2.Value);
			}
			ratingResult = " " + ratingValue + "/" + ratingCount;
			showValue.Text = ratingResult;
		}
	}
}


