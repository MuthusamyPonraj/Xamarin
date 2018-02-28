#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfCarousel.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfCarousel
{
	public partial class Carousel_Tablet : SampleView
	{
	
		
		public Carousel_Tablet()
		{
			InitializeComponent();
			carousel.SelectedItemOffset = 0;
			carousel.DataSource = GetDataSource();
			DeviceChanges();

            modePicker.WidthRequest = 150;
            modePicker.Items.Add("Default");
            modePicker.Items.Add("Linear");
            modePicker.SelectedIndex = 0;
            modePicker.SelectedIndexChanged += viewmodePicker_SelectedIndexChanged;
		}

		void DeviceChanges()
		{
			
			if (Device.OS == TargetPlatform.iOS)
			{
				carousel.ItemHeight = 300;
				carousel.ItemWidth = 150;

			}

            if (Device.OS == TargetPlatform.Android)
            {

                carousel.ItemHeight = Convert.ToInt32(300);
                carousel.ItemWidth = Convert.ToInt32(180);

            }
		}
	

		void viewmodePicker_SelectedIndexChanged(object sender, EventArgs e)
		{

			switch (modePicker.SelectedIndex)
			{
				case 0:
					carousel.ViewMode = ViewMode.Default;
					break;
				case 1:
					carousel.ViewMode = ViewMode.Linear;
					break;
			}
		}
		
		public void offsetValue_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				carousel.Offset = int.Parse(e.NewTextValue);
			}
		}
		public void ScaleValue_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				if (float.Parse(e.NewTextValue) <= 1)
				{
					carousel.ScaleOffset = float.Parse(e.NewTextValue);
				}
				else
				{
					carousel.ScaleOffset = 0.8f;

				}
			}
		}

		#region DataSource
		List<CarouselModel> GetDataSource()
		{
			List<CarouselModel> list = new List<CarouselModel>();
			list.Add(new CarouselModel("carousel_person1.png"));
			list.Add(new CarouselModel("carousel_person2.png"));
			list.Add(new CarouselModel("carousel_person3.png"));
			list.Add(new CarouselModel("carousel_person4.png"));
			list.Add(new CarouselModel("carousel_person5.png"));
			return list;
		}
		#endregion

		public void rotateValue_Changed(object c, TextChangedEventArgs e)
		{
			if (e.NewTextValue.Length > 0)
			{
				if (float.Parse(e.NewTextValue) > 0 && float.Parse(e.NewTextValue) <= 360)
				{

					carousel.RotationAngle = int.Parse(e.NewTextValue);
				}
				else
				{
					carousel.RotationAngle = 45;

				}
			}
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


