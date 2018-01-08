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
	
	public class MultipleSampleDataSource : UICollectionViewDataSource
	{
		NSMutableArray samplesCollections;
		AllSamplesViewController controller;

		public MultipleSampleDataSource(NSMutableArray collections, AllSamplesViewController controller)
		{
			samplesCollections = collections;
			this.controller = controller;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (UICollectionViewCell)collectionView.DequeueReusableCell("multipleSampleCell", indexPath);

			cell.BackgroundColor = UIColor.Clear;

			Control control = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

			UIImageView imageView = (UIImageView)cell.ViewWithTag(100);
			NSString str = new NSString("Controls/chart/Types/" + control.name);
			imageView.Image = UIImage.FromBundle(str);

			UILabel label = (UILabel)cell.ViewWithTag(101);
			label.Text = control.name;
			label.TextColor = UIColor.FromRGB(191.0f / 255.0f, 193.0f / 255.0f, 195.0f / 255.0f);


			if (controller.IndexPath.Row == indexPath.Row)
			{
				str = new NSString( str + "_selected");
				imageView.Image = UIImage.FromBundle(str);
				label.TextColor = Utility.themeColor;
			}

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)samplesCollections.Count;
		}
	}

	public class MultipleSampleDelegate : UICollectionViewDelegate
	{
		public AllSamplesViewController controller;
		NSMutableArray samplesCollections;

		public MultipleSampleDelegate(AllSamplesViewController controller, NSMutableArray collections)
		{
			this.controller = controller;
			samplesCollections = collections;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			if (controller.IndexPath != indexPath)
			{
				var cell = collectionView.CellForItem(indexPath);

				if (cell != null)
				{
					UILabel label = (UILabel)cell.ViewWithTag(101);
					label.TextColor = Utility.themeColor;

					Control control = samplesCollections.GetItem<Control>((nuint)indexPath.Row);
					UIImageView imageView = (UIImageView)cell.ViewWithTag(100);
					NSString str = new NSString("Controls/chart/Types/" + control.name + "_selected");
					imageView.Image = UIImage.FromBundle(str);
				}
				controller.IndexPath = indexPath;
				controller.LoadSample();
			}
		}

		public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem(indexPath);

			if (cell != null)
			{
				UILabel label = (UILabel)cell.ViewWithTag(101);
				label.TextColor = UIColor.FromRGB(191.0f / 255.0f, 193.0f / 255.0f, 195.0f / 255.0f);

				Control control = samplesCollections.GetItem<Control>((nuint)indexPath.Row);
				UIImageView imageView = (UIImageView)cell.ViewWithTag(100);
				NSString str = new NSString("Controls/chart/Types/" + control.name);
				imageView.Image = UIImage.FromBundle(str);
			}

		}

	}
}

