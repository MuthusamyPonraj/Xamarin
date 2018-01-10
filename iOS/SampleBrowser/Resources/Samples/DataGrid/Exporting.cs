#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Foundation;
using QuickLook;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.Exporting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Reflection;
using UIKit;

namespace SampleBrowser
{
    public class Exporting : SampleView
    {
        #region Fields

        SfDataGrid SfGrid;
        UIButton exportPdf;
        UIButton exportExcel;
        #endregion

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

		public Exporting()
		{
			this.SfGrid = new SfDataGrid();
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.ItemsSource = new ExportingViewModel().OrdersInfo;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			exportPdf = new UIButton(UIButtonType.RoundedRect);
			exportPdf.Layer.CornerRadius = 5;
			exportPdf.SetTitleColor (UIColor.Black, UIControlState.Normal);
			exportPdf.SetTitle("Export To Pdf",UIControlState.Normal);
			exportPdf.BackgroundColor = UIColor.FromRGB(212,208,200);
			exportPdf.TouchDown += ExportToPdf;

			exportExcel = new UIButton(UIButtonType.RoundedRect);
			exportExcel.SetTitle("Export To Excel", UIControlState.Normal);
			exportExcel.SetTitleColor (UIColor.Black, UIControlState.Normal);
			exportExcel.Layer.CornerRadius = 5;
			exportExcel.BackgroundColor = UIColor.FromRGB(212, 208, 200);
			exportExcel.TouchDown += ExportToExcel;            
			this.AddSubview(exportExcel);            
			this.AddSubview(exportPdf);            
			this.AddSubview(this.SfGrid);
		}

		private void ExportToExcel(object sender, EventArgs e)
		{
			DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
			var excelEngine = excelExport.ExportToExcel(this.SfGrid , new DataGridExcelExportingOption() {ExportRowHeight = false,ExportColumnWidth = false , DefaultColumnWidth = 100, DefaultRowHeight =  60});
			var workbook = excelEngine.Excel.Workbooks[0];
			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();
			Save("DataGrid.xlsx", "application/msexcel", stream);
		}

		private void ExportToPdf(object sender, EventArgs e)
		{
			DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
			MemoryStream stream = new MemoryStream();
			pdfExport.HeaderAndFooterExporting += pdfExport_HeaderAndFooterExporting;
			var doc = pdfExport.ExportToPdf(this.SfGrid);
			doc.Save(stream);
			doc.Close(true);
			Save("DataGrid.pdf", "application/pdf", stream);
		}

		private void pdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
		{
			var width = e.PdfPage.GetClientSize().Width;

			PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
			var assmbely = Assembly.GetExecutingAssembly();
			var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.Resources.Images.SyncfusionLogo.jpg");
			PdfImage pdfImage = PdfImage.FromStream(imagestream);
			header.Graphics.DrawImage(pdfImage, new RectangleF(0, 0, width, 50));
			e.PdfDocumentTemplate.Top = header;
		}


		private void Save(string filename, string contentType, MemoryStream stream)
		{
			string exception = string.Empty;
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filePath = Path.Combine(path, filename);
			try
			{
				FileStream fileStream = File.Open(filePath, FileMode.Create);
				stream.Position = 0;
				stream.CopyTo(fileStream);
				fileStream.Flush();
				fileStream.Close();
			}
			catch (Exception e)
			{
				exception = e.ToString();
			}
			if (contentType == "application/html" || exception != string.Empty)
				return;
			UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			while (currentController.PresentedViewController != null)
				currentController = currentController.PresentedViewController;
			UIView currentView = currentController.View;

			QLPreviewController qlPreview = new QLPreviewController();
			QLPreviewItem item = new QLPreviewItemBundles(filename, filePath);
			qlPreview.DataSource = new PreviewControllersDS(item);

			currentController.PresentViewController((UIViewController)qlPreview, true, (Action)null);
		}

		void GridAutoGenerateColumns(object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "OrderID")
			{
				e.Column.HeaderText = "Order ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "CustomerID")
			{
				e.Column.HeaderText = "Customer ID";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "Freight")
			{
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo("en-US");
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "ShipCity")
			{
				e.Column.HeaderText = "Ship City";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "ShipCountry")
			{
				e.Column.HeaderText = "Ship Country";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "Index")
			{
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "EmployeeID")
			{
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "FirstName")
			{
				e.Column.HeaderText = "First Name";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "LastName")
			{
				e.Column.HeaderText = "Last Name";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "Gender")
			{
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 20;
			}
			else if (e.Column.MappingName == "ShippingDate")
			{
				e.Column.HeaderText = "Shipping Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			}
			else if (e.Column.MappingName == "IsClosed")
			{
				e.Column.HeaderText = "Is Closed";
				e.Column.TextMargin = 30;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
		}

		public override void LayoutSubviews()
		{
            this.exportPdf.Frame = new CGRect((this.Frame.Left + 15), 10, ((this.Frame.Right / 2) - 30), 50);
            this.exportExcel.Frame = new CGRect(((this.Frame.Right / 2) + 15), 10, ((this.Frame.Right / 2) - 30), 50);
            this.SfGrid.Frame = new CGRect(0, 70, this.Frame.Width, this.Frame.Height - 70);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SfGrid.Dispose();
        }
    }

	public class QLPreviewItemBundles : QLPreviewItem
	{
		string _fileName, _filePath;
		public QLPreviewItemBundles(string fileName, string filePath)
		{
			_fileName = fileName;
			_filePath = filePath;
		}

		public override string ItemTitle
		{
			get
			{
				return _fileName;
			}
		}
		public override NSUrl ItemUrl
		{
			get
			{
				var documents = NSBundle.MainBundle.BundlePath;
				var lib = Path.Combine(documents, _filePath);
				var url = NSUrl.FromFilename(lib);
				return url;
			}
		}
	}

	public class PreviewControllersDS : QLPreviewControllerDataSource
	{
		private QLPreviewItem _item;

		public PreviewControllersDS(QLPreviewItem item)
		{
			_item = item;
		}

		public override nint PreviewItemCount(QLPreviewController controller)
		{
			return (nint)1;
		}

		public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
		{
			return _item;
		}
	}
}
