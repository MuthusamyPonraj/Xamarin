#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
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
    public class PdfViewerDemo : SamplePage
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
        Stopwatch stopwatch;
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
        public override View GetSampleContent(Context context)
        {
            fontColor = new Color(0, 118, 255);
            Typeface font = Typeface.CreateFromAsset(context.Assets, "PDFViewer_Android.ttf");
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            pdfViewerContext = context;
            mainView = (LinearLayout)layoutInflater.Inflate(Resource.Layout.PDFViewer, null);
            pageNumberEntry = (EditText)mainView.FindViewById(Resource.Id.pagenumberentry);
            pageNumberEntry.KeyPress += PageNumberEntry_KeyPress;
            pageCountText = (TextView)mainView.FindViewById(Resource.Id.pagecounttext);
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
            undomarginParams.SetMargins((context.Resources.DisplayMetrics.WidthPixels) / 2 - 60, 10, 0, 14);
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
            marginParams.SetMargins((context.Resources.DisplayMetrics.WidthPixels) / 2 + 60, 10, 0, 14);
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
            backupDocumentName = "GIS Succinctly";
            Stream docStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + backupDocumentName + ".pdf");
            dialog = new ProgressDialog(context);
            stopwatch = new Stopwatch();
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
            highlightModeButton = (Button)mainView.FindViewById(Resource.Id.highlightbutton);
            highlightModeButton.Typeface = font;
            highlightModeButton.SetTextColor(fontColor);
            highlightModeButton.TextSize = textSize;
            highlightModeButton.Click += HighlightModeButton_Click;
            underlineModeButton = (Button)mainView.FindViewById(Resource.Id.underlinebutton);
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
            annotationButton = (Button)mainView.FindViewById(Resource.Id.annotation);
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
            pdfViewerControl.TextMatchFound += PdfViewerControl_TextMatchFound;
            clearSearchButton = mainView.FindViewById<Button>(Resource.Id.clearSearchResult);
            clearSearchButton.Typeface = font;
            clearSearchButton.SetTextColor(fontColor);
            clearSearchButton.TextSize = textSize;
            clearSearchButton.Click += ClearSearchButton_Click;
            pdfViewerControl.SearchInitiated += PdfViewerControl_SearchInitiated;
            pdfViewerControl.SearchCompleted += PdfViewerControl_SearchProgressCompleted;
            pdfViewerControl.TextMarkupSelected += PdfViewerControl_TextMarkupSelected;
            pdfViewerControl.TextMarkupDeselected += PdfViewerControl_TextMarkupDeselected;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
            pdfViewerControl.LoadDocument(docStream);

            return mainView;
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
		    pdfViewerControl.AnnotationMode = AnnotationMode.None;
            annotationToolBar.Visibility = ViewStates.Gone;
            IsAnnotationModeSelected = false;
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
            isTextFound = false;
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
                    stopwatch.Start();
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
                isTextFound = false;
                clearSearchButton.Visibility = ViewStates.Invisible;
                InputMethodManager inputMethodManager = (InputMethodManager)mainView.Context.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(mainView.WindowToken, HideSoftInputFlags.None);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
            annotationToolBar.Visibility = ViewStates.Gone;
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
        ProgressDialog dialog;
        bool isTextFound;

        private void PdfViewerControl_TextMatchFound(object sender, TextMatchFoundEventArgs args)
        {
            stopwatch.Stop();
            timerStarted = false;
            if (!stopwatch.IsRunning)
            {
                if (dialog != null)
                {
                    dialog.Hide();
                }
            }
        }

        private void PdfViewerControl_SearchProgressCompleted(object sender, TextSearchCompletedEventArgs args)
        {
            stopwatch.Stop();
            timerStarted = false;
            if (!stopwatch.IsRunning)
            {
                if (dialog != null)
                {
                    dialog.Hide();
                    if (args.NoMatchFound)
                    {
                        var toast = Toast.MakeText(pdfViewerContext,  "\"" + args.TargetText + "\"" +" not found.", ToastLength.Short);
                        toast.SetGravity(GravityFlags.Center, 0, 0);
                        toast.Show();
                    }
                    else if (args.NoMoreOccurrence)
                    {
                        var toast = Toast.MakeText(pdfViewerContext, "No more occurrences.", ToastLength.Short);
                        toast.SetGravity(GravityFlags.Center, 0, 0);
                        toast.Show();
                    }
                    else if (!isTextFound)
                    {
                        isTextFound = true;
                    }
                }
            }
        }

        bool timerStarted = false;
        private void PdfViewerControl_SearchInitiated(object sender, TextSearchInitiatedEventArgs args)
        {
            if (!stopwatch.IsRunning)
                stopwatch.Start();
            else
            {
                stopwatch.Stop();
            }
            if (stopwatch.ElapsedMilliseconds > 2000 && !timerStarted)
            {
                timerStarted = true;
                dialog.SetMessage("Search Progress...");
                dialog.Show();
            }
        }

        #endregion

        private void PdfViewerControl_PageChanged(object sender, PageChangedEventArgs args)
        {
            pageNumberEntry.Text = args.PageNumber.ToString();
        }

        private void PdfViewerControl_DocumentLoaded(object sender, EventArgs args)
        {
            pageNumberEntry.Text = pdfViewerControl.PageNumber.ToString();
            pageCountText.Text = pdfViewerControl.PageCount.ToString();
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
            annotationButton.Text = "\uE71F";
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
            annotationButton.Text = "\uE700";
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Underline;
        }

        private void HighlightModeButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Visible;
            annotationButton.Visibility = ViewStates.Visible;
            annotationButton.Text = "\uE701";
            annotationBackButton.Visibility = ViewStates.Visible;
            removeButton.Visibility = ViewStates.Gone;
            annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
            pdfViewerControl.AnnotationMode = AnnotationMode.Highlight;


        }

        private void AnnotationModeButton_Click(object sender, EventArgs e)
        {
            if (!IsAnnotationModeSelected)
            {
                annotationToolBar.Visibility = ViewStates.Visible;
                annotationBarGrid.Visibility = ViewStates.Visible;
                annotationBackGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                toolBarGrid.Visibility = ViewStates.Visible;
                searchBarGrid.Visibility = ViewStates.Gone;
                IsAnnotationModeSelected = true;
            }
            else
            {
                pdfViewerControl.AnnotationMode = AnnotationMode.None;
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationBarGrid.Visibility = ViewStates.Gone;
                annotationBackGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                annotationColorBarGrid.Visibility = ViewStates.Gone;
                searchBarGrid.Visibility = ViewStates.Gone;
                IsAnnotationModeSelected = false;
            }
        }

        private void AnnotationColorButton_Click(object sender, EventArgs e)
        {
            annotationBackGrid.Visibility = ViewStates.Gone;
            annotationColorBarGrid.Visibility = ViewStates.Visible;
        }

        private void BlackcolorButton_Click(object sender, EventArgs e)
        {
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);

            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Black;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Black);
                annotation.Settings.Color = Android.Graphics.Color.Black;
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
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);

            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.White;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.White);
                annotation.Settings.Color = Android.Graphics.Color.White;
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
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);

            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Magenta;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Magenta);
                annotation.Settings.Color = Android.Graphics.Color.Magenta;
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
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);

            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Green;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Green);
                annotation.Settings.Color = Android.Graphics.Color.Green;
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
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);

            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Yellow;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Yellow);
                annotation.Settings.Color = Android.Graphics.Color.Yellow;
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
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);

            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
            {
                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Android.Graphics.Color.Cyan;
                annotationColorButton.SetBackgroundColor(pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            }
            if (pdfViewerControl.AnnotationMode == AnnotationMode.None && annotation != null)
            {
                annotationColorButton.SetBackgroundColor(Android.Graphics.Color.Cyan);
                annotation.Settings.Color = Android.Graphics.Color.Cyan;
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
            string fileName = backupDocumentName+".pdf";
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
            if (IsAnnotationModeSelected)
            {
                annotationToolBar.Visibility = ViewStates.Visible;
                annotationBackGrid.Visibility = ViewStates.Visible;
            }
            else
            {
                annotationToolBar.Visibility = ViewStates.Gone;
                annotationBackGrid.Visibility = ViewStates.Gone;
            }
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

    }
}