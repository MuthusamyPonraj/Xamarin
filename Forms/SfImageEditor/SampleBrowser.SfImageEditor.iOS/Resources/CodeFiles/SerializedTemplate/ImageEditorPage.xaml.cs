#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class ImageEditorPage : ContentPage
    {
        void Saved(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ViewModelMain.ModelList.Count; i++)
            {
                if (scr == ViewModelMain.ModelList[i].Name)
                {
                    ViewModelMain.ModelList[i].Strm = imageEditor.GetSerializedObject();
                }
            }
        }

        void ImageEditor_ImageSaving(object sender, ImageSavingEventArgs args)
        {

            for (int i = 0; i < ViewModelMain.ModelList.Count; i++)
            {
                if (_imageName == ViewModelMain.ModelList[i].ImageName)
                {
                    ViewModelMain.ModelList[i].Strm = imageEditor.GetSerializedObject();
                }
            }

        }


        private bool isSettingsOpen;
        Model data;
        ImageSource scr = null;
        ViewModel ViewModelMain;
        string location = "";
        string _imageName = "";

        public ImageEditorPage(ImageSource imagesource, ViewModel viewModel, Model model)
        {
            data = model;
            ViewModelMain = viewModel;
            this.BindingContext = ViewModelMain;
            scr = imagesource;
            InitializeComponent();
            imageEditor.ImageSaving += ImageEditor_ImageSaving;
            imageEditor.SetToolbarItemVisibility("Text,Path,Shape,Transform,Reset,Undo,Redo,Save", true);
            imageEditor.Source = imagesource;
            CustomHeader item1 = new CustomHeader();
            item1.Icon = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.settings.png");
            item1.HeaderName = "Settings";
            CustomHeader item2 = new CustomHeader();
            item2.HeaderName = "Share";
            item2.Icon = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.share.png");

            CustomHeader item3 = new CustomHeader();
            item3.Icon = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.info_24.png");
            item3.HeaderName = "About";
            imageEditor.ToolbarSettings.ToolbarItems.Add(item1);
            imageEditor.ToolbarSettings.ToolbarItems.Add(item2);
            imageEditor.ToolbarSettings.ToolbarItems.Add(item3);



            imageEditor.ToolbarSettings.ToolbarItemSelected += (sender, e) => {

                if (e.Toolbar is CustomHeader)
                {

                    var text = (e.Toolbar as CustomHeader).HeaderName;
                    if (text == "Share")
                    {
                        Share();
                    }

                    if (text == "Settings")
                    {
                        OpenSettings();
                    }
                    if (text == "About")
                    {
                        string strin = "ImageEditor allows you to serialize and deserialize any custom edits(Shapes,Text,Path) over an image. In this sample we have deserialized some custom edits and loaded in to the editor.";

                        DisplayAlert("About this sample", strin.ToString(), "OK");
                    }
                }


            };

            DelayActionAsync(1500, Action);
        }


        void ViewTapped(object sender, System.EventArgs e)
        {
            isSettingsOpen = false;
            TouchView.IsVisible = false;
            ClosePropertiesView();
        }


        void Action1()
        {
            for (int i = 0; i < ViewModelMain.ModelList.Count; i++)
            {
                if (_imageName == ViewModelMain.ModelList[i].ImageName)
                {
                    var str = ViewModelMain.ModelList[i].Strm;
                    imageEditor.LoadAsJson(str);
                }
            }
        }


        void Action()
        {

            for (int i = 0; i < ViewModelMain.ModelList.Count; i++)
            {
                if (scr == ViewModelMain.ModelList[i].Name)
                {
                    _imageName = ViewModelMain.ModelList[i].ImageName;
                    ViewModelMain.ModelList[i].Strm = imageEditor.GetSerializedObject();
                    var assembly = typeof(App).GetTypeInfo().Assembly;
                    Stream stream = assembly.GetManifestResourceStream("" + ViewModelMain.ModelList[i].Imagestream);
                    imageEditor.LoadAsJson(stream);

                }
            }
        }

        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);

            action();
        }

        void OpenSettings()
        {
            if (isSettingsOpen)
            {
                isSettingsOpen = false;
                TouchView.IsVisible = false;
                ClosePropertiesView();
            }
            else
            {
                isSettingsOpen = true;
                propertiesView.IsVisible = true;
                TouchView.IsVisible = true;
                OpenPropertiesView();
            }
        }

        void EditorTapped(object sender, System.EventArgs e)
        {
            OpenSettings();
        }


        void Share()
        {


            imageEditor.Save();
            imageEditor.ImageSaving += (sender, args) => {
            };
            imageEditor.ImageSaved += (sender, args) =>
            {
                location = args.Location;
            };
            DelayActionAsync(2500, Sharing);


        }

        void Sharing()
        {
            var temp = location;
            var filePath = DependencyService.Get<IFileStore>().GetFilePath();
            var share = DependencyService.Get<IShare>();
            share.Show("Title", "Message", temp);
        }


        void OpenPropertiesView()
        {
            if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 0, 0.25, 0.5));
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 1, 1, 0.5));
                    this.Opacity = 0.5;
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 1, 1, 0.25));
                    this.Opacity = 0.5;
                }
                if (!absoluteLay.Children.Contains(propertiesView))
                    absoluteLay.Children.Add(propertiesView);
            }
            else
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 1, 0.55, 1));
                }
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 1, 0.7, 1));
                }

                propertiesView.TranslateTo((-this.Width + 2 * propertiesView.Width) / 20, 0, 400, Easing.Linear);

            }
            lstView.ItemsSource = ViewModelMain.ModelList;

        }
        void ClosePropertiesView()
        {
            if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone)
            {
                if (absoluteLay.Children.Contains(propertiesView))
                    absoluteLay.Children.Remove(propertiesView);
                if (Device.Idiom == TargetIdiom.Phone)
                    this.Opacity = 1;
            }
            else
            {
                propertiesView.TranslateTo(this.Width, 0, 400, Easing.Linear);
            }
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            data = ((sender as ListView).SelectedItem as Model);
            _imageName = data.ImageName;
            ClosePropertiesView();
            imageEditor.IsVisible = true;
            TouchView.IsVisible = false;
            isSettingsOpen = false;
            imageEditor.Source = data.Name;
            DelayActionAsync(1500, Action1);
        }
    }
    public class CustomHeader : HeaderToolBarItem
    {

        public string HeaderName { get; set; }
    }
}
