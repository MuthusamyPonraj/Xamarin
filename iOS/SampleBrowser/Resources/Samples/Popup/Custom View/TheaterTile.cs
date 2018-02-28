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
using Syncfusion.SfPopupLayout;
using UIKit;

namespace SampleBrowser
{
	public class TheaterTile : GridCell
	{
		TheaterLayout theaterLayout;
		UIImageView infoImage;
		UILabel theaterTitle;
		UILabel theaterLocation;
        UILabel timing1;
		UILabel timing2;
		SfPopupLayout popup;
		object rowData;
		public TheaterTile()
		{
			popup = PopupCustomizations.popupLayout;
			theaterLayout = new TheaterLayout();

			infoImage = new UIImageView();
			infoImage.UserInteractionEnabled = true;
			var tapGesture = new UITapGestureRecognizer(DisplayInfo) { NumberOfTapsRequired = 1 };
			infoImage.AddGestureRecognizer(tapGesture);

			theaterTitle = new UILabel();
			theaterTitle.Font = UIFont.PreferredCaption1;

			theaterLocation = new UILabel();
			theaterLocation.Font = UIFont.PreferredFootnote;
			theaterLocation.TextColor = UIColor.LightGray;

			timing1 = new UILabel();
			timing1.TextColor = UIColor.FromRGB(0, 124, 238);
			timing1.Font = UIFont.PreferredCaption2;
			timing1.TextAlignment = UITextAlignment.Center;
			timing1.Layer.BorderColor = UIColor.FromRGBA(0, 124, 238, 26).CGColor;
			timing1.Layer.BorderWidth = 0.5f;
			timing1.UserInteractionEnabled = true;
			var timingTapGesture = new UITapGestureRecognizer(TimingTapped) { NumberOfTapsRequired = 1 };
			timing1.AddGestureRecognizer(timingTapGesture);

			timing2 = new UILabel();
			timing2.TextColor = UIColor.FromRGB(0, 124, 238);
			timing2.Font = UIFont.PreferredCaption2;
			timing2.TextAlignment = UITextAlignment.Center;
			timing2.Layer.BorderColor = UIColor.FromRGBA(0, 124, 238, 26).CGColor;
			timing2.UserInteractionEnabled = true;
			var timingTapGesture2 = new UITapGestureRecognizer(TimingTapped) { NumberOfTapsRequired = 1 };
			timing2.AddGestureRecognizer(timingTapGesture2);
			timing2.Layer.BorderWidth = 0.5f;

			theaterLayout.AddSubview(theaterTitle);
			theaterLayout.AddSubview(theaterLocation);
			theaterLayout.AddSubview(timing1);
			theaterLayout.AddSubview(timing2);
			theaterLayout.AddSubview(infoImage);
			this.AddSubview(theaterLayout);
			this.CanRenderUnLoad = false;
		}

		private void TimingTapped()
		{
			popup.PopupView.HeaderTitle = "Terms & Conditions";
			popup.PopupView.BackgroundColor = UIColor.White;
			popup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
			popup.PopupView.PopupStyle.MessageBackgroundColor = UIColor.White;
			popup.PopupView.PopupStyle.MessageTextColor = UIColor.Gray;
			popup.PopupView.PopupStyle.MessageFontSize = 14;
			popup.PopupView.LayoutAppearance = LayoutAppearance.TwoButton;
			popup.PopupView.HeaderHeight = 50;
			popup.PopupView.PopupStyle.HeaderFontSize = 16;
			popup.PopupView.PopupMessage = "Terms and Conditions are a set of rules and guidelines that a user must agree to in order to use your website or mobile app. It acts as a legal contract where you maintain your rights to exclude users from your app in the event that they abuse you maintain your legal rights.";
			popup.PopupView.AcceptButtonText = "ACCEPT";
			popup.PopupView.DeclineButtonText = "DECLINE";
			popup.PopupView.PopupStyle.AcceptButtonTextColor = UIColor.FromRGB(0,124, 238);
			popup.PopupView.PopupStyle.DeclineButtonTextColor = UIColor.FromRGB(0,124, 238);
			popup.PopupView.PopupStyle.AcceptButtonBackgroundColor = UIColor.White;
			popup.PopupView.PopupStyle.DeclineButtonBackgroundColor = UIColor.White;
			popup.PopupView.AcceptCommand = new AcceptTermsCommand(popup);
			popup.IsOpen = true;
		}

		private void DisplayInfo()
		{
			popup.PopupView.HeaderTitle = (rowData as TicketBookingInfo).TheaterName;
			popup.PopupView.BackgroundColor = UIColor.White;
			popup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
			popup.PopupView.ShowFooter = false;
			popup.PopupView.HeaderHeight = 50;
			popup.PopupView.PopupStyle.HeaderFontSize = 16;
			popup.PopupView.PopupContentView = CreateInfoPopup();
			popup.IsOpen = true;
		}

		private UIView CreateInfoPopup()
		{
			UIView mainview = new UIView();

			UILabel location = new UILabel();
			location.Lines = 10;
			location.Font = UIFont.PreferredCaption1;
			location.TextColor = UIColor.Gray;
			location.LineBreakMode = UILineBreakMode.WordWrap;
			location.Text = (rowData as TicketBookingInfo).TheaterLocation + "421 E DRACHMAN TUCSON AZ 85705 - 7598 USA";

			UILabel facilitiesLabel = new UILabel();
			facilitiesLabel.Text = "Available Facilities";

			UIImageView mtick = new UIImageView();
			mtick.Image = UIImage.FromFile("Images/MTicket.png");

			UIImageView park = new UIImageView();
			park.Image = UIImage.FromFile("Images/Parking.png");

			UIImageView food = new UIImageView();
			food.Image = UIImage.FromFile("Images/FoodCourt.png");

			UILabel ticketLabel = new UILabel();
			ticketLabel.Text = "M-Ticket";
			ticketLabel.TextColor = UIColor.Black;
			ticketLabel.Font = UIFont.PreferredCaption2;

			UILabel parkingLabel = new UILabel();
			parkingLabel.Text = "Parking";
			parkingLabel.TextColor = UIColor.Black;
			parkingLabel.Font = UIFont.PreferredCaption2;

			UILabel foodLabel = new UILabel();
			foodLabel.Text = "Food Court";
			foodLabel.TextColor = UIColor.Black;
			foodLabel.Font = UIFont.PreferredCaption2;

			mainview.AddSubview(location);
			mainview.AddSubview(facilitiesLabel);
			mainview.AddSubview(mtick);
			mainview.AddSubview(park);
			mainview.AddSubview(food);
			mainview.AddSubview(ticketLabel);
			mainview.AddSubview(parkingLabel);
			mainview.AddSubview(foodLabel);

			location.Frame = new CGRect(Bounds.Left + 16, Bounds.Top + 20, 240, 40);
			facilitiesLabel.Frame = new CGRect(Bounds.Width / 4, location.Frame.Bottom + 12, Bounds.Width - Bounds.Left - 16, 40);
			mtick.Frame = new CGRect(Bounds.Left + 60, facilitiesLabel.Frame.Bottom + 10, 20, 20);
			park.Frame = new CGRect(mtick.Frame.Right + 60, facilitiesLabel.Frame.Bottom + 10, 20, 20);
			food.Frame = new CGRect(park.Frame.Right + 50, facilitiesLabel.Frame.Bottom + 10, 20, 20);
			ticketLabel.Frame = new CGRect(Bounds.Left + 50, mtick.Frame.Bottom + 10, 50, 20);
			parkingLabel.Frame = new CGRect(ticketLabel.Frame.Right + 30, mtick.Frame.Bottom + 10, 50, 20);
			foodLabel.Frame = new CGRect(parkingLabel.Frame.Right + 10, mtick.Frame.Bottom + 10, 60, 20);
			return mainview;
		}

		protected override void UnLoad()
		{
			this.RemoveFromSuperview();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			rowData = (this.DataColumn.RowData);
			infoImage.Image = (rowData as TicketBookingInfo).InfoImage;
			theaterTitle.Text = (rowData as TicketBookingInfo).TheaterName;
			theaterLocation.Text = (rowData as TicketBookingInfo).TheaterLocation;
			timing1.Text = (rowData as TicketBookingInfo).Timing1;
			timing2.Text = (rowData as TicketBookingInfo).Timing2;
			this.theaterLayout.Frame = new CGRect(Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height);
		}
	}

	public class TheaterLayout : UIView
	{
		public TheaterLayout()
		{

		}

		public override void LayoutSubviews()
		{
			this.Subviews[0].Frame = new CGRect(Bounds.Left + 16, Bounds.Top + 16, Bounds.Width - 60, 25);
			this.Subviews[1].Frame = new CGRect(Bounds.Left + 16, this.Subviews[0].Frame.Bottom + 6, Bounds.Width - 60 ,25);
            this.Subviews[2].Frame = new CGRect(Bounds.Left + 16, this.Subviews[1].Frame.Bottom + 6, 80,32);
			this.Subviews[3].Frame = new CGRect(this.Subviews[2].Frame.Right + 10, this.Subviews[1].Frame.Bottom + 6, 80,32);
			this.Subviews[4].Frame = new CGRect(this.Subviews[1].Frame.Right, Bounds.Height / 2 - 12 , 24, 24);
		}
	}


}
