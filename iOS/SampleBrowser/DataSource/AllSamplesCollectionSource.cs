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
	//DataSource we use common data source from collection view

	//Delegate...

	public class AllSamplesCollectionDelegate : UICollectionViewDelegate
	{
		AllSamplesViewController controller;

		public AllSamplesCollectionDelegate(AllSamplesViewController controller)
		{
			this.controller = controller;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			SampleViewController _controller = new SampleViewController( indexPath);
			_controller.SamplesCollection = controller.FeaturesCollections;
			_controller.indexPath = indexPath;

			controller.NavigationController.PushViewController(_controller, true);
		}
	}
}

