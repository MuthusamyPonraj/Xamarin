#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Views;
using System.Globalization;

namespace SampleBrowser
{
	public class Grouping:SamplePage
	{
		SfDataGrid sfGrid;
		GroupingViewModel viewModel;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new GroupingViewModel ();
			sfGrid.ItemsSource = viewModel.ProductDetails;
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.AllowGroupExpandCollapse = true;
			sfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription (){ ColumnName = "Product" });
			sfGrid.AutoGeneratingColumn += OnAutoGenerateColumn;
			sfGrid.QueryRowHeight += SfGrid_QueryRowHeight;
            sfGrid.AllowResizingColumn = true;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            sfGrid.ColumnSizer = ColumnSizer.Auto;
            //TableSummary codes
            GridTableSummaryRow summaryRow = new GridTableSummaryRow();
            summaryRow.Title = "Total items:{Total} items";
            summaryRow.ShowSummaryInRow = true;
            summaryRow.Position = Position.Bottom;
            GridSummaryColumn summaryColumn = new GridSummaryColumn();
            summaryColumn.Name = "Total";
            summaryColumn.MappingName = "OrderID";
            summaryColumn.Format = "{Count}";
            summaryColumn.SummaryType = Syncfusion.Data.SummaryType.CountAggregate;
            summaryRow.SummaryColumns.Add(summaryColumn);
            sfGrid.TableSummaryRows.Add(summaryRow);

            return sfGrid;
		}
		void SfGrid_QueryRowHeight (object sender, QueryRowHeightEventArgs e)
		{
			if (SfDataGridHelpers.IsCaptionSummaryRow (this.sfGrid, e.RowIndex)) {
                e.Height = 35 * sfGrid.Resources.DisplayMetrics.Density;
				e.Handled = true;
			}
		}

		void OnAutoGenerateColumn (object sender, AutoGeneratingColumnEventArgs e)
		{
            if (MainActivity.isTablet)
                e.Column.MaximumWidth = 300;
            else
                e.Column.MaximumWidth = 150;

            if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
			} else if (e.Column.MappingName == "UserRating") {
				e.Column.HeaderText = "User Rating";
			} else if (e.Column.MappingName == "ProductModel") {
				e.Column.HeaderText = "Product Model";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Price") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "ShippingDays") {
				e.Column.HeaderText = "Shipping Days";
			} else if (e.Column.MappingName == "ProductType") {
				e.Column.HeaderText = "Product Type";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
				e.Column.TextMargin = 10;
			} else if (e.Column.MappingName == "Availability") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
				e.Column.TextMargin = 10;
			}
		}

		public override void Destroy ()
		{
			this.sfGrid.AutoGeneratingColumn -= OnAutoGenerateColumn;
			this.sfGrid.QueryRowHeight -= SfGrid_QueryRowHeight;
			this.sfGrid.Dispose ();
			this.sfGrid = null;
			this.viewModel = null;
		}
	}
}

