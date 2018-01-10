#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Linq;

namespace SampleBrowser
{
	public class AllSamplesViewController : UIViewController
	{

		UICollectionView featuresCollectionView;
		UICollectionViewFlowLayout featuresLayout;
		public NSMutableArray FeaturesCollections { get; set; }

		UICollectionView samplesCollectionView;
		UICollectionViewFlowLayout samplesLayout;

		public NSString ControlName { get; set; }

		//Multiple view for samples

		SampleView sample;
		bool codeVisible;
		string[] type1Samples;
		string[] type2Samples;
		UIView customTab;
		UILabel tab1TextLabel;
		UILabel tab2TextLabel;
		UIView selectedTabHighlightView;
		UIBarButtonItem codeViewButton;

		public NSString Type1;
		public NSString Type2;
		public bool IsMultipleSampleView;
		public string sampleNameToLoad;
		public NSIndexPath IndexPath;
		public NSMutableArray TypesCollections { get; set; }

		public AllSamplesViewController()
		{

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			codeVisible = false;

			this.NavigationItem.Title = ControlName;
			this.NavigationController.SetNavigationBarHidden(false, false);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.View.BackgroundColor = Utility.backgroundColor;

			//Multiple view for samples

			if (IsMultipleSampleView)
			{
				this.View.BackgroundColor = UIColor.White;

				codeViewButton = new UIBarButtonItem();
				codeViewButton.Image = UIImage.FromBundle("Controls/Tags/Viewcode");
				codeViewButton.Style = UIBarButtonItemStyle.Plain;
				codeViewButton.Target = this;
				codeViewButton.Clicked += ViewCode;

				this.NavigationItem.SetRightBarButtonItem(codeViewButton, true);

				IndexPath = NSIndexPath.FromRowSection(0, 0);

				this.LoadTabView();
				this.PrapareSamplesList();
				this.LoadSample();
			}

			this.LoadCollectionView();
		}

		void LoadCollectionView()
		{
			featuresLayout = new UICollectionViewFlowLayout();
			featuresLayout.ScrollDirection = UICollectionViewScrollDirection.Vertical;
			featuresCollectionView = new UICollectionView(CGRect.Empty, featuresLayout);
			featuresCollectionView.RegisterClassForCell(typeof(UICollectionViewCell), "controlCell");
			featuresCollectionView.DataSource = new AllControlsCollectionSource(FeaturesCollections);
			featuresCollectionView.Delegate = new AllSamplesCollectionDelegate(this);
			featuresCollectionView.BackgroundColor = UIColor.Clear;

			if (IsMultipleSampleView)
				featuresCollectionView.Hidden = true;

			string nibName = "ControlCell";

			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0) || Utility.IsIpad)
			{
				nibName = "ControlCell_9";
			}

			UINib nibAllControls = UINib.FromName(nibName, null);
			featuresCollectionView.RegisterNibForCell(nibAllControls, "controlCell");

			this.View.AddSubview(featuresCollectionView);

			if (IsMultipleSampleView)
			{
			samplesLayout = new UICollectionViewFlowLayout();
			samplesLayout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
			samplesCollectionView = new UICollectionView(CGRect.Empty, samplesLayout);
			samplesCollectionView.RegisterClassForCell(typeof(UICollectionViewCell), "multipleSampleCell");
				samplesCollectionView.DataSource = new MultipleSampleDataSource(TypesCollections, this);
				samplesCollectionView.Delegate = new MultipleSampleDelegate(this, TypesCollections);
			samplesCollectionView.BackgroundColor = UIColor.FromRGB(43.0f / 255.0f, 51.0f / 255.0f, 56.0f / 255.0f);
			featuresCollectionView.Hidden = true;

			UINib nib = UINib.FromName("MultipleSampleCell", null);
			samplesCollectionView.RegisterNibForCell(nib, "multipleSampleCell");

			this.View.AddSubview(samplesCollectionView);
			}
		}

		void LoadTabView()
		{
			type1Samples = ((string)Type1).Split(',');
			type2Samples = ((string)Type2).Split(',');

			customTab = new UIView();
			customTab.BackgroundColor = UIColor.FromRGB(0, 123.0f / 255.0f, 229.0f / 255.0f);

			selectedTabHighlightView = new UIView();
			selectedTabHighlightView.BackgroundColor = UIColor.FromRGB(1.0f, 198.0f / 255.0f, 66.0f / 255.0f);

			tab1TextLabel = new UILabel();

			tab1TextLabel.TextColor = UIColor.White;
			tab1TextLabel.Text = type1Samples[0];
			tab1TextLabel.TextAlignment = UITextAlignment.Center;
			tab1TextLabel.Font = Utility.titleFont;

			tab2TextLabel = new UILabel();
			tab2TextLabel.TextColor = UIColor.White;
			tab2TextLabel.Text = type2Samples[0];
			tab2TextLabel.TextAlignment = UITextAlignment.Center;
			tab2TextLabel.Font = Utility.titleFont;

			customTab.AddSubview(selectedTabHighlightView);
			customTab.AddSubview(tab1TextLabel);
			customTab.AddSubview(tab2TextLabel);

			UITapGestureRecognizer singleFingerTap = new UITapGestureRecognizer();
			singleFingerTap.AddTarget(() => HandleSingleTap(singleFingerTap));
			customTab.AddGestureRecognizer(singleFingerTap);

			this.View.AddSubview(customTab);
		}

		void PrapareSamplesList()
		{
			NSMutableArray tab1Collections = new NSMutableArray();
			NSMutableArray tab2Collections = new NSMutableArray();

			//Samples = new NSMutableArray();

			for (nuint i = 0; i < FeaturesCollections.Count; i++)
			{
				Control control = FeaturesCollections.GetItem<Control>(i);

				if (type1Samples.Contains(control.name))
					tab1Collections.Add(control);

				else if (type2Samples.Contains(control.name))
				{
					tab2Collections.Add(control);
					//Samples.Add(new NSString(control.name));
				}
			}

			TypesCollections = tab1Collections;
			FeaturesCollections = tab2Collections;
		}

		CGRect tab1Rect, tab2Rect;
		float customTabHeight = 50;

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			nfloat width = this.View.Frame.Size.Width, height = this.View.Frame.Size.Height;

			featuresLayout.ItemSize = new CGSize(width - 20, 100);

			//Multiple view for samples
			if (IsMultipleSampleView)
			{
				samplesLayout.ItemSize = new CGSize(50, 70);

				customTab.Frame = new CGRect(0, 64, width, customTabHeight);
				selectedTabHighlightView.Frame = new CGRect(0, customTabHeight - 5, width / 2, 5);

				tab1Rect = new CGRect(0, 0, width / 2, customTabHeight);
				tab2Rect = new CGRect(width / 2, 0, width / 2, customTabHeight);

				tab1TextLabel.Frame = tab1Rect;
				tab2TextLabel.Frame = tab2Rect;

				featuresCollectionView.Frame = new CGRect(0, 64 + customTabHeight + 10, width, height - customTabHeight - 64 - 10);

				sample.Frame = new CGRect(0, 66 + customTabHeight, this.View.Frame.Width, this.View.Frame.Height - 66 - 70 - customTabHeight);

				samplesCollectionView.Frame = new CGRect(0, height-70, width, 70);
			}
			else
				featuresCollectionView.Frame = new CGRect(0, 10, width, height);

			//Update frames for iPad mode
			if (Utility.IsIpad)
			{
				nfloat cellWidth = (width / 2) - 60;
				featuresCollectionView.Frame = new CGRect(40, featuresCollectionView.Frame.Y, width - 100, height - featuresCollectionView.Frame.Y);
				featuresLayout.ItemSize = new CGSize(cellWidth, 100);
			}
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			NSIndexPath index = NSIndexPath.FromRowSection(0, 0);

			if (IndexPath != null && IsMultipleSampleView)
				samplesCollectionView.SelectItem(index, true, UICollectionViewScrollPosition.CenteredHorizontally);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			if (this.IsMovingFromParentViewController)
			{
				//moving back
				if (! codeVisible)
				{
					if (sample != null)
					{
						if (sample.OptionView != null)
						{
							sample.OptionView.RemoveFromSuperview();
							sample.OptionView.Dispose();
							sample.OptionView = null;
						}
						sample.RemoveFromSuperview();
						sample.Dispose();
						sample = null;
					}
					if (featuresCollectionView != null)
					{
						featuresCollectionView.Dispose();
						featuresCollectionView = null;
					}
					if (samplesCollectionView != null)
					{
						samplesCollectionView.Dispose();
						samplesCollectionView = null;
					}

					Utility.DisposeEx(this.View);

					this.Dispose();
				}
			}
		}

		//Multiple view for samples
		void HandleSingleTap(UITapGestureRecognizer gesture)
		{
			CGPoint point = gesture.LocationInView(customTab);

			if (tab1Rect.Contains(point))
			{
				codeViewButton.Enabled = true;
				featuresCollectionView.Hidden = true;
				samplesCollectionView.Hidden = false;
				sample.Hidden = false;
				selectedTabHighlightView.Frame = new CGRect(0, customTabHeight - 5, this.View.Frame.Size.Width / 2, 5);

				this.View.BackgroundColor = UIColor.White;
			}
			else if (tab2Rect.Contains(point))
			{
				codeViewButton.Enabled = false;
				samplesCollectionView.Hidden = true;
				sample.Hidden = true;
				featuresCollectionView.Hidden = false;
				selectedTabHighlightView.Frame = new CGRect(this.View.Frame.Size.Width/2, customTabHeight - 5, this.View.Frame.Size.Width / 2, 5);

				this.View.BackgroundColor = Utility.backgroundColor;
			}
		}

		public void LoadSample()
		{
			if (sample != null && sample.IsDescendantOfView(this.View))
			{
				foreach (UIView view in sample.Subviews)
				{
					view.RemoveFromSuperview();
					view.Dispose();
				}

				sample.RemoveFromSuperview();
				sample.Dispose();
			}

			sampleNameToLoad = type1Samples[(nuint)IndexPath.Row + 1]; //Note: 0th index is tab title

			ControlName = new NSString("Chart");

			this.Title = "Chart";

			if (sampleNameToLoad == "100% Stacked Area")
			{
				sampleNameToLoad = "StackingArea100";
			}
			else if (sampleNameToLoad == "100% Stacked Column")
			{
				sampleNameToLoad = "StackingColumn100";
			}
			else if (sampleNameToLoad == "100% Stacked Bar")
			{
				sampleNameToLoad = "StackingBar100";
			}

			sampleNameToLoad = sampleNameToLoad.Replace(" ", "");

			string classname = "SampleBrowser." + sampleNameToLoad;

			if (classname == "SampleBrowser.CustomizationKanban")
				this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(211.0f / 255.0f, 51.0f / 255.0f, 54.0f / 255.0f);
			else
				this.NavigationController.NavigationBar.BarTintColor = Utility.themeColor;

			Type sampleClass = Type.GetType(classname);

			if (sampleClass != null)
			{
				sample = Activator.CreateInstance(sampleClass) as SampleView;

				sample.RemoveFromSuperview();

				this.View.AddSubview(sample);

			}
		}

		void ViewCode(object sender, EventArgs ea)
		{
			CodeViewController viewController = new CodeViewController();
			viewController.controlName = ControlName;
			viewController.sampleName = sampleNameToLoad;
			codeVisible = true;
			this.NavigationController.PushViewController(viewController, true);
		}

	}
}