#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public partial class Tooltip : SampleBrowser.Core.SampleView
    {
        public Tooltip()
        {
            InitializeComponent();
            tooltipBehavior.BackgroundColor = Color.FromRgb(193, 39, 45);
            tooltipBehavior.Margin = 3.5;
            splineSeries.Color = Color.FromRgb(255, 150, 00);
            dataMarker.MarkerColor = Color.FromRgb(250, 0, 0);
            var data = new TooltipViewModel();
            splineSeries.ItemsSource = data.TooltipData;
            if (Device.Idiom == TargetIdiom.Desktop)
            {
                lineStyle.StrokeWidth = 0;
                splineSeries.TooltipTemplate = stack.Resources["toolTipTemplate_Desktop"] as DataTemplate;
            }
            else
                splineSeries.TooltipTemplate = stack.Resources["toolTipTemplate_Phone"] as DataTemplate;
        }
    }
}