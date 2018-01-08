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
using Syncfusion.SfCarousel.XForms;
using System.Collections.ObjectModel;
using SampleBrowser.Core;

namespace SampleBrowser.SfCarousel
{
	public partial class Carousel_Default : SampleView
	{
		#region Constructor
		public Carousel_Default()
		{
			InitializeComponent();
			carousel.SelectedItemOffset = 0;
			DeviceChanges();
			carousel.DataSource = GetDataSource();
			OptionSettings();
		}
		#endregion

		void DeviceChanges()
		{

			if (Device.OS == TargetPlatform.iOS)
			{
				carousel.ItemHeight = 300;
				carousel.ItemWidth = 150;
				optionLayout.Padding = new Thickness(0, 0, 10, 0);
			}

			if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
			{
				carousel.ItemHeight = (int)Core.SampleBrowser.ScreenHeight / 2;
				carousel.ItemWidth = (int)Core.SampleBrowser.ScreenWidth / 2;
                carousel.HeightRequest = 400;
                carousel.WidthRequest = 800;
                carouselLayout.Padding = new Thickness(0, 40, 0, 0);
            }

            if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                carousel.SelectedItemOffset = 80;
                carousel.HeightRequest = 600;
                carousel.WidthRequest = 800;
                carousel.HorizontalOptions = LayoutOptions.CenterAndExpand;
                carouselLayout.Padding = new Thickness(0, 80, 0, 0);
            }
			if (Device.OS == TargetPlatform.Windows)
			{
				carousel.ScaleOffset = 0.5f;
			}
           if (Device.OS == TargetPlatform.Android)
			{
				
                carouselLayout.Padding = new Thickness(0, 80, 0, 0);


			}

		}
		#region Options
		private void OptionSettings()
		{

			if (Device.OS == TargetPlatform.Android)
			{
				//if (App.Density > 1.5)
				{
					carousel.ItemHeight = Convert.ToInt32(250);
					carousel.ItemWidth = Convert.ToInt32(180);
				}
			}
            offset.ValueChanged += OffsetValueChanged;
            scale.ValueChanged+=HandleValueEventHandler;
            rotateangle.ValueChanged+=HandleValueEventHandler1;		
			viewmodePicker.Items.Add("Default");
			viewmodePicker.Items.Add("Linear");
			viewmodePicker.SelectedIndex = 0;
			viewmodePicker.SelectedIndexChanged += viewmodePicker_SelectedIndexChanged;
			Grid.SetColumn(offsetLabel, 0);
			Grid.SetColumn(offset, 1);
			Grid.SetColumn(scaleLabel, 0);
			Grid.SetColumn(scale, 1);
			Grid.SetColumn(rotateLabel, 0);
			Grid.SetColumn(rotateangle, 1);
		}

        void OffsetValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            Decimal temp = Convert.ToDecimal(offset.Value);
            float offsetvalue = (float)temp;
            carousel.Offset = offsetvalue;
        }

        void HandleValueEventHandler(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            Decimal tempvalue = Convert.ToDecimal(scale.Value);
			float scalevalue = (float)tempvalue;

			      if (scalevalue <= 1)
			      {
                carousel.ScaleOffset = scalevalue;
			      }
			      else
			      {
			          carousel.ScaleOffset = 0.8f;
			      }
			
        }

        void HandleValueEventHandler1(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            Decimal temp = Convert.ToDecimal(rotateangle.Value);
            int rotationangle = (int)temp;
			if (rotationangle > 0 && rotationangle <= 360)
            {
                carousel.RotationAngle = rotationangle;
            }
            else
            {
                carousel.RotationAngle = 45;
            }
           
         }

        void viewmodePicker_SelectedIndexChanged(object sender, EventArgs e)
		{

			switch (viewmodePicker.SelectedIndex)
			{
				case 0:
					carousel.ViewMode = ViewMode.Default;
					break;
				case 1:
					carousel.ViewMode = ViewMode.Linear;
					break;
			}
		}
		#endregion

		#region DataSource
		internal List<CarouselModel> GetDataSource()
		{
			List<CarouselModel> list = new List<CarouselModel>();
			if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone)
			{
				list.Add(new CarouselModel(ImagePathConverter.GetImageSource("SampleBrowser.SfCarousel.image1.png")));
				list.Add(new CarouselModel(ImagePathConverter.GetImageSource("SampleBrowser.SfCarousel.image2.png")));
				list.Add(new CarouselModel(ImagePathConverter.GetImageSource("SampleBrowser.SfCarousel.image3.png")));
				list.Add(new CarouselModel(ImagePathConverter.GetImageSource("SampleBrowser.SfCarousel.image4.png")));
				list.Add(new CarouselModel(ImagePathConverter.GetImageSource("SampleBrowser.SfCarousel.image5.png")));
			}
			else
			{
				list.Add(new CarouselModel("image1.png"));
				list.Add(new CarouselModel("image2.png"));
				list.Add(new CarouselModel("image3.png"));
				list.Add(new CarouselModel("image4.png"));
				list.Add(new CarouselModel("image5.png"));
			}
			return list;
		}
		#endregion


		public View getContent()
		{
			return this.Content;
		}
		public View getProperty()
		{
			return this.PropertyView;
		}
	}
}


