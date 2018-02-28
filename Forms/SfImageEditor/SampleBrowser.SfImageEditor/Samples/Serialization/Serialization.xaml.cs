#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class Serialization : SampleView
    {
        SerializationViewModel model;
        SerializationModel SelectedItem;

        bool isPressed = false;

        public Serialization()
        {
            InitializeComponent();
            model = new SerializationViewModel();
            listView.BindingContext = model;
            listView.ItemsSource = model.ModelList;
            deleteImage.Source = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.Delete1.png");

        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var items = listView.SelectedItems.ToList();
            foreach (SerializationModel item in items)
            {
                (item as SerializationModel).SelectedImageVisibility = "false";
                if (model.ModelList.Contains(item))
                    model.ModelList.Remove(item);
            }
            ClearItems();
            isPressed = false;
        }

        void ClearItems()
        {
            for (int i = 1; i < model.ModelList.Count; i++)
            {
                model.ModelList[i].SelectedImageVisibility = "false";
                model.ModelList[i].SelectedItemThickness = new Thickness(0, 0, 0, 0);

            }
            listView.SelectedItems.Clear();
            deleteImage.IsVisible = false;
            listView.SelectionChanged -= ListView_SelectionChanged;

        }

        void Handle_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            SelectedItem = e.ItemData as SerializationModel;
            //if (SelectedItem.ImageName == "CreateNew")
            //{
                var item = SelectedItem;
                if (SelectedItem.SelectedImageVisibility == "false")
                {
                    SelectedItem.SelectedImageVisibility = "false";
                    if (Device.OS == TargetPlatform.iOS)
                    {
                        Navigation.PushAsync(new NavigationPage(new SerializationContentPage(item, listView, model)));
                    }
                    else if (Device.OS == TargetPlatform.Windows)
                    {
                        Navigation.PushAsync(new SerializationContentPage(item, listView, model));
                    }
                    else
                    {
                        Navigation.PushModalAsync(new SerializationContentPage(item, listView, model));
                    }
                    ClearItems();

            }


        }


        void Handle_ItemHolding(object sender, Syncfusion.ListView.XForms.ItemHoldingEventArgs e)
        {
            isPressed = true;
            if (listView.SelectedItems.Count > 0)
            {
                listView.SelectedItems.Clear();
            }
            for (int i = 1; i < model.ModelList.Count; i++)
            {
                model.ModelList[i].SelectedImageVisibility = "true";
                model.ModelList[i].SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.NotSelected.png");
            }
            listView.SelectionChanged += ListView_SelectionChanged;
            deleteImage.IsVisible = true;
        }

        private void ListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            isPressed = true;
            deleteImage.IsVisible = true;
            for (int i = 0; i < e.AddedItems.Count; i++)
            {
                var item = e.AddedItems[i];

                if ((item as SerializationModel).ImageName == "CreateNew")
                {
                    listView.SelectedItems.Remove(item);
                }
                else
                {
                    (item as SerializationModel).SelectedImageVisibility = "true";
                    (item as SerializationModel).SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.Selected.png");
                    (item as SerializationModel).SelectedItemThickness = new Thickness(15, 15, 15, 15);
                }
            }
            for (int i = 0; i < e.RemovedItems.Count; i++)
            {
                var item = e.RemovedItems[i];
                (item as SerializationModel).SelectedImageVisibility = "true";
                (item as SerializationModel).SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.NotSelected.png");
                (item as SerializationModel).SelectedItemThickness = new Thickness(0, 0, 0, 0);


            }

        }


    }
 }
