#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;
using Com.Syncfusion.Rotator;
using System.Collections;
using Android.Graphics;


namespace SampleBrowser
{
    public class Rotator_Tab : SamplePage
    {
        public Rotator_Tab()
        {
        }

       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        SfRotator rotator;
        double actionBarHeight, navigationBarHeight, totalHeight;
        Button propertyButton;
        LinearLayout propertylayout;
        FrameLayout propertyFrameLayout, bottomButtonLayout, frame;
        Context con;
        int height;
        Spinner directionSpinner, tabStripSpinner, modeSpinner;
        ArrayAdapter<String> tabAdapter, directionAdapter, modeAdapter;
        int naviDirectionPosition = 0, naviStripPostion = 0, naviStripModePosition = 0, totalWidth;
        bool autoPlayPosition = false;
        Context context;
        public override View GetSampleContent(Android.Content.Context context1)
        {
            con = context1;
            context = context1;
            InitialMethod();
            
            //Rotator
            rotator = new SfRotator(con);
            rotator.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, height / 2);//ActionBar.LayoutParameters(ViewGroup.LayoutParams.MATCH_PARENT,height/2);
            rotator.NavigationStripMode = NavigationStripMode.Dots;
            rotator.NavigationDirection = NavigationDirection.Horizontal;
            rotator.NavigationStripPosition = NavigationStripPosition.Bottom;
            rotator.SelectedIndex = 2;
            rotator.EnableAutoPlay = false;
            rotator.SetBackgroundColor(Color.ParseColor("#ececec"));
            
            //Images List
            List<SfRotatorItem> images = new List<SfRotatorItem>();
            
            //Images Id List
            List<int> imageID = new List<int>();
            imageID.Add(Resource.Drawable.movie1);
            imageID.Add(Resource.Drawable.movie2);
            imageID.Add(Resource.Drawable.movie3);
            imageID.Add(Resource.Drawable.movie4);
            imageID.Add(Resource.Drawable.movie5);
            SfRotatorItem item;
            ImageView image;
            for (int i = 0; i < imageID.Count; i++)
            {
                item = new SfRotatorItem(con);
                image = new ImageView(con);
                image.SetImageResource(imageID[i]);
                item.Content = image;
                images.Add(item);
            }
            rotator.DataSource = images;
            FinalLayout();

            return frame;
        }

        private void InitialMethod()
        {
            frame = new FrameLayout(con);
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;
            height = (int)(con.Resources.DisplayMetrics.HeightPixels); //-(actionBarHeight+statusBarHeight+navigationBarHeight));

            TypedValue tv = new TypedValue();
            if (con.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, con.Resources.DisplayMetrics);
            }
            navigationBarHeight = getNavigationBarHeight(con);
            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
        }

        private void FinalLayout()
        {
            //completeLayout
            LinearLayout completeLayout = new LinearLayout(con);
            completeLayout.Orientation = Orientation.Vertical;
            completeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.65), GravityFlags.Top | GravityFlags.CenterHorizontal);
            completeLayout.AddView(rotator);

            //frame
            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.Rgb(236, 236, 236));
            frame.SetPadding(10, 10, 10, 10);

            //scrollView1
            ScrollView scrollView1 = new ScrollView(context);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.65), GravityFlags.Top | GravityFlags.CenterHorizontal);
            scrollView1.AddView(completeLayout);
            frame.AddView(scrollView1);

            //bottomButtonLayout
            bottomButtonLayout = new FrameLayout(context);
            bottomButtonLayout.SetBackgroundColor(Color.Transparent);
            bottomButtonLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);

            //propertyButton
            propertyButton = new Button(context);
            propertyButton.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            propertyButton.Text = "OPTIONS";
            propertyButton.Gravity = GravityFlags.Start;

            //propertyFrameLayout
            propertyFrameLayout = new FrameLayout(context);
            propertyFrameLayout.SetBackgroundColor(Color.Rgb(236, 236, 236));
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.35), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(context));
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                bottomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propertyFrameLayout.AddView(GetPropertyLayout(context));
            };

            //scrollView
            ScrollView scrollView = new ScrollView(context);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.35), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            //frame
            frame.AddView(scrollView);
            frame.AddView(bottomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
       

        public View GetPropertyLayout(Android.Content.Context context1)
        {
            context = context1;
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);          

            OptionLayout();
            NavigationDirectionLayout();
            StripPositionLayout();
            StripModeLayout();
            EnableAutoPlayLayout();

            return propertylayout;
        }
        LinearLayout proprtyOptionsLayout;
        FrameLayout topProperty;
        private void OptionLayout()
        {
            //propertylayout
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            //propertyLabel
            TextView propertyLabel = new TextView(context);
            propertyLabel.SetTextColor(Color.ParseColor("#282828"));
            propertyLabel.Gravity = GravityFlags.CenterVertical;
            propertyLabel.TextSize = 18;
            propertyLabel.SetPadding(0, 10, 0, 10);
            propertyLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Left | GravityFlags.CenterHorizontal);
            propertyLabel.Text = "  " + "OPTIONS";

            //closeLabel
            TextView closeLabel = new TextView(context);
            closeLabel.SetBackgroundColor(Color.Transparent);
            closeLabel.Gravity = GravityFlags.CenterVertical;
            closeLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLabel.SetBackgroundResource(Resource.Drawable.sfclosebutton);

            //closeLayout
            FrameLayout closeLayout = new FrameLayout(context);
            closeLayout.SetBackgroundColor(Color.Transparent);
            closeLayout.SetPadding(0, 10, 0, 10);
            closeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLayout.AddView(closeLabel);

            //topProperty
            topProperty = new FrameLayout(context);
            topProperty.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            topProperty.SetBackgroundColor(Color.Rgb(230, 230, 230));
            topProperty.AddView(propertyLabel);
            topProperty.AddView(closeLayout);
            topProperty.Touch += (object sendar, View.TouchEventArgs e) =>
            {
                propertyFrameLayout.RemoveAllViews();
                bottomButtonLayout.RemoveAllViews();
                bottomButtonLayout.AddView(propertyButton);
            };
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //spaceText
            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void NavigationDirectionLayout()
        {
            //Direction Label
            TextView directionLabel = new TextView(context);
            directionLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            directionLabel.Text = "Navigation Direction";
            directionLabel.TextSize = 15;
            directionLabel.SetTextColor(Color.Black);
            directionLabel.Gravity = GravityFlags.Left;

            //directionSpinner
            directionSpinner = new Spinner(context,SpinnerMode.Dialog);
            directionSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            directionSpinner.SetPadding(0, 0, 0, 0);

            //Direction List
            List<String> directionList = new List<String>();
            directionList.Add("Horizontal");
            directionList.Add("Vertical");
            
            //Direction adapter
            directionAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, directionList);
            directionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
           
            //Direction Spinner Item Selected Listener
            directionSpinner.Adapter = directionAdapter;
            directionSpinner.SetSelection(naviDirectionPosition);
            directionSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = directionAdapter.GetItem(e.Position);
                naviDirectionPosition = e.Position;
                if (selectedItem.Equals("Horizontal"))
                {
                    rotator.NavigationDirection = NavigationDirection.Horizontal;

                }
                else if (selectedItem.Equals("Vertical"))
                {
                    rotator.NavigationDirection = NavigationDirection.Vertical;

                }
            };

            //directionLayout
            LinearLayout directionLayout = new LinearLayout(context);
            directionLayout.Orientation = Android.Widget.Orientation.Horizontal;
            directionLayout.AddView(directionLabel);
            directionLayout.AddView(directionSpinner);
            proprtyOptionsLayout.AddView(directionLayout);

            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }

        private void StripPositionLayout()
        {
            //Tap Position	
            TextView tabPoitionLabel = new TextView(context);
            tabPoitionLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            tabPoitionLabel.Text = "Navigation Strip Position";
            tabPoitionLabel.Gravity = GravityFlags.Left;
            tabPoitionLabel.TextSize = 15;
            tabPoitionLabel.SetTextColor(Color.Black);

            //tabList
            List<String> tabList = new List<String>();
            tabList.Add("Bottom");
            tabList.Add("Top");
            tabList.Add("Right");
            tabList.Add("Left");
            tabStripSpinner = new Spinner(context,SpinnerMode.Dialog);
            tabStripSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            // Tap Adapter
            tabAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, tabList);
            tabAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //tabStripSpinner
            tabStripSpinner.Adapter = tabAdapter;
            tabStripSpinner.SetSelection(naviStripPostion);
            tabStripSpinner.SetPadding(0, 0, 0, 0);
            tabStripSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = tabAdapter.GetItem(e.Position);
                naviStripPostion = e.Position;
                if (selectedItem.Equals("Bottom"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Bottom;
                }
                else if (selectedItem.Equals("Top"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Top;
                }
                if (selectedItem.Equals("Right"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Right;

                }
                else if (selectedItem.Equals("Left"))
                {
                    rotator.NavigationStripPosition = NavigationStripPosition.Left;
                }
            };

            //tabPoitionLayout
            LinearLayout tabPoitionLayout = new LinearLayout(context);
            tabPoitionLayout.Orientation = Android.Widget.Orientation.Horizontal;
            tabPoitionLayout.AddView(tabPoitionLabel);
            tabPoitionLayout.AddView(tabStripSpinner);
            proprtyOptionsLayout.AddView(tabPoitionLayout);

            //spaceText
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);
        }

        private void StripModeLayout()
        {
            //modeLabel
            TextView modeLabel = new TextView(context);
            modeLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            modeLabel.Text = "Navigation Strip Mode";
            modeLabel.Gravity = GravityFlags.Left;
            modeLabel.TextSize = 15;
            modeLabel.SetTextColor(Color.Black);
            
            //Mode List
            List<String> modeList = new List<String>();
            modeList.Add("Dots");
            modeList.Add("Thumbnail");
            
            //Mode Spinner Item Selected Listener
            modeSpinner = new Spinner(context,SpinnerMode.Dialog);
            modeSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = modeAdapter.GetItem(e.Position);
                naviStripModePosition = e.Position;
                if (selectedItem.Equals("Dots"))
                {
                    rotator.NavigationStripMode = NavigationStripMode.Dots;
                }
                else if (selectedItem.Equals("Thumbnail"))
                {
                    rotator.NavigationStripMode = NavigationStripMode.Thumbnail;
                }
            };

            //modeAdapter
            modeAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, modeList);
            modeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            modeSpinner.Adapter = modeAdapter;
            modeSpinner.SetSelection(naviStripModePosition);

            //modeLayout
            LinearLayout modeLayout = new LinearLayout(context);
            modeLayout.Orientation = Android.Widget.Orientation.Horizontal;
            modeLayout.AddView(modeLabel);
            modeLayout.AddView(modeSpinner);
            proprtyOptionsLayout.AddView(modeLayout);

            //spaceText
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText4);
        }

        private void EnableAutoPlayLayout()
        {
            //autoPlayLabel
            TextView autoPlayLabel = new TextView(context);
            autoPlayLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            autoPlayLabel.Text = "Enable AutoPlay";
            autoPlayLabel.TextSize = 15;
            
            //Auto Play Switch
            Switch playSwitch = new Switch(context);
            playSwitch.Checked = autoPlayPosition;
            playSwitch.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
            {
                rotator.EnableAutoPlay = e.IsChecked;
                autoPlayPosition = e.IsChecked;
            };

            //spaceText
            TextView spaceText7 = new TextView(context);
            spaceText7.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            //autoPlayLayout
            LinearLayout autoPlayLayout = new LinearLayout(context);
            autoPlayLayout.Orientation = Android.Widget.Orientation.Horizontal;
            autoPlayLayout.AddView(autoPlayLabel);
            autoPlayLayout.AddView(playSwitch);
            autoPlayLayout.AddView(spaceText7);
            proprtyOptionsLayout.AddView(autoPlayLayout);

            //spaceText
            TextView spaceText5 = new TextView(context);
            spaceText5.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText5);
            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            //layout1
            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);
            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);          
        }
        private int getStatusBarHeight(Context con)
        {
            int barHeight = 0;
            int resourceId = con.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                barHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return barHeight;
        }
        private int getNavigationBarHeight(Context con)
        {
            int navBarHeight = 0;
            int resourceId = con.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                navBarHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return navBarHeight;
        }
    }
}

