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
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Calendar;
using Com.Syncfusion.Calendar.Enums;
using Android.Graphics;

namespace SampleBrowser
{
    public class CalendarGettingStarted_Tab : SamplePage
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        double actionBarHeight, navigationBarHeight, totalHeight;
        FrameLayout mainLayout;
        SfCalendar calendar;
        ViewMode viewMode = ViewMode.MonthView;
        LinearLayout propertylayout;
        ArrayAdapter<String> dataAdapter;
        Spinner modeSpinner;
        Button propertyButton;
        FrameLayout propertyFrameLayout, bottomButtonLayout;
        int modeSpinnerPosition = 0 ;   
        Context context;
        FrameLayout frame;
        LinearLayout proprtyOptionsLayout;
        FrameLayout topProperty;
      
        public CalendarGettingStarted_Tab()
        {

        }
        public override View GetSampleContent(Context context1)
        {
            context = context1;
            InizialMethod();

            //calendar
            calendar = new SfCalendar(context);
            calendar.ShowEventsInline = false;
			calendar.HeaderHeight = 100;
            MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
			labelSettings.DateLabelSize = 14;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.MonthViewLabelSetting = labelSettings;
            monthViewSettings.TodayTextColor = Color.ParseColor("#1B79D6");
            monthViewSettings.InlineBackgroundColor = Color.ParseColor("#E4E8ED");
            monthViewSettings.WeekDayBackgroundColor=Color.ParseColor("#F7F7F7");
            calendar.MonthViewSettings = monthViewSettings;
            mainLayout.AddView(calendar);

            OptionMainView();

            return frame;
        }

        private void InizialMethod()
        {
            frame = new FrameLayout(context);
            totalHeight = context.Resources.DisplayMetrics.HeightPixels;
            TypedValue tv = new TypedValue();
            if (context.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, context.Resources.DisplayMetrics);
            }
            navigationBarHeight = getNavigationBarHeight(context);

            totalHeight = (totalHeight - navigationBarHeight - actionBarHeight);

            mainLayout = new FrameLayout(context);
            mainLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.8), GravityFlags.Top | GravityFlags.CenterHorizontal);
        }
       
        private void OptionMainView()
        {
            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.Rgb(236, 236, 236));
            frame.SetPadding(10, 10, 10, 10);

            //calendarFrame
            FrameLayout calendarFrame = new FrameLayout(context);
            calendarFrame.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.8), GravityFlags.Top | GravityFlags.CenterHorizontal);

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
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.2), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(context));
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                bottomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propertyFrameLayout.AddView(GetPropertyLayout(context));
            };

            //scrollView
            ScrollView scrollView = new ScrollView(context);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.2), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            frame.AddView(mainLayout);
            frame.AddView(scrollView);
            frame.AddView(bottomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
		float totalWidth;
        public View GetPropertyLayout(Context context)
        {
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);          

            OptionLayout();
            ViewModeLayout();
            FinalLayout();

            return propertylayout;
        }

        private void OptionLayout()
        {
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
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 60, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void ViewModeLayout()
        {
            //ViewMode
            TextView viewModeLabel = new TextView(context);
            viewModeLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            viewModeLabel.TextSize = 15;
            viewModeLabel.Text = "ViewMode";
            modeSpinner = new Spinner(context,SpinnerMode.Dialog);
            modeSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            //Vie Mode List
            List<String> viewModeList = new List<String>();
            viewModeList.Add("Month View");
            viewModeList.Add("Year View");
            
            //Data Adapter
            dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, viewModeList);
            dataAdapter.SetDropDownViewResource
            (Android.Resource.Layout.SimpleSpinnerDropDownItem);
            modeSpinner.Adapter = dataAdapter;
            modeSpinner.SetSelection(modeSpinnerPosition);
            
            //Mode Spinner Item Selected Listener
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                modeSpinnerPosition = e.Position;
                if (selectedItem.Equals("Month View"))
                {
                    viewMode = ViewMode.MonthView;
                }
                if (selectedItem.Equals("Year View"))
                {
                    viewMode = ViewMode.YearView;
                }
                ApplyChanges();
            };

            //viewModeLayout
            LinearLayout viewModeLayout = new LinearLayout(context);
            viewModeLayout.Orientation = Android.Widget.Orientation.Horizontal;
            viewModeLayout.AddView(viewModeLabel);
            viewModeLayout.AddView(modeSpinner);
            proprtyOptionsLayout.AddView(viewModeLayout);

            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 60, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }

        private void FinalLayout()
        {
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
        //Apply Changes Method
        public void ApplyChanges()
        {
            calendar.ViewMode = viewMode;
            calendar.UpdateCalendar();
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

