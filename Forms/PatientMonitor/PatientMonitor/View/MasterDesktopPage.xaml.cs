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
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PatientMonitor
{
    public partial class MasterDesktopPage : ContentPage
    {
        public MasterDesktopPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ContentLayout.Children.Add(new GridViewPage());
        }

        private void button_clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            btn_Home.BackgroundColor = Color.FromHex("#278CFC");
            btn_Event.BackgroundColor = Color.FromHex("#278CFC");
            ContentLayout.Children.Clear();
            if (button.Text == "My Patients")
            {
                ContentLayout.Children.Add(new GridViewPage());
            }
            
            else if(button.Text == "My Appointments")
            {
                ContentLayout.Children.Add(new HistoryView());
            }
            button.BackgroundColor = Color.FromHex("#FF3824AA");
        }
    }
}
