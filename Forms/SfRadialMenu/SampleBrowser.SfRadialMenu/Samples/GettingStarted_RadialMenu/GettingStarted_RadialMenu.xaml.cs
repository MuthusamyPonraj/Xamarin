#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfRadialMenu.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfRadialMenu
{
    public partial class GettingStarted_RadialMenu : SampleView
    {
        ObservableCollection<string> list;
        public GettingStarted_RadialMenu()
        {
            InitializeComponent();
            list = new ObservableCollection<string>();
            list.CollectionChanged += (sender, e) =>
            {
                Label lbl = new Label();
                lbl.FontSize = 14;
                lbl.Text = e.NewItems[0].ToString();
                eventLogLayout.Children.Insert(0, lbl);
            };

            slider.ValueChanging += (sender, e) =>
            {
                radial_Menu.Close();
                radial_Menu.RimRadius = e.Value;
            };
            rotationSwitch.Toggled += (sender, e) =>
            {
                radial_Menu.EnableRotation = e.Value;
            };
            dragSwitch.Toggled += (sender, e) =>
            {
                radial_Menu.IsDragEnabled = e.Value;
            };
            if (Device.OS == TargetPlatform.Android)
            {
                eventLogsLabel.FontSize = 18;
                eventLogsLabel.HeightRequest = 40;
                clearLogsButton.HeightRequest = 35;
                clearLogsButton.FontSize = 12;
                logRow.Height = 35;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            eventLogLayout.Children.Clear();
        }

        void Handle_ItemTapped(object sender, Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs e)
        {
            var tempItem = (sender as SfRadialMenuItem);
            if (tempItem.FontIconText == "")
                list.Add("Spectrum range one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Spectrum range two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Spectrum range three is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Spectrum range four is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Notification mode one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Notification mode two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Notification mode three is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Slient mode is activated");
            else if (tempItem.FontIconText == "")
                list.Add("Vibrate mode is activated");
            else if (tempItem.FontIconText == "")
                list.Add("Normal mode is activated");
            else if (tempItem.FontIconText == "")
                list.Add("Brightness level is adjusted");
            else if (tempItem.FontIconText == "")
                list.Add("Battery mode one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Battery mode two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Battery mode three is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Power saver mode one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Power saver mode two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Power saver mode three is selected");
        }
        void Radial_Menu_Opening(object sender, OpeningEventArgs e)
        {
            list.Add("RadialMenu is Opening");
        }

        void Radial_Menu_Opened(object sender, OpenedEventArgs e)
        {
            list.Add("RadialMenu is Opened");
        }

        void Radial_Menu_Closed(object sender, ClosedEventArgs e)
        {
            list.Add("RadialMenu is Closed");
        }

        void Radial_Menu_Closing(object sender, ClosingEventArgs e)
        {
            list.Add("RadialMenu is Closing");
        }

        void Radial_Menu_Navigating(object sender, NavigatingEventArgs e)
        {
            list.Add("RadialMenu is Navigating");
        }

        void Radial_Menu_Navigated(object sender, NavigatedEventArgs e)
        {
            list.Add("RadialMenu is Navigated");
        }

        void Radial_Menu_CenterButtonTapped(object sender, CenterButtonBackTappedEventArgs e)
        {
            list.Add("CenterButtonBack is Tapped");
        }
    }
}

