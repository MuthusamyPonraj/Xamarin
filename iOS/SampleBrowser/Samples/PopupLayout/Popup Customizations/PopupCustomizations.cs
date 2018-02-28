#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfDataGrid;
using Syncfusion.iOS.PopupLayout;
using UIKit;

namespace SampleBrowser
{
	public class PopupCustomizations : SampleView
    {
        #region Fields

        internal static SfDataGrid datagrid;
        TicketBookingViewModel viewModel;
        SfPopupLayout popupLayout;
        UIView mainView;
		UILabel message;


        #endregion
        public PopupCustomizations()
		{
            CreateMainView();
            CreateDataGrid();
            CreatePopup();
            this.AddSubview(popupLayout);
        }

        private void CreateMainView()
        {
            mainView = new UIView();

        }

        private void CreateDataGrid()
        {
            datagrid = new SfDataGrid();
            viewModel = new TicketBookingViewModel();
            datagrid.AutoGenerateColumns = false;
            datagrid.ColumnSizer = ColumnSizer.Star;
            datagrid.RowHeight = 117;
            datagrid.GridLoaded += datagrid_GridLoaded; 

            GridTextColumn movieList = new GridTextColumn();
            movieList.HeaderText = "Movies List";
            movieList.HeaderTextAlignment = UIKit.UITextAlignment.Center;
            movieList.UserCellType = typeof(MovieTile);

            datagrid.Columns.Add(movieList);
            datagrid.ItemsSource = viewModel.TheaterInformation;
            mainView.AddSubview(datagrid);
        }

        private void datagrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            popupLayout.PopupView.HeaderTitle = "Book tickets !";
            popupLayout.PopupView.AcceptButtonText = "OK";
			message = new UILabel();
			message.Font = UIFont.SystemFontOfSize(12);
			message.BackgroundColor = UIColor.White;
            message.TextColor = UIColor.Black;
			message.Text = "Click on the book button to start booking tickets";
            UIView view = new UIView();
			popupLayout.PopupView.ContentView = view;
            view.BackgroundColor = UIColor.White;
            view.AddSubview(message);
            popupLayout.PopupView.AppearanceMode = AppearanceMode.OneButton;
            popupLayout.PopupView.PopupStyle.BorderThickness = 1;
            popupLayout.PopupView.PopupStyle.BorderColor = UIColor.Black;
            popupLayout.PopupView.PopupStyle.CornerRadius = 10;
            popupLayout.PopupView.ShowCloseButton = false;
            popupLayout.PopupView.PopupStyle.HeaderFontSize = 17;
			popupLayout.PopupView.FooterHeight = 50;
            popupLayout.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            popupLayout.PopupView.PopupStyle.AcceptButtonBackgroundColor = UIColor.White;
            popupLayout.PopupView.Frame = new CGRect(-1, -1, -1, 200);
            popupLayout.StaysOpen = true;
            popupLayout.IsOpen = true;
            message.Frame = new CGRect(10, 0, popupLayout.PopupView.Frame.Width - 20, view.Frame.Height);
        }

        private void CreatePopup()
        {
            popupLayout = new SfPopupLayout();
            popupLayout.Content = mainView;
        }

        public override void LayoutSubviews()
        {
            mainView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
			datagrid.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            popupLayout.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }
    }
}
