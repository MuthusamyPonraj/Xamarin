#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using SampleBrowser.Core;
using System.IO;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    public partial class PDFViewerCustomToolbar_Desktop : SampleView
    {
        bool m_isPageInitiated = false;
        bool isHighlightClicked = true;
        bool isUnderlineClicked = true;
        bool isStrikeThroughClicked = true;
        bool isAnnotationEditMode = false;
        bool canSetValueToSource = true;
        TextMarkupAnnotation selectedAnnotation;
        InkAnnotation selectedInkAnnotation;
        public PDFViewerCustomToolbar_Desktop()
        {
            InitializeComponent();
            if (Application.Current.MainPage != null)
            {
                toolbar.WidthRequest = Application.Current.MainPage.Width;
                searchBar.WidthRequest = Application.Current.MainPage.Width;
            }
            textSearchEntry.TextChanged += TextSearchEntry_TextChanged;
            pdfViewerControl.Toolbar.Enabled = false;
            pdfViewerControl.UnhandledConditionOccurred += PdfViewerControl_UnhandledCondition;
            pdfViewerControl.TextMatchFound += PdfViewerControl_TextMatchFound;
            pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
            pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
            pdfViewerControl.CanUndoInkModified += PdfViewerControl_CanUndoInkModified;
            pdfViewerControl.CanRedoInkModified += PdfViewerControl_CanRedoInkModified;
            (BindingContext as PdfViewerViewModel).HighlightColor = pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color;
            (BindingContext as PdfViewerViewModel).UnderlineColor = pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color;
            (BindingContext as PdfViewerViewModel).StrikeThroughColor = pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color;
            (BindingContext as PdfViewerViewModel).InkColor = pdfViewerControl.AnnotationSettings.Ink.Color;
            opacitySlider.Value = pdfViewerControl.AnnotationSettings.Ink.Opacity*100;
            opacitySlider.ValueChanged += OpacitySlider_ValueChanged;
            thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Ink.Thickness;
            thicknessSlider.ValueChanged += ThicknessSlider_ValueChanged;
            m_isPageInitiated = true;
        }

        private void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {
            selectedInkAnnotation = null;
            isAnnotationEditMode = false;
            canSetValueToSource = false;
            thicknessSlider.Value = pdfViewerControl.AnnotationSettings.Ink.Thickness;
            opacitySlider.Value = pdfViewerControl.AnnotationSettings.Ink.Opacity*100;
        }

        private void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
            selectedInkAnnotation = sender as InkAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).InkDeleteColor = new Color(selectedInkAnnotation.Settings.Color.R, selectedInkAnnotation.Settings.Color.G, selectedInkAnnotation.Settings.Color.B);
            thicknessSlider.Value = selectedInkAnnotation.Settings.Thickness;
            opacitySlider.Value = selectedInkAnnotation.Settings.Opacity*100;
            canSetValueToSource = true;
        }

        private void ThicknessSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedInkAnnotation != null)
                    selectedInkAnnotation.Settings.Thickness = (float)e.NewValue;
                else
                    pdfViewerControl.AnnotationSettings.Ink.Thickness = (float)e.NewValue;
            }
            sliderValue.Text = ((Int32)e.NewValue).ToString();
            canSetValueToSource = true;
        }

        private void OpacitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (canSetValueToSource)
            {
                if (selectedInkAnnotation != null)
                    selectedInkAnnotation.Settings.Opacity = (float)(e.NewValue / 100);
                else
                    pdfViewerControl.AnnotationSettings.Ink.Opacity = (float)(e.NewValue / 100);
            }
            opacityValue.Text = ((int)e.NewValue).ToString()+"%";
            canSetValueToSource = true;
        }

        private void InkDeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedInkAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedInkAnnotation);
                selectedInkAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

        private void InkButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
        }

        private void UndoInk_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.UndoInk();
        }

        private void RedoInk_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.RedoInk();
        }

        private void EndSession_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.EndInkSession(true);
        }

        private void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
            if (args.CanRedoInk)
            {
                inkRedoBtn.TextColor = Color.FromHex("#0076FF");
                inkRedoBtn.InputTransparent = false;
            }
            else
            {
                inkRedoBtn.TextColor = Color.DarkGray;
                inkRedoBtn.InputTransparent = true;
            }
        }

        private void PdfViewerControl_CanUndoInkModified(object sender, CanUndoInkModifiedEventArgs args)
        {
            if (args.CanUndoInk)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    inkUndoBtn.TextColor = Color.FromHex("#0076FF");
                    inkUndoBtn.InputTransparent = false;
                });
            }
            else
            {
                inkUndoBtn.TextColor = Color.DarkGray;
                inkUndoBtn.InputTransparent = true;
            }
        }

        private void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
        {
            if (args.CanRedo)
            {
                redoButton.TextColor = Color.FromHex("#0076FF");
                redoButton.InputTransparent = false;
            }
            else
            {
                redoButton.TextColor = Color.FromHex("#808080");
                redoButton.InputTransparent = true;
            }
        }

        private void PdfViewerControl_CanUndoModified(object sender, CanUndoModifiedEventArgs args)
        {
            if (args.CanUndo)
            {
                undoButton.TextColor = Color.FromHex("#0076FF");
                undoButton.InputTransparent = false;
            }
            else
            {
                undoButton.TextColor = Color.FromHex("#808080");
                undoButton.InputTransparent = true;
            }
        }


        private void PdfViewerControl_TextMarkupSelected(object sender, TextMarkupSelectedEventArgs args)
        {
            selectedAnnotation = sender as TextMarkupAnnotation;
            isAnnotationEditMode = true;
            (BindingContext as PdfViewerViewModel).DeleteButtonColor = new Color(selectedAnnotation.Settings.Color.R, selectedAnnotation.Settings.Color.G, selectedAnnotation.Settings.Color.B);
        }

        private void PdfViewerControl_TextMarkupDeselected(object sender, TextMarkupDeselectedEventArgs args)
        {
            selectedAnnotation = null;
            isAnnotationEditMode = false;
        }

        private void InkBackButton_Clicked(object sender, EventArgs e)
        {
            pdfViewerControl.AnnotationMode = AnnotationMode.None;
        }
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (selectedAnnotation != null)
            {
                pdfViewerControl.RemoveAnnotation(selectedAnnotation);
                selectedAnnotation = null;
                isAnnotationEditMode = false;
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string filePath = DependencyService.Get<ISave>().Save(pdfViewerControl.SaveDocument() as MemoryStream);
            string message = "The PDF has been saved to " + filePath;
            DependencyService.Get<IAlertView>().Show(message);
        }

        private void ColorButton_Clicked(object sender, EventArgs e)
        {
            switch ((sender as Button).CommandParameter.ToString())
            {
                case "Cyan":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.FromHex("#00FFFF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.FromHex("#00FFFF");
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.FromHex("#00FFFF");
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.FromHex("#00FFFF");
                        }
                    }
                    break;

                case "Green":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.Green;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.Green;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.Green;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.Green;
                        }
                    }
                    break;

                case "Yellow":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.Yellow;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.Yellow;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.Yellow;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.Yellow;
                        }
                    }
                    break;

                case "Magenta":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.FromHex("#FF00FF");
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.FromHex("#FF00FF");
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.FromHex("#FF00FF");
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.FromHex("#FF00FF");
                        }
                    }
                    break;

                case "Black":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.Black;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.Black;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.Black;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.Black;
                        }
                    }
                    break;

                case "White":
                    {
                        if (!isAnnotationEditMode)
                        {
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                                pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = Color.White;
                            if (pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                                pdfViewerControl.AnnotationSettings.Ink.Color = Color.White;
                        }
                        else
                        {
                            if (selectedAnnotation != null)
                                selectedAnnotation.Settings.Color = Color.White;
                            if (selectedInkAnnotation != null)
                                selectedInkAnnotation.Settings.Color = Color.White;
                        }
                    }
                    break;
            }
        }

        void PdfViewerControl_TextMatchFound(object sender, TextMatchFoundEventArgs args)
        {
            searchNextButton.IsVisible = true;
            searchPreviousButton.IsVisible = true;
        }

        private void PdfViewerControl_UnhandledCondition(object sender, UnhandledConditionEventArgs args)
        {
            DependencyService.Get<IAlertView>().Show(args.Description);
        }


        private void TextSearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as Entry).Text == string.Empty)
            {
                pdfViewerControl.CancelSearch();
                searchNextButton.IsVisible = false;
                searchPreviousButton.IsVisible = false;
            }
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            textSearchEntry.Focus();
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Application.Current.MainPage != null && Application.Current.MainPage.Width > 0 && m_isPageInitiated)
            {
                toolbar.WidthRequest = Application.Current.MainPage.Width;
                searchBar.WidthRequest = Application.Current.MainPage.Width;
            }
        }
    }

}

