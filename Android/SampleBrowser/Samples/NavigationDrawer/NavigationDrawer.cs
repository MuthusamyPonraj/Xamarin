#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Android.Util;


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
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    [Activity(Label = "NavigationDrawer")]
    public class NavigationDrawer : SamplePage
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        LinearLayout inboxLayout, mail1, mail2, mail3, mail4, mail9, mail10, mail11;
        LinearLayout.LayoutParams layoutParams5, layoutParams;
        SeparatorView labelSeparator4, labelSeparator3, labelSeparator5;
        SeparatorView labelSeparator6, labelSeparator7, labelSeparator8, labelSeparator9;
        LinearLayout outboxlayout, mail12, mail13, mail14, mail15, mail16, mail17;
        LinearLayout mail5, mail6, profilelayout, linear2;
        SeparatorView labelSeparator10, labelSeparator11, labelSeparator12, labelSeparator13;
        SeparatorView labelSeparator14, labelSeparator15, labelSeparator16, labelSeparator17;
        Button iconbutton;
        ListView viewItem;
        SfNavigationDrawer slideDrawer;
        LinearLayout propertylayout;
        ArrayAdapter<String> dataAdapter, dataAdapter1, arrayAdapter;
        Spinner positionSpinner, animationSpinner;
        Position sliderposition = Position.Left;
        Transition sliderTransition = Transition.SlideOnTop;
        Context context;
        int height, width;
        double actionBarHeight;   
        TextView profileContentLabel;       
        FrameLayout ContentFrame;
        ScrollView textScroller;              

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
            slideDrawer.Position = sliderposition;
            slideDrawer.Transition = sliderTransition;
        }
       
        public override View GetPropertyWindowLayout(Context context)
        {          
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
            layoutParams = new LinearLayout.LayoutParams(width * 2, 3);
            layoutParams.SetMargins(0, 20, 0, 0);

            positionLabelLayout();
            AnimationLayout();

            return propertylayout;
        }

        private void positionLabelLayout()
        {
            //cultureLabel
            TextView cultureLabel = new TextView(context);
            cultureLabel.TextSize = 20;
            cultureLabel.Text = "Position";
           
            //positionlist
            List<String> positionlist = new List<String>();
            positionlist.Add("Left");
            positionlist.Add("Right");
            positionlist.Add("Top");
            positionlist.Add("Bottom");

            //dataAdapter
            dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, positionlist);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //positionSpinner
            positionSpinner = new Spinner(context,SpinnerMode.Dialog);
            positionSpinner.SetGravity(GravityFlags.Left);
            positionSpinner.Adapter = dataAdapter;
            positionSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Left"))
                {
                    sliderposition = Position.Left;
                }
                if (selectedItem.Equals("Right"))
                {
                    sliderposition = Position.Right;
                }
                if (selectedItem.Equals("Top"))
                {
                    sliderposition = Position.Top;
                }
                if (selectedItem.Equals("Bottom"))
                {
                    sliderposition = Position.Bottom;
                }
            };

            propertylayout.AddView(cultureLabel);
            propertylayout.AddView(positionSpinner);

            //labelSeparator
            SeparatorView labelSeparator = new SeparatorView(context, width * 2);
            labelSeparator.separatorColor = Color.LightGray;
            labelSeparator.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);
            //propertylayout.AddView(labelSeparator, layoutParams);
        }

        private void AnimationLayout()
        {
            //cultureLabel1
            TextView cultureLabel1 = new TextView(context);
            cultureLabel1.TextSize = 20;
            cultureLabel1.Text = "Animations";           

            //transitionlist
            List<String> transitionlist = new List<String>();
            transitionlist.Add("SlideOnTop");
            transitionlist.Add("Reveal");
            transitionlist.Add("Push");

            //dataAdapter1
            dataAdapter1 = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, transitionlist);
            dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem); ;

            //animationSpinner
            animationSpinner = new Spinner(context,SpinnerMode.Dialog);
            animationSpinner.SetGravity(GravityFlags.Left);
            animationSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter1.GetItem(e.Position);
                if (selectedItem.Equals("SlideOnTop"))
                {
                    sliderTransition = Transition.SlideOnTop;
                }
                if (selectedItem.Equals("Reveal"))
                {
                    sliderTransition = Transition.Reveal;
                }
                if (selectedItem.Equals("Push"))
                {
                    sliderTransition = Transition.Push;
                }
            };

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);

            animationSpinner.Adapter = dataAdapter1;
            propertylayout.AddView(cultureLabel1);
            propertylayout.AddView(animationSpinner);

            //labelSeparator1
            SeparatorView labelSeparator1 = new SeparatorView(context, width * 2);
            labelSeparator1.separatorColor = Color.LightGray;
            labelSeparator1.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);
            //propertylayout.AddView(labelSeparator1, layoutParams);

            propertylayout.SetPadding(5, 0, 5, 0);
        }
      
        public override View GetSampleContent(Context context1)
        {
            context = context1;
            IconButtonLayout();
            HomeContentLayout();
            MainContentLayout();          
            ProfileContentLayout();
            InboxContentLayout();
            OutBoxLayout();
            ClickListenerLayout();

            return slideDrawer;
        }

        private void IconButtonLayout()
        {
            //iconbutton
            iconbutton = new Button(context);
            iconbutton.SetBackgroundResource(Resource.Drawable.burgericon);
            FrameLayout.LayoutParams btlayoutParams = new FrameLayout.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_btn_wt), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_btn_ht), GravityFlags.Center);
            iconbutton.LayoutParameters = btlayoutParams;
            iconbutton.SetPadding(10, 0, 0, 0);
            if (context.Resources.DisplayMetrics.Density > 1.5)
            {
                iconbutton.SetX(10);
            }
            iconbutton.Gravity = GravityFlags.CenterVertical;
        }
       
        private void HomeContentLayout()
        {
            //HomeLabel
            profileContentLabel = new TextView(context);
            profileContentLabel.TextSize = 20;
            profileContentLabel.Text = "Home";
            profileContentLabel.SetTextColor(Color.White);
            profileContentLabel.Gravity = GravityFlags.Center;

            //linearLayout
            LinearLayout linearLayout = new LinearLayout(context);
            FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, getDimensionPixelSize(context, Resource.Dimension.nav_drawer_header_ht), GravityFlags.Center);
            layoutParams.SetMargins(10, 0, 0, 0);
            linearLayout.SetPadding(10, 0, 0, 0);
            linearLayout.AddView(iconbutton);
            linearLayout.AddView(profileContentLabel, layoutParams);
            linearLayout.SetBackgroundColor(Color.Rgb(47, 173, 227));

            TypedValue tv = new TypedValue();
            if (context.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, context.Resources.DisplayMetrics);
            }
            height = Convert.ToInt32(context.Resources.DisplayMetrics.HeightPixels - actionBarHeight);
            width = context.Resources.DisplayMetrics.WidthPixels;

            //linear2
            linear2 = new LinearLayout(context);
            linear2.Orientation = Orientation.Vertical;
            linear2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            FrameLayout.LayoutParams layout2 = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            linear2.AddView(linearLayout, layout2);
        }
       
        private void MainContentLayout()
        {
            //textScroller
            textScroller = new ScrollView(context);
            textScroller.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            //textView
            TextView textView = new TextView(context);
            textView.Text = "\n \t Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus. Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet. Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula. Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.";
            textView.TextSize = 16;
            textView.SetPadding(20, 0, 20, 0);
            textScroller.AddView(textView);
            ContentFrame = new FrameLayout(context);
            ContentFrame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height - actionBarHeight));
            ContentFrame.SetBackgroundColor(Color.White);
            ContentFrame.AddView(textScroller);
            textScroller.SetBackgroundColor(Color.White);
            linear2.AddView(ContentFrame);

            //contentLayout
            LinearLayout contentLayout = new LinearLayout(context);
            RoundedImageView roundedImg = new RoundedImageView(context, getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size));
            roundedImg.SetPadding(0, 10, 0, 10);
            roundedImg.SetImageResource(Resource.Drawable.user);
            LinearLayout.LayoutParams layparams8 = new LinearLayout.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size));
            layparams8.Gravity = GravityFlags.Center;
            roundedImg.LayoutParameters = new ViewGroup.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size));

            //userNameLabel1
            TextView userNameLabel1 = new TextView(context);
            userNameLabel1.Text = "James Pollock";
            userNameLabel1.Gravity = GravityFlags.Center;
            userNameLabel1.TextSize = 17;
            userNameLabel1.SetTextColor(Color.White);
            userNameLabel1.SetPadding(0, 20, 0, 0);
            userNameLabel1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

            //headerLayout
            LinearLayout headerLayout = new LinearLayout(context);
            headerLayout.Orientation = Orientation.Vertical;
            headerLayout.SetBackgroundColor(Color.Rgb(47, 173, 227));
            headerLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, getDimensionPixelSize(context, Resource.Dimension.nav_drawer_slider_ht));
            headerLayout.SetGravity(GravityFlags.Center);
            headerLayout.AddView(roundedImg, layparams8);
            headerLayout.AddView(userNameLabel1);
            LinearLayout.LayoutParams layparams2 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height * 0.15));
            layparams2.Gravity = GravityFlags.Center;
            contentLayout.AddView(headerLayout);
            LinearLayout.LayoutParams layparams5 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (2));
            contentLayout.AddView(new SeparatorView(context, width) { separatorColor = Color.LightGray }, layparams5);
            contentLayout.SetBackgroundColor(Color.White);
            linear2.SetBackgroundColor(Color.White);

            //slideDrawer
            slideDrawer = new Com.Syncfusion.Navigationdrawer.SfNavigationDrawer(context);
            slideDrawer.ContentView = linear2;
            slideDrawer.DrawerWidth = (float)(200);
            slideDrawer.DrawerHeight = (float)(300);
            slideDrawer.Transition = Transition.SlideOnTop;
            slideDrawer.TouchThreshold = 90;
            slideDrawer.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            viewItem = new ListView(context);
            viewItem.VerticalScrollBarEnabled = true;
            iconbutton.Click += (object sender, EventArgs e) => {
                slideDrawer.ToggleDrawer();
            };

            //positionlist
            List<String> positionlist = new List<String>();
            positionlist.Add("Home");
            positionlist.Add("Profile");
            positionlist.Add("Inbox");
            positionlist.Add("Outbox");
            positionlist.Add("Sent Items");
            positionlist.Add("Trash");

            arrayAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleListItem1, positionlist);
            viewItem.Adapter = arrayAdapter;
            viewItem.SetBackgroundColor(Color.White);
            viewItem.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            contentLayout.AddView(viewItem);
            contentLayout.Orientation = Orientation.Vertical;

            //frameLayout
            FrameLayout frameLayout = new FrameLayout(context);
            frameLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frameLayout.SetBackgroundColor(Color.White);
            frameLayout.AddView(contentLayout);
            slideDrawer.DrawerContentView = frameLayout;
        }
       
        private void ProfileContentLayout()
        {
            //profilelayout
            profilelayout = new LinearLayout(context);
            profilelayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            profilelayout.Orientation = Orientation.Vertical;
            LinearLayout linearLayout2 = new LinearLayout(context);
            linearLayout2.SetGravity(GravityFlags.Center);
            linearLayout2.SetPadding(0, 30, 0, 30);
            linearLayout2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            RoundedImageView roundedImg1 = new RoundedImageView(context, getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht));
            roundedImg1.LayoutParameters = new ViewGroup.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht));
            roundedImg1.SetImageResource(Resource.Drawable.user);
            LinearLayout txtlayout = new LinearLayout(context);
            txtlayout.SetPadding(40, 0, 0, 0);
            txtlayout.Orientation = Orientation.Vertical;

            //userNameLabel2
            TextView userNameLabel2 = new TextView(context);
            userNameLabel2.TextSize = 20;
            userNameLabel2.Text = "JamesPollock";
            userNameLabel2.SetTextColor(Color.Black);

            //userAgeLabel
            TextView userAgeLabel = new TextView(context);
            userAgeLabel.Text = "Age 30";
            userAgeLabel.TextSize = 13;
            userAgeLabel.SetTextColor(Color.Black);

            //txtlayout
            txtlayout.AddView(userNameLabel2);
            txtlayout.AddView(userAgeLabel);
            linearLayout2.AddView(roundedImg1);
            linearLayout2.AddView(txtlayout);
            linearLayout2.SetBackgroundColor(Color.White);
            profilelayout.AddView(linearLayout2);
            profilelayout.Orientation = Orientation.Vertical;

            //separatorparams
            FrameLayout.LayoutParams separatorparams = new FrameLayout.LayoutParams(width, 2, GravityFlags.Center);
            SeparatorView labelSeparator2 = new SeparatorView(context, width);
            labelSeparator2.separatorColor = Color.LightGray;
            labelSeparator2.SetPadding(20, 0, 20, 20);
            profilelayout.AddView(labelSeparator2, separatorparams);

            //profiledescriptionLabel
            TextView profiledescriptionLabel = new TextView(context);
            profiledescriptionLabel.TextSize = 16;
            profiledescriptionLabel.SetPadding(20, 0, 20, 0);
            profiledescriptionLabel.SetBackgroundColor(Color.White);
            profiledescriptionLabel.Text = "\n" +
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
                "\n" + "\n" + "when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
                "\n" + "\n" + "James Pollock";
            profilelayout.AddView(profiledescriptionLabel);
            profilelayout.SetBackgroundColor(Color.White);
        }

        
        private void InboxContentLayout()
        {
            //inboxLayout
            inboxLayout = new LinearLayout(context);
            inboxLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            inboxLayout.SetBackgroundColor(Color.White);
            inboxLayout.Orientation = Orientation.Vertical;
            mail1 = new LinearLayout(context);

            //userNameLabel3
            TextView userNameLabel3 = new TextView(context);
            userNameLabel3.Text = "John";
            userNameLabel3.TextSize = 18;
            TextView updateLabel1 = new TextView(context);
            updateLabel1.Text = "Update on Timeline";
            updateLabel1.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel1.TextSize = 16;
            TextView messageLabel1 = new TextView(context);
            messageLabel1.Text = "Hi John, See you at 10AM";

            //labelSeparator3
            labelSeparator3 = new SeparatorView(context, width * 2);
            labelSeparator3.separatorColor = Color.LightGray;
            labelSeparator3.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);

            //layoutParams5
            layoutParams5 = new LinearLayout.LayoutParams(width * 2, 3);
            layoutParams5.SetMargins(0, 10, 15, 0);
            messageLabel1.TextSize = 13;
            mail1.AddView(userNameLabel3);
            mail1.AddView(messageLabel1);

            //mail2
            mail2 = new LinearLayout(context);
            TextView userNameLabel4 = new TextView(context);
            userNameLabel4.Text = "Caster";
            userNameLabel4.TextSize = 18;
            TextView updateLabel2 = new TextView(context);
            updateLabel2.Text = "Update on Timeline";
            updateLabel2.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel2.TextSize = 16;
            TextView messageLabel2 = new TextView(context);
            messageLabel2.Text = "Hi Caster, See you at 11AM";
            messageLabel2.TextSize = 13;
            mail2.AddView(userNameLabel4);
            mail2.AddView(messageLabel2);
            labelSeparator4 = new SeparatorView(context, width * 2);
            labelSeparator4.separatorColor = Color.LightGray;
            labelSeparator4.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail3
            mail3 = new LinearLayout(context);
            TextView userNameLabel5 = new TextView(context);
            userNameLabel5.Text = "Joey";
            userNameLabel5.TextSize = 18;
            TextView updateLabel3 = new TextView(context);
            updateLabel3.Text = "Update on Timeline";
            updateLabel3.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel3.TextSize = 16;
            TextView messageLabel3 = new TextView(context);
            messageLabel3.Text = "Hi Joey, See you at 1PM";
            messageLabel3.TextSize = 13;
            mail3.AddView(userNameLabel5);
            mail3.AddView(messageLabel3);
            labelSeparator5 = new SeparatorView(context, width * 2);
            labelSeparator5.separatorColor = Color.LightGray;
            labelSeparator5.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail4
            mail4 = new LinearLayout(context);
            TextView userNameLabel6 = new TextView(context);
            userNameLabel6.Text = "Xavier";
            userNameLabel6.TextSize = 18;
            TextView updateLabel4 = new TextView(context);
            updateLabel4.Text = "Update on Timeline";
            updateLabel4.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel4.TextSize = 16;
            TextView messageLabel4 = new TextView(context);
            messageLabel4.Text = "Hi Xavier, See you at 2PM";
            messageLabel4.TextSize = 13;
            mail4.AddView(userNameLabel6);
            mail4.AddView(messageLabel4);
            labelSeparator6 = new SeparatorView(context, width * 2);
            labelSeparator6.separatorColor = Color.LightGray;
            labelSeparator6.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail9
            mail9 = new LinearLayout(context);
            TextView userNameLabel7 = new TextView(context);
            userNameLabel7.Text = "Gonzalez";
            userNameLabel7.TextSize = 18;
            TextView updateLabel5 = new TextView(context);
            updateLabel5.Text = "Update on Timeline";
            updateLabel5.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel5.TextSize = 16;
            TextView messageLabel5 = new TextView(context);
            messageLabel5.Text = "Hi Gonzalez, See you at 3PM";
            messageLabel5.TextSize = 13;
            mail9.AddView(userNameLabel7);
            mail9.AddView(messageLabel5);
            labelSeparator7 = new SeparatorView(context, width * 2);
            labelSeparator7.separatorColor = Color.LightGray;
            labelSeparator7.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail10
            mail10 = new LinearLayout(context);
            TextView userNameLabel8 = new TextView(context);
            userNameLabel8.Text = "Rodriguez";
            userNameLabel8.TextSize = 18;
            TextView updateLabel6 = new TextView(context);
            updateLabel6.Text = "Update on Timeline";
            updateLabel6.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel6.TextSize = 16;
            TextView messageLabel6 = new TextView(context);
            messageLabel6.Text = "Hi Rodriguez, See you at 4PM";
            messageLabel6.TextSize = 13;
            mail10.AddView(userNameLabel8);
            mail10.AddView(messageLabel6);
            labelSeparator8 = new SeparatorView(context, width * 2);
            labelSeparator8.separatorColor = Color.LightGray;
            labelSeparator8.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail11
            mail11 = new LinearLayout(context);
            TextView userNameLabel9 = new TextView(context);
            userNameLabel9.Text = "Ruben";
            userNameLabel9.TextSize = 18;
            TextView updateLabel7 = new TextView(context);
            updateLabel7.Text = "Update on Timeline";
            updateLabel7.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel7.TextSize = 16;
            TextView messageLabel7 = new TextView(context);
            messageLabel7.Text = "Hi Ruben, See you at 6PM";
            messageLabel7.TextSize = 13;
            mail11.AddView(userNameLabel9);
            mail11.AddView(messageLabel7);
            labelSeparator9 = new SeparatorView(context, width * 2);
            labelSeparator9.separatorColor = Color.LightGray;
            labelSeparator9.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail Orientation 
            mail1.Orientation = Orientation.Vertical;
            mail2.Orientation = Orientation.Vertical;
            mail3.Orientation = Orientation.Vertical;
            mail4.Orientation = Orientation.Vertical;
            mail9.Orientation = Orientation.Vertical;
            mail10.Orientation = Orientation.Vertical;
            mail11.Orientation = Orientation.Vertical;

            //mail LayoutParameters
            mail1.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail1.SetPadding(20, 10, 10, 5);
            mail2.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail2.SetPadding(20, 10, 10, 5);
            mail3.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail3.SetPadding(20, 10, 10, 5);
            mail4.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail4.SetPadding(20, 10, 10, 5);
            mail9.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail9.SetPadding(20, 10, 10, 5);
            mail10.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail10.SetPadding(20, 10, 10, 5);
            mail11.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail11.SetPadding(20, 10, 10, 5);

            //inboxview
            inboxLayout.SetPadding(20, 0, 20, 20);
            inboxLayout.AddView(mail1);
            inboxLayout.AddView(labelSeparator3, layoutParams5);
            inboxLayout.AddView(mail2);
            inboxLayout.AddView(labelSeparator4, layoutParams5);
            inboxLayout.AddView(mail3);
            inboxLayout.AddView(labelSeparator5, layoutParams5);
            inboxLayout.AddView(mail4);
            inboxLayout.AddView(labelSeparator6, layoutParams5);
            inboxLayout.AddView(mail9);
            inboxLayout.AddView(labelSeparator7, layoutParams5);
            inboxLayout.AddView(mail10);
            inboxLayout.AddView(labelSeparator9, layoutParams5);
            inboxLayout.AddView(mail11);
            inboxLayout.AddView(labelSeparator8, layoutParams5);
        }
       
        private void OutBoxLayout()
        {
            //outboxlayout
            outboxlayout = new LinearLayout(context);
            outboxlayout.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            outboxlayout.SetBackgroundColor(Color.White);
            outboxlayout.Orientation = (Orientation.Vertical);

            //mail5
            mail5 = new LinearLayout(context);
            TextView userNameLabel10 = new TextView(context);
            userNameLabel10.Text = "Ruben";
            userNameLabel10.TextSize = 20;
            TextView updateLabel8 = new TextView(context);
            updateLabel8.Text = "Update on Timeline";
            updateLabel8.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel8.TextSize = 16;
            TextView messageLabel8 = new TextView(context);
            messageLabel8.Text = "Hi Ruben, see you at 6PM";
            labelSeparator10 = new SeparatorView(context, width * 2);
            labelSeparator10.separatorColor = Color.LightGray;
            labelSeparator10.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            messageLabel8.TextSize = 13;
            mail5.AddView(userNameLabel10);
            mail5.AddView(messageLabel8);

            //mail6
            mail6 = new LinearLayout(context);
            TextView userNameLabel11 = new TextView(context);
            userNameLabel11.Text = "Rodriguez";
            userNameLabel11.TextSize = 20;
            TextView updateLabel9 = new TextView(context);
            updateLabel9.Text = "Update on Timeline";
            updateLabel9.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel9.TextSize = 16;
            TextView messageLabel9 = new TextView(context);
            messageLabel9.Text = "Hi Rodriguez, see you at 4PM";
            messageLabel9.TextSize = 13;
            mail6.AddView(userNameLabel11);
            mail6.AddView(messageLabel9);

            //mail12
            mail12 = new LinearLayout(context);
            TextView userNameLabel12 = new TextView(context);
            userNameLabel12.Text = "Gonzalez";
            userNameLabel12.TextSize = 20;
            TextView updateLabel10 = new TextView(context);
            updateLabel10.Text = "Update on Timeline";
            updateLabel10.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel10.TextSize = 16;
            TextView messageLabel10 = new TextView(context);
            messageLabel10.Text = "Hi Gonzalez, see you at 3PM";
            mail12.AddView(userNameLabel12);
            mail12.AddView(messageLabel10);
            labelSeparator11 = new SeparatorView(context, width * 2);
            labelSeparator11.separatorColor = Color.LightGray;
            labelSeparator11.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));          
            mail12.Orientation = Orientation.Vertical;
            mail12.Orientation = (Orientation.Vertical);
            mail5.Orientation = Orientation.Vertical;
            mail6.Orientation = Orientation.Vertical;

            //mail13
            mail13 = new LinearLayout(context);
            TextView userNameLabel13 = new TextView(context);
            userNameLabel13.Text = "Xavier";
            userNameLabel13.TextSize = 20;
            TextView updateLabel11 = new TextView(context);
            updateLabel11.Text = "Update on Timeline";
            updateLabel11.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel11.TextSize = 16;
            TextView messageLabel11 = new TextView(context);
            messageLabel11.Text = "Hi Xavier, see you at 2PM";
            labelSeparator12 = new SeparatorView(context, width * 2);
            labelSeparator12.separatorColor = Color.LightGray;
            labelSeparator12.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail13.AddView(userNameLabel13);
            mail13.AddView(messageLabel11);
            mail13.Orientation = (Orientation.Vertical);
            mail13.Orientation = (Orientation.Vertical);

            //mail14
            mail14 = new LinearLayout(context);
            TextView userNameLabel14 = new TextView(context);
            userNameLabel14.Text = "Joey";
            userNameLabel14.TextSize = 20;
            TextView updateLabel12 = new TextView(context);
            updateLabel12.Text = "Update on Timeline";
            updateLabel12.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel12.TextSize = 16;
            TextView messageLabel12 = new TextView(context);
            messageLabel12.Text = "Hi Joey, see you at 1PM";
            labelSeparator13 = new SeparatorView(context, width * 2);
            labelSeparator13.separatorColor = Color.LightGray;
            labelSeparator13.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail14.AddView(userNameLabel14);
            mail14.AddView(messageLabel12);
            mail14.Orientation = (Orientation.Vertical);
            mail14.Orientation = (Orientation.Vertical);

            //mail15
            mail15 = new LinearLayout(context);
            TextView userNameLabel15 = new TextView(context);
            userNameLabel15.Text = "Joey";
            userNameLabel15.TextSize = 20;
            TextView updateLabel13 = new TextView(context);
            updateLabel13.Text = "Update on Timeline";
            updateLabel13.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel13.TextSize = 16;
            TextView messageLabel13 = new TextView(context);
            messageLabel13.Text = "Hi Joey, see you at 1PM";
            labelSeparator14 = new SeparatorView(context, width * 2);
            labelSeparator14.separatorColor = Color.LightGray;
            labelSeparator14.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail15.AddView(userNameLabel15);
            mail15.AddView(messageLabel13);
            mail15.Orientation = (Orientation.Vertical);
            mail15.Orientation = (Orientation.Vertical);

            //mail16
            mail16 = new LinearLayout(context);
            TextView userNameLabel16 = new TextView(context);
            userNameLabel16.Text = ("Caster");
            userNameLabel16.TextSize = (20);
            TextView updateLabel14 = new TextView(context);
            updateLabel14.Text = ("Update on Timeline");
            updateLabel14.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel14.TextSize = (16);
            TextView messageLabel14 = new TextView(context);
            messageLabel14.Text = ("Hi Caster, see you at 11PM");
            labelSeparator15 = new SeparatorView(context, width * 2);
            labelSeparator15.separatorColor = Color.LightGray;
            labelSeparator15.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail16.AddView(userNameLabel16);
            mail16.AddView(messageLabel14);
            mail16.Orientation = (Orientation.Vertical);
            mail16.Orientation = (Orientation.Vertical);

            //mail17
            mail17 = new LinearLayout(context);
            TextView userNameLabel17 = new TextView(context);
            userNameLabel17.Text = "john";
            userNameLabel17.TextSize = 20;
            TextView updateLabel15 = new TextView(context);
            updateLabel15.Text = ("Update on Timeline");
            updateLabel15.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel15.TextSize = (16);
            TextView messageLabel15 = new TextView(context);
            messageLabel15.Text = ("Hi John, see you at 10AM");
            labelSeparator16 = new SeparatorView(context, width * 2);
            labelSeparator16.separatorColor = Color.LightGray;
            labelSeparator16.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail17.AddView(userNameLabel17);
            mail17.AddView(messageLabel15);
            mail17.Orientation = (Orientation.Vertical);
            mail17.Orientation = (Orientation.Vertical);

            //mail LayoutParameters
            mail6.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail6.SetPadding(20, 10, 10, 10);
            mail5.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail5.SetPadding(20, 10, 10, 5);
            mail12.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail12.SetPadding(20, 10, 10, 5);
            mail13.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail13.SetPadding(20, 10, 10, 5);
            mail14.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail14.SetPadding(20, 10, 10, 5);
            mail15.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail15.SetPadding(20, 10, 10, 5);
            mail16.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail16.SetPadding(20, 10, 10, 5);
            mail17.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail17.SetPadding(20, 10, 10, 5);

            labelSeparator17 = new SeparatorView(context, width * 2);
            labelSeparator17.separatorColor = Color.LightGray;
            labelSeparator17.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //outboxView
            outboxlayout.SetPadding(20, 0, 20, 20);
            outboxlayout.AddView(mail5);
            outboxlayout.AddView(labelSeparator17, layoutParams5);
            outboxlayout.AddView(mail6);
            outboxlayout.AddView(labelSeparator10, layoutParams5);
            outboxlayout.AddView(mail12);
            outboxlayout.AddView(labelSeparator11, layoutParams5);
            outboxlayout.AddView(mail13);
            outboxlayout.AddView(labelSeparator12, layoutParams5);
            outboxlayout.AddView(mail15);
            outboxlayout.AddView(labelSeparator14, layoutParams5);
            outboxlayout.AddView(mail16);
            outboxlayout.AddView(labelSeparator15, layoutParams5);
            outboxlayout.AddView(mail17);
            outboxlayout.AddView(labelSeparator16, layoutParams5);
        }

        private void ClickListenerLayout()
        {
            //Item click Listener
            viewItem.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
                String selectedItem = arrayAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Home"))
                {
                    ContentFrame.RemoveAllViews();
                    ContentFrame.AddView(textScroller);
                    profileContentLabel.Text = "Home";

                }
                if (selectedItem.Equals("Profile"))
                {
                    ContentFrame.RemoveAllViews();
                    ContentFrame.AddView(profilelayout);
                    profileContentLabel.Text = "Profile";

                }
                if (selectedItem.Equals("Inbox"))
                {
                    ContentFrame.RemoveAllViews();
                    inboxLayout.RemoveAllViews();
                    inboxLayout.SetPadding(20, 0, 20, 20);
                    inboxLayout.AddView(mail1);
                    inboxLayout.AddView(labelSeparator3, layoutParams5);
                    inboxLayout.AddView(mail2);
                    inboxLayout.AddView(labelSeparator4, layoutParams5);
                    inboxLayout.AddView(mail3);
                    inboxLayout.AddView(labelSeparator5, layoutParams5);
                    inboxLayout.AddView(mail4);
                    inboxLayout.AddView(labelSeparator6, layoutParams5);
                    inboxLayout.AddView(mail9);
                    inboxLayout.AddView(labelSeparator7, layoutParams5);
                    inboxLayout.AddView(mail10);
                    inboxLayout.AddView(labelSeparator9, layoutParams5);
                    inboxLayout.AddView(mail11);
                    inboxLayout.AddView(labelSeparator8, layoutParams5);
                    ContentFrame.AddView(inboxLayout);
                    profileContentLabel.Text = "Inbox";
                }
                if (selectedItem.Equals("Outbox"))
                {

                    ContentFrame.RemoveAllViews();
                    outboxlayout.RemoveAllViews();
                    outboxlayout.SetPadding(20, 0, 20, 20);
                    outboxlayout.AddView(mail5);
                    outboxlayout.AddView(labelSeparator17, layoutParams5);
                    outboxlayout.AddView(mail6);
                    outboxlayout.AddView(labelSeparator10, layoutParams5);
                    outboxlayout.AddView(mail12);
                    outboxlayout.AddView(labelSeparator11, layoutParams5);
                    outboxlayout.AddView(mail13);
                    outboxlayout.AddView(labelSeparator12, layoutParams5);
                    outboxlayout.AddView(mail15);
                    outboxlayout.AddView(labelSeparator14, layoutParams5);
                    outboxlayout.AddView(mail16);
                    outboxlayout.AddView(labelSeparator15, layoutParams5);
                    outboxlayout.AddView(mail17);
                    outboxlayout.AddView(labelSeparator16, layoutParams5);
                    ContentFrame.AddView(outboxlayout);
                    profileContentLabel.Text = "Outbox";
                }
                if (selectedItem.Equals("Sent Items"))
                {
                    ContentFrame.RemoveAllViews();
                    inboxLayout.RemoveAllViews();
                    inboxLayout.SetPadding(20, 0, 20, 20);

                    inboxLayout.AddView(mail10);
                    inboxLayout.AddView(labelSeparator4, layoutParams5);
                    inboxLayout.AddView(mail9);
                    inboxLayout.AddView(labelSeparator5, layoutParams5);
                    inboxLayout.AddView(mail4);
                    inboxLayout.AddView(labelSeparator6, layoutParams5);
                    inboxLayout.AddView(mail3);
                    inboxLayout.AddView(labelSeparator8, layoutParams5);
                    inboxLayout.AddView(mail11);
                    inboxLayout.AddView(labelSeparator3, layoutParams5);
                    inboxLayout.AddView(mail1);
                    inboxLayout.AddView(labelSeparator7, layoutParams5);
                    inboxLayout.AddView(mail2);
                    inboxLayout.AddView(labelSeparator9, layoutParams5);
                    ContentFrame.AddView(inboxLayout);
                    profileContentLabel.Text = "Sent Items";
                }
                if (selectedItem.Equals("Trash"))
                {
                    ContentFrame.RemoveAllViews();
                    outboxlayout.RemoveAllViews();
                    outboxlayout.SetPadding(20, 0, 20, 20);
                    outboxlayout.AddView(mail13);
                    outboxlayout.AddView(labelSeparator12, layoutParams5);
                    outboxlayout.AddView(mail5);
                    outboxlayout.AddView(labelSeparator17, layoutParams5);
                    outboxlayout.AddView(mail12);
                    outboxlayout.AddView(labelSeparator11, layoutParams5);
                    outboxlayout.AddView(mail15);
                    outboxlayout.AddView(labelSeparator14, layoutParams5);
                    outboxlayout.AddView(mail17);
                    outboxlayout.AddView(labelSeparator16, layoutParams5);
                    outboxlayout.AddView(mail16);
                    outboxlayout.AddView(labelSeparator15, layoutParams5);
                    outboxlayout.AddView(mail6);
                    outboxlayout.AddView(labelSeparator10, layoutParams5);
                    ContentFrame.AddView(outboxlayout);
                    profileContentLabel.Text = "Trash";
                }
                slideDrawer.ToggleDrawer();
            };
        }
        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
    }
}

