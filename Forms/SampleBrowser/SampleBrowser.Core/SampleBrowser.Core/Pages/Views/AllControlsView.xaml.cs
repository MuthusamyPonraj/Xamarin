#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms;

namespace SampleBrowser.Core
{
	/// <summary>
	/// View for AllControls View in ControlsHomePage.
	/// </summary>
	public partial class AllControlsView : ContentView
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AllControlsView"/> class.
		/// </summary>
		public AllControlsView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Method for calculating Screen Height and Width.
		/// </summary>
		protected override void OnSizeAllocated(double width, double height)
		{
            if (width > 0 && height > 0)
            {
                double gridWidth = 300;
                grid.HeightRequest = 0.15 * height;
                grid.WidthRequest = gridWidth;
                imageCol.Width = 0.3 * gridWidth;
                if (Device.RuntimePlatform == Device.UWP)
                {
                    grid.HeightRequest = 0.13 * height;
                }
            }
                base.OnSizeAllocated(width, height);
		}
	}
}