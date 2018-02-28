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
	public class TheaterTile : GridCell
	{
		TheaterLayout theaterLayout;
		UIImageView infoImage;
		UILabel theaterTitle;
		UILabel theaterLocation;
        UILabel timing1;
		UILabel timing2;
        UILabel overlayTags;
        SfPopupLayout popup;
		object rowData;
		SfDataGrid dataGrid;
		UILabel message;

		public TheaterTile()
		{
			theaterLayout = new TheaterLayout();

			infoImage = new UIImageView();
            infoImage.Alpha = 0.54f;
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
            popup.IsOpen = false;
			popup.PopupView.HeaderTitle = "Terms & Conditions";
			popup.PopupView.BackgroundColor = UIColor.White;
			popup.PopupView.ShowHeader = true;
			popup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            UIView view = new UIView();
            message = new UILabel();
            view.BackgroundColor = UIColor.White;
			message.TextColor = UIColor.Gray;
			message.Font = UIFont.SystemFontOfSize(14);
            message.AutoresizingMask = UIViewAutoresizing.All;
			popup.PopupView.ShowCloseButton = false;
            view.AddSubview(message);
            popup.PopupView.PopupStyle.BorderColor = UIColor.LightGray;
			popup.PopupView.AppearanceMode = AppearanceMode.TwoButton;
			popup.PopupView.HeaderHeight = 40;
			popup.PopupView.FooterHeight = 40;
            popup.PopupView.ShowFooter = true;
			popup.PopupView.PopupStyle.HeaderFontSize = 16;
			message.Text = "1. Children below the age of 18 cannot be admitted for movies certified A. 2.Please carry proof of age fir movies certified A. 3. Drinking and alcohol is strictly prohibited inside the premises 4. Please purchase tickets for children above age of 3.";
			message.Lines = 10;
			message.TextAlignment = UITextAlignment.Center;
			message.LineBreakMode = UILineBreakMode.WordWrap;
			popup.PopupView.AcceptButtonText = "Accept";
			popup.PopupView.DeclineButtonText = "Decline";
            popup.StaysOpen = true;
            message.Frame = new CGRect(10, 0, popup.PopupView.Frame.Width - 20, popup.PopupView.Frame.Height);
            popup.PopupView.ContentView = view;
			popup.PopupView.PopupStyle.AcceptButtonTextColor = UIColor.FromRGB(0,124, 238);
			popup.PopupView.PopupStyle.DeclineButtonTextColor = UIColor.FromRGB(0,124, 238);
			popup.PopupView.PopupStyle.AcceptButtonBackgroundColor = UIColor.White;
			popup.PopupView.PopupStyle.DeclineButtonBackgroundColor = UIColor.White;
            popup.PopupView.AcceptButtonClicked += PopupView_AcceptButtonClicked;
            popup.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            popup.PopupView.Frame = new CGRect(-1,-1,this.DataColumn.Renderer.DataGrid.Frame.Width - 20,this.DataColumn.Renderer.DataGrid.Frame.Height/1.75);
			popup.IsOpen = true;
            message.Frame = new CGRect(10, 0, popup.PopupView.Frame.Width - 20, view.Frame.Height);
        }

        private void PopupView_AcceptButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (popup.PopupView.AcceptButtonText == "Accept")
            {
                popup.PopupView.ContentView = CreateSeatSelectionPage();
                popup.StaysOpen = true;
                e.Cancel = true;
            }
            else if(popup.PopupView.AcceptButtonText == "Proceed")
            {
                overlayTags = new UILabel();
                overlayTags.Hidden = false;
                overlayTags.Text = "Tickets booked successfully";
                overlayTags.Layer.CornerRadius = 20f;
                overlayTags.TextColor = UIColor.White;
                overlayTags.TextAlignment = UITextAlignment.Center;
                overlayTags.ClipsToBounds = true;
                overlayTags.Font = UIFont.SystemFontOfSize(14);
                overlayTags.BackgroundColor = UIColor.FromRGB(101.0f / 255.0f, 101.0f / 255.0f, 101.0f / 255.0f);
                overlayTags.Layer.ZPosition = 1000;
                dataGrid.Superview.AddSubview(overlayTags);
                overlayTags.Frame = new CoreGraphics.CGRect((dataGrid.Superview.Frame.Right / 2) - 100, dataGrid.Superview.Frame.Bottom - 20, 200, 40);

                UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveLinear, () =>
                {
                    overlayTags.Alpha = 1.0f;
                },
                    () =>
                    {
                        UIView.Animate(3.0, () =>
                        {
                            overlayTags.Alpha = 0.0f;
                        });
                    }
                );
            }

        }

        private UIView CreateSeatSelectionPage()
        {
            UIView seatSelectionMainLayout = new UIView();
            seatSelectionMainLayout.BackgroundColor = UIColor.White; 

            SeatSelectionLayout numberOfSeatsLayout = new SeatSelectionLayout(popup); 
            numberOfSeatsLayout.Frame = new CGRect(5, 5, popup.PopupView.Frame.Width - 10, 42);

            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("1"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("2"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("3"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("4"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("5"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("6"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("7"));
            numberOfSeatsLayout.AddSubview(CreateSeatSelectionLayout("8"));

            UILabel title2 = new UILabel();
            title2.Text = "Select your seat class";
            title2.TextColor = UIColor.Black;
            title2.Font = UIFont.SystemFontOfSize(14);
            title2.Frame = new CGRect(15, 92, popup.PopupView.Frame.Width, 16);

            UILabel clas = new UILabel();
            clas.Text = "Silver";
            clas.TextColor = UIColor.Gray;
            clas.Font = UIFont.PreferredCaption1;
            clas.Frame = new CGRect(15, 133, 60, 20);

            UILabel cost = new UILabel();
            cost.Text = "$ 19.69";
            cost.TextColor = UIColor.Black;
            cost.Font = UIFont.PreferredCaption1;
            cost.Frame = new CGRect(105, 133, 60, 20);


            UILabel avail = new UILabel();
            avail.Text = "Available";
            avail.TextColor = UIColor.Green;
            avail.Font = UIFont.PreferredCaption1;
            avail.Frame = new CGRect(175, 133, 60, 20);


            UILabel clas2 = new UILabel();
            clas2.Text = "Premier";
            clas2.TextColor = UIColor.Gray;
            clas2.Font = UIFont.PreferredCaption1;
            clas2.Frame = new CGRect(15, 153, 60, 20);

            UILabel cost2 = new UILabel();
            cost2.Text = "$ 23.65";
            cost2.TextColor = UIColor.Black;
            cost2.Font = UIFont.PreferredCaption1;
            cost2.Frame = new CGRect(105, 153, 60, 20);


            UILabel avail2 = new UILabel();
            avail2.Text = "Unavailable";
            avail2.TextColor = UIColor.Red;
            avail2.Font = UIFont.PreferredCaption1;
            avail2.Frame = new CGRect(175, 153, 80, 20);

            seatSelectionMainLayout.AddSubview(numberOfSeatsLayout);
            seatSelectionMainLayout.AddSubview(title2);
            seatSelectionMainLayout.AddSubview(clas);
            seatSelectionMainLayout.AddSubview(cost);
            seatSelectionMainLayout.AddSubview(avail);
            seatSelectionMainLayout.AddSubview(clas2);
            seatSelectionMainLayout.AddSubview(cost2);
            seatSelectionMainLayout.AddSubview(avail2);

            popup.PopupView.HeaderTitle = "How many seats ?";
            popup.PopupView.PopupStyle.HeaderTextColor = UIColor.Black;
            popup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
            popup.PopupView.PopupStyle.BorderThickness = 1;
            popup.PopupView.ShowFooter = true;
            popup.PopupView.ShowCloseButton = true;
            popup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            popup.PopupView.FooterHeight = 40;
            popup.PopupView.AcceptButtonText = "Proceed";
            popup.PopupView.PopupStyle.AcceptButtonBackgroundColor = UIColor.FromRGB(0, 124, 238);
            popup.PopupView.PopupStyle.AcceptButtonTextColor = UIColor.White;

            return seatSelectionMainLayout;
        }

        private UILabel CreateSeatSelectionLayout(string count)
        {
            var seatCountLabel = new UILabel();
            if (count == "2")
            {
                seatCountLabel.BackgroundColor = UIColor.FromRGB(0, 124, 238);
                seatCountLabel.TextColor = UIColor.White;
            }
            else
            {
                seatCountLabel.BackgroundColor = UIColor.White;
                seatCountLabel.TextColor = UIColor.Black;
            }

            seatCountLabel.Text = count;

            seatCountLabel.Font = UIFont.BoldSystemFontOfSize(12);
            seatCountLabel.TextAlignment = UITextAlignment.Center;
            seatCountLabel.UserInteractionEnabled = true;
            var tapGesture = new UITapGestureRecognizer(SeatSelected) { NumberOfTapsRequired = 1 };
            seatCountLabel.AddGestureRecognizer(tapGesture);
            return seatCountLabel;
        }

        void SeatSelected(UITapGestureRecognizer tasture)
        {
            foreach (var v in tasture.View.Superview.Subviews)
            {
                (v as UILabel).TextColor = UIColor.Black;
                v.BackgroundColor = UIColor.White;
            }
            tasture.View.BackgroundColor = UIColor.FromRGB(0, 124, 238);
            (tasture.View as UILabel).TextColor = UIColor.White;
        }

        private void DisplayInfo()
		{
            popup.IsOpen = false;
            popup.PopupView.AppearanceMode = AppearanceMode.OneButton;
			popup.PopupView.HeaderTitle = (rowData as TicketBookingInfo).TheaterName;
			popup.PopupView.BackgroundColor = UIColor.White;
			popup.PopupView.ShowCloseButton = true;
			popup.PopupView.PopupStyle.HeaderTextColor = UIColor.Black;
			popup.PopupView.PopupStyle.HeaderTextAlignment = UIKit.UITextAlignment.Center;
			popup.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.White;
			popup.PopupView.ShowFooter = false;
			popup.PopupView.FooterHeight = 35;
			popup.PopupView.HeaderHeight = 30;
            popup.StaysOpen = false;
			popup.PopupView.PopupStyle.HeaderFontSize = 16;
			popup.PopupView.ShowHeader = true;
			popup.PopupView.ContentView = CreateInfoPopup();

            popup.PopupView.Frame = new CGRect(-1, -1, this.DataColumn.Renderer.DataGrid.Frame.Width - 40, this.DataColumn.Renderer.DataGrid.Frame.Height / 2);
			popup.IsOpen = true;
		}

		private UIView CreateInfoPopup()
		{
			UIView mainview = new UIView();

			UILabel location = new UILabel();
			location.Lines = 10;
			location.Font = UIFont.PreferredCaption1;
			location.TextColor = UIColor.FromRGB(0,124, 238);
			location.LineBreakMode = UILineBreakMode.WordWrap;
			location.Text = (rowData as TicketBookingInfo).TheaterLocation + "421 E DRACHMAN TUCSON AZ 85705 - 7598 USA";

			UILabel facilitiesLabel = new UILabel();
			facilitiesLabel.Text = "Available Facilities";

			UIImageView mtick = new UIImageView();
			mtick.Image = UIImage.FromFile("Images/Popup_MTicket.png");

			UIImageView park = new UIImageView();
			park.Image = UIImage.FromFile("Images/Popup_Parking.png");

			UIImageView food = new UIImageView();
			food.Image = UIImage.FromFile("Images/Popup_FoodCourt.png");

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
			facilitiesLabel.Frame = new CGRect(Bounds.Width / 4.5, location.Frame.Bottom + 12, Bounds.Width - Bounds.Left - 16, 40);
			mtick.Frame = new CGRect(Bounds.Left + 55, facilitiesLabel.Frame.Bottom + 10, 20, 20);
			park.Frame = new CGRect(mtick.Frame.Right + 55, facilitiesLabel.Frame.Bottom + 10, 20, 20);
			food.Frame = new CGRect(park.Frame.Right + 45, facilitiesLabel.Frame.Bottom + 10, 20, 20);
			ticketLabel.Frame = new CGRect(Bounds.Left + 45, mtick.Frame.Bottom + 10, 50, 20);
			parkingLabel.Frame = new CGRect(ticketLabel.Frame.Right + 25, mtick.Frame.Bottom + 10, 50, 20);
			foodLabel.Frame = new CGRect(parkingLabel.Frame.Right + 5, mtick.Frame.Bottom + 10, 60, 20);
			return mainview;
		}

		protected override void UnLoad()
		{
			this.RemoveFromSuperview();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			dataGrid = this.DataColumn.Renderer.DataGrid;
			popup = (this.dataGrid.Superview as UIView).Superview as SfPopupLayout;
			rowData = (this.DataColumn.RowData);
			infoImage.Image = (rowData as TicketBookingInfo).InfoImage;
			theaterTitle.Text = (rowData as TicketBookingInfo).TheaterName;
			theaterLocation.Text = (rowData as TicketBookingInfo).TheaterLocation;
			timing1.Text = (rowData as TicketBookingInfo).Timing1;
			timing2.Text = (rowData as TicketBookingInfo).Timing2;
			this.theaterLayout.Frame = new CGRect(Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height);
            this.popup.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height + 20);
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

    public class SeatSelectionLayout : UIView
    {
        SfPopupLayout popup;
        public SeatSelectionLayout(SfPopupLayout pop)
        {
            popup = pop;
        }

        public override void LayoutSubviews()
        {
            nfloat temp = 0;
            for (int i = 0; i < this.Subviews.Length; i++)
            {
                this.Subviews[i].Frame = new CGRect(temp, this.Frame.Top, (popup.PopupView.Frame.Width - 10) / 8, 42);
                temp = temp + ((popup.PopupView.Frame.Width - 10) / 8);
            }
        }
    }


}
