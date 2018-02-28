#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class BannerCreator : SampleView
    {
        ImageSerializeModel model;

        ViewModel viewModel;

        Model data;
        public BannerCreator()
        {
            data = new Model();
            viewModel = new ViewModel();
            model = new ImageSerializeModel(viewModel);
            InitializeComponent();
            BindingContext = model;

        }

        void ImageTapped(object sender, System.EventArgs e)
        {

            LoadFromStream((sender as Image).Source, viewModel, data);
        }

        void LoadFromStream(ImageSource source, ViewModel viewModel, Model data)
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                  Navigation.PushAsync(new NavigationPage(new ImageEditorToolbarPage(source, viewModel, data)));
            }
			else if (Device.OS == TargetPlatform.Windows)
            {
                Navigation.PushAsync(new ImageEditorToolbarPage(source, viewModel, data));
            }
            else
            {

                Navigation.PushModalAsync(new ImageEditorToolbarPage(source, viewModel, data));


            }
        }
    }
    public class ImageSerializeModel
    {
        public ImageSource BroweImage1 { get; set; }
        public ImageSource BroweImage2 { get; set; }
        public ImageSource BroweImage3 { get; set; }

        public ImageSerializeModel(ViewModel viewmodel)
        {
            BroweImage1 = viewmodel.ModelList[0].Name;
            BroweImage2 = viewmodel.ModelList[1].Name;
            BroweImage3 = viewmodel.ModelList[2].Name;
        }

    }


    public class ViewModel
    {
        public ObservableCollection<Model> ModelList
        {
            get;
            set;
        }
        public ViewModel()
        {
            ModelList = new ObservableCollection<Model>
            {

                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.dashboard.jpg"),ImageName="Dashboard"} ,
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.succinity.png"),ImageName="Succinity"} ,
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.twitter.jpeg"),ImageName="Twitter"} ,

    };

        }
    }

    public class Model : INotifyPropertyChanged
    {
        private ImageSource name;
        public ImageSource Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");

            }
        }

        private string _imagestream;
        public string Imagestream
        {
            get { return _imagestream; }
            set
            {
                _imagestream = value;
                RaisePropertyChanged("Imagestream");
            }
        }

        private Stream _stream;
        public Stream Strm
        {
            get { return _stream; }
            set
            {
                _stream = value;
                RaisePropertyChanged("Strm");
            }
        }


        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

}
