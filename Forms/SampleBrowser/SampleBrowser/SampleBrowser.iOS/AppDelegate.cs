#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using SampleBrowser.Core.iOS;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.RangeNavigator.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfBarcode.XForms.iOS;
using Syncfusion.SfNavigationDrawer.XForms.iOS;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.SfCarousel.XForms.iOS;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.SfGauge.XForms.iOS;
using Syncfusion.SfImageEditor.XForms.iOS;
using Syncfusion.SfKanban.XForms.iOS;
using Syncfusion.SfMaps.XForms.iOS;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.SfNumericUpDown.XForms.iOS;
using Syncfusion.SfPicker.XForms.iOS;
using Syncfusion.SfPullToRefresh.XForms.iOS;
using Syncfusion.SfRadialMenu.XForms.iOS;
using Syncfusion.SfRangeSlider.XForms.iOS;
using Syncfusion.SfRotator.XForms.iOS;
using Syncfusion.SfSchedule.XForms.iOS;
using Syncfusion.SfSparkline.XForms.iOS;
using Syncfusion.SfSunburstChart.XForms.iOS;
using Syncfusion.SfTreeMap.XForms.iOS;
using Syncfusion.SfPdfViewer.XForms.iOS;
using Syncfusion.SfDiagram.XForms.iOS;
using Syncfusion.SfDataGrid.XForms.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SampleBrowseriOS))]

namespace SampleBrowser.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
		App formsApp;
		protected App FormsApp
		{
			get
			{
				return formsApp;
			}
		}

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            SfSparkline.SfSparklineSampleBrowser.Init();
            SfSparkline.iOS.SfSparklineSampleBrowser.Init();
            SfKanban.SfKanbanSampleBrowser.Init();
            SfKanban.iOS.SfKanbanSampleBrowser.Init();
            SfSunburstChart.SfSunburstChartSampleBrowser.Init();
            SfSunburstChart.iOS.SfSunburstChartSampleBrowser.Init();
            SfChart.SfChartSampleBrowser.Init();
            SfChart.iOS.SfChartSampleBrowser.Init();
			SfTreeMap.SfTreeMapSampleBrowser.Init();
            SfTreeMap.iOS.SfTreeMapSampleBrowser.Init();
            SfMaps.SfMapsSampleBrowser.Init();
            SfMaps.iOS.SfMapsSampleBrowser.Init();
			SfLinearGauge.SfLinearGaugeSampleBrowser.Init();
            SfLinearGauge.iOS.SfLinearGaugeSampleBrowser.Init();
            SfCircularGauge.SfCircularGaugeSampleBrowser.Init();
            SfCircularGauge.iOS.SfCircularGaugeSampleBrowser.Init();
            SfDigitalGauge.SfDigitalGaugeSampleBrowser.Init();
            SfDigitalGauge.iOS.SfDigitalGaugeSampleBrowser.Init();
            SfImageEditor.SfImageEditorSampleBrowser.Init();
            SfImageEditor.iOS.SfImageEditorSampleBrowser.Init();
            SfListView.SfListViewSampleBrowser.Init();
            SfListView.iOS.SfListViewSampleBrowser.Init();
			SfPdfViewer.SfPdfViewerSampleBrowser.Init();
			SfPdfViewer.iOS.SfPdfViewerSampleBrowser.Init();
			SfDiagram.SfDiagramSampleBrowser.Init();
			SfDiagram.iOS.SfDiagramSampleBrowser.Init();
            SfDataGrid.SfDataGridSampleBrowser.Init();
            SfDataGrid.iOS.SfDataGridSampleBrowser.Init();
            SfPullToRefresh.SfPullToRefreshSampleBrowser.Init();
            SfPullToRefresh.iOS.SfPullToRefreshSampleBrowser.Init();

            SfRangeNavigator.SfRangeNavigatorSampleBrowser.Init();
            SfRangeNavigator.iOS.SfRangeNavigatorSampleBrowser.Init();
			SfBusyIndicator.SfBusyIndicatorSampleBrowser.Init();
			SfBusyIndicator.iOS.SfBusyIndicatorSampleBrowser.Init();
			SfCarousel.SfCarouselSampleBrowser.Init();
			SfCarousel.iOS.SfCarouselSampleBrowser.Init();
			SfCalendar.SfCalendarSampleBrowser.Init();
			SfCalendar.iOS.SfCalendarSampleBrowser.Init();
			SfRating.SfRatingSampleBrowser.Init();
			SfRating.iOS.SfRatingSampleBrowser.Init();
			SfRotator.SfRotatorSampleBrowser.Init();
			SfRotator.iOS.SfRotatorSampleBrowser.Init();
			SfPicker.SfPickerSampleBrowser.Init();
			SfPicker.iOS.SfPickerSampleBrowser.Init();
			SfRadialMenu.SfRadialMenuSampleBrowser.Init();
			SfRadialMenu.iOS.SfRadialMenuSampleBrowser.Init();
			SfRangeSlider.SfRangeSliderSampleBrowser.Init();
			SfRangeSlider.iOS.SfRangeSliderSampleBrowser.Init();
			SfNumericTextBox.SfNumericTextBoxSampleBrowser.Init();
			SfNumericTextBox.iOS.SfNumericTextBoxSampleBrowser.Init();
			SfNumericUpDown.SfNumericUpDownSampleBrowser.Init();
			SfNumericUpDown.iOS.SfNumericUpDownSampleBrowser.Init();
			SfAutoComplete.SfAutoCompleteSampleBrowser.Init();
			SfAutoComplete.iOS.SfAutoCompleteSampleBrowser.Init();
			SfNavigationDrawer.SfNavigationDrawerSampleBrowser.Init();
			SfNavigationDrawer.iOS.SfNavigationDrawerSampleBrowser.Init();


			Calculate.CalculateSampleBrowser.Init();
			Calculate.iOS.CalculateSampleBrowser.Init();
			DataSource.DataSourceSampleBrowser.Init();
			DataSource.iOS.DataSourceSampleBrowser.Init();
			new Syncfusion.SfBarcode.XForms.iOS.SfBarcodeRenderer();
			SfBarcode.SfBarcodeSampleBrowser.Init();
			SfBarcode.iOS.SfBarcodeSampleBrowser.Init();
			SfScheduleRenderer.Init();
			SfSchedule.SfScheduleSampleBrowser.Init();
			SfSchedule.iOS.SfScheduleSampleBrowser.Init();
            XlsIO.XlsIOSampleBrowser.Init();
            XlsIO.iOS.XlsIOSampleBrowser.Init();
			Presentation.PresentationSampleBrowser.Init();
            Presentation.iOS.PresentationSampleBrowser.Init();
			PDF.PDFSampleBrowser.Init();
            PDF.iOS.PDFSampleBrowser.Init();
            DocIO.DocIOSampleBrowser.Init();
            DocIO.iOS.DocIOSampleBrowser.Init();


			SampleBrowseriOS.Init();
            new LongLabelRenderer();
			
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
            Core.iOS.CoreSampleBrowser.Init(UIScreen.MainScreen.Bounds, uiApplication.StatusBarFrame.Size.Height);

            LoadApplication(formsApp = new App());
			SfListViewRenderer.Init();
			SfImageEditorRenderer.Init();
			SfSparklineRenderer.Init();
			SfKanbanRenderer.Init();
			SfChartRenderer.Init();
			SfRangeNavigatorRenderer.Init();
			SfScheduleRenderer.Init();
			SfPickerRenderer.Init();
			SfNavigationDrawerRenderer.Init();
			SfRatingRenderer.Init();
			SfAutoCompleteRenderer.Init();
			SfBusyIndicatorRenderer.Init();
			SfRangeSliderRenderer.Init();
			SfNumericTextBoxRenderer.Init();
			SfRotatorRenderer.Init();
			SfCalendarRenderer.Init();
			SfCarouselRenderer.Init();
			SfNumericUpDownRenderer.Init();
			SfRadialMenuRenderer.Init();
			SfSunburstChartRenderer.Init();
			SfPullToRefreshRenderer.Init();
            SfPdfDocumentViewRenderer.Init();
			SfDiagramRenderer.Init();
			SfImageEditorRenderer.Init();
            SfLinearGaugeRenderer.Init();
            SfDigitalGaugeRenderer.Init();
            SfGaugeRenderer.Init();
            SfDataGridRenderer.Init();
            SfPullToRefreshRenderer.Init();
            new SfMapsRenderer();
            new SfTreeMapRenderer();
			return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    return UIInterfaceOrientationMask.Portrait;
                case TargetIdiom.Tablet:
                    return UIInterfaceOrientationMask.Portrait;
                default:
                    return UIInterfaceOrientationMask.Portrait;
            }
        }
    }
}