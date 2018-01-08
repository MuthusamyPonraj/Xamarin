#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Android.App;
using Android.Util;
using System;
using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Rating;
using Android.Content.Res;

using Android.Graphics;
using Android.Views.InputMethods;

namespace SampleBrowser
{
    public class Rating_Tab : SamplePage
    {
        /*********************************
         **Local Varabile Inizialization**
         *********************************/
        LinearLayout pageLayout, columnLayout, imageLayout, contentLayout, propertylayout;
        LinearLayout proprtyOptionsLayout, textLayout, timeLayout, valueLayout ;
        LinearLayout descriptionLayout, ratingLayout, padLayout;
        TextView title, movieLabel, time, description, dummyLabel2, dummyLabel, ratingLable, showLable;
        FrameLayout propertyFrameLayout, buttomButtonLayout, topProperty, frame;
        double actionBarHeight, navigationBarHeight, totalHeight;
        int percisionPosition = 0, toolTipSpinnerPosition = 0, itemCountPosition = 5;
        ImageView imageView;
        SfRating sfRating, sfRating1;
        SfRatingSettings sfRatingSettings, sfRatingSetings1;
        ArrayAdapter<String> precisionAdapter, placementAdapter;
        Precision precisionPosition = Precision.Standard;
        TooltipPlacement toolTipPosition = TooltipPlacement.None;
        EditText itemCountEntry;
        int constCount = 5, height, width, totalWidth;
        Button propertyButton;   
        Context con, context;
        Spinner precisionSpinner, toolTipSpinner;     
  
        public override View GetSampleContent(Context con1)
        {
            con = con1;
            InitialLayout();
            TitleLayout();
            ImageLayout();

            //Non Editable Rating
            ratingLayout = new LinearLayout(con);
            ratingLayout.SetPadding(5, 2, 0, 0);
            sfRatingSettings = new SfRatingSettings();
            sfRating1 = new SfRating(con);         
            sfRating1.ItemSize = 33;           
            sfRating1.Precision = Precision.Exact;
            sfRating1.Value = 3.5;
            sfRating1.ReadOnly = true;
            sfRating1.ItemSpacing = 0;
            sfRating1.TooltipPlacement = TooltipPlacement.None;
            sfRatingSettings.RatedFill = Color.ParseColor("#fbd10a");
            sfRatingSettings.UnRatedFill = Color.ParseColor("#cdcccb");
            sfRatingSettings.RatedStrokeWidth = 0;
            sfRatingSettings.UnRatedStrokeWidth = 0;
            sfRating1.RatingSettings = sfRatingSettings;
			sfRating1.LayoutParameters = new ViewGroup.LayoutParams((int)(400 * con.Resources.DisplayMetrics.Density) ,(int)(33 * con.Resources.DisplayMetrics.Density));
            ratingLayout.AddView(sfRating1);
            textLayout.AddView(ratingLayout);
            contentLayout.AddView(textLayout);
            DescriptionLayout();

            //Editable Rating 
            sfRatingSetings1 = new SfRatingSettings();
            sfRatingSetings1.RatedStroke = Color.ParseColor("#2095f2");
            sfRating = new SfRating(con);
            sfRating.ItemSize = 53;          
            sfRating.ItemSpacing = 33;
            sfRating.ItemCount = 5;
            sfRating.TooltipPrecision = 1;
            sfRating.Value = 3;
            sfRating.RatingSettings = sfRatingSetings1;
			sfRating.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(55 * con.Resources.DisplayMetrics.Density));
            padLayout.AddView(dummyLabel);
            padLayout.AddView(sfRating);
            pageLayout.AddView(padLayout);

            ValueLayout();
            ShowLabelLayout();

            return frame;
        }

        private void InitialLayout()
        {
            frame = new FrameLayout(con);
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;

            TypedValue tv = new TypedValue();
            if (con.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, con.Resources.DisplayMetrics);
            }
            navigationBarHeight = getNavigationBarHeight(con);
            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
            height = con.Resources.DisplayMetrics.HeightPixels / 2;
            width = con.Resources.DisplayMetrics.WidthPixels / 2;

            //pageLayout
            pageLayout = new LinearLayout(con);
            pageLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.7), GravityFlags.Top | GravityFlags.CenterHorizontal);
            pageLayout.Orientation = Android.Widget.Orientation.Vertical;
        }

        private void TitleLayout()
        {
            //title
            title = new TextView(con);
            title.TextSize = 25;
            title.SetTextColor(Color.ParseColor("#282828"));
            title.Text = "Movie Rating";
            title.SetPadding(30, 40, 0, 0);
            pageLayout.AddView(title);

            //columnLayout
            columnLayout = new LinearLayout(con);
            columnLayout.Orientation = Android.Widget.Orientation.Horizontal;
            columnLayout.SetPadding(0, 10, 0, 0);
        }

        private void ImageLayout()
        {
            //image Layout
            imageLayout = new LinearLayout(con);
            imageView = new ImageView(con);
            imageView.SetScaleType(ImageView.ScaleType.FitXy);
            imageView.SetImageResource(Resource.Drawable.movie);
            FrameLayout.LayoutParams layoutParams1 = new FrameLayout.LayoutParams(width, (height * 2) / 3, GravityFlags.Center);
            imageView.SetPadding(30, 10, 10, 0);
            imageLayout.AddView(imageView, layoutParams1);
            imageLayout.SetGravity(GravityFlags.Center);
           
            //Content Layout
            contentLayout = new LinearLayout(con);
            contentLayout.Orientation = Android.Widget.Orientation.Vertical;
            contentLayout.SetPadding(10, 5, 20, 0);
            movieLabel = new TextView(con);
            movieLabel.TextSize = 16;
            movieLabel.SetTextColor(Color.ParseColor("#282828"));
            movieLabel.Text = "The walk ( 2015 )";
            contentLayout.AddView(movieLabel);
            
            //Text Layout
            textLayout = new LinearLayout(con);
            textLayout.Orientation = Android.Widget.Orientation.Horizontal;
            textLayout.SetPadding(0, 5, 0, 0);
            time = new TextView(con);
            time.TextSize = 9;
            time.SetTextColor(Color.ParseColor("#282828"));
            time.Text = "PG | 2 h 20 min  ";
            textLayout.AddView(time);
        }

        private void DescriptionLayout()
        {
            //Description
            description = new TextView(con);
            descriptionLayout = new LinearLayout(con);
            descriptionLayout.SetPadding(0, 0, 0, 0);            
            description.TextSize = 10;         
            description.SetTextColor(Color.ParseColor("#282828"));
            description.SetLineSpacing(6, 1);
            description.Text = "In 1973, French street performer Philippe Petit is trying to make a living in Paris with juggling acts and wire walking, much to the chagrin of his father. During one performance, he eats a hard candy which was given to him by an audience member and injures his tooth. He visits the dentist and, while in the waiting room, sees a picture in a magazine of the Twin Towers in New York City. He analyzes the photo and decides to make it his mission to walk a tightrope between the two buildings. Meanwhile, he is evicted from his parents' house by his father, citing his lack of income and the fact that he's a street performer. Philippe returns to the circus that inspired him to wire walk as a child and practices in the big top after hours, but is caught by Papa Rudy, whom he impresses with his juggling skills. ";
            description.SetPadding(0, 0, 20, 0);
            descriptionLayout.AddView(description);
            contentLayout.AddView(descriptionLayout);
            contentLayout.LayoutParameters = new ViewGroup.LayoutParams(width, (height * 2) / 3);
            columnLayout.AddView(imageLayout);
            columnLayout.AddView(contentLayout);
            pageLayout.AddView(columnLayout);
            
            //Time Layout
            timeLayout = new LinearLayout(con);
            timeLayout.SetPadding(30, 35, 30, 0);
            FrameLayout.LayoutParams separatorparams = new FrameLayout.LayoutParams(width * 2, 2, GravityFlags.Center);
            SeparatorView separatorView = new SeparatorView(con, width * 2);
            separatorView.separatorColor = Color.ParseColor("#a5a5a5");
            timeLayout.AddView(separatorView, separatorparams);
            pageLayout.AddView(timeLayout);
            
            //Dummy Label
            dummyLabel2 = new TextView(con);
            dummyLabel2.TextSize = 15;
            dummyLabel2.SetPadding(30, 28, 0, 0);
            dummyLabel2.SetTextColor(Color.ParseColor("#282828"));
            dummyLabel2.Text = "Rate";
            pageLayout.AddView(dummyLabel2);

            //padLayout
            padLayout = new LinearLayout(con);
            padLayout.Orientation = Android.Widget.Orientation.Horizontal;
            dummyLabel = new TextView(con);
            dummyLabel.Text = "      ";
        }

        private void ValueLayout()
        {
            //Value Layout
            valueLayout = new LinearLayout(con);
            valueLayout.Orientation = Android.Widget.Orientation.Horizontal;
            valueLayout.SetPadding(30, 15, 0, 0);
            ratingLable = new TextView(con);
            ratingLable.TextSize = 10;
            ratingLable.SetTextColor(Color.ParseColor("#282828"));
            ratingLable.Text = "Rating :  ";
            valueLayout.AddView(ratingLable);
            
            //sfRating Value Changed Listener
            sfRating.ValueChanged += (object sender, ValueChangedEventArgs e) => {
				if (!e.Value.ToString().Equals(""))
                {
                    //valueString = e.P1.ToString ();
					UpdateText(e.Value);
                }
            };
        }

        private void ShowLabelLayout()
        {
            //Show Label
            showLable = new TextView(con);
            showLable.TextSize = 10;
            showLable.SetTextColor(Color.ParseColor("#282828"));
            UpdateText(sfRating.Value);
            valueLayout.AddView(showLable);
            pageLayout.AddView(valueLayout);

            //frame
            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.White);
            frame.SetPadding(10, 10, 10, 10);

            //scrollView1
            ScrollView scrollView1 = new ScrollView(con);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.7), GravityFlags.Top | GravityFlags.CenterHorizontal);
            scrollView1.AddView(pageLayout);
            frame.AddView(scrollView1);

            //buttomButtonLayout
            buttomButtonLayout = new FrameLayout(con);
            buttomButtonLayout.SetBackgroundColor(Color.Transparent);
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
            propertyFrameLayout.AddView(GetPropertyLayout(con));
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                propertyFrameLayout.AddView(GetPropertyLayout(con));
            };

            //scrollView
            ScrollView scrollView = new ScrollView(con);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.3), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            //frame
            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
        private void UpdateText(double rateValue)
        {
            int tempIntValue = (int)rateValue;
            float tempFloatValue = (float)rateValue;
            float diffenceValue = tempFloatValue - tempIntValue;
            String changeValue;
            if (diffenceValue == 0)
                changeValue = tempIntValue.ToString();
            else
            {
                String valueString = String.Format("{0:0.#}", tempFloatValue);
                changeValue = valueString;
            }
            showLable.Text = changeValue + " / " + sfRating.ItemCount;
        }
   
        //Apply Changes Method
        public void ApplyChanges()
        {
            sfRating.Precision = precisionPosition;
            sfRating.TooltipPlacement = toolTipPosition;
            sfRating.ItemCount = constCount;
            sfRating.Value = 3;
            if (sfRating.Value > constCount)
                sfRating.Value = 0;
            UpdateText(sfRating.Value);
            base.OnApplyChanges();
        }
      
        public View GetPropertyLayout(Context context1)
        {
            context = context1;
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);           

            InitialMethod();
            PrecisionLayout();
            TooltipLayout();
            ItemCountLayout();

            return propertylayout;
        }
        
        private void InitialMethod()
        {
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

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
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void PrecisionLayout()
        {
            //Precision
            TextView precisionLabel = new TextView(context);
            precisionLabel.TextSize = 15;
            precisionLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            precisionLabel.Text = "Precision";
           
            //Precision Spinner
            precisionSpinner = new Spinner(context,SpinnerMode.Dialog);
            precisionSpinner.SetGravity(GravityFlags.Left);
           
            //Precision List
            List<String> precisionList = new List<String>();
            precisionList.Add("Standard");
            precisionList.Add("Half");
            precisionList.Add("Exact");
           
            //precision Adapter
            precisionAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, precisionList);
            precisionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            
            //precisionSpinner ItemSelected Listener
            precisionSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = precisionAdapter.GetItem(e.Position);
                percisionPosition = e.Position;
                if (selectedItem.Equals("Standard"))
                {
                    precisionPosition = Precision.Standard;
                }
                if (selectedItem.Equals("Half"))
                {
                    precisionPosition = Precision.Half;
                }
                if (selectedItem.Equals("Exact"))
                {
                    precisionPosition = Precision.Exact;
                }
                ApplyChanges();
            };

            precisionSpinner.Adapter = precisionAdapter;
            precisionSpinner.SetSelection(percisionPosition);
            precisionSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            precisionSpinner.SetPadding(0, 0, 0, 20);

            //precisionLayout
            LinearLayout precisionLayout = new LinearLayout(context);
            precisionLayout.Orientation = Android.Widget.Orientation.Horizontal;
            precisionLayout.AddView(precisionLabel);
            precisionLayout.AddView(precisionSpinner);
            proprtyOptionsLayout.AddView(precisionLayout);
            
            //spaceText
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }

        private void TooltipLayout()
        {
            //ToolTip
            TextView tooltipLabel = new TextView(context);
            tooltipLabel.TextSize = 15;
            tooltipLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent);
            tooltipLabel.Text = "Tooltip Placement";
            LinearLayout.LayoutParams toollabelParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            toollabelParams.SetMargins(0, 10, 0, 0);
            
            //ToolTip Spinner
            toolTipSpinner = new Spinner(context,SpinnerMode.Dialog);
            toolTipSpinner.SetGravity(GravityFlags.Left);
            
            //Placement List
            List<String> placementList = new List<String>();
            placementList.Add("None");
            placementList.Add("TopLeft");
            placementList.Add("BottomRight");
          
            //Placement Adapter
            placementAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, placementList);
            placementAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
          
            //ToolTip Spinner Item Selected Listener
            toolTipSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = placementAdapter.GetItem(e.Position);
                toolTipSpinnerPosition = e.Position;
                if (selectedItem.Equals("None"))
                {
                    toolTipPosition = TooltipPlacement.None;
                }
                if (selectedItem.Equals("TopLeft"))
                {
                    toolTipPosition = TooltipPlacement.TopLeft;
                }
                if (selectedItem.Equals("BottomRight"))
                {
                    toolTipPosition = TooltipPlacement.BottomRight;
                }
                ApplyChanges();
            };
            toolTipSpinner.Adapter = placementAdapter;
            toolTipSpinner.SetSelection(toolTipSpinnerPosition);
            toolTipSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent);

            //toolTipLayout
            LinearLayout toolTipLayout = new LinearLayout(context);
            toolTipLayout.Orientation = Android.Widget.Orientation.Horizontal;
            toolTipLayout.AddView(tooltipLabel);
            toolTipLayout.AddView(toolTipSpinner);
            proprtyOptionsLayout.AddView(toolTipLayout);
           
            //spaceText
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);
        }
       
        private void ItemCountLayout()
        {
            //ItemCount
            TextView itemLabel = new TextView(context);
            itemLabel.Text = "Item Count";
            itemLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent);
            itemLabel.Gravity = GravityFlags.CenterVertical;
            itemLabel.TextSize = 15;
            itemCountEntry = new EditText(context);        
            itemCountEntry.Gravity = GravityFlags.Left;
            itemCountEntry.Text = itemCountPosition.ToString();
            itemCountEntry.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent);
            itemCountEntry.TextSize = 16;
            itemCountEntry.InputType = Android.Text.InputTypes.ClassPhone;
            itemCountEntry.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				if (itemCountEntry.Text.Length > 0)
					try
					{
						constCount = Convert.ToInt32(e.Text.ToString());
					}
					catch (Exception)
					{
						constCount = 1;
					}

                itemCountPosition = constCount;
                ApplyChanges();
            };
          
            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            //itemCountLayout
            LinearLayout itemCountLayout = new LinearLayout(context);
            itemCountLayout.Orientation = Android.Widget.Orientation.Horizontal;
            itemCountLayout.AddView(itemLabel);
            itemCountLayout.AddView(itemCountEntry);
            proprtyOptionsLayout.AddView(itemCountLayout);
            
            //spaceText
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 60, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText4);

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
                itemCountEntry.GetGlobalVisibleRect(outRect);

                if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY))
                {
                    itemCountEntry.ClearFocus();
                }
                hideSoftKeyboard((Activity)context);
            };

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



