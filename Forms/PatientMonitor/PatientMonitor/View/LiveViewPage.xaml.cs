#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PatientMonitor
{
	public partial class LiveViewPage : ContentPage
    {
        LiveHistoryViewModel liveVM;
		public LiveViewPage ()
		{
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
            
            InitializeComponent();
            this.BindingContextChanged -= LiveViewPage_BindingContextChanged;
            this.BindingContextChanged += LiveViewPage_BindingContextChanged;
            
            if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                Label label = new Label();
                label.WidthRequest = 20;
               // PaddingStack.Children.Add(label);
                 
            }
           
                historyButton.Clicked += B_Clicked;
        }

        void LiveViewPage_BindingContextChanged(object sender, EventArgs e)
        {
            liveVM = this.BindingContext as LiveHistoryViewModel;
            liveVM.LiveObservations.CollectionChanged -= LiveObservations_CollectionChanged;
            liveVM.LiveObservations.CollectionChanged += LiveObservations_CollectionChanged;
        }

        void LiveObservations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            BPLabel1.Text = liveVM.LiveObservations[liveVM.LiveObservations.Count - 1].BP.ToString() + "/73";
            RRValueLabel.Text = liveVM.LiveObservations[liveVM.LiveObservations.Count - 1].RR.ToString();
            TempValueLabel.Text = liveVM.LiveObservations[liveVM.LiveObservations.Count - 1].Temp.ToString();
        }
        private void B_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryView() { BindingContext = this.BindingContext });
        }
    }
}

