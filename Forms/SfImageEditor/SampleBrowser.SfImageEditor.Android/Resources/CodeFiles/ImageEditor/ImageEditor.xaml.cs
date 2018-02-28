#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfImageEditor.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfImageEditor
{
	public partial class ImageEditor : SampleView
	{
		Grid filePickerGrid;


		bool isTakePhoto = false, isOpenGallery = false;

        
		void ImageTapped(object sender, System.EventArgs e)
		{
			LoadFromStream((sender as Image).Source);
		}

		void LoadFromStream(ImageSource source)
		{
            if (Device.OS == TargetPlatform.iOS)
            {
                Navigation.PushAsync(new NavigationPage(new SfImageEditorPage(source)));
            }
            else if (Device.OS == TargetPlatform.Windows)
            {
                Navigation.PushAsync(new SfImageEditorPage(source));
            }
            else
            {
                Navigation.PushModalAsync(new SfImageEditorPage(source));
            }
		}
        

		ImageModel model;
		public ImageEditor()
		{
			model = new ImageModel();
			BindingContext = model;
			InitializeComponent();
		}
	}

	public class ImageModel : INotifyPropertyChanged
	{
		public ImageSource BroweImage1 { get; set; }
		public ImageSource BroweImage2 { get; set; }
		public ImageSource BroweImage3 { get; set; }
	    public int UndoCount { get; set; }
	    public int RedoCount { get; set; }

	    private bool isColorPaletteVisible;

	    public bool IsColorPaletteVisible
	    {
	        get { return isColorPaletteVisible; }
	        set
	        {
	            isColorPaletteVisible = value;
                OnPropertyChanged("IsColorPaletteVisible");
	        }
	    }

	    public bool IsImageEdited { get; set; }

	    private bool isTouched;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsTouched
	    {
	        get { return isTouched; }
	        set
	        {
	            isTouched = value;
                OnPropertyChanged("IsTouched");
	        }
	    }

	    public ImageModel()
		{
			BroweImage1 = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.image2.png");
			BroweImage2 = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.image3.png");
			BroweImage3 = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.image4.png");
		}

	    private void OnPropertyChanged(string name)
	    {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	    }

	    public void DetectTouch()
	    {
	        IsTouched = !isTouched;
	        OnPropertyChanged("IsTouched");
        }
	}

	public class SfImageEditorPage : ContentPage
	{
		public SfImageEditorPage(ImageSource imagesource)
		{
            Syncfusion.SfImageEditor.XForms.SfImageEditor editor = new Syncfusion.SfImageEditor.XForms.SfImageEditor();
			editor.Source = imagesource;
           
			Content = editor;
		}
	}
}
