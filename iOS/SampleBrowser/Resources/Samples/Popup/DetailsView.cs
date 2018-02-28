#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UIKit;
using Syncfusion.SfPopupLayout;

namespace SampleBrowser
{
    public class DetailsView : SampleView
    {
        #region Fields

        internal static UITableView tableView;
        ContatsViewModel viewModel;
        DataSource sfDataSource;
        internal static SfPopupLayout popupLayout;

        #endregion

        #region Constructor

        public DetailsView()
        {
            tableView = new UITableView();
            tableView.RowHeight = 70;
            tableView.SeparatorColor = UIColor.Clear;
            tableView.EstimatedRowHeight = 70;
            tableView.AllowsSelection = false;
            viewModel = new ContatsViewModel();
            sfDataSource = new DataSource();
            sfDataSource.Source = viewModel.ContactsList;
            tableView.Source = new PopupTableViewSource(sfDataSource);

            tableView.ContentInset = new UIEdgeInsets(-30, 0, 0 ,0);
            tableView.BackgroundColor = UIColor.FromRGB(244, 244, 244);
            tableView.SectionHeaderHeight = 50;
            popupLayout = new SfPopupLayout();
            popupLayout.Content = tableView;
            this.AddSubview(popupLayout);
        }

        #endregion

        #region Override Methods

        public override void LayoutSubviews()
        {
            popupLayout.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        #endregion

    }

    public class PopupTableViewSource : UITableViewSource
    {

        #region Field

        DataSource dataSource;

        #endregion

        #region Constructor

        public PopupTableViewSource(DataSource sfDataSource)
        {
            dataSource = sfDataSource;
        }

        #endregion

        #region implemented abstract members of UITableViewDataSource

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var item = dataSource.DisplayItems[indexPath.Row];
            if (item is Contacts)
            {
                PopupContactCell cell = tableView.DequeueReusableCell("TableCell") as PopupContactCell;
                if (cell == null)
                    cell = new PopupContactCell();
                cell.UpdateValue(item);
                return cell;
            }
            return new UITableViewCell();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return (nint)dataSource.DisplayItems.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return tableView.RowHeight;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var mainView = new UIView();
            var view = new UILabel();
            mainView.Layer.AddSublayer(new CALayer());
            mainView.Layer.Frame = tableView.Frame;
            mainView.Layer.Sublayers[0].BackgroundColor = UIColor.FromRGB(244, 244, 244).CGColor;
            mainView.Layer.Sublayers[0].Frame = new CGRect(0, 0, 15, 50);
            view.Frame = new CGRect(15, 10, tableView.Frame.Width - 15, 50);
            view.BackgroundColor = UIColor.FromRGB(244, 244, 244);
            view.Text = "Today";
            view.TextColor = UIColor.FromRGB(0, 0, 0);
            mainView.AddSubview(view);
            return mainView;
        }

        #endregion
    }

    public class PopupContactCell : UITableViewCell
    {
        #region Field

        private UIImageView imageView1;
        private UIImageView imageView2;        
        private UILabel Label1;
        private UILabel Label2;
        private UILabel Label3;
        private UILabel Label4;
        internal static UILabel currentLabel;

        #endregion

        #region Constructor

        public PopupContactCell()
        {
            this.AutosizesSubviews = false;
            this.BackgroundColor = UIColor.FromRGB(255, 255, 255);

            Label1 = CreateLabel(Label1);
            Label1.Font = UIFont.FromName("Helvetica Neue", 15);

            Label2 = CreateLabel(Label2);
            Label2.TextColor = UIColor.LightGray;

            imageView1 = new UIImageView();
            imageView2 = new UIImageView() { Alpha = 0.54f };

            Label3 = new UILabel() { BackgroundColor = UIColor.FromRGB(244, 244, 244) };
            Label4 = new UILabel() { BackgroundColor = UIColor.FromRGB(244, 244, 244) };

            SelectionStyle = UITableViewCellSelectionStyle.Blue;
            this.AddSubviews(new UIView[] { Label3, imageView1, Label1, Label2, imageView2, Label4 });
            this.Layer.AddSublayer(new CALayer());
        }


        #endregion

        #region Private Method

        private UILabel CreateLabel(UILabel label)
        {
            label = new UILabel();
            label.TextColor = UIColor.Black;
            label.TextAlignment = UITextAlignment.Left;
            label.LineBreakMode = UILineBreakMode.CharacterWrap;
            label.Font = UIFont.FromName("Helvetica Neue", 11);
            return label;
        }

        Random r = new Random();
        public void UpdateValue(object obj)
        {
            var contact = obj as Contacts;
            Label1.Text = contact.ContactName;
            Label2.Text = contact.ContactNumber;
            imageView1.Image = UIImage.FromBundle("Images/PopupImage" + r.Next(1, 10) + ".png");
            imageView2.Image = UIImage.FromBundle("Images/CallerImage.png");
        }

        #endregion

        #region override 

        public override void LayoutSubviews()
        {
            this.Layer.Frame = this.Frame;
            this.Layer.Sublayers[0].BackgroundColor = UIColor.FromRGB(244, 244, 244).CGColor;
            this.Layer.Sublayers[0].Frame = new CGRect(0, 0, this.Frame.Width, 10);
            nfloat y = 0;
            foreach (var subview in this.Subviews)
            {
                if (subview is UILabel && !(subview == imageView1) && subview != Label3 && subview != Label4)
                {
                    subview.Frame = new CoreGraphics.CGRect(imageView1.Frame.Right + 20, y + 20, (this.Frame.Width - imageView1.Frame.Right - 85), this.Frame.Height / 3);
                    y += subview.Frame.Height;
                }
                else if (subview == imageView1)
                {
                    subview.Frame = new CGRect(Label3.Frame.Right + 10, 23, 33, 35);
                }
                else if (subview is UIImageView && subview == imageView2)
                {
                    subview.Frame = new CoreGraphics.CGRect(Label1.Frame.Right + 20, 28, 25, this.Frame.Height - 48);
                }
                else if (subview == Label3)
                {
                    subview.Frame = new CGRect(0, 0, 10, this.Frame.Height);
                }
                else if (subview == Label4)
                {
                    subview.Frame = new CGRect(imageView2.Frame.Right + 10, 0, 16, this.Frame.Height);
                }
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            foreach(var view in this.Subviews)
            {
                if( view == Label1)
                {
                    currentLabel = Label1;
                    break;
                }
            }

            DetailsView.popupLayout.PopupView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            DetailsView.popupLayout.PopupView.ShowHeader = false;
            DetailsView.popupLayout.PopupView.ShowFooter = false;

            DetailsView.popupLayout.PopupView.Frame = new CGRect(0, 0, this.Frame.Width - Label4.Frame.Width - 5, 150);
            DetailsView.popupLayout.PopupView.PopupContentView = GetCustomPopupView();
            DetailsView.popupLayout.ShowPopup(imageView1.Frame.X - 10, this.Frame.Bottom - 10);
        }

        private UIView GetCustomPopupView()
        {
            UIImageView imageView1;
            UIImageView imageView2;
            UIImageView imageView3;
            UILabel label1;
            UILabel label2;
            UILabel label3;
            UIView view1;
            UIView view2;
            UIView view3;
            UIView mainView;

            var height = DetailsView.popupLayout.PopupView.Frame.Height / 3;

            imageView1 = new UIImageView();
            imageView1.Image = UIImage.FromBundle("Images/SendMessage.png");
            imageView1.Alpha = 0.54f;
            imageView1.Frame = new CGRect(10, 15, 20, 20);

            label1 = new UILabel();
            label1.Text = "Send Message";
            label1.TextColor = UIColor.FromRGB(0, 0, 0);
            label1.Alpha = 0.54f;
            label1.UserInteractionEnabled = true;
            UITapGestureRecognizer gesture = new UITapGestureRecognizer();
            gesture.AddTarget(() => 
            {
                DetailsView.popupLayout.PopupView.PopupAnimation = PopupAnimation.None;
                DetailsView.popupLayout.DismissPopup(true);
                DetailsView.popupLayout.PopupView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
                DetailsView.popupLayout.PopupView.PopupStyle.HeaderBackgroundColor = UIColor.FromRGB(0, 124, 238);
                DetailsView.popupLayout.PopupView.ShowHeader = true;
                DetailsView.popupLayout.PopupView.ShowFooter = false;
                DetailsView.popupLayout.PopupView.HeaderHeight = 50;
                DetailsView.popupLayout.PopupView.HeaderTitle = currentLabel.Text;
                DetailsView.popupLayout.PopupView.PopupStyle.HeaderTextColor = UIColor.FromRGB(255, 255, 255);

                var textField = new UITextField();
                textField.Frame = new CGRect(20, 20, 150, 50);
                textField.Text = "Type Message...";

                var imageView = new UIImageView();
                imageView.Frame = new CGRect(200, 30, 30, 30);
                imageView.Image = UIImage.FromBundle("Images/SendMessageIcon.png");

                var view = new UIView();
                view.AddSubview(textField);
                view.AddSubview(imageView);

                DetailsView.popupLayout.PopupView.Frame = new CGRect(30, 0, 250, 150);
                DetailsView.popupLayout.PopupView.PopupContentView = view;
                DetailsView.popupLayout.ShowPopup(30, DetailsView.popupLayout.Frame.Height / 3);

            });
            label1.AddGestureRecognizer(gesture);
            label1.Frame = new CGRect(50, 13, this.Frame.Width, 20);

            view1 = new UIView();
            view1.AddSubview(imageView1);
            view1.AddSubview(label1);
            view1.Frame = new CGRect(10, 0, this.Frame.Width, height);

            imageView2 = new UIImageView();
            imageView2.Image = UIImage.FromBundle("Images/BlockContact.png");
            imageView2.Alpha = 0.54f;
            imageView2.Frame = new CGRect(10, 13, 22, 22);

            label2 = new UILabel();
            label2.Text = "Block/report contact";
            label2.TextColor = UIColor.FromRGB(0, 0, 0);
            label2.Alpha = 0.54f;
            label2.Frame = new CGRect(50, 13, this.Frame.Width, 20);

            view2 = new UIView();
            view2.AddSubview(imageView2);
            view2.AddSubview(label2);
            view2.Frame = new CGRect(10, height, this.Frame.Width, height);

            imageView3 = new UIImageView();
            imageView3.Image = UIImage.FromBundle("Images/ContactInfo.png");
            imageView3.Alpha = 0.54f;
            imageView3.Frame = new CGRect(10, 13, 22, 22);

            label3 = new UILabel();
            label3.Text = "Contact Details";
            label3.TextColor = UIColor.FromRGB(0, 0, 0);
            label3.Alpha = 0.54f;
            label3.Frame = new CGRect(50, 13, this.Frame.Width, 20);

            view3 = new UIView();
            view3.AddSubview(imageView3);
            view3.AddSubview(label3);
            view3.Frame = new CGRect(10, height * 2, this.Frame.Width, height);

            mainView = new UIView();
            mainView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
            mainView.AddSubview(view1);
            mainView.AddSubview(view2);
            mainView.AddSubview(view3);

            return mainView;
        }

        #endregion
    }

}
