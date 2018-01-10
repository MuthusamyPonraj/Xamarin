#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.SfDataGrid.XForms.Exporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ExportingBehaviors : Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private Xamarin.Forms.Image excelImage;
        private Xamarin.Forms.Image pdfImage;
        protected override void OnAttachedTo(SampleView bindable)
        {
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            excelImage = bindable.FindByName<Xamarin.Forms.Image>("excelImage");
            pdfImage = bindable.FindByName<Xamarin.Forms.Image>("pdfImage");
            excelImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(ExportToExcel) });
            pdfImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(ExportToPdf) });
            this.pdfImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.PdfExport.png");
            this.excelImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.ExcelExport.png");
            this.excelImage.Margin = new Thickness(0, 0, 10, 0);
            base.OnAttachedTo(bindable);
        }
        private void ExportToPdf(object obj)
        {
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            pdfExport.HeaderAndFooterExporting += pdfExport_HeaderAndFooterExporting;
            MemoryStream stream = new MemoryStream();
            var doc = pdfExport.ExportToPdf(dataGrid, new DataGridPdfExportOption() { FitAllColumnsInOnePage = true });
            doc.Save(stream);
            doc.Close(true);

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DataGrid.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DataGrid.pdf", "application/pdf", stream);
        }

        private void ExportToExcel(object obj)
        {
            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            DataGridExcelExportingOption exportOption = new DataGridExcelExportingOption();
            if (Device.RuntimePlatform == Device.iOS)
            {
                exportOption.ExportColumnWidth = false;
                exportOption.DefaultColumnWidth = 150;
            }
            var excelEngine = excelExport.ExportToExcel(dataGrid, exportOption);
            var workbook = excelEngine.Excel.Workbooks[0];
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DataGrid.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DataGrid.xlsx", "application/msexcel", stream);
        }

        private void pdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;

            PdfStandardFont font = null;
            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
            var assmbely = this.GetType().GetTypeInfo().Assembly;
            var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.SfDataGrid.Icons.DataGrid.SyncfusionLogo.jpg");
            PdfImage pdfImage = PdfImage.FromStream(imagestream);
            header.Graphics.DrawImage(pdfImage, new RectangleF(width - 148, 0, 148, 60));
            if (Device.RuntimePlatform == Device.iOS)
                font = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
            else
                font = new PdfStandardFont(PdfFontFamily.Helvetica, 13, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            header.Graphics.DrawString("Customer Details", font, PdfBrushes.Black, new RectangleF(0, 25, 200, 60), format);
            e.PdfDocumentTemplate.Top = header;
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            dataGrid = null;
            pdfImage = null;
            excelImage = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
