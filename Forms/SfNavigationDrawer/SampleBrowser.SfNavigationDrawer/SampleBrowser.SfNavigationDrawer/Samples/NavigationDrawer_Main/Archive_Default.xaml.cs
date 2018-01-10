#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfNavigationDrawer.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfNavigationDrawer
{
public partial class Archive_Default : ContentView
{
	public Archive_Default(ObservableCollection<Message> items, string title)
	{
		InitializeComponent();
		headerGradiant.WidthRequest = Core.SampleBrowser.ScreenWidth;
		headerLabel.Text = title;
		listView.ItemsSource = items;
		btn.BackgroundColor = Color.FromHex("#00a0e1");

		btn.HeightRequest = 40;
		btn.WidthRequest = 40;
		btn.Text = "H";
		btn.FontSize = 16;
            if(Device.OS == TargetPlatform.iOS && Device.Idiom == TargetIdiom.Tablet)
            {
                headingGrid.Padding = new Thickness(10, 10, 0, 10);
            }
		if (Device.OS == TargetPlatform.Android)
		{
			btn.FontFamily = "navigation.ttf#navigation";
		}
		else if (Device.OS == TargetPlatform.Windows)
		{
			btn.FontSize = 21;
			btn.Text = "\xE700";
			btn.FontFamily = "Segoe MDL2 Assets";
			btn.HeightRequest = 50;
			btn.WidthRequest = 50;
		}
		else
		{
			btn.Image = (FileImageSource)ImageSource.FromFile("burgericon.png");
		}
		btn.TextColor = Color.White;

	}

	void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
	{
		(sender as ListView).SelectedItem = null;
	}

	void Btn_Clicked(object sender, EventArgs e)
	{
		DependencyService.Get<IToggleDrawer>().ToggleDrawer();
	}
}
}
