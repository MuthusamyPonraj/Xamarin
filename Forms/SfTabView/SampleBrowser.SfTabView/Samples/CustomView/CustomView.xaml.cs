#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Globalization;

namespace SampleBrowser.SfTabView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomView : SampleView
    {
        TapGestureRecognizer tabGesture;
        public CustomView()
        {
            InitializeComponent();
            this.BindingContext = new ViewModelCustomTab();
            if(Device.RuntimePlatform == "iOS")
                this.ReadCountLabel.WidthRequest = this.ReadCountLabel.HeightRequest = 20;
            SfTabItem item = new SfTabItem();
            this.refreshButton.TextColor = Color.Transparent;
            this.refreshButton.Clicked += RefreshButton_Clicked;
            Device.StartTimer(TimeSpan.FromMilliseconds(5000), () =>
            {
                this.refreshIndicator.IsVisible = false;
                this.refreshIndicator.IsRunning = false;
                this.refreshButton.TextColor = Color.FromHex("#FF00AFF0");
                return false;
            });

            tabGesture = new TapGestureRecognizer();
            tabGesture.Tapped += TabGesture_Tapped;

            ContactsHeader.GestureRecognizers.Add(tabGesture);
            ChatsHeader.GestureRecognizers.Add(tabGesture);

        }

        void TabGesture_Tapped(object sender, EventArgs e)
        {
            if(sender is Grid)
            {
                simTab.SelectedIndex = (sender as Grid).StyleId == "ChatsHeader" ? 0 : 1;
            }
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            this.refreshIndicator.IsVisible = true;
            this.refreshIndicator.IsRunning = true;
            this.refreshButton.TextColor = Color.Transparent;
            Device.StartTimer(TimeSpan.FromMilliseconds(2500), () =>
            {
                this.refreshIndicator.IsVisible = false;
                this.refreshIndicator.IsRunning = false;
                this.refreshButton.TextColor = Color.FromHex("#FF00AFF0");
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Contacts are up to date", "OK");
                return false;
            });
        }
    }

    public class booltofontConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return FontAttributes.Bold;
            return FontAttributes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
    public class booltocolorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.Black;
            return Color.Gray;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}