#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using SampleBrowser.Core;
using SampleBrowser.Core.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AllControlsSamplePage), typeof(ContentPageRenderer))]

namespace SampleBrowser.Core.iOS
{
    public class ContentPageRenderer : PageRenderer
    {
        public ContentPageRenderer()
        {         
        }

        public new AllControlsSamplePage Element
        {
            get { return (AllControlsSamplePage)base.Element; }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (UIKeyboard.WillHideNotification != null)
            {
                observerHideKeyboard = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyBoardEnabled);
            }

            if (UIKeyboard.WillShowNotification != null)
            {
                observerShowKeyboard = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyBoardEnabled);
            }
        }

        NSObject observerHideKeyboard;
        NSObject observerShowKeyboard;

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NSNotificationCenter.DefaultCenter.RemoveObserver(observerHideKeyboard);
            NSNotificationCenter.DefaultCenter.RemoveObserver(observerShowKeyboard);
        }
 
        void OnKeyBoardEnabled(NSNotification notification)
        {
            if (!IsViewLoaded) return;

            var pageBounds = Element.Bounds;
            double yPosition = UIKeyboard.FrameBeginFromNotification(notification).Y - UIKeyboard.FrameEndFromNotification(notification).Y;
            var propertiesViewBounds = new Rectangle(Element.PropertiesView.X, Element.PropertiesView.Y - yPosition, Element.PropertiesView.Width, Element.PropertiesView.Height);
            Element.PropertiesView.Layout(propertiesViewBounds);
        }
    }
}