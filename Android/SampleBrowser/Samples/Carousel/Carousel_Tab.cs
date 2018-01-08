#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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
using Com.Syncfusion.Carousel;

using Java.Util;
using Android.Graphics;
using Android.Views.InputMethods;


namespace SampleBrowser
{
    public class Carousel_Tab
    {
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        LinearLayout propertylayout;
        FrameLayout propertyFrameLayout, buttomButtonLayout;
        EditText offSet, scaleOffset, RotateAngle;
        Button propertyButton;
        FrameLayout frame;
        double rotatorAnglePosition = 45, scaleOffsetPosition = 0.8, offsetPosition = 60;
        LinearLayout proprtyOptionsLayout;
        FrameLayout topProperty;
        int offSetValue = 60, RotationAngleValue = 45, selectionPosition = 0;
        double scaleOffsetValue = 0.8;
        Spinner tickSpinner;
        ArrayAdapter<String> dataAdapter;       
        int  totalWidth;
        SfCarousel carousel;
        double actionBarHeight, navigationBarHeight,  totalHeight;
        Context context;
        public View GetSampleContent(Context context1)
        {
            context = context1;
            InitialMethod();

            //carousel
            carousel = new SfCarousel(context);
            List<SfCarouselItem> tempCollection = new List<SfCarouselItem>();
            for (int i = 1; i <= 7; i++)
            {
                SfCarouselItem carouselItem = new SfCarouselItem(context);
                carouselItem.ImageName = "images" + i;
                tempCollection.Add(carouselItem);
            }
            carousel.DataSource = tempCollection;
            carousel.SelectedIndex = 3;
            carousel.ScaleOffset = 0.8f;         
            if (context.Resources.DisplayMetrics.Density > 1.5)
            {
                carousel.ItemHeight = Convert.ToInt32(240 * context.Resources.DisplayMetrics.Density);
                carousel.ItemWidth = Convert.ToInt32(170 * context.Resources.DisplayMetrics.Density);
            }
            carousel.LayoutParameters = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, 700);

            FinalMethod();

            return frame;
        }

        private void InitialMethod()
        {
            frame = new FrameLayout(context);
            totalHeight = context.Resources.DisplayMetrics.HeightPixels;

            TypedValue tv = new TypedValue();
            if (context.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, context.Resources.DisplayMetrics);
            }
            
            navigationBarHeight = getNavigationBarHeight(context);
            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
        }

        private void FinalMethod()
        {
            LinearLayout mainLayout = new LinearLayout(context);          
            mainLayout.SetBackgroundColor(Color.White);
            mainLayout.SetGravity(GravityFlags.Center);
            mainLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.65), GravityFlags.Center | GravityFlags.CenterHorizontal);
            mainLayout.AddView(carousel);
            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.White);

            //scrollView
            ScrollView scrollView1 = new ScrollView(context);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.65), GravityFlags.Top | GravityFlags.CenterHorizontal);
            scrollView1.AddView(mainLayout);
            frame.AddView(scrollView1);

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
            propertyFrameLayout.SetBackgroundColor(Color.Rgb(240, 240, 240));
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.35), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(context));
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propertyFrameLayout.AddView(GetPropertyLayout(context));
            };

            //scrollView
            ScrollView scrollView = new ScrollView(context);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.35), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }

        public View GetPropertyLayout(Context context)
		{
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            OptionLayout();
            OffsetLayout();
            ScaleOffsetLayout();
            RotationAngleLayout();
            VisualModeLayout();
       
            return propertylayout;
        }

        private void OptionLayout()
        {
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
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            };
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //spaceText
            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void OffsetLayout()
        {
            //OffsetLabel
            TextView offsetLabel = new TextView(context);
            offsetLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            offsetLabel.Text = "Offset";
            offsetLabel.TextSize = 15;
            offsetLabel.Gravity = GravityFlags.CenterVertical;

            //offSetText
            offSet = new EditText(context);
            offSet.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            offSet.Text = offsetPosition.ToString();
            offSet.InputType = Android.Text.InputTypes.ClassNumber;
            offSet.TextSize = 16;
            offSet.SetTextColor(Color.Black);
           
            //Offset Text Changed Listener
            offSet.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (offSet.Text.Length > 0)
                {
                    int i = Convert.ToInt32(e.Text.ToString());
                    if (i >= 40 && i <= 100)
                        offSetValue = i;
                    else
                        offSetValue = 60;
                }
                offsetPosition = offSetValue;
                //ApplyChanges();
            };

            //offSetLayout
            LinearLayout offSetLayout = new LinearLayout(context);
            offSetLayout.Orientation = Android.Widget.Orientation.Horizontal;
            offSetLayout.AddView(offsetLabel);
            offSetLayout.AddView(offSet);
            proprtyOptionsLayout.AddView(offSetLayout);

            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }

        private void ScaleOffsetLayout()
        {
            //ScaleLabel
            TextView scaleLabel = new TextView(context);
            scaleLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            scaleLabel.Text = "Scale Offset";
            scaleLabel.TextSize = 16;
            scaleLabel.Gravity = GravityFlags.CenterVertical;

            //scaleOffsetText
            scaleOffset = new EditText(context);
            scaleOffset.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            scaleOffset.InputType = Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.ClassNumber;
            scaleOffset.TextSize = 16;
            scaleOffset.Text = scaleOffsetPosition.ToString();
            scaleOffset.SetTextColor(Color.Black);
            
            //Scale Offset Text Changed Listener
            scaleOffset.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (scaleOffset.Text.Length > 0)
                {
                    float i = (float)Convert.ToDouble(e.Text.ToString());
                    if (i >= 0.5 && i <= 1)
                        scaleOffsetValue = i;
                    else
                        scaleOffsetValue = 0.8;
                }
                scaleOffsetPosition = scaleOffsetValue;
                //  ApplyChanges();
            };

            //scaleLayout
            LinearLayout scaleLayout = new LinearLayout(context);
            scaleLayout.Orientation = Android.Widget.Orientation.Horizontal;
            scaleLayout.AddView(scaleLabel);
            scaleLayout.AddView(scaleOffset);
            proprtyOptionsLayout.AddView(scaleLayout);

            //spaceText
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);
        }

        private void RotationAngleLayout()
        {
            //Rotator Lable
            TextView rotateLabel = new TextView(context);
            rotateLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            rotateLabel.Text = "Rotation Angle";
            rotateLabel.TextSize = 16;
            rotateLabel.Gravity = GravityFlags.CenterVertical;

            //Rotation Angle
            RotateAngle = new EditText(context);
            RotateAngle.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            RotateAngle.InputType = Android.Text.InputTypes.ClassNumber;
            RotateAngle.TextSize = 16;
            RotateAngle.Text = rotatorAnglePosition.ToString();
            RotateAngle.SetTextColor(Color.Black);
           
            //Rotation Angle Text Changed Listener
            RotateAngle.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                if (RotateAngle.Text.Length > 0)
                {
                    int i = Convert.ToInt32(e.Text.ToString());
                    if (i >= 0 && i <= 360)
                        RotationAngleValue = i;
                    else
                        RotationAngleValue = 45;
                }
                rotatorAnglePosition = RotationAngleValue;
                // ApplyChanges();
            };

            //rotateLayout
            LinearLayout rotateLayout = new LinearLayout(context);
            rotateLayout.Orientation = Android.Widget.Orientation.Horizontal;
            rotateLayout.AddView(rotateLabel);
            rotateLayout.AddView(RotateAngle);
            proprtyOptionsLayout.AddView(rotateLayout);

            //spaceText
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 50, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText4);
        }

        private void VisualModeLayout()
        {
            //placementLabel
            TextView placementLabel = new TextView(context);
            placementLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            placementLabel.Text = "View Mode";
            placementLabel.TextSize = 15;

            //tickSpinner
            tickSpinner = new Spinner(context,SpinnerMode.Dialog);
            tickSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            tickSpinner.SetPadding(0, 0, 0, 0);

            //positionList
            List<String> positionList = new List<String>();
            positionList.Add("Default");
            positionList.Add("Linear");
            dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, positionList);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            tickSpinner.Adapter = dataAdapter;
            tickSpinner.SetSelection(selectionPosition);

            //tickSpinner ItemSelected Listener
            tickSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                selectionPosition = e.Position;
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Default"))
                {
                    if (context.Resources.DisplayMetrics.Density > 1.5)
                    {
                        carousel.ItemHeight = Convert.ToInt32(250 * context.Resources.DisplayMetrics.Density);
                        carousel.ItemWidth = Convert.ToInt32(180 * context.Resources.DisplayMetrics.Density);
                    }
                    carousel.ViewMode = ViewMode.Default;
                }
                else if (selectedItem.Equals("Linear"))
                {
                    if (context.Resources.DisplayMetrics.Density > 1.5)
                    {
                        carousel.ItemHeight = Convert.ToInt32(250 * context.Resources.DisplayMetrics.Density);
                        carousel.ItemWidth = Convert.ToInt32(250 * context.Resources.DisplayMetrics.Density);
                    }
                    carousel.ViewMode = ViewMode.Linear;
                }
                //ApplyChanges();
            };

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.Orientation = Android.Widget.Orientation.Horizontal;
            linearLayout.AddView(placementLabel);
            linearLayout.AddView(tickSpinner);
            proprtyOptionsLayout.AddView(linearLayout);

            //spaceText
            TextView spaceText5 = new TextView(context);
            spaceText5.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 50, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText5);
            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            //layout1
            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);

            //propertylayout
            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);
            propertylayout.FocusableInTouchMode = true;
            propertylayout.Touch += (object sender, View.TouchEventArgs e) =>
            {
                Rect outRect = new Rect();
                RotateAngle.GetGlobalVisibleRect(outRect);

                if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY))
                {
                    RotateAngle.ClearFocus();
                }
                hideSoftKeyboard((Activity)context);
            };
        }
        public void ApplyChanges()
        {
            carousel.Offset = offSetValue;
            carousel.RotationAngle = RotationAngleValue;
            carousel.ScaleOffset = (float)scaleOffsetValue;
            // carousel.ViewMode = viewMode;
        }
        public static void hideSoftKeyboard(Activity activity)
        {
            InputMethodManager inputMethodManager = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);
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

