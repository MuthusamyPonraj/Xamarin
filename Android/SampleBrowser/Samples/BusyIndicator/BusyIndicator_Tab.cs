#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Sfbusyindicator;
using Android.Graphics;
using Com.Syncfusion.Sfbusyindicator.Enums;
using Android.Util;

namespace SampleBrowser
{
    public class BusyIndicator_Tab : SamplePage
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        double actionBarHeight, navigationBarHeight, totalHeight;
        FrameLayout propertyFrameLayout, buttomButtonLayout;
        int animationSpinnerPosition = 0,totalWidth;
        SfBusyIndicator sfBusyIndicator;
        LinearLayout propertylayout;
        TextView animationTypeText;
        Spinner animationSpinner;
        Button propertyButton;
        FrameLayout frame;
        Context con;
       
        public override View GetSampleContent(Context con1)
        {
            con = con1;
            InitialMethod();
            AnimationModeLayout();

            //sfBusyIndicator
            sfBusyIndicator = new SfBusyIndicator(con);
            sfBusyIndicator.IsBusy = true;
            sfBusyIndicator.TextColor = Color.Rgb(62, 101, 254);
            sfBusyIndicator.AnimationType = AnimationTypes.DoubleCircle;
            sfBusyIndicator.ViewBoxWidth = 133;
            sfBusyIndicator.ViewBoxHeight = 133;
            sfBusyIndicator.TextSize = 60;
            sfBusyIndicator.Title = "";
            sfBusyIndicator.SetBackgroundColor(Color.Rgb(255, 255, 255));

            FrameLayout mainView = GetView(con);
            return mainView;
        }

        private void InitialMethod()
        {
            /*****************
             **Initial Setup**
             *****************/
           
            totalWidth = (con.Resources.DisplayMetrics.WidthPixels);
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;

            TypedValue tv = new TypedValue();
            if (con.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, con.Resources.DisplayMetrics);
            }
            navigationBarHeight = getNavigationBarHeight(con);
            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
        }       

        private void AnimationModeLayout()
        {
            /*********************
             **Animation Mode**
             *********************/
            animationSpinner = new Spinner(con,SpinnerMode.Dialog);
            animationSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            animationSpinner.SetMinimumHeight(60);
            animationSpinner.DropDownWidth = 500;
            animationSpinner.SetSelection(animationSpinnerPosition);
            animationSpinner.SetBackgroundColor(Color.Gray);

            //Animation List
            List<String> animationList = new List<String>();
            animationList.Add("Ball");
            animationList.Add("Battery");
            animationList.Add("DoubleCircle");
            animationList.Add("ECG");
            animationList.Add("Globe");
            animationList.Add("HorizontalPulsingBox");
            animationList.Add("MovieTimer");
            animationList.Add("Print");
            animationList.Add("Rectangle");
            animationList.Add("RollingBall");
            animationList.Add("SingleCircle");
            animationList.Add("SlicedCircle");
            animationList.Add("ZoomingTarget");
			animationList.Add("Gear");
		

            //Data Adapter
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
                (con, Android.Resource.Layout.SimpleSpinnerItem, animationList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            animationSpinner.Adapter = dataAdapter;
            animationSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(animationSpinner_ItemSelected);

            //Animation Text
            animationTypeText = new TextView(con);
            animationTypeText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            animationTypeText.TextSize = 15;
            animationTypeText.Text = "Animation Types";
        }
        LinearLayout linearLayout;
        private FrameLayout GetView(Context con)
        {
            frame = new FrameLayout(con);
           
            //linearLayout
            linearLayout = new LinearLayout(con);
            linearLayout.SetPadding(20, 20, 20, 10);
            linearLayout.SetBackgroundColor(Color.White);
            linearLayout.LayoutParameters = new FrameLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                (int)(totalHeight * 0.7), GravityFlags.Top | GravityFlags.CenterHorizontal);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.AddView(sfBusyIndicator);

            OptionViewLayout();

            return frame;
        }

        private void OptionViewLayout()
        {
            /****************
           **Options View**
           ****************/
            propertylayout = new LinearLayout(con);
            propertylayout.Orientation = Orientation.Vertical;

            //propertyLabel
            TextView propertyLabel = new TextView(con);
            propertyLabel.SetTextColor(Color.ParseColor("#282828"));
            propertyLabel.Gravity = GravityFlags.CenterVertical;
            propertyLabel.TextSize = 18;
            propertyLabel.SetPadding(0, 10, 0, 10);
            propertyLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Left | GravityFlags.CenterHorizontal);
            propertyLabel.Text = "  " + "OPTIONS";

            //closeLabel
            TextView closeLabel = new TextView(con);
            closeLabel.SetBackgroundColor(Color.Transparent);
            closeLabel.Gravity = GravityFlags.CenterVertical;
            closeLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLabel.SetBackgroundResource(Resource.Drawable.sfclosebutton);

            //closeLayout
            FrameLayout closeLayout = new FrameLayout(con);
            closeLayout.SetBackgroundColor(Color.Transparent);
            closeLayout.SetPadding(0, 10, 0, 10);
            closeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLayout.AddView(closeLabel);

            //topProperty
            FrameLayout topProperty = new FrameLayout(con);
            topProperty.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            topProperty.SetBackgroundColor(Color.Rgb(230, 230, 230));
            topProperty.AddView(propertyLabel);
            LinearLayout proprtyOptionsLayout = new LinearLayout(con);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //spaceText
            TextView spaceText1 = new TextView(con);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);

            //animationSpinnerLayout
            LinearLayout animationSpinnerLayout = new LinearLayout(con);
            animationSpinnerLayout.Orientation = Android.Widget.Orientation.Horizontal;
            animationSpinnerLayout.AddView(animationTypeText);
            animationSpinnerLayout.AddView(animationSpinner);
            proprtyOptionsLayout.AddView(animationSpinnerLayout);

            //spaceText
            TextView spaceText2 = new TextView(con);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
            TextView spaceLabel = new TextView(con);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            //layout1
            LinearLayout layout1 = new LinearLayout(con);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);
            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);

            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.Rgb(240, 240, 240));
            frame.SetPadding(10, 10, 10, 10);

            ScrollView scrollView1 = new ScrollView(con);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.7), GravityFlags.Top | GravityFlags.CenterHorizontal);
            // scrollView1.AddView(linearLayout);
            frame.AddView(linearLayout);

            //buttomButtonLayout
            buttomButtonLayout = new FrameLayout(con);
            buttomButtonLayout.SetBackgroundColor(Color.Rgb(240, 240, 240));
            buttomButtonLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);

            //propertyButton
            propertyButton = new Button(con);
            propertyButton.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            propertyButton.Text = "OPTIONS";
            propertyButton.Gravity = GravityFlags.Start;

            //propertyFrameLayout
            propertyFrameLayout = new FrameLayout(con);
            propertyFrameLayout.SetBackgroundColor(Color.Rgb(240, 240, 240));
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(propertylayout);

            //PropertyButton Click Listener
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propertyFrameLayout.AddView(propertylayout);
            };
            ScrollView scrollView = new ScrollView(con);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
        }

        /*****************************************
         **Animation Spinner ItemSelected Method**
         *****************************************/
        private void animationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner animationSpinner = (Spinner)sender;
            animationSpinnerPosition = e.Position;
            String selectedItem = animationSpinner.GetItemAtPosition(e.Position).ToString();
            if (selectedItem.Equals("Ball"))
            {
                sfBusyIndicator.Duration = 1000;
                sfBusyIndicator.TextColor = Color.ParseColor("#243FD9");
                sfBusyIndicator.AnimationType = AnimationTypes.Ball;
            }
            else if (selectedItem.Equals("Battery"))
            {
                sfBusyIndicator.Duration = 300;
                sfBusyIndicator.TextColor = Color.ParseColor("#A70015");
                sfBusyIndicator.AnimationType = AnimationTypes.Battery;
            }
            else if (selectedItem.Equals("DoubleCircle"))
            {
                sfBusyIndicator.Duration = 1400;
                sfBusyIndicator.TextColor = Color.ParseColor("#958C7B");
                sfBusyIndicator.AnimationType = AnimationTypes.DoubleCircle;
            }
            else if (selectedItem.Equals("ECG"))
            {
                sfBusyIndicator.Duration = 1500;
                sfBusyIndicator.TextColor = Color.ParseColor("#DA901A");
                sfBusyIndicator.AnimationType = AnimationTypes.Ecg;
            }
            else if (selectedItem.Equals("Globe"))
            {
                sfBusyIndicator.Duration = 800;
                sfBusyIndicator.TextColor = Color.ParseColor("#9EA8EE");
                sfBusyIndicator.AnimationType = AnimationTypes.Globe;
            }
            else if (selectedItem.Equals("HorizontalPulsingBox"))
            {
                sfBusyIndicator.Duration = 500;
                sfBusyIndicator.TextColor = Color.ParseColor("#E42E06");
                sfBusyIndicator.AnimationType = AnimationTypes.HorizontalPulsingBox;
            }
            else if (selectedItem.Equals("MovieTimer"))
            {
                sfBusyIndicator.Duration = 600;
                sfBusyIndicator.TextColor = Color.ParseColor("#2d2d2d");
                sfBusyIndicator.SecondaryColor = Color.ParseColor("#9b9b9b");
                sfBusyIndicator.AnimationType = AnimationTypes.MovieTimer;
            }
            else if (selectedItem.Equals("Print"))
            {
                sfBusyIndicator.Duration = 1000;
                sfBusyIndicator.TextColor = Color.ParseColor("#5E6FF8");
                sfBusyIndicator.AnimationType = AnimationTypes.Print;
            }
            else if (selectedItem.Equals("Rectangle"))
            {
                sfBusyIndicator.Duration = 200;
                sfBusyIndicator.TextColor = Color.ParseColor("#27AA9E");
                sfBusyIndicator.AnimationType = AnimationTypes.Rectangle;
            }
            else if (selectedItem.Equals("RollingBall"))
            {
                sfBusyIndicator.Duration = 1000;
                sfBusyIndicator.TextColor = Color.ParseColor("#2d2d2d");
                sfBusyIndicator.SecondaryColor = Color.White;
                sfBusyIndicator.AnimationType = AnimationTypes.RollingBall;
            }
            else if (selectedItem.Equals("SingleCircle"))
            {
                sfBusyIndicator.Duration = 1000;
                sfBusyIndicator.TextColor = Color.ParseColor("#AF2541");
                sfBusyIndicator.AnimationType = AnimationTypes.SingleCircle;
            }
            else if (selectedItem.Equals("SlicedCircle"))
            {
                sfBusyIndicator.Duration = 1600;
                sfBusyIndicator.TextColor = Color.ParseColor("#779772");
                sfBusyIndicator.AnimationType = AnimationTypes.SlicedCircle;
            }
            else if (selectedItem.Equals("ZoomingTarget"))
            {
                sfBusyIndicator.Duration = 600;
                sfBusyIndicator.TextColor = Color.ParseColor("#ED8F3C");
                sfBusyIndicator.AnimationType = AnimationTypes.ZoomingTarget;
            }
			else if (selectedItem.Equals("Gear"))
			{
				sfBusyIndicator.Duration = 1500;
				sfBusyIndicator.TextColor = Color.Gray;
				sfBusyIndicator.AnimationType = AnimationTypes.GearBox;
			}
		
        }
        private int getStatusBarHeight(Android.Content.Context con)
        {
            int barHeight = 0;
            int resourceId = con.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                barHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return barHeight;
        }

        private int getNavigationBarHeight(Android.Content.Context con)
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

