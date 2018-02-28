#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Syncfusion.Android.PopupLayout;
using Android.Graphics.Drawables;
using System.Threading.Tasks;
using Android.Util;

namespace SampleBrowser
{
    public class PopupCustomizations : SamplePage
    {
        SfPopupLayout popup;
        FrameLayout mainView;
        List<TableItem> items;
        internal static ListView movieList;
        ListView theatreList;
        LinearLayout dateSelectionView;
        LinearLayout dateView;
        internal static RelativeLayout secondPage;
        TextView dayLabel;
        TextView dateLabel;
        Context cont;
        float density;

        public override View GetSampleContent(Context context)
        {
            cont = context;
            density = cont.Resources.DisplayMetrics.Density;
            CreateMainView();
            CreatePopup();
            CreateMovieSelectionPage();
            CreateDateSelectionPage();
            (context as FeaturesTabbedPage).ActionBar.CustomView.SetBackgroundColor(Color.DarkGray);
            (context as FeaturesTabbedPage).ActionBar.SetBackgroundDrawable(new ColorDrawable(Color.DarkGray));
            popup.IsOpen = true;
            TheaterAdapter.counter = 0;
            return popup;
        }

        private void CreateDateSelectionPage()
        {
            secondPage = new RelativeLayout(cont);
            LinearLayout secondPageContent = new LinearLayout(cont);
            secondPageContent.Orientation = Orientation.Vertical;
            secondPage.Id = 2;
            popup.IsOpen = false;
            TouchObserverView rel = new TouchObserverView(cont);
            rel.Alpha = 0.8f;
            rel.ViewAttachedToWindow += async delegate
            {
                for (int i = 0; i < 3; i++)
                {
                    if (TheaterAdapter.counter == 0)
                    {
                        popup.IsOpen = false;
                        rel.Visibility = ViewStates.Visible;
                        popup.PopupView.AnimationMode = AnimationMode.Zoom;
                        var image = new ImageView(cont);
                        image.SetImageResource(Resource.Drawable.Popup_DateSelected);
                        popup.PopupView.ShowHeader = false;
                        popup.PopupView.ShowFooter = false;
                        popup.PopupView.ContentView = image;
                        popup.PopupView.HeightRequest = 200;
                        popup.PopupView.WidthRequest = 200;
                        popup.PopupView.SetBackgroundColor(Color.Transparent);
                        popup.PopupView.SetBackgroundColor(Color.Transparent);
                        popup.PopupView.ContentView.SetBackgroundColor(Color.Transparent);
                        popup.PopupView.PopupStyle.BorderColor = Color.Transparent;
                        popup.Show((int)(10 * density), 0);
                        TheaterAdapter.counter++;
                        await Task.Delay(700);
                    }
                    else if (TheaterAdapter.counter == 1)
                    {
                        popup.IsOpen = false;
                        await Task.Delay(700);
                        rel.Visibility = ViewStates.Visible;                      
                        var image = new ImageView(cont);
                        popup.PopupView.AnimationMode = AnimationMode.SlideOnLeft;
                        image.SetImageResource(Resource.Drawable.Popup_TheatrInfo);
                        popup.PopupView.ContentView = image;
                        popup.Show((int)(cont.Resources.DisplayMetrics.WidthPixels - 40 * density), (int)(135 * density));
                        TheaterAdapter.counter++;
                        await Task.Delay(700);
                    }
                    else if (TheaterAdapter.counter == 2)
                    {
                        popup.IsOpen = false;
                        await Task.Delay(700);
                        rel.Visibility = ViewStates.Visible;                      
                        var image = new ImageView(cont);
                        popup.PopupView.AnimationMode = AnimationMode.SlideOnTop;
                        image.SetImageResource(Resource.Drawable.Popup_SelectSeats);
                        popup.PopupView.ContentView = image;
                        popup.Show((int)(10 * density), (int)(80 * density));
                        TheaterAdapter.counter++;
                        await Task.Delay(700);
                        rel.Visibility = ViewStates.Gone;
                        popup.StaysOpen = false;
                        popup.IsOpen = false;
                    }
                    if (TheaterAdapter.counter >= 4)
                    {
                        popup.StaysOpen = false;
                        popup.IsOpen = false;
                    }
                }
                popup.StaysOpen = false;
                rel.Visibility = ViewStates.Gone;
                popup.IsOpen = false;
                TheaterAdapter.counter = 0;
            };
            dateSelectionView = new LinearLayout(cont);
            dateSelectionView.Orientation = Orientation.Horizontal;
            dateSelectionView.AddView(CreateDateView(0, 0), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(1), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(2), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(3), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(4), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(5), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(6), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);

            theatreList = new ListView(cont);
            PopulateTheatreList();
            theatreList.Adapter = new TheaterAdapter((cont as FeaturesTabbedPage), items, popup, mainView);
            theatreList.ItemClick += MovieList_ItemClick;

            secondPageContent.AddView(dateSelectionView, ViewGroup.LayoutParams.MatchParent, (int)(62 * density));
            secondPageContent.AddView(theatreList, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            secondPage.AddView(secondPageContent, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            secondPage.AddView(rel, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            rel.SetBackgroundColor(Color.Black);
        }

        private void PopulateTheatreList()
        {
            items = new List<TableItem>();
            items.Add(new TableItem() { Heading = "ABC Cinemas Dolby Atmos", SubHeading = "No.15, 12th Main Road, Sector 1", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="10:00 AM",Timing2="4:00 PM" });
            items.Add(new TableItem() { Heading = "XYZ Theater 4K Dolby Atmos", SubHeading = "No.275, 3rd Cross Road,Area 27", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="11:00 AM",Timing2="6:00 PM" });
            items.Add(new TableItem() { Heading = "QWERTY Theater", SubHeading = "No.275, 3rd Cross Road,Sector North", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="10:30 AM"});
            items.Add(new TableItem() { Heading = "FYI Cinemas 4K", SubHeading = "No.15, 12th Main Road,Sector South", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="3:00 PM" ,});
            items.Add(new TableItem() { Heading = "The Cinemas Dolby Digital", SubHeading = "No.275, 3rd Cross Road,Layout 71", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="2:30 PM" ,Timing2="9:00 PM"});
            items.Add(new TableItem() { Heading = "SF Theater Dolby Atmos RDX", SubHeading = "North West Layout", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="1:30 PM" ,Timing2="6:00 PM"});
            items.Add(new TableItem() { Heading = "Grid Cinemas 4K Dolby Atmos", SubHeading = "No.15, 12th Main Road,Area 33", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="3:30 PM"});
            items.Add(new TableItem() { Heading = "Grand Theater", SubHeading = "No.275, 3rd Cross Road,South Sector", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="6:00 PM"});
            items.Add(new TableItem() { Heading = "Layout Cinemas Dolby Atmos RDX", SubHeading = "No.15, 12th Main Road,Area 152", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="6:00 PM" ,Timing2="10:30 PM"});
            items.Add(new TableItem() { Heading = "Xamarin Cinemas Dolby Atmos RDX", SubHeading = "No.275, 3rd Cross Road,Sector 77", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="2:30 PM" ,Timing2="6:30 PM" });
        }

        private LinearLayout CreateDateView(int date, object selected = null)
        {
            dateView = new LinearLayout(cont);
            if (selected == null)
                dateView.SetBackgroundColor(Color.White);
            else
                dateView.SetBackgroundColor(Color.ParseColor("#007CEE"));
            dateView.Click += DateView_Click;
            dateView.Orientation = Orientation.Vertical;

            dayLabel = new TextView(cont);
            dayLabel.SetBackgroundColor(Color.Transparent);
            dayLabel.Text = DateTime.Now.AddDays(date).DayOfWeek.ToString().Substring(0, 3).ToUpper();
            if (selected == null)
                dayLabel.SetTextColor(Color.Argb(54, 00, 00, 00));
            else
                dayLabel.SetTextColor(Color.White);
            dayLabel.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
            dayLabel.SetTextSize(Android.Util.ComplexUnitType.Dip, 12);
            dayLabel.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;

            dateLabel = new TextView(cont);
            dateLabel.SetBackgroundColor(Color.Transparent);
            dateLabel.Text = DateTime.Now.AddDays(date).Day.ToString();
            dateLabel.TextAlignment = TextAlignment.Center;
            if (selected == null)
                dateLabel.SetTextColor(Color.Black);
            else
                dateLabel.SetTextColor(Color.White);
            dateLabel.SetTextSize(Android.Util.ComplexUnitType.Dip, 14);
            dateLabel.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
            dateLabel.Gravity = GravityFlags.CenterHorizontal;

            dateView.AddView(dayLabel, ViewGroup.LayoutParams.MatchParent, (int)(31 * density));
            dateView.AddView(dateLabel, ViewGroup.LayoutParams.MatchParent, (int)(31 * density));
            return dateView;
        }

        private void DateView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ((sender as LinearLayout).Parent as LinearLayout).ChildCount; i++)
            {
                // Remove selection color to other date views
                (((sender as LinearLayout).Parent as LinearLayout).GetChildAt(i) as LinearLayout).SetBackgroundColor(Color.White);
                ((((sender as LinearLayout).Parent as LinearLayout).GetChildAt(i) as LinearLayout).GetChildAt(0) as TextView).SetTextColor(Color.Argb(54, 00, 00, 00));
                ((((sender as LinearLayout).Parent as LinearLayout).GetChildAt(i) as LinearLayout).GetChildAt(1) as TextView).SetTextColor(Color.Black);
            }
            ((sender as LinearLayout).GetChildAt(0) as TextView).SetTextColor(Color.White);
            ((sender as LinearLayout).GetChildAt(1) as TextView).SetTextColor(Color.White);
            (sender as LinearLayout).SetBackgroundColor(Color.ParseColor("#007CEE"));
        }

        private void CreateMovieSelectionPage()
        {
            movieList = new ListView(cont);
            movieList.Id = 1;
            PopulateMovieList();
            movieList.Adapter = new MovieAdapter((cont as FeaturesTabbedPage), items, mainView,popup);
            movieList.ItemClick += MovieList_ItemClick;
            mainView.AddView(movieList);
        }

        private void CreateMainView()
        {
            mainView = new FrameLayout(cont);
        }

        private void PopulateMovieList()
        {
            items = new List<TableItem>();
            items.Add(new TableItem() { Heading = "Longest Run", SubHeading = "Liam Kneeson | Dean Kruger", ImageResourceId = Resource.Drawable.Popup_Movie1 });
            items.Add(new TableItem() { Heading = "AA-Team", SubHeading = "Dirk Benedict | Liam Kneeson", ImageResourceId = Resource.Drawable.Popup_Movie2});
            items.Add(new TableItem() { Heading = "Configuring 2", SubHeading = "Vera Farmigan | Pat Wilson", ImageResourceId = Resource.Drawable.Popup_Movie3});
            items.Add(new TableItem() { Heading = "Inside Us 2", SubHeading = "Pat Wilson | Rose Bryane", ImageResourceId = Resource.Drawable.Popup_Movie4});
            items.Add(new TableItem() { Heading = "Safer House", SubHeading = "Regan Reynolds | Denzol Washington", ImageResourceId = Resource.Drawable.Popup_Movie5});
            items.Add(new TableItem() { Heading = "Run All Day", SubHeading = "Liam Kneeson | Jeniffer Rodriguez", ImageResourceId = Resource.Drawable.Popup_Movie6});
            items.Add(new TableItem() { Heading = "Code Red", SubHeading = "Jake Gylle | Michelle Manhatan", ImageResourceId = Resource.Drawable.Popup_Movie7});
            items.Add(new TableItem() { Heading = "Clash Of The Dragons", SubHeading = "Gemma Verteron | Sam Worthonn", ImageResourceId = Resource.Drawable.Popup_Movie8});
            items.Add(new TableItem() { Heading = "A Run Among The TombStones", SubHeading = "Liam Kneeson | Daniel Stevens", ImageResourceId = Resource.Drawable.Popup_Movie9});
            items.Add(new TableItem() { Heading = "Error 404", SubHeading = "Liam Kneeson | Dene Kruger", ImageResourceId = Resource.Drawable.Popup_Movie10});
        }

        private void MovieList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var backbutton = ((((this.cont as FeaturesTabbedPage).SettingsButton.Parent as RelativeLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as RelativeLayout).GetChildAt(0);
            backbutton.Click += backbutton_Click;
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            var child = this.mainView.GetChildAt(0);
            if (child.Id == 2)
            {
                this.mainView.RemoveView(child);
                if (this.mainView.IndexOfChild(PopupCustomizations.movieList) == -1)
                    this.mainView.AddView(movieList);
            }
        }

        internal void CreatePopup()
        {
            popup = new SfPopupLayout(cont);
            popup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            popup.Content = mainView;
            popup.PopupView.ShowFooter = true;
            popup.PopupView.ShowCloseButton = false;
            popup.PopupView.HeaderTitle = "Book tickets !";
            popup.PopupView.PopupStyle.HeaderTextSize = 18;
            popup.StaysOpen = true;
            TextView messageView = new TextView(this.cont);
            messageView.Text = "Click on the book button to start booking tickets";
            messageView.SetTextColor(Color.Black);
            messageView.SetBackgroundColor(Color.White);
            messageView.TextSize = 16;
            popup.PopupView.ContentView = messageView;
            popup.PopupView.ContentView.SetPadding((int)(10 * cont.Resources.DisplayMetrics.Density), 0, 0, 0);
            popup.PopupView.AcceptButtonText = "OK";
            //popup.PopupView.PopupStyle.BorderColor = Color.Gray;
           //popup.PopupView.PopupStyle.BorderThickness = 1;
            popup.PopupView.PopupStyle.CornerRadius = 3;
            popup.PopupView.HeightRequest = 200;
        }
    }

    internal class TouchObserverView : View
    {
        public TouchObserverView(Context context) : base(context)
        {
        }

        public TouchObserverView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public TouchObserverView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public TouchObserverView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected TouchObserverView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return true;
        }
    }
}