#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfRadialMenu
{
    public partial class Customization_RadialMenu : SampleView
    {
        Rotator_ViewModel rotator_ViewModel;
        public Customization_RadialMenu()
        {
            InitializeComponent();
            //teamUSARadialMenu.Point = new Point(0, 0);
            rotator_ViewModel = new Rotator_ViewModel();
            sfRotator.BindingContext = rotator_ViewModel;
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), TimerElapsed);

        }

        void Handle_ItemTapped(object sender, Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs e)
        {
            Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem item1 = sender as Syncfusion.SfRadialMenu.XForms.SfRadialMenuItem;
            rotator_ViewModel.RotatorCollection[sfRotator.SelectedIndex].TeamColor = item1.BackgroundColor;
            teamUSARadialMenu.Close();
        }

        private bool TimerElapsed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                teamUSARadialMenu.Show();
            });
            return false;
        }
    }

}
