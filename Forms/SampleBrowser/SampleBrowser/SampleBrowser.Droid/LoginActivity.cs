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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleBrowser.Droid
{
    [Activity(Label = "Syncfusion Components for Xamarin.Forms(Beta)")]
    public class LoginActivity : Activity
    {
        public static string UserName { get; set; }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LayoutInflater layoutInflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
            View loginView = layoutInflater.Inflate(Resource.Layout.LoginActivity_Layout,null,true);

            Button button = (Button)loginView.FindViewById(Resource.Id.button_login);

            SetContentView(loginView);

            button.Click+= (sender, e) => {
                EditText passwordInput = (EditText)loginView.FindViewById(Resource.Id.input_email);
                UserName = passwordInput.Text;

                if (UserName != string.Empty && UserName.Trim() !="")
                {
		    	 ISharedPreferences preferences = this.GetSharedPreferences("net.hockeyapp.android.login", 0);

		  	 if (preferences!=null)
                     	   {
				 preferences.Edit().PutString("email", UserName).Apply();
			   }

                    this.Finish();
                }
            };
           
        }
    }
}
