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
using Syncfusion.SfPdfViewer.Android;
using System.IO;
using System.Reflection;
using Android.Views.InputMethods;
using System.Diagnostics;
using static Android.Views.ViewGroup;
using Android.Graphics;

namespace SampleBrowser
{
    [Activity(ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class CustomToolBarPdfViewerDemo : SamplePage
    {
        SfPdfViewer pdfViewerControl;
        EditText pageNumberEntry;
        TextView pageCountText;
        LinearLayout mainView;
        RelativeLayout toolBarGrid;
        GridLayout bottomtoolBarGrid;
        GridLayout annotationBarGrid;
        GridLayout annotationBackGrid;
        GridLayout searchBarGrid;
        GridLayout annotationColorBarGrid;
        EditText searchView;
        Button searchButton;
        Button backButton;
        Button clearSearchButton;
        Context pdfViewerContext;
        Button selectionButton;
        string backupDocumentName = string.Empty;
        Button annotationModeButton;
        Button highlightModeButton;
        Button underlineModeButton;
        Button strikeoutModeButton;
        Button annotationBackButton;
        Button annotationColorButton;
        internal bool m_isAnnotationModeSelected;
        Button cyancolorButton;
        Button yellowcolorButton;
        Button greencolorButton;
        Button magentacolorButton;
        Button whitecolorButton;
        Button blackcolorButton;
        Button removeButton;
        Button undoButton;
        Button redoButton;
        Button saveButton;
        TextMarkupAnnotation annotation;
        FrameLayout annotationToolBar;
        Button annotationButton;
        Color fontColor;
        float textSize = 27;
        FrameLayout annotationsToolbar;
        GridLayout annotationsGrid;
        Button TextMarkupAnnotationButton;
        Button InkAnnotationButton;
        Button annotationsBackButton;
        FrameLayout inkannotationtoolbar;
        GridLayout inkannotationgrid;
        Button inkundobutton;
        Button inkredobutton;
        Button inkannotationbackbutton;
        FrameLayout inkannotationbottomtoolbar;
        GridLayout inkannotationbottomgrid;
        Button inkannotationThicknessButton;
        Button inkAnnotationColorButton;
        FrameLayout inkannotationthicknessToolbar;
        GridLayout inkannotationthicknessGrid;
        LinearLayout lineView1;
        FrameLayout annotationbottomcolortoolbar;
        Button opacityButton;
        Button inkBackButton;
        Button inkButton;
        internal int currentColorPosition;
        FrameLayout inkannotationbottomopacitytoolbar;
        ImageButton lineFive1;
        ImageButton lineFour1;
        ImageButton lineOne1;
        LinearLayout linesLayout1;
        ImageButton lineThree1;
        ImageButton lineTwo1;
        private ImageButton lineOneContainer1;
        private ImageButton lineTwoContainer1;
        private ImageButton lineThreeContainer1;
        private ImageButton lineFourContainer1;
        private ImageButton lineFiveContainer1;
        SeekBar seekbar1;
        InkAnnotation inkannot;
        bool m_opacityChanged;
        Button textmarkupannotationBackButton;
        Button inkremovebutton;
        TextView endprogressLabel;
        bool m_thicknessChanged;
     
        public override View GetSampleContent(Context context)
        {           
            fontColor = new Color(0, 118, 255);
            Typeface font = Typeface.CreateFromAsset(context.Assets, "PDFViewer_Android.ttf");
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            pdfViewerContext = context;
            mainView = (LinearLayout)layoutInflater.Inflate(Resource.Layout.CustomToolbarPDFViewer, null);
            pageNumberEntry = (EditText)mainView.FindViewById(Resource.Id.pagenumberentry1);
            pageNumberEntry.KeyPress += PageNumberEntry_KeyPress;
            pageCountText = (TextView)mainView.FindViewById(Resource.Id.pagecounttext1);
            searchButton = mainView.FindViewById<Button>(Resource.Id.searchButton);
            searchButton.Typeface = font;
            searchButton.SetTextColor(fontColor);
            searchButton.TextSize = textSize;
            searchButton.Click += SearchButton_Click;
            saveButton = mainView.FindViewById<Button>(Resource.Id.savebutton);
            saveButton.Typeface = font;
            saveButton.TextSize = textSize;
            saveButton.SetTextColor(fontColor);
            saveButton.Click += SaveButton_Click;
            undoButton = mainView.FindViewById<Button>(Resource.Id.undobutton);
            MarginLayoutParams undomarginParams = new MarginLayoutParams(undoButton.LayoutParameters);
            Android.Telephony.TelephonyManager manager = (Android.Telephony.TelephonyManager)context.GetSystemService(Context.TelephonyService) as Android.Telephony.TelephonyManager;
            if (manager.PhoneType == Android.Telephony.PhoneType.None)
            {
                undomarginParams.SetMargins((context.Resources.DisplayMetrics.WidthPixels) / 2 - 60, 10, 0, 14);

            }
            else
            {
                undomarginParams.SetMargins((context.Resources.DisplayMetrics.WidthPixels) / 2 - 60, 22, 0, 14);
            }
            
            RelativeLayout.LayoutParams undolayoutParams = new RelativeLayout.LayoutParams(undomarginParams);
            undoButton.LayoutParameters = undolayoutParams;
            undoButton.Typeface = font;
            undoButton.TextSize = textSize;
            undoButton.SetTextColor(Color.Gray);
            undoButton.Click += UndoButton_Click;
            redoButton = mainView.FindViewById<Button>(Resource.Id.redobutton);
            redoButton.SetTextColor(Color.Gray);
            redoButton.Typeface = font;
            redoButton.TextSize = textSize;
            MarginLayoutParams marginParams = new MarginLayoutParams(redoButton.LayoutParameters);
            if (manager.PhoneType == Android.Telephony.PhoneType.None)
            {
                marginParams.SetMargins((context.Resources.DisplayMetrics.WidthPixels) / 2 + 60, 10, 0, 14);
            }
            else
            {
                marginParams.SetMargins((context.Resources.DisplayMetrics.WidthPixels) / 2 + 60, 22, 10, 10);
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(marginParams);
            redoButton.LayoutParameters = layoutParams;
            redoButton.Click += RedoButton_Click;
            removeButton = mainView.FindViewById<Button>(Resource.Id.removebutton);
            removeButton.Typeface = font;
            removeButton.SetTextColor(fontColor);
            removeButton.TextSize = textSize;
            removeButton.Click += RemoveButton_Click;
            annotationModeButton = (Button)mainView.FindViewById(Resource.Id.annotationbutton);
            annotationModeButton.Typeface = font;
            annotationModeButton.SetTextColor(fontColor);
            annotationModeButton.TextSize = textSize;
            annotationModeButton.Click += AnnotationModeButton_Click;
            pdfViewerControl = (SfPdfViewer)mainView.FindViewById(Resource.Id.pdfviewercontrol);
            pdfViewerControl.DocumentLoaded += PdfViewerControl_DocumentLoaded;
            pdfViewerControl.PageChanged += PdfViewerControl_PageChanged;
            backupDocumentName = "F# Succinctly";
            Stream docStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + backupDocumentName + ".pdf");
            annotationToolBar = mainView.FindViewById<FrameLayout>(Resource.Id.annotationtoolbar);
            annotationToolBar.Visibility = ViewStates.Gone;
            toolBarGrid = mainView.FindViewById<RelativeLayout>(Resource.Id.toolbarGrid);
            toolBarGrid.Visibility = ViewStates.Visible;
            bottomtoolBarGrid = mainView.FindViewById<GridLayout>(Resource.Id.bottomtoolbarGrid);
            bottomtoolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid = mainView.FindViewById<GridLayout>(Resource.Id.searchGrid);
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationBarGrid = mainView.FindViewById<GridLayout>(Resource.Id.annotationgrid);
            annotationBarGrid.Visibility = ViewStates.Invisible;
            annotationBackGrid = mainView.FindViewById<GridLayout>(Resource.Id.annotationbackgrid);
            annotationBackGrid.Visibility = ViewStates.Invisible;
            annotationColorBarGrid = mainView.FindViewById<GridLayout>(Resource.Id.selectedannotationcolorchangedGrid);
            annotationColorBarGrid.Visibility = ViewStates.Invisible;
            backButton = mainView.FindViewById<Button>(Resource.Id.backButton);
            backButton.Typeface = font;
            backButton.SetTextColor(fontColor);
            backButton.TextSize = textSize;
            highlightModeButton = (Button)mainView.FindViewById(Resource.Id.highlightbtn);
            highlightModeButton.Typeface = font;
            highlightModeButton.SetTextColor(fontColor);
            highlightModeButton.TextSize = textSize;
            highlightModeButton.Click += HighlightModeButton_Click;
            underlineModeButton = (Button)mainView.FindViewById(Resource.Id.underlinebtn);
            underlineModeButton.Typeface = font;
            underlineModeButton.SetTextColor(fontColor);
            underlineModeButton.TextSize = textSize;
            underlineModeButton.Click += UnderlineModeButton_Click;
            strikeoutModeButton = (Button)mainView.FindViewById(Resource.Id.strikeoutbutton);
            strikeoutModeButton.Typeface = font;
            strikeoutModeButton.SetTextColor(fontColor);
            strikeoutModeButton.TextSize = textSize;
            strikeoutModeButton.Click += StrikeoutModeButton_Click;
            annotationBackButton = (Button)mainView.FindViewById(Resource.Id.annotationbackbutton);
            annotationBackButton.Typeface = font;
            annotationBackButton.SetTextColor(fontColor);
            annotationBackButton.TextSize = textSize;
            annotationBackButton.Click += AnnotationBackButton_Click;
            annotationColorButton = (Button)mainView.FindViewById(Resource.Id.annotationcolorbutton);
            annotationColorButton.Click += AnnotationColorButton_Click;
            annotationButton = (Button)mainView.FindViewById(Resource.Id.annotationbtn);
            annotationButton.Typeface = font;
            annotationButton.SetTextColor(fontColor);
            annotationButton.TextSize = textSize;
            cyancolorButton = (Button)mainView.FindViewById(Resource.Id.cyanbutton);
            cyancolorButton.Click += CyancolorButton_Click;
            yellowcolorButton = (Button)mainView.FindViewById(Resource.Id.yellowbutton);
            yellowcolorButton.Click += YellowcolorButton_Click;
            greencolorButton = (Button)mainView.FindViewById(Resource.Id.greenbutton);
            greencolorButton.Click += GreencolorButton_Click;
            magentacolorButton = (Button)mainView.FindViewById(Resource.Id.magentabutton);
            magentacolorButton.Click += MagentacolorButton_Click;
            whitecolorButton = (Button)mainView.FindViewById(Resource.Id.whitebutton);
            whitecolorButton.Click += WhitecolorButton_Click;
            blackcolorButton = (Button)mainView.FindViewById(Resource.Id.blackbutton);
            blackcolorButton.Click += BlackcolorButton_Click;
            backButton.Click += BackButton_Click;
            searchView = mainView.FindViewById<EditText>(Resource.Id.search);
            searchView.SetHintTextColor(Android.Graphics.Color.Rgb(189, 189, 189));
            searchView.Hint = "Search text";
            searchView.FocusableInTouchMode = true;
            searchView.TextSize = 18;
            searchView.SetTextColor(Android.Graphics.Color.Rgb(103, 103, 103));
            searchView.TextAlignment = TextAlignment.Center;
            searchView.KeyPress += SearchView_KeyPress;
            searchView.TextChanged += SearchView_TextChanged;
            selectionButton = mainView.FindViewById<Button>(Resource.Id.selectDocumentButton);
            selectionButton.Typeface = font;
            selectionButton.SetTextColor(fontColor);
            selectionButton.TextSize = textSize;
            selectionButton.Click += SelectionButton_Click;
            clearSearchButton = mainView.FindViewById<Button>(Resource.Id.clearSearchResult);
            clearSearchButton.Typeface = font;
            clearSearchButton.SetTextColor(fontColor);
            clearSearchButton.TextSize = textSize;
            clearSearchButton.Click += ClearSearchButton_Click;
            annotationsGrid = (GridLayout)mainView.FindViewById(Resource.Id.annotationsgrid);
            annotationsGrid.Visibility = ViewStates.Gone;
            annotationsToolbar = (FrameLayout)mainView.FindViewById(Resource.Id.annotationstoolbar);
            annotationsToolbar.Visibility = ViewStates.Gone;
            TextMarkupAnnotationButton = (Button)mainView.FindViewById(Resource.Id.textmarkupannotationButton);
            TextMarkupAnnotationButton.Typeface = font;
            TextMarkupAnnotationButton.SetTextColor(fontColor);
            TextMarkupAnnotationButton.TextSize = textSize;
            TextMarkupAnnotationButton.Click += TextMarkupAnnotationButton_Click;
            InkAnnotationButton = (Button)mainView.FindViewById(Resource.Id.inkannotationButton);
            InkAnnotationButton.Typeface = font;
            InkAnnotationButton.SetTextColor(fontColor);
            InkAnnotationButton.TextSize = textSize;
            InkAnnotationButton.Click += InkAnnotationButton_Click;
            annotationsBackButton = (Button)mainView.FindViewById(Resource.Id.annotationsBackButton);
            annotationsBackButton.Typeface = font;
            annotationsBackButton.SetTextColor(fontColor);
            annotationsBackButton.TextSize = textSize;
            annotationsBackButton.Click += AnnotationsBackButton_Click;

            inkannotationgrid = (GridLayout)mainView.FindViewById(Resource.Id.inkannotationgrid);
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationtoolbar);
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkundobutton = (Button)mainView.FindViewById(Resource.Id.inkundobutton1);
            inkundobutton.Typeface = font;
            inkundobutton.TextSize = textSize;
            inkundobutton.SetTextColor(Color.Gray);
            inkundobutton.Click += Inkundobutton_Click;
            inkredobutton = (Button)mainView.FindViewById(Resource.Id.inkredobutton1);
            inkredobutton.Typeface = font;
            inkredobutton.TextSize = textSize;
            inkredobutton.SetTextColor(Color.Gray);
            inkredobutton.Click += Inkredobutton_Click;
            inkannotationbackbutton = (Button)mainView.FindViewById(Resource.Id.inkannotationbackbutton);
            inkannotationbackbutton.Typeface = font;
            inkannotationbackbutton.SetTextColor(fontColor);
            inkannotationbackbutton.TextSize = textSize;
            inkannotationbackbutton.Click += Inkannotationbackbutton_Click;

            inkannotationbottomgrid = (GridLayout)mainView.FindViewById(Resource.Id.inkannotationbottomgrid);
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationbottomtoolbar);
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            inkannotationThicknessButton = (Button)mainView.FindViewById(Resource.Id.inkannotationThicknessButton);
            inkannotationThicknessButton.Typeface = font;
            inkannotationThicknessButton.TextSize = textSize;
            inkannotationThicknessButton.Click += InkannotationThicknessButton_Click;
            inkAnnotationColorButton = (Button)mainView.FindViewById(Resource.Id.inkAnnotationColorButton);
            inkAnnotationColorButton.Click += InkAnnotationColorButton_Click;

            inkannotationthicknessToolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationthicknessToolbar);
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid = (GridLayout)mainView.FindViewById(Resource.Id.inkannotationthicknessGrid);
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;

            lineView1 = (LinearLayout)mainView.FindViewById(Resource.Id.lines1);
            lineView1.Visibility = ViewStates.Gone;

            annotationbottomcolortoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.annotationbottomcolortoolbar);
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;

            opacityButton = (Button)mainView.FindViewById(Resource.Id.opacitybtn);
            opacityButton.Visibility = ViewStates.Gone;
            opacityButton.Typeface = font;         
            opacityButton.TextSize = textSize;
            opacityButton.Click += OpacityButton_Click;

            inkannotationbottomopacitytoolbar = (FrameLayout)mainView.FindViewById(Resource.Id.inkannotationbottomopacitytoolbar);
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;

            inkBackButton = (Button)mainView.FindViewById(Resource.Id.inkBackButton);
            inkBackButton.Visibility = ViewStates.Gone;
            inkBackButton.Typeface = font;
            inkBackButton.SetTextColor(fontColor);
            inkBackButton.TextSize = textSize;
            inkBackButton.Click += InkBackButton_Click;

            inkButton = (Button)mainView.FindViewById(Resource.Id.inkButton);
            inkButton.Visibility = ViewStates.Gone;
            inkButton.Typeface = font;
            inkButton.SetTextColor(fontColor);
            inkButton.TextSize = textSize;

            textmarkupannotationBackButton= (Button)mainView.FindViewById(Resource.Id.textmarkupannotationBackButton);
            textmarkupannotationBackButton.Typeface = font;
            textmarkupannotationBackButton.SetTextColor(fontColor);
            textmarkupannotationBackButton.TextSize = textSize;
            textmarkupannotationBackButton.Click += TextmarkupannotationBackButton_Click;

            inkremovebutton = (Button)mainView.FindViewById(Resource.Id.inkremovebutton);
            inkremovebutton.Typeface = font;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkremovebutton.SetTextColor(fontColor);
            inkremovebutton.TextSize = textSize;
            inkremovebutton.Click += Inkremovebutton_Click;

            linesLayout1 = (LinearLayout)mainView.FindViewById(Resource.Id.lines1);
            linesLayout1.Visibility = ViewStates.Gone;
            lineOneContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.lineonecontainer1);
            lineOneContainer1.Tag = 0;
            lineOne1 = (ImageButton)mainView.FindViewById(Resource.Id.lineone1);
            lineOne1.Tag = 0;
            lineOne1.Click += ThickLinesClick;
            lineOneContainer1.Click += ThickContainerClick;
            lineTwoContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linetwocontainer1);
            lineTwoContainer1.Tag = 1;
            lineTwo1 = (ImageButton)mainView.FindViewById(Resource.Id.linetwo1);
            lineTwo1.Tag = 1;
            lineTwo1.Click += ThickLinesClick;
            lineTwoContainer1.Click += ThickLinesClick;
            lineThreeContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linethreecontainer1);
            lineThreeContainer1.Tag = 2;
            lineThree1 = (ImageButton)mainView.FindViewById(Resource.Id.linethree1);
            lineThree1.Tag = 2;
            lineThree1.Click += ThickLinesClick;
            lineThreeContainer1.Click += ThickContainerClick;
            lineFourContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linefourcontainer1);
            lineFourContainer1.Tag = 3;
            lineFour1 = (ImageButton)mainView.FindViewById(Resource.Id.linefour1);
            lineFour1.Tag = 3;
            lineFour1.Click += ThickLinesClick;
            lineFourContainer1.Click += ThickContainerClick;
            lineFiveContainer1 = (ImageButton)mainView.FindViewById(Resource.Id.linefivecontainer1);
            lineFiveContainer1.Tag = 4;
            lineFive1 = (ImageButton)mainView.FindViewById(Resource.Id.linefive1);
            lineFive1.Tag = 4;
            lineFive1.Click += ThickLinesClick;
            lineFiveContainer1.Click += ThickContainerClick;

            seekbar1 = (SeekBar)mainView.FindViewById(Resource.Id.seekbar1);
            seekbar1.StopTrackingTouch += Seekbar_StopTrackingTouch;
            seekbar1.ProgressChanged += Seekbar_ProgressChanged;
            endprogressLabel = (TextView)mainView.FindViewById(Resource.Id.endprogress);
            pdfViewerControl.Toolbar.Enabled = false;
            pdfViewerControl.InkDeselected += PdfViewerControl_InkDeselected; ;
            pdfViewerControl.InkSelected += PdfViewerControl_InkSelected; ;
            pdfViewerControl.CanUndoInkModified += PdfViewerControl_CanUndoInkModified;
            pdfViewerControl.CanRedoInkModified += PdfViewerControl_CanRedoInkModified;
            pdfViewerControl.TextMarkupSelected += PdfViewerControl_TextMarkupSelected;
            pdfViewerControl.TextMarkupDeselected += PdfViewerControl_TextMarkupDeselected;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;           
            pdfViewerControl.LoadDocument(docStream);
            return mainView;
        }

        private bool ThicknessChanged
        {
            get
            {
                return m_thicknessChanged;
            }
            set
            {
                m_thicknessChanged = value;
            }
        }
        private void Seekbar_StopTrackingTouch(object sender, SeekBar.StopTrackingTouchEventArgs e)
        {
            double val = Math.Round((double)e.SeekBar.Progress / 100, 2);
            decimal dec = (decimal)val;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                pdfViewerControl.AnnotationSettings.Ink.Opacity = (float)(dec);
              
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkannot.Settings.Opacity = (float)(dec);
            }
            endprogressLabel.Text = string.Format("{0}%", (double)e.SeekBar.Progress);
        }

        private void ThickContainerClick(object sender, EventArgs e)
        {
            currentColorPosition = (int)((ImageButton)sender).Tag;
            Set();
        }
        private void ThickLinesClick(object sender, EventArgs e)
        {
            currentColorPosition = (int)((ImageButton)sender).Tag;
            Set();
        }
        internal void Set()
        {

            SetThickness(currentColorPosition);

        }

        private void SetThickness(int position)
        {
            switch (position)
            {
                case 0:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 1;
                    }
                    else if(pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 1;

                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 1:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 2;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 2;

                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 2:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 5;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 5;

                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 3:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 7;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 7;

                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
                case 4:
                    if (inkannot != null)
                    {
                        inkannot.Settings.Thickness = 10;
                    }
                    else if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                        pdfViewerControl.AnnotationSettings.Ink.Thickness = 10;

                    lineView1.Visibility = ViewStates.Invisible;
                    linesLayout1.Visibility = ViewStates.Gone;
                    ThicknessChanged = false;
                    break;
            }
        }
        private void Inkremovebutton_Click(object sender, EventArgs e)
        {
            inkannot = (sender as InkAnnotation);
            pdfViewerControl.RemoveAnnotation(inkannot);
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            inkButton.Visibility = ViewStates.Gone;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            pdfViewerControl.RemoveAnnotation(annotation);
            IsAnnotationModeSelected = false;
        }

        private void TextmarkupannotationBackButton_Click(object sender, EventArgs e)
        {
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Visible;
            annotationsGrid.Visibility = ViewStates.Visible;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
        }

        private bool OpacityChanged
        {

            get
            {
                return m_opacityChanged;
            }

            set
            {
                m_opacityChanged = value;
            }
        }

        private void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
            inkannot = (sender as InkAnnotation);
            Color color = new Color((byte)inkannot.Settings.Color.R, (byte)inkannot.Settings.Color.G, (byte)inkannot.Settings.Color.B, (byte)255);
            inkAnnotationColorButton.SetBackgroundColor(color);
            inkannotationThicknessButton.SetTextColor(color);
            linesLayout1.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Invisible;
            inkannotationgrid.Visibility = ViewStates.Invisible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;

        }

        private void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {
            inkannot = null;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            inkButton.Visibility = ViewStates.Gone;
            inkBackButton.Visibility = ViewStates.Gone;
            inkremovebutton.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
            toolBarGrid.Visibility = ViewStates.Visible;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
        }
     
        private void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
            if (args.CanRedoInk)
            {
                inkredobutton.SetTextColor(fontColor);
            }
            else
            {
                inkredobutton.SetTextColor(Color.Gray);
            }
        }

        private void PdfViewerControl_CanUndoInkModified(object sender, CanUndoInkModifiedEventArgs args)
        {
            if (args.CanUndoInk)
            {
                inkundobutton.SetTextColor(fontColor);
            }
            else
            {
                inkundobutton.SetTextColor(Color.Gray);
            }
        }

        private void Seekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {           
            endprogressLabel.Text = string.Format("{0}%", (e.Progress));
        }

        private void InkBackButton_Click(object sender, EventArgs e)
        {
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Visible;
            annotationsGrid.Visibility = ViewStates.Visible;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;            
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            pdfViewerControl.EndInkSession(false);
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            if(!pdfViewerControl.CanUndo)
            undoButton.SetTextColor(Color.Gray);
        }

        private void OpacityButton_Click(object sender, EventArgs e)
        {
            if (!OpacityChanged)
            {
                seekbar1.Progress = ((int)(pdfViewerControl.AnnotationSettings.Ink.Opacity * 100));
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Visible;
                OpacityChanged = true;
            }
            else
            {
                OpacityChanged = false;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            }
        }

        private void InkAnnotationColorButton_Click(object sender, EventArgs e)
        {         
            if (annotationbottomcolortoolbar.Visibility == ViewStates.Visible)
            {
                OpacityChanged = false;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                opacityButton.Visibility = ViewStates.Gone;
                return;
            }
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {

                Color color = pdfViewerControl.AnnotationSettings.Ink.Color;
                color.A = (byte)(pdfViewerControl.AnnotationSettings.Ink.Opacity * 255);
                opacityButton.SetTextColor(color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                Color color = inkannot.Settings.Color;
                color.A = (byte)(inkannot.Settings.Opacity * 255);
                opacityButton.SetTextColor(color);
            }
            opacityButton.Visibility = ViewStates.Visible;
            annotationbottomcolortoolbar.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Visible;
            lineView1.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
        }

        private void InkannotationThicknessButton_Click(object sender, EventArgs e)
        {
            if(ThicknessChanged)
            {
                lineView1.Visibility = ViewStates.Gone;
                linesLayout1.Visibility = ViewStates.Gone;
                ThicknessChanged = false;
                return;
            }
            if (annotationbottomcolortoolbar.Visibility == ViewStates.Visible)
            {
                OpacityChanged = false;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                opacityButton.Visibility = ViewStates.Gone;               
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                lineOne1.SetBackgroundColor(pdfViewerControl.AnnotationSettings.Ink.Color);
                lineTwo1.SetBackgroundColor(pdfViewerControl.AnnotationSettings.Ink.Color);
                lineThree1.SetBackgroundColor(pdfViewerControl.AnnotationSettings.Ink.Color);
                lineFour1.SetBackgroundColor(pdfViewerControl.AnnotationSettings.Ink.Color);
                lineFive1.SetBackgroundColor(pdfViewerControl.AnnotationSettings.Ink.Color);
                ThicknessChanged = true;

            }
            if (inkannot != null)
            {
                lineOne1.SetBackgroundColor(inkannot.Settings.Color);
                lineTwo1.SetBackgroundColor(inkannot.Settings.Color);
                lineThree1.SetBackgroundColor(inkannot.Settings.Color);
                lineFour1.SetBackgroundColor(inkannot.Settings.Color);
                lineFive1.SetBackgroundColor(inkannot.Settings.Color);
                ThicknessChanged = true;
            }
            lineView1.Visibility = ViewStates.Visible;
            linesLayout1.Visibility = ViewStates.Visible;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }

        private void Inkannotationbackbutton_Click(object sender, EventArgs e)
        {
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Visible;
            annotationsGrid.Visibility = ViewStates.Visible;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Invisible;
            pdfViewerControl.EndInkSession(true);
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
        }

        private void Inkredobutton_Click(object sender, EventArgs e)
        {
            pdfViewerControl.RedoInk();
        }

        private void Inkundobutton_Click(object sender, EventArgs e)
        {
          
            pdfViewerControl.UndoInk();
        }

        private void AnnotationsBackButton_Click(object sender, EventArgs e)
        {
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            IsAnnotationModeSelected = false;
        }

        private void InkAnnotationButton_Click(object sender, EventArgs e)
        {
            inkAnnotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.Ink.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Invisible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Visible;
            inkannotationgrid.Visibility = ViewStates.Visible;
            inkannotationbottomgrid.Visibility = ViewStates.Visible;
            inkannotationbottomtoolbar.Visibility = ViewStates.Visible;
            inkButton.Visibility = ViewStates.Visible;
            inkBackButton.Visibility = ViewStates.Visible;
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationThicknessButton.SetTextColor(pdfViewerControl.AnnotationSettings.Ink.Color);           
        }

        private void TextMarkupAnnotationButton_Click(object sender, EventArgs e)
        {
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;

            annotationToolBar.Visibility = ViewStates.Visible;
            annotationBarGrid.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            searchBarGrid.Visibility = ViewStates.Gone;
        }

        private bool IsAnnotationModeSelected
        {
            get
            {
                return m_isAnnotationModeSelected;
            }
            set
            {
                m_isAnnotationModeSelected = value;
            }
        }

        #region DocumentSelectionMenu
        private void SelectionButton_Click(object sender, EventArgs e)
        {           
            if (searchBarGrid.Visibility == ViewStates.Visible)
            {
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }

            PopupMenu popup = new PopupMenu(pdfViewerContext, selectionButton);
            popup.Inflate(Resource.Drawable.popup_menu_pdfViewer);
            popup.MenuItemClick += Popup_MenuItemClick;
            popup.Show();
        }

        private void Popup_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            string documentName = e.Item.TitleFormatted.ToString();
            if (documentName != backupDocumentName)
            {
                Stream docStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + documentName + ".pdf");
                pdfViewerControl.LoadDocument(docStream);
                backupDocumentName = documentName;
            }
        }
        #endregion

        #region TextSearch
        private void SearchView_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (searchView.Text != string.Empty)
            {
                clearSearchButton.Visibility = ViewStates.Visible;
            }
            else
            {
                clearSearchButton.Visibility = ViewStates.Invisible;
            }
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            pdfViewerControl.CancelSearch();
            searchView.Text = "";
            clearSearchButton.Visibility = ViewStates.Invisible;
            InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
            inputMethodManager.ShowSoftInput(searchView, ShowFlags.Implicit);
        }

        private void SearchView_KeyPress(object sender, View.KeyEventArgs e)
        {
            var editText = sender as EditText;
            if (e.KeyCode == Keycode.Enter)
            {
                if (!string.IsNullOrWhiteSpace(editText.Text) && !string.IsNullOrEmpty(editText.Text))
                {
                    searchText = editText.Text;
                    pdfViewerControl.SearchText(searchText);
                }
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
            if (e.KeyCode == Keycode.Del)
            {
                if (editText.Length() > 0)
                {
                    editText.Text = editText.Text.Remove(editText.Length() - 1, 1);
                    editText.SetSelection(editText.Text.Length);
                }
                else
                    pdfViewerControl.CancelSearch();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (searchBarGrid.Visibility == ViewStates.Visible)
            {
                searchBarGrid.Visibility = ViewStates.Invisible;
                toolBarGrid.Visibility = ViewStates.Visible;
                pdfViewerControl.CancelSearch();
                searchView.Text = "";
                clearSearchButton.Visibility = ViewStates.Invisible;
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;

            IsAnnotationModeSelected = false;
            if (toolBarGrid.Visibility == ViewStates.Visible)
            {
                toolBarGrid.Visibility = ViewStates.Invisible;
                searchBarGrid.Visibility = ViewStates.Visible;
                searchView.RequestFocus();
                clearSearchButton.Visibility = ViewStates.Invisible;
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.ShowSoftInput(searchView, ShowFlags.Implicit);
            }
        }

        string searchText = string.Empty;
        bool isTextFound;

        #endregion

        private void PdfViewerControl_PageChanged(object sender, PageChangedEventArgs args)
        {
            pageNumberEntry.Text = args.PageNumber.ToString();
        }

        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
            pageCountText.Text = pdfViewerControl.PageCount.ToString();
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                pdfViewerControl.EndInkSession(false);
            inkremovebutton.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
        }

        private void PageNumberEntry_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                int pageNumber = 0;
                if (int.TryParse((pageNumberEntry.Text), out pageNumber))
                {
                    if ((pageNumber > 0) && (pageNumber <= pdfViewerControl.PageCount))
                        pdfViewerControl.GoToPage(pageNumber);
                    else
                    {
                        DisplayAlertDialog();
                        pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
                    }
                }
                pageNumberEntry.ClearFocus();
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
        }

        void DisplayAlertDialog()
        {
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(mainView.Context);
            alertDialog.SetTitle("Error");
            alertDialog.SetMessage("Please enter the valid page number");
            alertDialog.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alertDialog.Create();
            dialog.Show();
        }

        private void AnnotationBackButton_Click(object sender, EventArgs e)
        {

            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
        }

        private void StrikeoutModeButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationButton.Text = "\uE711";
            removeButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Visible;
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Strikethrough;
        }

        private void UnderlineModeButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Visible;
            removeButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Visible;
            annotationButton.Text = "\uE70d";
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Underline;
        }

        private void HighlightModeButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Visible;
            annotationButton.Text = "\uE715";
            annotationBackButton.Visibility = ViewStates.Visible;
            removeButton.Visibility = ViewStates.Gone;
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Highlight;


        }

        private void AnnotationModeButton_Click(object sender, EventArgs e)
        {
            if (!pdfViewerControl.CanUndo)
                undoButton.SetTextColor(Color.Gray);
            if (!IsAnnotationModeSelected)
            {
                if (searchBarGrid.Visibility == ViewStates.Visible)
                {
                    InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                    inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
                }
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.EndInkSession(false);
                annotationsToolbar.Visibility = ViewStates.Visible;
                annotationsGrid.Visibility = ViewStates.Visible;
                annotationBackGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                searchBarGrid.Visibility = ViewStates.Gone;
                IsAnnotationModeSelected = true;
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationBarGrid.Visibility = ViewStates.Gone;
                inkannotationtoolbar.Visibility = ViewStates.Gone;
                inkannotationgrid.Visibility = ViewStates.Gone;
                inkannotationbottomgrid.Visibility = ViewStates.Gone;
                inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                opacityButton.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                lineView1.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessGrid.Visibility = ViewStates.Gone;
                linesLayout1.Visibility = ViewStates.Gone;
                inkremovebutton.Visibility = ViewStates.Gone;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;             
            }
            else
            {
                if (searchBarGrid.Visibility == ViewStates.Visible)
                {
                    InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                    inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
                }
                if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    pdfViewerControl.EndInkSession(false);
                inkremovebutton.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationBarGrid.Visibility = ViewStates.Gone;
                annotationBackGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                searchBarGrid.Visibility = ViewStates.Gone;
                IsAnnotationModeSelected = false;
                annotationsToolbar.Visibility = ViewStates.Gone;
                annotationsGrid.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessGrid.Visibility = ViewStates.Gone;
                linesLayout1.Visibility = ViewStates.Gone;
                inkannotationtoolbar.Visibility = ViewStates.Gone;
                inkannotationgrid.Visibility = ViewStates.Gone;
                inkannotationbottomgrid.Visibility = ViewStates.Gone;
                inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                opacityButton.Visibility = ViewStates.Gone;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                lineView1.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            }
        }

        private void AnnotationColorButton_Click(object sender, EventArgs e)
        {
            annotationbottomcolortoolbar.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Visible;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
        }

        private void BlackcolorButton_Click(object sender, EventArgs e)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                inkannot.Settings.Color = Android.Graphics.Color.Black;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                annotation.Settings.Color = Android.Graphics.Color.Black;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                annotationToolBar.Visibility = ViewStates.Visible;              
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Black;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Black);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }

        private void WhitecolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;               
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;               
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;             
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                annotation.Settings.Color = Android.Graphics.Color.White;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                inkannot.Settings.Color = Android.Graphics.Color.White;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.White);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.White;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.White);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }

        private void MagentacolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationToolBar.Visibility = ViewStates.Visible;
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                annotation.Settings.Color = Android.Graphics.Color.Magenta;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                inkannot.Settings.Color = Android.Graphics.Color.Magenta;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Magenta);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Magenta;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Magenta);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }
        private void GreencolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                annotation.Settings.Color = Android.Graphics.Color.Green;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                inkannot.Settings.Color = Android.Graphics.Color.Green;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Green);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Green;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Green);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }



        private void YellowcolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Yellow);
                inkannot.Settings.Color = Android.Graphics.Color.Yellow;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Yellow);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Yellow);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Yellow;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Yellow);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Yellow);
                annotation.Settings.Color = Android.Graphics.Color.Yellow;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }

        private void CyancolorButton_Click(object sender, EventArgs e)
        {

            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Cyan);
                annotation.Settings.Color = Android.Graphics.Color.Cyan;
                annotationToolBar.Visibility = ViewStates.Visible;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && inkannot != null)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Cyan);
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Cyan);
                inkannot.Settings.Color= Android.Graphics.Color.Cyan;
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                inkAnnotationColorButton.SetBackgroundColor(Android.Graphics.Color.Cyan);
                pdfViewerControl.AnnotationSettings.Ink.Color = Android.Graphics.Color.Cyan;
                inkannotationThicknessButton.SetTextColor(Android.Graphics.Color.Cyan);
                annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
                inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
                inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
                OpacityChanged = false;
            }
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Invisible;
            annotationBackGrid.Visibility = ViewStates.Invisible;
            annotationColorBarGrid.Visibility = ViewStates.Invisible;
            pdfViewerControl.RemoveAnnotation(annotation);
            IsAnnotationModeSelected = false;

            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            annotationToolBar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.PerformRedo();
            IsAnnotationModeSelected = false;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            pdfViewerControl.PerformUndo();
            IsAnnotationModeSelected = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            annotationToolBar.Visibility = ViewStates.Gone;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            IsAnnotationModeSelected = false;
            Stream stream1 = pdfViewerControl.SaveDocument();
            MemoryStream stream = stream1 as MemoryStream;
            string root = null;
            string fileName = backupDocumentName + ".pdf";
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists()) file.Delete();
            Java.IO.FileOutputStream outs = new Java.IO.FileOutputStream(file);
            outs.Write(stream.ToArray());
            outs.Flush();
            outs.Close();

            AlertDialog.Builder alertDialog = new AlertDialog.Builder(mainView.Context);
            alertDialog.SetTitle("Save");
            alertDialog.SetMessage("The modified document is saved in the below location. " + "\n" + file.Path);
            alertDialog.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alertDialog.Create();
            dialog.Show();

        }

        private void SelectedannotationColorButton_Click(object sender, EventArgs e)
        {
            annotationColorBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            if (annotationBarGrid.Visibility == ViewStates.Visible)
                annotationBarGrid.Visibility = ViewStates.Invisible;
            if (annotationBackButton.Visibility == ViewStates.Visible)
                annotationBackButton.Visibility = ViewStates.Invisible;
            if (annotationColorButton.Visibility == ViewStates.Visible)
                annotationColorButton.Visibility = ViewStates.Invisible;
        }

        private void PdfViewerControl_TextMarkupDeselected(object sender, TextMarkupDeselectedEventArgs args)
        {
            annotationColorBarGrid.Visibility = ViewStates.Gone;
           
            annotationButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;

            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationBarGrid.Visibility = ViewStates.Gone;
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
	    annotationToolBar.Visibility = ViewStates.Gone;
        }

        private void PdfViewerControl_TextMarkupSelected(object sender, TextMarkupSelectedEventArgs args)
        {
            annotation = (sender as TextMarkupAnnotation);
            annotationToolBar.Visibility = ViewStates.Visible;
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationColorButton.SetBackgroundColor(annotation.Settings.Color);
            removeButton.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Gone;
            annotationBackButton.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
           
            inkannotationbottomopacitytoolbar.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Gone;
            searchBarGrid.Visibility = ViewStates.Gone;
            annotationsToolbar.Visibility = ViewStates.Gone;
            annotationsGrid.Visibility = ViewStates.Gone;
            inkannotationthicknessToolbar.Visibility = ViewStates.Gone;
            inkannotationthicknessGrid.Visibility = ViewStates.Gone;
            linesLayout1.Visibility = ViewStates.Gone;
            inkannotationtoolbar.Visibility = ViewStates.Gone;
            inkannotationgrid.Visibility = ViewStates.Gone;
            inkannotationbottomgrid.Visibility = ViewStates.Gone;
            inkannotationbottomtoolbar.Visibility = ViewStates.Gone;
            toolBarGrid.Visibility = ViewStates.Visible;
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            opacityButton.Visibility = ViewStates.Gone;
            annotationbottomcolortoolbar.Visibility = ViewStates.Gone;
            lineView1.Visibility = ViewStates.Gone;
          
        }

        private void PdfViewerControl_CanUndoModified(object sender, CanUndoModifiedEventArgs args)
        {
            if (args.CanUndo)
            {
                undoButton.SetTextColor(fontColor);
            }
            else
            {
                undoButton.SetTextColor(Color.Gray);
            }
        }

        private void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
        {
            if (args.CanRedo)
            {
                redoButton.SetTextColor(fontColor);
            }
            else
            {
                redoButton.SetTextColor(Color.Gray);
            }
        }

        public override void Destroy()
        {
            pdfViewerControl.Unload();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            base.Destroy();
        }
    }
}