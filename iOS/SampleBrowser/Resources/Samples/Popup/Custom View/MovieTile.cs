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
using UIKit;

namespace SampleBrowser
{
	public class MovieTile : GridCell
	{
		MovieLayout movieLayout;
		UIImageView movieImage;
		UILabel movieTitle;
		UILabel movieCast;
		UILabel twoDLabel;
		UILabel threeDLabel;
		UILabel certificateLabel;
		UIButton book;
		DateLayout dateLayout;
		SfDataGrid dataGrid;
		//UILabel movieTitle;

		public MovieTile()
		{
			movieLayout = new MovieLayout();

			movieImage = new UIImageView();

			movieTitle = new UILabel();
			movieTitle.Font = UIFont.PreferredCaption1;

			movieCast = new UILabel();
			movieCast.Font = UIFont.PreferredFootnote;
			movieCast.TextColor = UIColor.LightGray;

			book = new UIButton();
			book.SetTitle("Book", UIControlState.Normal);
			book.SetTitleColor(UIColor.White, UIControlState.Normal);
			book.BackgroundColor = UIColor.FromRGB(0, 124, 238);
			book.Font = UIFont.PreferredCaption1;
			book.TouchUpInside += Book_TouchUpInside;	

			twoDLabel = new UILabel();
			twoDLabel.Text = "2D";
			twoDLabel.TextColor = UIColor.Gray;
			twoDLabel.Font = UIFont.PreferredCaption2;
			twoDLabel.TextAlignment = UITextAlignment.Center;
			twoDLabel.Layer.BorderColor = UIColor.DarkGray.CGColor;
			twoDLabel.Layer.BorderWidth = 0.5f;

			certificateLabel = new UILabel();
			certificateLabel.Text = "UA";
			certificateLabel.TextColor = UIColor.Gray;
			certificateLabel.Font = UIFont.PreferredCaption2;
			certificateLabel.TextAlignment = UITextAlignment.Center;
			certificateLabel.Layer.BorderColor = UIColor.DarkGray.CGColor;
			certificateLabel.Layer.BorderWidth = 0.5f;

			movieLayout.AddSubview(movieImage);
			movieLayout.AddSubview(movieTitle);
			movieLayout.AddSubview(movieCast);
			movieLayout.AddSubview(book);
			movieLayout.AddSubview(certificateLabel);
			movieLayout.AddSubview(twoDLabel);

			this.AddSubview(movieLayout);
			this.CanRenderUnLoad = false;
		}

		void Book_TouchUpInside(object sender, EventArgs e)
		{
			var grid = this.DataColumn.Renderer.DataGrid;
			grid.Columns.RemoveAt(0);
			grid.HeaderRowHeight = 62;
			GridTextColumn theaterList = new GridTextColumn();
			theaterList.HeaderText = "Movies List";
			theaterList.HeaderTemplate = CreateDateViewTemplate();
			theaterList.HeaderTextAlignment = UIKit.UITextAlignment.Center;
			theaterList.UserCellType = typeof(TheaterTile);

            grid.Columns.Add(theaterList);
		}

		private UIView CreateDateViewTemplate()
		{
			dateLayout = new DateLayout();
			return dateLayout;
		}

		protected override void UnLoad()
		{
			this.RemoveFromSuperview();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			var rowData = (this.DataColumn.RowData as TicketBookingInfo);
			movieImage.Image = rowData.MovieImage;
			movieTitle.Text = rowData.MovieName;
			movieCast.Text = rowData.Cast;

			if (rowData.MovieName == "A-Team" || rowData.MovieName == "Conjuring 2" || rowData.MovieName == "Insidious 2" || rowData.MovieName == "Clash Of The Titans")
			{
				threeDLabel = new UILabel();
				threeDLabel.Text = "3D";
				threeDLabel.TextColor = UIColor.Gray;
				threeDLabel.Font = UIFont.PreferredCaption2;
				threeDLabel.TextAlignment = UITextAlignment.Center;
				threeDLabel.Layer.BorderColor = UIColor.DarkGray.CGColor;
				threeDLabel.Layer.BorderWidth = 0.5f;
				movieLayout.AddSubview(threeDLabel);
			}

			this.movieLayout.Frame = new CGRect(Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height);
		}
	}

	public class MovieLayout : UIView
	{
		public MovieLayout()
		{
			
		}

		public override void LayoutSubviews()
		{
			this.Subviews[0].Frame = new CGRect(Bounds.Left + 5, Bounds.Top +16, 65, 85);
            this.Subviews[1].Frame = new CGRect(this.Subviews[0].Frame.Right + 8, Bounds.Top + 16, Bounds.Width - 60 - this.Subviews[0].Frame.Right - 8, 25);
            this.Subviews[2].Frame = new CGRect(this.Subviews[0].Frame.Right + 8, Subviews[1].Frame.Bottom + 8, Bounds.Width - 60 - this.Subviews[0].Frame.Right - 8, 25);
            this.Subviews[3].Frame = new CGRect(this.Subviews[1].Frame.Right + 5, Bounds.Height / 2 - 15, Bounds.Width - this.Subviews[1].Frame.Right - 10, 30);
            this.Subviews[4].Frame = new CGRect(this.Subviews[0].Frame.Right + 8, Subviews[2].Frame.Bottom + 10, 30, 20);
            this.Subviews[5].Frame = new CGRect(this.Subviews[4].Frame.Right + 10, Subviews[2].Frame.Bottom + 10, 30, 20);
			if(this.Subviews.Length > 6)
            this.Subviews[6].Frame = new CGRect(this.Subviews[5].Frame.Right + 10, Subviews[2].Frame.Bottom + 10, 30, 20);
		}

	}

	public class DateLayout : UIView
	{
		UILabel dayLabel;
		UILabel dateLabel;

		public DateLayout()
		{

			UserInteractionEnabled = true;
			this.AddSubview(new UIView() { UserInteractionEnabled = true });

			this.AddSubview(new UIView() { UserInteractionEnabled = true });

			this.AddSubview(new UIView() { UserInteractionEnabled = true });

			this.AddSubview(new UIView() { UserInteractionEnabled = true });

			this.AddSubview(new UIView() { UserInteractionEnabled = true });

			this.AddSubview(new UIView() { UserInteractionEnabled = true });

			this.AddSubview(new UIView() { UserInteractionEnabled = true });

			foreach (var v in this.Subviews)
			{
				var tapGesture = new UITapGestureRecognizer(DateSelected) { NumberOfTapsRequired = 1 };
				v.AddGestureRecognizer(tapGesture);
			}

			this.BackgroundColor = UIColor.White;
		}

		void DateSelected(UITapGestureRecognizer tasture)
		{
			foreach (var v in tasture.View.Superview.Subviews)
			{
				foreach (var c in v.Subviews)
				{
					if ((c as UILabel).Text.Length > 2)
						(c as UILabel).TextColor = UIColor.Gray;
					else
						(c as UILabel).TextColor = UIColor.Black;
					c.BackgroundColor = UIColor.White;

				}
			}
			foreach (var v in tasture.View.Subviews)
			{
				v.BackgroundColor = UIColor.FromRGB(0, 124, 238);
				(v as UILabel).TextColor = UIColor.White;
			}
		}


		public override void LayoutSubviews()
		{
			nfloat temp = 0;
			for (int i = 0; i< this.Subviews.Length; i++)
			{
				this.Subviews[i].Add(CreateDayLabel(GetDay(i)));
				this.Subviews [i].Add(CreateDateLabel(i));
				this.Subviews[i].Frame = new CGRect(Bounds.Left + temp ,Bounds.Top,Bounds.Width / 7,62);
				temp = temp + (Bounds.Width / 7);

                this.Subviews[i].Subviews[0].Frame = new CGRect(Bounds.Left, Bounds.Top, Bounds.Width / 7, 29);
				this.Subviews[i].Subviews[1].Frame = new CGRect(Bounds.Left, this.Subviews[i].Subviews[0].Frame.Bottom, Bounds.Width / 7, 29);
			}
		}

		private string GetDay(int i)
		{
			return DateTime.Now.AddDays(i).DayOfWeek.ToString().Substring(0, 3).ToUpper();
		}

		private UILabel CreateDateLabel(int num)
		{
			dateLabel = new UILabel();
			dateLabel.BackgroundColor = UIColor.White;
			dateLabel.Text = DateTime.Now.AddDays(num).Day.ToString();
			dateLabel.TextColor = UIColor.Black;
			dateLabel.UserInteractionEnabled = false;
			dateLabel.Font = UIFont.PreferredCaption1;
			dateLabel.TextAlignment = UITextAlignment.Center;
			return dateLabel;
		}

		private UILabel CreateDayLabel(string day)
		{
			dayLabel = new UILabel();
			dayLabel.Text = day;
			dayLabel.UserInteractionEnabled = false;
			dayLabel.BackgroundColor = UIColor.White;
			dayLabel.TextColor = UIColor.Gray;
			dayLabel.Font = UIFont.PreferredCaption1;
			dayLabel.TextAlignment = UITextAlignment.Center;
			return dayLabel;
		}
	}
}
