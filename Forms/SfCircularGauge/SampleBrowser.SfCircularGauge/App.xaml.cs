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
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfCircularGauge
{
    [Preserve(AllMembers = true)]
    public partial class App : Application
    {
        static public double ScreenWidth;

        static public double ScreenHeight;

        static public double NavigationBarHeight;

        static public double StatusBarHeight;

        static public Platforms Platform;

        static public double Density;

        public static bool isUWP;

        public App()
        {
            InitializeComponent();

            MainPage = Core.SampleBrowser.GetMainPage("SfCircularGauge", "SampleBrowser.SfCircularGauge");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public enum Platforms
        {
            UWP,
            Android,
            iOS
        }
    }
}
