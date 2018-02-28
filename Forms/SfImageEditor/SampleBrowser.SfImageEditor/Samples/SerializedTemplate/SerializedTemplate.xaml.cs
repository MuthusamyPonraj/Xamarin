#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfImageEditor.XForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SampleBrowser.SfImageEditor
{
    public partial class SerializedTemplate : SampleView
    {
        ImageSerializeModel model;

        ViewModel viewModel;

        Model data;
       
        public SerializedTemplate()
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
               Navigation.PushAsync(new NavigationPage(new ImageEditorPage(source, viewModel, data)));
            }
			 else if (Device.OS == TargetPlatform.Windows)
            {
                Navigation.PushAsync(new ImageEditorPage(source, viewModel, data));
            }
            else
            {
                Navigation.PushModalAsync(new ImageEditorPage(source, viewModel, data));
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
              
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.banner1.jpg"),Imagestream="SampleBrowser.SfImageEditor.Icons.Ban1.txt",ImageName="Coffee"},
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.banner2.jpg"),Imagestream="SampleBrowser.SfImageEditor.Icons.Ban2.txt",ImageName="Food"},
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.banner3.jpg"),Imagestream="SampleBrowser.SfImageEditor.Icons.Ban3.txt",ImageName="Syncfusion"},

            };

            for (int i = 0; i < ModelList.Count; i++)
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("" + ModelList[i].Imagestream);
                ModelList[i].Strm = stream;

            }


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
