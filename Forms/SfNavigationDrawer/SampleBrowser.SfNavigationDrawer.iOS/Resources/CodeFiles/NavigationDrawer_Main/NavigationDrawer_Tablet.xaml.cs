#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using Syncfusion.SfNavigationDrawer.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfNavigationDrawer
{
    public partial class NavigationDrawer_Tablet : SampleView
    {
        public NavigationDrawer_Tablet()
        {
            InitializeComponent();
            //var maincontent = new MainContentView_Default();

            MenuCollectionViewModel vm = new MenuCollectionViewModel();

            Archive_Default mailcollection = new Archive_Default(vm.MenuCollection[0].MessageContent, "Inbox");
            navigationDrawer.ContentView = new Archive_Default(vm.MenuCollection[0].MessageContent, "Inbox");

            navigationDrawer.ContentView.BackgroundColor = Color.White;
            navigationDrawer.TouchThreshold = 100;
            this.listView.ItemsSource = new MenuCollectionViewModel().MenuCollection;
            if (Device.OS == TargetPlatform.iOS)
            {
                navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
                navigationDrawer.DrawerHeaderHeight = 150;

            }
            if (Device.OS == TargetPlatform.iOS && Device.Idiom == TargetIdiom.Tablet)
            {
                userImage.HorizontalOptions = LayoutOptions.Center;
                userNameLabel.HorizontalOptions = LayoutOptions.Center;
                userImage.Margin = new Thickness(7, 14, 0, 0);
                drawerContentViewGrid.Padding = new Thickness(13, 1, 0.5, 1);
            }
            if (Device.OS == TargetPlatform.Android && Device.Idiom == TargetIdiom.Tablet)
            {
                userImage.HorizontalOptions = LayoutOptions.Center;
                userNameLabel.HorizontalOptions = LayoutOptions.Center;
            }
            else
            {
                navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
                navigationDrawer.DrawerHeaderHeight = 150;
            }
            if (Device.Idiom == TargetIdiom.Phone && (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone))
            {

                userImage.VerticalOptions = LayoutOptions.Center;
                navigationDrawer.DrawerWidth = (float)(Core.SampleBrowser.ScreenWidth * 0.8);
            }
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                {

                    navigationDrawer.DrawerWidth = 400;
                    userImage.VerticalOptions = LayoutOptions.Center;
                }
            }
            navigationDrawer.DrawerHeight = (float)Core.SampleBrowser.ScreenHeight;
            navigationDrawer.DrawerFooterHeight = 0;
            navigationDrawer.Duration = 400;
            navigationDrawer.Position = Position.Left;
            navigationDrawer.Transition = Syncfusion.SfNavigationDrawer.XForms.Transition.SlideOnTop;
            this.Padding = new Thickness(-5);
            loadPropertyView();
        }

        void Handle_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var tempListView = sender as SfListView;
            for (int i = 0; i < 8; i++)
            {
                var tempItem = (listView.ItemsSource as ObservableCollection<MenuCollectionModel>)[i];
                if ((e.ItemData as MenuCollectionModel) != tempItem)
                {
                    tempItem.FontColor = Color.FromHex("#8e8e92");
                }
            }

            var temp = e.ItemData as MenuCollectionModel;
            temp.FontColor = Color.FromHex("#007ad0");
            navigationDrawer.ContentView = new Archive_Default(temp.MessageContent, (e.ItemData as MenuCollectionModel).MenuItem).Content;
            DependencyService.Get<IToggleDrawer>().ToggleDrawer();
        }

        void loadPropertyView()
        {
            optionLayout.Padding = new Thickness(0, 0, 10, 0);
            transitionPicker.Items.Add("SlideOnTop");
            transitionPicker.Items.Add("Push");
            transitionPicker.SelectedIndex = 0;
            transitionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                switch (transitionPicker.SelectedIndex)
                {
                    case 0:
                        {
                            navigationDrawer.Transition = Transition.SlideOnTop;
                        }
                        break;
                    case 1:
                        {
                            navigationDrawer.Transition = Transition.Push;
                        }
                        break;
                }
            };
            positionPicker.Items.Add("Left");
            positionPicker.Items.Add("Right");
            positionPicker.SelectedIndex = 0;
            positionPicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                switch (positionPicker.SelectedIndex)
                {
                    case 0:
                        {
                            navigationDrawer.Position = Position.Left;
                            navigationDrawer.DrawerHeight = 500;
                        }
                        break;
                    case 1:
                        {
                            navigationDrawer.Position = Position.Right;
                            navigationDrawer.DrawerHeight = 500;
                        }
                        break;
                }
            };
        }
        public View getContent()
        {
            return this.Content;
        }
        public View getPropertyView()
        {
            return this.PropertyView;
        }
    }
}

