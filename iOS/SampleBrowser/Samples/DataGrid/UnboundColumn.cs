#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Syncfusion.SfDataGrid;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    class UnboundColumn: SampleView
    {
        #region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public UnboundColumn ()
		{
			this.SfGrid = new SfDataGrid ();
            this.SfGrid.ColumnSizer = ColumnSizer.Auto;
            this.SfGrid.SelectionMode = SelectionMode.Single;
            this.SfGrid.AutoGenerateColumns = false;
			this.SfGrid.ItemsSource = new UnboundViewModel ().Products;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
            this.SfGrid.GridStyle = new Blue();
            this.SfGrid.AllowResizingColumn = true;
            this.SfGrid.GridStyle = new CustomGridStyle();

            GridTextColumn ProductName = new GridTextColumn();
            ProductName.HeaderText = "Product Name";
            ProductName.LineBreakMode = UILineBreakMode.WordWrap;
            ProductName.TextAlignment = UITextAlignment.Left;
            ProductName.HeaderTextAlignment = UITextAlignment.Center;
            //ProductName.HeaderCellTextSize = 12;
            ProductName.MappingName = "ProductName";
            SfGrid.Columns.Add(ProductName);

            GridTextColumn UnitPrice = new GridTextColumn();
            UnitPrice.HeaderText = "Price";
            UnitPrice.Format = "C";
            UnitPrice.HeaderTextAlignment = UITextAlignment.Center;
            //UnitPrice.HeaderCellTextSize = 12;
            UnitPrice.TextAlignment = UITextAlignment.Center;
            UnitPrice.MappingName = "UnitPrice";
            SfGrid.Columns.Add(UnitPrice);

            GridTextColumn Quantity = new GridTextColumn();
            Quantity.HeaderText = "Quantity";
            Quantity.HeaderTextAlignment = UITextAlignment.Center;
            //Quantity.HeaderCellTextSize = 12;
            Quantity.MappingName = "Quantity";
            Quantity.TextAlignment = UITextAlignment.Center;
            SfGrid.Columns.Add(Quantity);

            GridUnboundColumn Amount = new GridUnboundColumn();
            Amount.HeaderText = "Amount";
            Amount.TextAlignment = UITextAlignment.Left;
            Amount.Expression = "UnitPrice * Quantity";
            Amount.Format = "C";
            Amount.HeaderTextAlignment = UITextAlignment.Center;
            Amount.TextAlignment = UITextAlignment.Center;
            //Amount.HeaderCellTextSize = 12;
            Amount.MappingName = "Amount";
            SfGrid.Columns.Add(Amount);

            GridUnboundColumn Total = new GridUnboundColumn();
            //Total.HeaderTemplate = label;
            Total.TextAlignment = UITextAlignment.Left;
            Total.Expression = "(Quantity * UnitPrice) - ((Quantity * UnitPrice)/100 * Quantity)";
            Total.Format = "C";
            Total.HeaderText = "Discounted Total";
            Total.HeaderTextAlignment = UITextAlignment.Center;
            //Total.HeaderCellTextSize  = UIFont.siz;
            Total.TextAlignment = UITextAlignment.Center ;
            Total.MappingName = "Total";
            SfGrid.Columns.Add(Total);
            foreach (GridColumn column in SfGrid.Columns)
            {
                if (UserInterfaceIdiomIsPhone)
                    SfGrid.ColumnSizer = ColumnSizer.None;
                else
                    SfGrid.ColumnSizer = ColumnSizer.Star;
            }
            this.AddSubview (SfGrid);
		}
        public override void LayoutSubviews()
        {
            this.SfGrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SfGrid.Dispose();
        }
    }
}
