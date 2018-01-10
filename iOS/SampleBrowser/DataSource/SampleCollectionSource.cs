#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class SampleCollectionSource : UICollectionViewDataSource
	{
		public HomeViewController controller;

		public SampleCollectionSource(HomeViewController _controller)
		{
			this.controller = _controller;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (UICollectionViewCell)collectionView.DequeueReusableCell("cell", indexPath);

			cell.BackgroundColor = UIColor.Clear;

			Control control = controller.FeaturedSamples.GetItem<Control>((uint)indexPath.Row);

			UIImageView imageView = (UIImageView)cell.ViewWithTag(100);

			imageView.Image = control.image;
			imageView.Layer.BorderColor = UIColor.White.CGColor;

			UIBezierPath shadowPath = UIBezierPath.FromRect(new CoreGraphics.CGRect(cell.Bounds.X,
																					cell.Bounds.Y,
																					cell.Bounds.Width,
			                                                                        control.image.Size.Height));
			imageView.Layer.ShadowColor = UIColor.Black.CGColor;
			imageView.Layer.ShadowOffset = new CoreGraphics.CGSize(0f, 0f);
			imageView.Layer.ShadowOpacity= 0.6f;
			imageView.Layer.ShadowRadius = 7.0f;
			imageView.Layer.ShadowPath = shadowPath.CGPath;
			imageView.Layer.BorderWidth = 2.0f;

			UILabel label = (UILabel)cell.ViewWithTag(101);
			label.Text = control.dispName;
			label.TextColor = UIColor.White;

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)controller.FeaturedSamples.Count;
		}
	}

	public class SampleCollectionDelegate : UICollectionViewDelegate
	{
		public HomeViewController controller;

		public SampleCollectionDelegate(HomeViewController controller)
		{
			this.controller = controller;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			SampleViewController _controller = new SampleViewController( indexPath);
			_controller.SamplesCollection = controller.FeaturedSamples;

			Control contrl = controller.controls.GetItem<Control>((nuint)indexPath.Row);
			_controller.ControlName = contrl.name;

			controller.NavigationController.PushViewController(_controller, true);
		}
	}

	public class FeaturedSampleCollectionDelegate : UICollectionViewDelegate
	{
		public HomeViewController controller;

		public FeaturedSampleCollectionDelegate(HomeViewController controller)
		{
			this.controller = controller;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			SampleViewController _controller = new SampleViewController(indexPath);
			_controller.SamplesCollection = controller.FeaturedSamples;

			//Control contrl = controller.controls.GetItem<Control>((nuint)indexPath.Row);
			_controller.ControlName = "Chart";

			//_controller.DisplayNameCollection = controller.FeaturedSamplesNames;
			//_controller.ImageCollection = controller.FeaturedSamplesImages;

			controller.NavigationController.PushViewController(_controller, true);
		}
	}
}