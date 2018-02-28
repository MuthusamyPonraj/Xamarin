#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;
using System.Globalization;
using CoreGraphics;
using Syncfusion.SfPopupLayout;
using System.Linq;
using System.Reflection;
using Foundation;
using System.Threading;
using System.Timers;
using CoreAnimation;
using System.Threading.Tasks;

namespace SampleBrowser
{
	public class PopupGettingStarted : SampleView
	{
		#region Fields

		SfDataGrid sfGrid;
		int clickCount = 0;
		UIView mainView;
		SfPopupLayout sfPopUp;
		UIView backgroundView;
		UIImageView imageView;
		UIImageView img;
		UITapGestureRecognizer tapGesture;

		#endregion

		static bool UserInterfaceIdiomIsPhone
		{
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public PopupGettingStarted()
		{
			mainView = new UIView();
			CreatePopup();
			CreateDataGrid();
			sfPopUp.Content = mainView;
			mainView.AddSubview(sfGrid);
			this.AddSubview(sfPopUp);
			tapGesture = new UITapGestureRecognizer() { NumberOfTapsRequired = 1 };
			tapGesture.AddTarget(() => { BackgroundViewPressed(tapGesture); });
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			if (Utility.IsIpad)
			{
				if ((UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeLeft)
					|| (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeRight))
					this.sfGrid.ColumnSizer = ColumnSizer.LastColumnFill;
				else
					this.sfGrid.ColumnSizer = ColumnSizer.None;
			}
			this.sfGrid.Frame = new CGRect(mainView.Frame.Left, mainView.Frame.Top, mainView.Frame.Width, mainView.Frame.Height );
			this.sfPopUp.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height );

			var navigationBar = (((mainView.Superview as UIView).Window.RootViewController)as UINavigationController).NavigationBar;
			//var tapGesture = new UITapGestureRecognizer() { NumberOfTapsRequired = 1 };
			//tapGesture.AddTarget(() => { HandleBackButtonPressed(tapGesture); });
   //         navigationBar.UserInteractionEnabled = true;
			//var a = navigationBar.Frame.Height;
			//var aa= (navigationBar.GestureRecognizers[0] as UITapGestureRecognizer);
   //         //navigationBar.AddGestureRecognizer(tapGesture);
			//var aaasa = navigationBar.Subviews[1];
			//var aas = (aaasa.GestureRecognizers[0] as UITapGestureRecognizer);
			//aaasa.BackgroundColor = UIColor.Yellow;
			//(aaasa as UIVisualEffectView).BackgroundColor = UIColor.Yellow;
			//aaasa.AddGestureRecognizer(tapGesture);
		}

		private void CreateDataGrid()
		{
			sfGrid = new SfDataGrid();
			sfGrid.GridLoaded += SfGrid_GridLoaded;
			sfGrid.GridLongPressed += SfGrid_GridLongPressed;
			GridImageColumn customerImageColumn = new GridImageColumn();
			customerImageColumn.MappingName = "CustomerImage";
			customerImageColumn.HeaderText = "Image";

			GridSwitchColumn isOpenColumn = new GridSwitchColumn();
			isOpenColumn.MappingName = "IsOpen";
			isOpenColumn.HeaderText = "Is Open";
			isOpenColumn.AllowEditing = true;

			//GridTextColumn balanceScaleColumn = new GridTextColumn ();
			//balanceScaleColumn.UserCellType = typeof(LinearGuageCell);
			//balanceScaleColumn.MappingName = "BalanceScale";
			//balanceScaleColumn.HeaderText = "Balance Scale";

			//GridTextColumn chartcell = new GridTextColumn ();
			//chartcell.UserCellType = typeof(LineChartCell);
			//chartcell.MappingName = "Transactions";
			//chartcell.HeaderText = "Transactions";

			GridTextColumn customerIdColumn = new GridTextColumn();
			customerIdColumn.MappingName = "CustomerID";
			customerIdColumn.HeaderText = "Customer ID";
			customerIdColumn.TextAlignment = UITextAlignment.Center;


			GridTextColumn currentColumn = new GridTextColumn();
			currentColumn.MappingName = "Current";
			currentColumn.Format = "C";
			currentColumn.CultureInfo = new CultureInfo("en-US");
			currentColumn.TextAlignment = UITextAlignment.Center;

			GridTextColumn customerNameColumn = new GridTextColumn();
			customerNameColumn.MappingName = "CustomerName";
			customerNameColumn.HeaderText = "Customer Name";
			customerNameColumn.TextMargin = 10;
			customerNameColumn.TextAlignment = UITextAlignment.Left;

			GridTextColumn savingsColumn = new GridTextColumn();
			savingsColumn.MappingName = "Savings";
			savingsColumn.Format = "C";
			savingsColumn.CultureInfo = new CultureInfo("en-US");
			savingsColumn.TextAlignment = UITextAlignment.Center;

			sfGrid.Columns.Add(customerImageColumn);
			//SfGrid.Columns.Add (chartcell);
			sfGrid.Columns.Add(customerIdColumn);
			//sfGrid.Columns.Add(currentColumn);
			sfGrid.Columns.Add(customerNameColumn);
			sfGrid.Columns.Add(savingsColumn);
			//SfGrid.Columns.Add (balanceScaleColumn);
			//sfGrid.Columns.Add(isOpenColumn);
			sfGrid.AutoGenerateColumns = false;
			this.sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.ItemsSource = new FormattingViewModel().BankInfo;
			sfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB(219, 219, 219);
			sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.HeaderRowHeight = 45;
			sfGrid.RowHeight = 65;
			sfGrid.GridStyle = new CustomStyles();
			sfGrid.ColumnSizer = ColumnSizer.Star;
		}

		private void SfGrid_GridLongPressed(object sender, GridLongPressedEventArgs e)
		{
			sfPopUp.IsOpen = false;
			sfPopUp.ShowPopup(mainView);
		}

		private void SfGrid_GridLoaded(object sender, GridLoadedEventArgs e)
		{
			sfPopUp.PopupView.Frame = new CGRect(this.sfPopUp.Frame.Width - 25, 0, 150, 100);
			sfPopUp.ShowPopup();
		}

		private void CreatePopup()
		{
			sfPopUp = new SfPopupLayout();
			sfPopUp.PopupView.PopupAnimation = PopupAnimation.None;
			sfPopUp.PopupView.PopupStyle.BorderThickness = 0;
			sfPopUp.PopupView.PopupStyle.BorderColor = UIColor.Clear;
			sfPopUp.PopupView.LayoutAppearance = LayoutAppearance.Custom;
			sfPopUp.PopupView.ShowFooter = false;
			sfPopUp.PopupView.ShowHeader = false;
			sfPopUp.PopupOpened += SfPopUp_PopupOpened;
			sfPopUp.PopupClosed += SfPopUp_PopupClosed;
			sfPopUp.BackgroundColor = UIColor.Clear;
			sfPopUp.BackgroundColor = UIColor.Clear;

			imageView = new UIImageView();
			imageView.Image = UIImage.FromFile("Images/InfoNotification.png");
			sfPopUp.PopupView.PopupContentView = imageView;
		}

		private void SfPopUp_PopupClosed(object sender, EventArgs e)
		{
			//if (clickCount == 5)
				//backgroundView.RemoveFromSuperview();

		}

		private void SfPopUp_PopupOpened(object sender, EventArgs e)
		{

			AddBackgroundView();
			if (clickCount == 0)
			{
				Action moveUpDown = () =>
				{
					var xpos = sfPopUp.PopupView.Center.X;
					var ypos = sfPopUp.PopupView.Center.Y + 20;
					imageView.Center = new CGPoint(xpos, ypos);
				};

				UIView.Animate(1, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat, moveUpDown, () => { });
			}
			else if (clickCount == 1)
			{
				Action moveLeftRight = () =>
				{
					var xpos = sfPopUp.PopupView.Center.X + 50;
					var ypos = sfPopUp.PopupView.Center.Y;
					imageView.Center = new CGPoint(xpos, ypos);
				};

				UIView.Animate(2, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Repeat, moveLeftRight, () => { });
			}
			else if (clickCount == 2)
			{
				imageView.Alpha = 0.0f;
				Action setOpacity = () =>
				{
					imageView.Alpha = 1.0f;
				};

				UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveEaseInOut , setOpacity ,async () => 
				{
					imageView.Alpha = 0.0f;
					await Task.Delay(200);
					imageView.Alpha = 1.0f;
					await Task.Delay(1000);
					LoopAnimate();
				});
			}
			else if (clickCount == 3)
			{
				Action moveLeftRight = () =>
				{
					var xpos = sfPopUp.PopupView.Center.X + 60;
					var ypos = sfPopUp.PopupView.Center.Y;
					imageView.Center = new CGPoint(xpos, ypos);
				};

				UIView.Animate(2, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Repeat, moveLeftRight, () => { });
			}
			else if (clickCount == 4)
			{
				CGPoint fromPt = new CGPoint(img.Center.X + 10, img.Center.Y + 10);
				img.Layer.Position = new CGPoint(img.Center.X + 70, img.Center.Y + 70);
				CGPath path = new CGPath();
				path.AddLines(new CGPoint[] { fromPt, new CGPoint(30, 20),new CGPoint(40, 25), new CGPoint(50, 30), new CGPoint(60, 40),new CGPoint(70, 50),new CGPoint(80, 60), new CGPoint(80,70) });
				CAKeyFrameAnimation animPosition = (CAKeyFrameAnimation)CAKeyFrameAnimation.FromKeyPath("position");
				animPosition.Path = path;
				animPosition.RepeatCount = int.MaxValue;
				animPosition.Duration = 1.25;
				img.Layer.AddAnimation(animPosition, "position");
			}
		}

		private async void LoopAnimate()
		{
			if (clickCount > 2)
				return;
			else
			{
				imageView.Alpha = 0.0f;
				Action setOpacity = () =>
				{
					imageView.Alpha = 1.0f;
				};

				UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveEaseInOut, setOpacity, async () =>
								{
									imageView.Alpha = 0.0f;
									await Task.Delay(200);
									imageView.Alpha = 1.0f;
									await Task.Delay(1000);
									LoopAnimate();
								});
			}
		}

		private void AddBackgroundView()
		{
			if (mainView.Subviews.FirstOrDefault(x => x.Tag == 100) == null)
			{
				backgroundView = new UIView();
				backgroundView.Tag = 100;
				backgroundView.BackgroundColor = UIColor.Black;
				backgroundView.Alpha = 0.7f;
				backgroundView.AddGestureRecognizer(tapGesture);
				this.mainView.AddSubview(backgroundView);
				backgroundView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
			}
		}

		void BackgroundViewPressed(UITapGestureRecognizer tapGesture)
		{
			clickCount++;
			sfPopUp.IsOpen = false;
			if (imageView == null)
			{
				imageView = new UIImageView();
			}
			if (clickCount == 1)
			{
				imageView = null;
				imageView = new UIImageView();

				UIView hostingView = new UIView();
				sfPopUp.IsOpen = false;
				imageView.Image = UIImage.FromFile("Images/ResizingIllustration.png");
				sfPopUp.PopupView.Frame = new CGRect(this.Frame.Width / 2 - 50,0, 160, 100);
				hostingView.Frame = new CGRect(sfPopUp.PopupView.Frame.Left, sfPopUp.PopupView.Frame.Top,160,100);
				imageView.Frame = new CGRect(0, hostingView.Frame.Top,100,100);
				hostingView.AddSubview(imageView);
				sfPopUp.PopupView.PopupContentView = hostingView;
				sfPopUp.IsOpen = true;
			}
			else if (clickCount == 2)
			{
				imageView = null;
				sfPopUp.IsOpen = false;
				imageView = new UIImageView();
				imageView.Image = UIImage.FromFile("Images/EditIllustration.png");
				sfPopUp.PopupView.PopupContentView = imageView;
				var point = this.sfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(6, 2));
				sfPopUp.PopupView.Frame = new CGRect(point.X, point.Y, 100, 100);
				sfPopUp.IsOpen = true;
			}
			else if (clickCount == 3)
			{
				imageView = null;
				sfPopUp.IsOpen = false;

				UIView hostingView = new UIView();

				imageView = new UIImageView();
				imageView.StopAnimating();
				imageView.Image = UIImage.FromFile("Images/SwipeIllustration.png");
				var point = this.sfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(6, 0));
				sfPopUp.PopupView.Frame = new CGRect(point.X + 5, point.Y + 5, 250, 100);
				hostingView.Frame = new CGRect(sfPopUp.PopupView.Frame.Left, sfPopUp.PopupView.Frame.Top,250,100);
				imageView.Frame = new CGRect(0, 0, 150, 100);
				hostingView.AddSubview(imageView);
				sfPopUp.PopupView.PopupContentView = hostingView;
				sfPopUp.IsOpen = true;
			}
			else if (clickCount == 4)
			{
				sfPopUp.IsOpen = false;
				UIView view = new UIView();
				imageView = null;
				imageView = new UIImageView();
				imageView.Image = UIImage.FromFile("Images/DragAndDropIllustration.png");
				imageView.Frame = new CGRect(0,0,200,100);
				var point = this.sfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(6, 0));
				view.AddSubview(imageView);
				img = new UIImageView();
				img.Image = UIImage.FromFile("Images/HandSymbol.png");
				img.Frame = new CGRect(10, 0, 20, 20);
				view.AddSubview(img);
				sfPopUp.PopupView.PopupContentView = view;
				sfPopUp.PopupView.Frame = new CGRect(point.X + 10, point.Y + 5, 200, 100);
				sfPopUp.IsOpen = true;
			}
			else if (clickCount > 4)
			{
				backgroundView.RemoveFromSuperview();
			}
		}

		protected override void Dispose(bool disposing)
		{
			//sfPopUp.DismissPopup(true);
			if (backgroundView != null)
			{
				mainView.WillRemoveSubview(backgroundView);
				mainView.SendSubviewToBack(backgroundView);
				sfPopUp.RemoveFromSuperview();
				backgroundView.BackgroundColor = UIColor.Brown;
				backgroundView.UserInteractionEnabled = false;
				backgroundView.Frame = new CGRect(0, 0, 0, 0);
				backgroundView.RemoveFromSuperview();
				backgroundView = null;
			}

			base.Dispose(disposing);
			sfGrid.Dispose();
			mainView = null;
			sfPopUp.Dispose();
		}


	}
}

