#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class SemiPieChart : SampleView
	{
		public SemiPieChart()
		{
			InitializeComponent();
			series.ItemsSource = model.SemiCircularData;
			if (!(Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS))
			{
				Chart.Series[0].AnimationDuration = 2;
			}

            if(Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.iOS ||
                Device.OS==TargetPlatform.WinPhone)
            {
                DataMarkerLabelStyle style = new DataMarkerLabelStyle();
                style.Margin = new Thickness(3, 2, 3, 2);
                dataMarker.LabelStyle = style;
            }
        }

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
            if (height > width)
            {
                if (height > width)
                {
                    double padding = (layout.Height - layout.Width) / 2;
                    layout.Padding = new Thickness(0, padding / 2, 0, padding);
                    Chart.Legend.DockPosition = LegendPlacement.Bottom;
                    Chart.Legend.ItemMargin = new Thickness(2, 2, 2, 2);
                }
                else
                {
                    double padding = (layout.Width - layout.Height) / 2;
                    layout.Padding = new Thickness(padding / 2, 0, padding / 2, 0);
                    Chart.Legend.ItemMargin = new Thickness(0, 0, padding / 5, 0);
                    Chart.Legend.DockPosition = LegendPlacement.Right;
                }
            }
		}
	}
}