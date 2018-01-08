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
using Java.Util;
using Android.Text.Format;
using Java.Text;

namespace SampleBrowser
{
	public class CalendarConfiguration_Tab : SamplePage
	{
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        int modeSpinnerPosition = 0, totalWidth;
        int minYear = 2012, minMonth = 0, minDay = 1;
        int maxYear = 2018, maxMonth = 11, maxDay = 1;
        String minTextDate = "1/1/2012", maxTextDate = "1/12/2018";
        double actionBarHeight, navigationBarHeight, totalHeight;
        FrameLayout propertyFrameLayout, buttomButtonLayout, frame, topProperty;
        SelectionMode selectioMode = SelectionMode.SingleSelection;
        Button minDateButton, maxDateButton, propertyButton;
        DatePickerDialog minDatePicker, maxDatePicker;
        LinearLayout proprtyOptionsLayout, propertylayout;
		FrameLayout mainLayout;
        private Calendar minPick, maxPick;
        const int DATE_DIALOG_ID = 0;
        ArrayAdapter<String> dataAdapter;
        Spinner modeSpinner;
        TextView closeLabel;
        SfCalendar calendar;
        Context context;	

        public override View GetSampleContent (Context context1)
		{
            context= context1;
            InitialMethod(context);
        
            //calendar
            calendar = new SfCalendar (context);
			calendar.ShowEventsInline = false;
			calendar.ViewMode = ViewMode.MonthView;
			calendar.HeaderHeight = 100;
            MonthViewLabelSetting labelSettings = new MonthViewLabelSetting();
			labelSettings.DateLabelSize = 14;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.MonthViewLabelSetting = labelSettings;
            monthViewSettings.TodayTextColor = Color.ParseColor("#1B79D6");
            monthViewSettings.InlineBackgroundColor = Color.ParseColor("#E4E8ED");
            monthViewSettings.CurrentMonthTextColor = (Color.ParseColor("#F7F7F7"));
            monthViewSettings.WeekDayBackgroundColor=Color.ParseColor("#464646");
            monthViewSettings.WeekDayTextColor = Color.ParseColor("#F9F9F9");
            monthViewSettings.PreviousMonthTextColor = Color.ParseColor("#BFBFBF");
            monthViewSettings.PreviousMonthBackgroundColor = Color.ParseColor("#F9F9F9");
            calendar.MonthViewSettings = monthViewSettings;
            calendar.DrawMonthCell += calendar_DrawMonthCell;
            mainLayout.AddView (calendar);

            OptionMainView(context);

            return frame;
        }

        private void InitialMethod(Context context)
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

            //mainLayout
            mainLayout = new FrameLayout(context);
            mainLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.8), GravityFlags.Top | GravityFlags.CenterHorizontal);
        }


        private void OptionMainView(Context context)
        {
            //frame
            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.Rgb(236, 236, 236));
            frame.SetPadding(10, 10, 10, 10);

            //calendarFrame
            FrameLayout calendarFrame = new FrameLayout(context);
            calendarFrame.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.8), GravityFlags.Top | GravityFlags.CenterHorizontal);

            //buttomButtonLayout
            buttomButtonLayout = new FrameLayout(context);
            buttomButtonLayout.SetBackgroundColor(Color.Transparent);
            buttomButtonLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);

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
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propertyFrameLayout.AddView(GetPropertyLayout(context));
            };

            ScrollView scrollView = new ScrollView(context);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.2), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            frame.AddView(mainLayout);
            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
       

        public View GetPropertyLayout (Context context)
		{
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);          

            OptionLayout();
            SelectionModeLayout();
            MinimumDateLayout();
            MaximumDateLayout();
            FinialLayout();

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
            closeLabel = new TextView(context);
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
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            };
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //spaceText
            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void SelectionModeLayout()
        {
            //ViewMode
            TextView viewModeLabel = new TextView(context);
            viewModeLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            viewModeLabel.TextSize = 15;
            viewModeLabel.Text = "Selection Mode";
            modeSpinner = new Spinner(context,SpinnerMode.Dialog);
            modeSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);          

            //Selection List
            List<String> selectionList = new List<String>();
            selectionList.Add("Single Selection");
            selectionList.Add("Multiple Selection");
           
            //Data Adapter
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, selectionList);
            dataAdapter.SetDropDownViewResource
            (Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //ModeSpinner
            modeSpinner.Adapter = dataAdapter;
            modeSpinner.SetSelection(modeSpinnerPosition);
            //Mode Spinner Item Changed Listener
            modeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                modeSpinnerPosition = e.Position;
                if (selectedItem.Equals("Single Selection"))
                {
                    selectioMode = SelectionMode.SingleSelection;
                }
                if (selectedItem.Equals("Multiple Selection"))
                {
                    selectioMode = SelectionMode.MultiSelection;
                }
               
                ApplyChanges();
            };
            LinearLayout viewModeLayout = new LinearLayout(context);
            viewModeLayout.Orientation = Android.Widget.Orientation.Horizontal;
            viewModeLayout.AddView(viewModeLabel);
            viewModeLayout.AddView(modeSpinner);
            proprtyOptionsLayout.AddView(viewModeLayout);

            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }
            
        private void MinimumDateLayout()
        {
            minPick = Calendar.Instance;
            minPick.Set(2012, 0, 1);
            maxPick = Calendar.Instance;
            maxPick.Set(2018, 11, 1);

            //Minimum Date Text
            TextView minDate = new TextView(context);
            minDate.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            minDate.Text = "Min Date";
            minDate.TextSize = 15;
            minDate.Gravity = GravityFlags.Left;

            //minDateButton
            minDateButton = new Button(context);
            minDateButton.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            minDateButton.SetBackgroundColor(Color.ParseColor("#8CD4CF"));
            minDateButton.Text = minTextDate;
            minDateButton.TextSize = 16;
            minDatePicker = new DatePickerDialog(context, MinDateSetting, minYear,
                minMonth, minDay);
            minDateButton.Click += (object sender, EventArgs e) => {
                minDatePicker.Show();
            };

            //minDateLayout
            LinearLayout minDateLayout = new LinearLayout(context);
            minDateLayout.Orientation = Android.Widget.Orientation.Horizontal;
            minDateLayout.AddView(minDate);
            minDateLayout.AddView(minDateButton);

            proprtyOptionsLayout.AddView(minDateLayout);

            //spaceText
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);
        }
        
        private void MaximumDateLayout()
        {
            //Maximum Date Text
            TextView maxDate = new TextView(context);
            maxDate.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            maxDate.Text = "Max Date";
            maxDate.TextSize = 15;
            maxDate.Gravity = GravityFlags.Left;

            //maxDateButton
            maxDateButton = new Button(context);
            maxDateButton.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            maxDateButton.Text = maxTextDate;
            maxDateButton.TextSize = 16;
            maxDateButton.SetBackgroundColor(Color.ParseColor("#8CD4CF"));
            maxDatePicker = new DatePickerDialog(context, MaxDateSetting, maxYear,
                maxMonth, maxDay);
            maxDateButton.Click += (object sender, EventArgs e) => {
                maxDatePicker.Show();
            };

            //maxDateLayout
            LinearLayout maxDateLayout = new LinearLayout(context);
            maxDateLayout.Orientation = Android.Widget.Orientation.Horizontal;
            maxDateLayout.AddView(maxDate);
            maxDateLayout.AddView(maxDateButton);
            proprtyOptionsLayout.AddView(maxDateLayout);

            //spaceText
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText4);
        }
        
        private void FinialLayout()
        {
            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);

            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);
        }
       
        //Minimum DateSelected Method      
        void MinDateSetting (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			DateTime newMinDate = e.Date;
            minYear = newMinDate.Year;
            minMonth = newMinDate.Month;
            minDay = newMinDate.Day;
            minTextDate = minDay.ToString() + "/" + minMonth.ToString() + "/" + minYear.ToString();
            Calendar minCal = Calendar.Instance;
			minCal.Set (newMinDate.Year, newMinDate.Month-1, newMinDate.Day);

			if (calendar.MaxDate == null || (calendar.MaxDate != null && minCal.Before (calendar.MaxDate))) {
				calendar.MinDate = minCal;
				StringBuilder stringBuilder = new StringBuilder ().Append (newMinDate.Day).Append ("/").Append (newMinDate.Month).Append ("/").Append (newMinDate.Year);
				minDateButton.Text = stringBuilder.ToString ();
			}
		}
        
        
        //Maximum DateSelected Method     
        void MaxDateSetting (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			DateTime newMaxDate = e.Date;
            maxYear = newMaxDate.Year;
            maxMonth = newMaxDate.Month;
            maxDay = newMaxDate.Day;
            maxTextDate = maxDay.ToString() + "/" + maxMonth.ToString() + "/" + maxYear.ToString();

            Calendar maxCal = Calendar.Instance;
			maxCal.Set (newMaxDate.Year, newMaxDate.Month-1, newMaxDate.Day);
			if (calendar.MinDate == null || (calendar.MinDate != null && maxCal.After (calendar.MinDate))) {				
				calendar.MaxDate = maxCal;
				StringBuilder stringBuilder = new StringBuilder ().Append (newMaxDate.Day).Append ("/").Append (newMaxDate.Month).Append ("/").Append (newMaxDate.Year);
				maxDateButton.Text = stringBuilder.ToString ();
			}
		}
		// Apply Changes Method
		public void ApplyChanges ()
		{
			calendar.SelectionMode = selectioMode;
		}

        void calendar_DrawMonthCell(object sender, SfCalendar.DrawMonthCellEventArgs e)
        {
            SimpleDateFormat compareString = new SimpleDateFormat("dd/MM/yyyy");
            String temp = new SimpleDateFormat("dd/MM/yyyy").Format(e.P1.Date.Time);
            Java.Util.Date date = compareString.Parse(temp);
            string dayString = new SimpleDateFormat("EEEE").Format(date);
            if (dayString.ToLower().Equals("sunday") || dayString.ToLower().Equals("saturday"))
            {
                e.P1.TextColor = Color.ParseColor("#0990e9");
                e.P1.FontAttribute = (int)TypefaceStyle.Bold;
            }
            else
            {
                e.P1.TextColor = Color.ParseColor("#7F7F7F");
                e.P1.FontAttribute = (int)TypefaceStyle.Italic;
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

