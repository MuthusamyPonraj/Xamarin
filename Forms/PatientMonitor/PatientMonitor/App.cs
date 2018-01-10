#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace PatientMonitor
{

    public class App : Application
    {
        public App()
        {
            HomeViewModel viewModel = new HomeViewModel();
            if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Desktop)
            {
                MainPage = new NavigationPage(new PatientMonitor.MasterDesktopView());
            }
            else
            {
                MainPage = new NavigationPage(new PatientMonitor.HomePage() { BindingContext = viewModel });
            }
        }
    }
}