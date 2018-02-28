#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Collections.Generic;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    internal class PdfViewerViewModel : INotifyPropertyChanged
    {
        private Stream m_pdfDocumentStream;
        private bool m_isToolbarVisible = true;
        private bool m_isPickerVisible = false;
        private bool m_isSearchbarVisible = false;
        private bool m_isBottomToolbarVisible = true;
        private bool m_isSecondaryAnnotationBarVisible = false;
        private bool m_isHightlightBarVisible = false;
        private bool m_isUnderlineBarVisible = false;
        private bool m_isStrikeThroughBarVisible = false;
        private bool m_isEditAnnotationBarVisible = false;
        private bool m_isColorBarVisible = false;
        private bool m_isMainAnnotationBarVisible = false;
        private bool m_isInkBarVisible = false;
        private bool m_isThicknessBarVisible = false;
        private bool m_isOpacityBarVisible = false;
        private bool m_isInkColorBarVisible = false;
        private bool m_isEditInkBarVisible = false;
        private int m_annotationRowHeight = 50, m_colorRowHeight = 0, m_opacityRowHeight = 0;
        private int m_annotationGridHeightRequest = 0;
        private Color m_toggleColor = Color.LightGray;
        private Color m_highlightColor;
        private Color m_underlineColor;
        private Color m_strikeThroughColor;
        private Color m_deleteButtonColor;
        private Color m_inkdeleteColor;
        private Color m_inkColor;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SearchAndToolbarToggleCommand { get; set; }
        public ICommand AnnotationCommand { get; set; }
        public ICommand FileOpenCommand { get; set; }
        public ICommand HighlightCommand { get; set; }
        public ICommand UnderlineCommand { get; set; }
        public ICommand StrikeThroughCommand { get; set; }
        public ICommand ColorButtonClickedCommand { get; set; }
        public ICommand ColorCommand { get; set; }
        public ICommand AnnotationBackCommand { get; set; }
        public ICommand TextMarkupSelectedCommand { get; set; }
        public ICommand TextMarkupDeselectedCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DocumentLoadedCommand { get; set; }
        public ICommand TextMarkupCommand { get; set; }
        public ICommand InkCommand { get; set; }
        public ICommand TextMarkupBackCommand { get; set; }
        public ICommand InkBackButtonCommand { get; set; }
        public ICommand InkThicknessCommand { get; set; }
        public ICommand InkOpacityCommand { get; set; }
        public ICommand InkSelectedCommand { get; set; }
        public ICommand InkDeselectedCommand { get; set; }
        public ICommand InkDeleteCommand { get; set; }

        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                NotifyPropertyChanged("PdfDocumentStream");

            }
        }

        public int AnnotationGridHeightRequest
        {
            get { return m_annotationGridHeightRequest; }
            set
            {
                m_annotationGridHeightRequest = value;
                NotifyPropertyChanged("AnnotationGridHeightRequest");
            }
        }
        public Color DeleteButtonColor
        {
            get { return m_deleteButtonColor; }
            set
            {
                m_deleteButtonColor = value;
                NotifyPropertyChanged("DeleteButtonColor");
            }
        }

        public Color ToggleColor
        {
            get { return m_toggleColor; }
            set
            {
                m_toggleColor = value;
                NotifyPropertyChanged("ToggleColor");

            }
        }

        public bool IsColorBarVisible
        {
            get
            {
                return m_isColorBarVisible;
            }
            set
            {
                m_isColorBarVisible = value;
                NotifyPropertyChanged("IsColorBarVisible");
            }
        }

        public bool IsThicknessBarVisible
        {
            get
            {
                return m_isThicknessBarVisible;
            }
            set
            {
                m_isThicknessBarVisible = value;
                NotifyPropertyChanged("IsThicknessBarVisible");
            }
        }

        public bool IsInkColorBarVisible
        {
            get { return m_isInkColorBarVisible; }
            set
            {
                m_isInkColorBarVisible = value;
                NotifyPropertyChanged("IsInkColorBarVisible");
            }
        }

        public bool IsOpacityBarVisible
        {
            get
            {
                return m_isOpacityBarVisible;
            }
            set
            {
                m_isOpacityBarVisible = value;
                NotifyPropertyChanged("IsOpacityBarVisible");
            }
        }

        public bool IsMainAnnotationBarVisible
        {
            get
            {
                return m_isMainAnnotationBarVisible;
            }
            set
            {
                m_isMainAnnotationBarVisible = value;
                NotifyPropertyChanged("IsMainAnnotationBarVisible");
            }
        }

        public bool IsToolbarVisible
        {
            get { return m_isToolbarVisible; }
            set
            {
                if (m_isToolbarVisible == value)
                    return;
                m_isToolbarVisible = value;
                NotifyPropertyChanged("IsToolbarVisible");
            }
        }

        public bool IsEditAnnotationBarVisible
        {
            get { return m_isEditAnnotationBarVisible; }
            set
            {
                m_isEditAnnotationBarVisible = value;
                NotifyPropertyChanged("IsEditAnnotationBarVisible");
            }
        }

        public int AnnotationRowHeight
        {
            get { return m_annotationRowHeight; }
            set
            {
                m_annotationRowHeight = value;
                NotifyPropertyChanged("AnnotationRowHeight");
            }
        }

        public int OpacityRowHeight
        {
            get { return m_opacityRowHeight; }
            set
            {
                m_opacityRowHeight = value;
                NotifyPropertyChanged("OpacityRowHeight");
            }
        }

        public int ColorRowHeight
        {
            get { return m_colorRowHeight; }
            set
            {
                m_colorRowHeight = value;
                NotifyPropertyChanged("ColorRowHeight");
            }
        }

        public bool IsSecondaryAnnotationBarVisible
        {
            get { return m_isSecondaryAnnotationBarVisible; }
            set
            {
                if (m_isSecondaryAnnotationBarVisible == value) return;
                m_isSecondaryAnnotationBarVisible = value;
                NotifyPropertyChanged("IsSecondaryAnnotationBarVisible");
            }
        }

        public bool IsHighlightBarVisible
        {
            get { return m_isHightlightBarVisible; }
            set
            {
                if (m_isHightlightBarVisible == value) return;
                m_isHightlightBarVisible = value;
                NotifyPropertyChanged("IsHighlightBarVisible");
            }
        }

        public bool IsUnderlineBarVisible
        {
            get { return m_isUnderlineBarVisible; }
            set
            {
                if (m_isUnderlineBarVisible == value) return;
                m_isUnderlineBarVisible = value;
                NotifyPropertyChanged("IsUnderlineBarVisible");
            }
        }

        public Color InkDeleteColor
        {
            get { return m_inkdeleteColor; }
            set
            {
                m_inkdeleteColor = value;
                NotifyPropertyChanged("InkDeleteColor");
            }
        }

        public bool IsStrikeThroughBarVisible
        {
            get { return m_isStrikeThroughBarVisible; }
            set
            {
                if (m_isStrikeThroughBarVisible == value) return;
                m_isStrikeThroughBarVisible = value;
                NotifyPropertyChanged("IsStrikeThroughBarVisible");
            }
        }
        public Color HighlightColor
        {
            get { return m_highlightColor; }
            set
            {
                if (m_highlightColor == value) return;
                m_highlightColor = value;
                NotifyPropertyChanged("HighlightColor");
            }
        }

        public Color InkColor
        {
            get { return m_inkColor; }
            set
            {
                m_inkColor = value;
                NotifyPropertyChanged("InkColor");
            }
        }

        public Color UnderlineColor
        {
            get { return m_underlineColor; }
            set
            {
                if (m_underlineColor == value) return;
                m_underlineColor = value;
                NotifyPropertyChanged("UnderlineColor");
            }
        }

        public Color StrikeThroughColor
        {
            get { return m_strikeThroughColor; }
            set
            {
                if (m_strikeThroughColor == value) return;
                m_strikeThroughColor = value;
                NotifyPropertyChanged("StrikeThroughColor");
            }
        }
        public bool IsSearchbarVisible
        {
            get { return m_isSearchbarVisible; }
            set
            {
                if (m_isSearchbarVisible == value)
                    return;
                m_isSearchbarVisible = value;
                NotifyPropertyChanged("IsSearchbarVisible");
            }
        }

        public bool IsBottomToolbarVisible
        {
            get { return m_isBottomToolbarVisible; }
            set
            {
                if (m_isBottomToolbarVisible == value)
                    return;
                m_isBottomToolbarVisible = value;
                NotifyPropertyChanged("IsBottomToolbarVisible");
            }
        }

        public bool IsEditInkBarVisible
        {
            get { return m_isEditInkBarVisible; }
            set
            {
                m_isEditInkBarVisible = value;
                NotifyPropertyChanged("IsEditInkBarVisible");
            }
        }
        public bool IsPickerVisible
        {
            get { return m_isPickerVisible; }
            set
            {
                m_isPickerVisible = value;
                NotifyPropertyChanged("IsPickerVisible");
            }
        }

        private string m_searchedText = string.Empty;
        public string SearchedText
        {
            get { return m_searchedText; }
            set
            {
                m_searchedText = value;
                if (m_searchedText != string.Empty)
                {
                    IsCancelVisible = true;
                }
                else
                {
                    IsCancelVisible = false;
                }
                NotifyPropertyChanged("SearchedText");
            }
        }

        private bool m_isCancelVisible = false;
        public bool IsCancelVisible
        {
            get { return m_isCancelVisible; }
            set
            {
                if (m_isCancelVisible == value)
                    return;
                m_isCancelVisible = value;
                NotifyPropertyChanged("IsCancelVisible");
            }
        }

        public bool IsInkBarVisible
        {
            get { return m_isInkBarVisible; }
            set
            {
                m_isInkBarVisible = value;
                NotifyPropertyChanged("IsInkBarVisible");
            }
        }

        private Document m_selectedItem;
        public Document SelectedItem
        {
            get
            {
                return m_selectedItem;
            }
            set
            {
                if (m_selectedItem == value)
                {
                    IsPickerVisible = false;
                    return;
                }
                m_selectedItem = value;
                PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.SfPdfViewer.Assets." + m_selectedItem.FileName + ".pdf");
                NotifyPropertyChanged("SelectedItem");
                IsPickerVisible = false;
            }
        }


        private IList<Document> m_pdfDocumentCollection;
        public IList<Document> PdfDocumentCollection
        {
            get
            {
                if (m_pdfDocumentCollection == null)
                {
                    m_pdfDocumentCollection = new List<Document> { new Document("F# Succinctly"), new Document("GIS Succinctly"), new Document("HTTP Succinctly"), new Document("JavaScript Succinctly") };
                }
                return m_pdfDocumentCollection;
            }
            set
            {
                if (m_pdfDocumentCollection == value)
                    return;
                m_pdfDocumentCollection = value;
                NotifyPropertyChanged("PdfDocumentCollection");
            }
        }
        public PdfViewerViewModel()
        {
            m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.SfPdfViewer.Assets.F# Succinctly.pdf");
            SearchAndToolbarToggleCommand = new Command<object>(OnSearchAndToolbarToggleCommand, CanExecute);
            FileOpenCommand = new Command<object>(OnFileOpenedCommand, CanExecute);
            AnnotationCommand = new Command<object>(OnAnnotationIconClickedCommand, CanExecute);
            HighlightCommand = new Command<object>(OnHighlightCommand, CanExecute);
            UnderlineCommand = new Command<object>(OnUnderlineCommand, CanExecute);
            StrikeThroughCommand = new Command<object>(OnStrikeThroughCommand, CanExecute);
            AnnotationBackCommand = new Command<object>(OnAnnotationBackCommand, CanExecute);
            ColorButtonClickedCommand = new Command<object>(OnColorButtonClickedCommand, CanExecute);
            ColorCommand = new Command<object>(OnColorCommand, CanExecute);
            TextMarkupSelectedCommand = new Command<object>(OnTextMarkupSelectedCommand, CanExecute);
            TextMarkupDeselectedCommand = new Command<object>(OnTextMarkupDeselectedCommand, CanExecute);
            DeleteCommand = new Command<object>(OnDeleteCommand, CanExecute);
            DocumentLoadedCommand = new Command<object>(OnDocumentLoadedCommand, CanExecute);
            TextMarkupCommand = new Command<object>(OnTextMarkupCommand, CanExecute);
            InkCommand = new Command<object>(OnInkCommand, CanExecute);
            TextMarkupBackCommand = new Command<object>(OnTextMarkupBackCommand, CanExecute);
            InkBackButtonCommand = new Command<object>(OnInkBackButtonCommand, CanExecute);
            InkThicknessCommand = new Command<object>(OnInkThicknessCommand, CanExecute);
            InkOpacityCommand = new Command<object>(OnInkOpacityCommand, CanExecute);
            InkSelectedCommand = new Command<object>(OnInkSelectedCommand, CanExecute);
            InkDeselectedCommand = new Command<object>(OnInkDeselectedCommand, CanExecute);
        }

        private void OnInkDeselectedCommand(object parameter)
        {
            if (IsEditInkBarVisible)
            {
                AnnotationGridHeightRequest = 0;
                IsInkBarVisible = false;
                IsEditInkBarVisible = false;
                IsThicknessBarVisible = false;
                IsInkColorBarVisible = false;
                IsOpacityBarVisible = false;
            }
        }

        private void OnInkOpacityCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 100)
            {
                AnnotationGridHeightRequest = 150;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                OpacityRowHeight = 50;
                IsOpacityBarVisible = true;
            }
            else
            {
                AnnotationGridHeightRequest = 100;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                OpacityRowHeight = 1;
                IsOpacityBarVisible = false;
            }

        }

        private void OnInkThicknessCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 100;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                IsThicknessBarVisible = true;
            }
            else
            {
                if (IsInkColorBarVisible)
                {
                    AnnotationGridHeightRequest = 100;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 50;
                    IsInkColorBarVisible = false;
                    IsThicknessBarVisible = true;
                    IsOpacityBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    IsThicknessBarVisible = false;
                }
            }
        }
        private void OnInkBackButtonCommand(object parameter)
        {
            IsInkBarVisible = false;
            IsColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsOpacityBarVisible = false;
            IsInkColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            ColorRowHeight = 1;
            IsMainAnnotationBarVisible = true;
            IsToolbarVisible = true;
        }
        private void OnTextMarkupBackCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = true;
        }
        private void OnTextMarkupCommand(object parameter)
        {
            IsMainAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = true;
        }

        private void OnInkCommand(object parameter)
        {
            IsMainAnnotationBarVisible = false;
            IsToolbarVisible = false;
            IsInkBarVisible = true;
        }

        private void OnDeleteCommand(object parameter)
        {
            IsEditAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkColorBarVisible = false;
            IsThicknessBarVisible = false;
            IsOpacityBarVisible = false;
            AnnotationGridHeightRequest = 0;
        }

        private void OnDocumentLoadedCommand(object parameter)
        {
            AnnotationGridHeightRequest = 0;
            IsSecondaryAnnotationBarVisible = false;
            IsColorBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsInkBarVisible = false;
            IsInkColorBarVisible = false;
            IsEditInkBarVisible = false;
            IsThicknessBarVisible = false;
            IsOpacityBarVisible = false;
            IsMainAnnotationBarVisible = false;
        }
        private void OnTextMarkupSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditAnnotationBarVisible = true;
        }

        private void OnTextMarkupDeselectedCommand(object parameter)
        {
			if (IsEditAnnotationBarVisible)
			{
				AnnotationGridHeightRequest = 0;
				IsEditAnnotationBarVisible = false;
			}
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }

        private void OnSearchAndToolbarToggleCommand(object destinationPageParam)
        {
            IsToolbarVisible = !IsToolbarVisible;
            IsSearchbarVisible = !IsSearchbarVisible;
            IsPickerVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsColorBarVisible = false;
            IsHighlightBarVisible = IsUnderlineBarVisible = IsStrikeThroughBarVisible = false;
			IsEditAnnotationBarVisible = false;
            AnnotationGridHeightRequest = 0;
            SearchedText = string.Empty;
        }

        private void OnFileOpenedCommand(object openedFile)
        {
            IsPickerVisible = !IsPickerVisible;
        }

        private void OnAnnotationIconClickedCommand(object parameter)
        {
            IsSearchbarVisible = false;
            if (AnnotationGridHeightRequest == 0)
            {
                AnnotationGridHeightRequest = 50;
                IsMainAnnotationBarVisible = true;
            }
            else
            {
                if (!IsEditAnnotationBarVisible)
                {
                    AnnotationGridHeightRequest = 0;
                    IsMainAnnotationBarVisible = false;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    IsMainAnnotationBarVisible = true;
                }
            }

            AnnotationRowHeight = 50;
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsEditAnnotationBarVisible = false;
            IsSecondaryAnnotationBarVisible = false;
            IsEditInkBarVisible = false;
            IsInkBarVisible = false;
            IsPickerVisible = false;
        }

        private void OnHighlightCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsHighlightBarVisible = true;
        }

        private void OnUnderlineCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = true;
        }

        private void OnStrikeThroughCommand(object parameter)
        {
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = true;
        }

        private void OnAnnotationBackCommand(object parameter)
        {
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            IsHighlightBarVisible = false;
            IsUnderlineBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsSecondaryAnnotationBarVisible = true;
        }

        private void OnColorButtonClickedCommand(object parameter)
        {
            if (AnnotationGridHeightRequest == 50)
            {
                AnnotationGridHeightRequest = 100;
                AnnotationRowHeight = 50;
                ColorRowHeight = 50;
                if (IsHighlightBarVisible || IsUnderlineBarVisible || IsStrikeThroughBarVisible || IsEditAnnotationBarVisible)
                    IsColorBarVisible = true;
                else if (IsInkBarVisible || IsEditInkBarVisible)
                    IsInkColorBarVisible = true;
            }
            else
            {
                if (IsThicknessBarVisible)
                {
                    IsThicknessBarVisible = false;
                    AnnotationGridHeightRequest = 100;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 50;
                    if (IsHighlightBarVisible || IsUnderlineBarVisible || IsStrikeThroughBarVisible || IsEditAnnotationBarVisible)
                        IsColorBarVisible = true;
                    else if (IsInkBarVisible || IsEditInkBarVisible)
                        IsInkColorBarVisible = true;
                }
                else
                {
                    AnnotationGridHeightRequest = 50;
                    AnnotationRowHeight = 50;
                    ColorRowHeight = 1;
                    if (IsHighlightBarVisible || IsUnderlineBarVisible || IsStrikeThroughBarVisible || IsEditAnnotationBarVisible)
                        IsColorBarVisible = false;
                    else if (IsInkBarVisible || IsEditInkBarVisible)
                        IsInkColorBarVisible = false;
                    IsOpacityBarVisible = false;
                    IsThicknessBarVisible = false;
                }
            }
        }

        private void OnInkSelectedCommand(object parameter)
        {
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            IsSecondaryAnnotationBarVisible = false;
            IsHighlightBarVisible = false;
            IsStrikeThroughBarVisible = false;
            IsUnderlineBarVisible = false;
            IsMainAnnotationBarVisible = false;
            IsEditInkBarVisible = true;
        }

        private void OnColorCommand(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Cyan":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.FromHex("#00FFFF");
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.FromHex("#00FFFF");
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.FromHex("#00FFFF");
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.FromHex("00FFFF");
                        if (IsInkBarVisible)
                            InkColor = Color.FromHex("00FFFF");
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.FromHex("00FFFF");
                    }
                    break;

                case "Green":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.Green;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.Green;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.Green;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.Green;
                        if (IsInkBarVisible)
                            InkColor = Color.Green;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.Green;
                    }
                    break;

                case "Yellow":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.Yellow;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.Yellow;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.Yellow;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.Yellow;
                        if (IsInkBarVisible)
                            InkColor = Color.Yellow;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.Yellow;
                    }
                    break;

                case "Magenta":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.FromHex("#FF00FF");
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.FromHex("#FF00FF");
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.FromHex("#FF00FF");
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.FromHex("#FF00FF");
                        if (IsInkBarVisible)
                            InkColor = Color.FromHex("#FF00FF");
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.FromHex("#FF00FF");
                    }
                    break;

                case "Black":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.Black;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.Black;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.Black;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.Black;
                        if (IsInkBarVisible)
                            InkColor = Color.Black;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.Black;
                    }
                    break;

                case "White":
                    {
                        if (IsHighlightBarVisible)
                            HighlightColor = Color.White;
                        if (IsStrikeThroughBarVisible)
                            StrikeThroughColor = Color.White;
                        if (IsUnderlineBarVisible)
                            UnderlineColor = Color.White;
                        if (IsEditAnnotationBarVisible)
                            DeleteButtonColor = Color.White;
                        if (IsInkBarVisible)
                            InkColor = Color.White;
                        if (IsEditInkBarVisible)
                            InkDeleteColor = Color.White;
                    }
                    break;

            }
            AnnotationGridHeightRequest = 50;
            AnnotationRowHeight = 50;
            ColorRowHeight = 1;
            IsColorBarVisible = false;
            IsInkColorBarVisible = false;
            IsOpacityBarVisible = false;
        }

    }

}
