#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.OS;

namespace SampleBrowser.Droid
{
	[Activity(Theme = "@style/Theme.Splash",
              MainLauncher = true,
				 NoHistory = true, Icon = "@drawable/AppIcon")]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			System.Threading.Thread.Sleep(200);
			this.StartActivity(typeof(MainActivity));
		}
	}
}