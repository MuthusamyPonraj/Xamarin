#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SampleBrowser.Core.Droid.SampleBrowserDroid))]

namespace SampleBrowser.Droid
{
	[Activity(Label = "SampleBrowser.Droid", Icon = "@drawable/AppIcon", Theme = "@style/MyTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Core.Android.SampleBrowserActivity
	{
        App app;
		protected App App
        {
            get
            {
                return app;
            }
        }

		internal static MainActivity MainPageActivity;

        protected override void OnCreate(Bundle savedInstanceState)
		{
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


			base.OnCreate(savedInstanceState);
            MainPageActivity = this;
            Forms.Init(this, savedInstanceState);

            Core.Droid.CoreSampleBrowser.Init(Resources, null);

			LoadApplication(app = new App());
        }
        
        
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            if (newConfig.Orientation == Android.Content.Res.Orientation.Landscape)
                RequestedOrientation = ScreenOrientation.Portrait;
        }
	}
}