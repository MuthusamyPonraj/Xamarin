#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ListView.XForms.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SampleBrowser.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new SampleBrowser.App());

            new Syncfusion.RangeNavigator.XForms.UWP.SfRangeNavigatorRenderer();

            new Syncfusion.SfAutoComplete.XForms.UWP.SfAutoCompleteRenderer();

            new Syncfusion.SfBarcode.XForms.UWP.SfBarcodeRenderer();

            new Syncfusion.SfBusyIndicator.XForms.UWP.SfBusyIndicatorRenderer();

            new Syncfusion.SfCalendar.XForms.UWP.SfCalendarRenderer();

            new Syncfusion.SfChart.XForms.UWP.SfChartRenderer();

            Syncfusion.SfDataGrid.XForms.UWP.SfDataGridRenderer.Init();

            new Syncfusion.SfDiagram.XForms.UWP.SfDiagramRenderer();

            new Syncfusion.SfGauge.XForms.UWP.SfGaugeRenderer();

            new Syncfusion.SfKanban.XForms.UWP.SfKanbanRenderer();

            new Syncfusion.SfMaps.XForms.UWP.SfMapsRenderer();

            new Syncfusion.SfNavigationDrawer.XForms.UWP.SfNavigationDrawerRenderer();

            new Syncfusion.SfPdfViewer.XForms.UWP.SfPdfDocumentViewRenderer();

            new Syncfusion.SfPicker.XForms.UWP.SfPickerRenderer();

            Syncfusion.SfPullToRefresh.XForms.UWP.SfPullToRefreshRenderer.Init();

            new Syncfusion.SfRating.XForms.UWP.SfRatingRenderer();

            new Syncfusion.SfRotator.XForms.UWP.SfRotatorRenderer();

            new Syncfusion.SfSparkline.XForms.UWP.SfSparklineRenderer();

            new Syncfusion.SfSunburstChart.XForms.UWP.SfSunburstChartRenderer();

            new Syncfusion.SfTreeMap.XForms.UWP.SfTreeMapRenderer();

            SfListViewRenderer.Init();
        }
    }
}