#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Globalization;
using System.Linq;
using System.ComponentModel;

namespace SampleBrowser
{
	public class Sorting:SamplePage
	{
		SfDataGrid sfGrid;
		SortingViewModel viewModel;
		CheckBox allowsorting;
		CheckBox allowtristatesorting;
		CheckBox allowsortingforSupplierID;
		CheckBox allowsortingforProductID;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new SortingViewModel ();
			viewModel.SetRowstoGenerate (100);
			sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			sfGrid.ItemsSource = viewModel.Products;
            sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.AllowSorting = true;
			sfGrid.AllowTriStateSorting = true;
			sfGrid.GridStyle.AlternatingRowColor = Color.Rgb(206, 206, 206);
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            this.sfGrid.SortColumnDescriptions.Add (new SortColumnDescription (){ ColumnName ="ProductID", SortDirection = ListSortDirection.Descending });
			return sfGrid;
		}

		public override void OnApplyChanges ()
		{
			base.OnApplyChanges ();
		}

		public override View GetPropertyWindowLayout (Android.Content.Context context)
		{
			LinearLayout linear = new LinearLayout (context);
			linear.Orientation = Orientation.Vertical;
			allowsorting = new CheckBox (context);
			allowtristatesorting = new CheckBox (context);
			allowsortingforSupplierID = new CheckBox (context);
			allowsortingforProductID = new CheckBox (context);

			allowsorting.Text = "Allow Sorting";
			allowtristatesorting.Text = "Allow TriState Sorting";
			allowsortingforSupplierID.Text = "Allow Sorting For SupplierID";
			allowsortingforProductID.Text = "Allow Sorting For ProductID";

			allowsorting.Checked = true;
			allowtristatesorting.Checked = true;
			allowsortingforSupplierID.Checked = true;
			allowsortingforProductID.Checked = true;

			allowsorting.CheckedChange += OnAllowSortingChanged;
			allowtristatesorting.CheckedChange += OnAllowTriStateSortingChanged;
			allowsortingforProductID.CheckedChange += OnSortingForProductIDChanged;
			allowsortingforSupplierID.CheckedChange += OnSortingForSupplierIDChanged;
			linear.AddView (allowsorting);
			linear.AddView (allowtristatesorting);
			linear.AddView (allowsortingforSupplierID);
			linear.AddView (allowsortingforProductID);
			return linear;
		}

		void OnSortingForSupplierIDChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			var supplierId = sfGrid.Columns.FirstOrDefault (x => x.MappingName == "SupplierID");

			if (e.IsChecked)
				supplierId.AllowSorting = true;
			else
				supplierId.AllowSorting = false;
		}

		void OnAllowTriStateSortingChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
				sfGrid.AllowTriStateSorting = true;
			else
				sfGrid.AllowTriStateSorting = false;
		}

		void OnSortingForProductIDChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			var productId = sfGrid.Columns.FirstOrDefault (x => x.MappingName == "ProductID");

			if (e.IsChecked)
				productId.AllowSorting = true;
			else
				productId.AllowSorting = false;
		}

		void OnAllowSortingChanged (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			if (e.IsChecked)
				sfGrid.AllowSorting = true;
			else
				sfGrid.AllowSorting = false;
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "SupplierID") {
				e.Column.HeaderText = "Supplier ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ProductName") {
				e.Column.HeaderText = "Product Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Quantity") {
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "UnitPrice") {
				e.Column.HeaderText = "Unit Price";
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "UnitsInStock") {
				e.Column.HeaderText = "Units In Stock";
				e.Column.TextAlignment = GravityFlags.Center;
			}
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
			sfGrid.Dispose ();
			sfGrid = null;
			allowsorting = null;
			allowtristatesorting = null;
			allowsortingforProductID = null;
			allowsortingforSupplierID = null;
			viewModel = null;
		}
	}
}

