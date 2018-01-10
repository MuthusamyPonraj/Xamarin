#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Reflection;
using CoreGraphics;
using Syncfusion.SfPdfViewer.iOS;
using UIKit;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Foundation;
namespace SampleBrowser
{
	class PdfViewerDemo : SampleView
	{
		private SfPdfViewer pdfViewerControl;
		private const float DefaultToolbarHeight = 50f;
		private UIView parentView;
		private UIView toolbar;
		UITextField pageNumberField = new UITextField();
		UILabel totalPageLabel = new UILabel();
		UIButton undoButton = new UIButton();
		UIButton redoButton = new UIButton();
		UISearchBar searchBar = new UISearchBar();
		UIButton searchButton = new UIButton();
		UIButton backButton = new UIButton();
		UIButton searchNextButton = new UIButton();
		UIButton searchPreviousButton = new UIButton();
		UIButton fileButton = new UIButton();
		CGRect toolBarFrame = new CGRect();
		CGRect bottomToolbarFrame = new CGRect();
		CGRect annotationFrame = new CGRect();
		CGRect separateAnnotationFrame = new CGRect();
		CGRect colorFrame = new CGRect();
		bool isLoaded = false;
		UIView toolBar = new UIView();
		UIView searchToolBar = new UIView();
		ActivityIndicator activityDialog;
		DropDownMenu dropDownMenu;
		UIAlertView popUpAlertView;
		Stream fileStream;
		UIView bottomToolBar = new UIView();
		UIButton textMarkupAnnotationButton = new UIButton();
		UIView annotationToolbar = new UIView();
		UIButton highlightAnnotationButton = new UIButton();
		UIButton underlineAnnotationButton = new UIButton();
		UIButton strikeOutAnnotationButton = new UIButton();
		UIView highlightToolbar = new UIView();
		UIView underlineToolbar = new UIView();
		UIView strikeOutToolbar = new UIView();
		UIButton toolbarBackbutton = new UIButton();
		UIButton colorButton = new UIButton();
		UIView colorToolbar = new UIView();
		UIButton deleteButton = new UIButton();
		UIButton saveButton = new UIButton();
		UIButton highlightEnable = new UIButton();
		UIButton underlineEnable = new UIButton();
		UIButton strikeEnable = new UIButton();
		UIButton redButton = new UIButton();
		UIButton blueButton = new UIButton();
		UIButton yellowButton = new UIButton();
		UIButton blackButton = new UIButton();
		UIButton greenButton = new UIButton();
		UIButton grayButton = new UIButton();
		UIButton whiteButton = new UIButton();
		UIAlertView pagePopupView = new UIAlertView();
		bool isAnnotationToolbarVisible;
		IAnnotation annotation;
		AlertViewDelegate alertViewDelegate;
		UIFont highFont;
		bool IsSelected;

		public PdfViewerDemo()
		{
			parentView = new UIView(this.Frame);
			var tap = new UITapGestureRecognizer(OnSingleTap);
			tap.CancelsTouchesInView = false; //for iOS5
			highFont = UIFont.FromName("PDFViewer_IOS", 30);
			this.AddGestureRecognizer(tap);
			pdfViewerControl = new SfPdfViewer();
			pdfViewerControl.PageChanged += ViewerControl_PageChanged;
			pdfViewerControl.SearchCompleted += PdfViewerControl_SearchCompleted;
			pdfViewerControl.TextMarkupSelected += PdfViewerControl_TextMarkupSelected;
			pdfViewerControl.TextMarkupDeselected += PdfViewerControl_TextMarkupDeselected;
			pdfViewerControl.CanUndoModified += PdfViewerControl_CanUndoModified;
			pdfViewerControl.CanRedoModified += PdfViewerControl_CanRedoModified;
			pageNumberField.Text = "1";
			CreateTopToolbar();
			bottomToolBar = CreateBottomToolbar();
			toolbar = toolBar;
			parentView.AddSubview(pdfViewerControl);
			AddSubview(parentView);
			AddSubview(toolbar);
			AddSubview(bottomToolBar);
			activityDialog = new ActivityIndicator();
			activityDialog.Frame = new CGRect(UIScreen.MainScreen.Bounds.Width / 2 - 125, UIScreen.MainScreen.Bounds.Height / 2 - 50, 250, 100);
			popUpAlertView = new UIAlertView();
			dropDownMenu = CreateDropDownMenu();

			dropDownMenu.DropDownMenuItemChanged += (e, a) =>
			{
				fileStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets." + a.DisplayText + ".pdf");
				pdfViewerControl.LoadDocument(fileStream);
				ResetToolBar();
                RemoveAllToolbars(false);
				dropDownMenu.Close();
			};
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			parentView.Frame = new CGRect(0, DefaultToolbarHeight, this.Frame.Width, this.Frame.Height - (DefaultToolbarHeight));
			if (!isLoaded)
			{
				var fileStream = typeof(PdfViewerDemo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDFViewer.Assets.GIS Succinctly.pdf");
				pdfViewerControl.LoadDocument(fileStream);
				totalPageLabel.Text = "/ " + pdfViewerControl.PageCount.ToString();

				totalPageLabel.SetNeedsDisplay();
				isLoaded = true;

			}
			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				pdfViewerControl.Frame = new CGRect(0, 0, parentView.Frame.Width, parentView.Frame.Height - DefaultToolbarHeight + 2);
			else
				pdfViewerControl.Frame = new CGRect(0, 0, parentView.Frame.Width, parentView.Frame.Height - DefaultToolbarHeight + 2);
			toolBarFrame.Width = parentView.Frame.Width;
			toolbar.Frame = toolBarFrame;
			searchButton.Frame = new CGRect(parentView.Frame.Width - 60, 7, 35, 35);
			undoButton.Frame = new CGRect((parentView.Frame.Width/2)-25, 7, 35, 35);
			redoButton.Frame = new CGRect((parentView.Frame.Width/2)+10, 7, 35, 35);
			bottomToolbarFrame.X = -2;
			bottomToolbarFrame.Width = parentView.Frame.Width + 3;
			bottomToolbarFrame.Y = parentView.Frame.Height + 2;
			bottomToolBar.Frame = bottomToolbarFrame;
			textMarkupAnnotationButton.Frame = new CGRect(parentView.Frame.Width - 60, 7, 35, 35);

			colorFrame.Width = bottomToolbarFrame.Width;
			annotationFrame.Width = bottomToolbarFrame.Width;
			colorFrame.Height = bottomToolbarFrame.Height;
			colorFrame.Y = parentView.Frame.Height - (DefaultToolbarHeight + colorFrame.Height - 4);
			colorToolbar.Frame = colorFrame;
			annotationFrame.Height = bottomToolbarFrame.Height;
			annotationFrame.Y = parentView.Frame.Height - annotationFrame.Height + 4;
			annotationToolbar.Frame = annotationFrame;
			if (!IsSelected)
				colorButton.Frame = new CGRect(parentView.Frame.Width - 120, 7, 35, 35);
			else
				colorButton.Frame = new CGRect(parentView.Frame.Width - 55, 7, 35, 35);
			separateAnnotationFrame.Width = bottomToolbarFrame.Width;
			separateAnnotationFrame.Height = bottomToolbarFrame.Height;
			separateAnnotationFrame.Y = parentView.Frame.Height - separateAnnotationFrame.Height + 4;
			highlightToolbar.Frame = separateAnnotationFrame;
			underlineToolbar.Frame = separateAnnotationFrame;
			strikeOutToolbar.Frame = separateAnnotationFrame;

			redButton.Frame = new CGRect(parentView.Frame.Width - 50, 7, 35, 35);
			blueButton.Frame = new CGRect(parentView.Frame.Width - 95, 7, 35, 35);
			greenButton.Frame = new CGRect(parentView.Frame.Width - 140, 7, 35, 35);
			grayButton.Frame = new CGRect(parentView.Frame.Width - 185, 7, 35, 35);
			blackButton.Frame = new CGRect(parentView.Frame.Width - 230, 7, 35, 35);
			yellowButton.Frame = new CGRect(parentView.Frame.Width - 275, 7, 35, 35);
			whiteButton.Frame = new CGRect(parentView.Frame.Width - 315, 7, 35, 35);
			deleteButton.Frame = new CGRect(parentView.Frame.Width - 100, 7, 35, 35);
			toolbarBackbutton.Frame = new CGRect(parentView.Frame.Width - 55, 7, 35, 35);

		}
		private void PdfViewerControl_SearchCompleted(object sender, TextSearchCompletedEventArgs args)
		{
			if (args.NoMatchFound)
			{
				popUpAlertView.Title = "\"" + args.TargetText + "\"" +" not found.";
				popUpAlertView.AddButton("OK");
				popUpAlertView.Show();
			}
			else if (args.NoMoreOccurrence)
			{
				popUpAlertView.Title = "Search Result";
				popUpAlertView.Message = "No more occurrences.";
				popUpAlertView.AddButton("OK");
				popUpAlertView.Show();
			}

		}

		void PdfViewerControl_TextMarkupSelected(object sender, TextMarkupSelectedEventArgs args)
		{
			annotation = sender as IAnnotation;
			if (args.AnnotationType == TextMarkupAnnotationType.Highlight)
			{
				highlightToolbar = CreateSeparateAnnotationToolbar(highlightToolbar, highlightEnable, "\ue70f", true, (annotation as TextMarkupAnnotation).Settings.Color);
				this.Add(highlightToolbar);
			}
			else if (args.AnnotationType == TextMarkupAnnotationType.Underline)
			{
				underlineToolbar = CreateSeparateAnnotationToolbar(underlineToolbar, underlineEnable, "\ue711", true, (annotation as TextMarkupAnnotation).Settings.Color);
				this.Add(underlineToolbar);
			}
			else
			{
				strikeOutToolbar = CreateSeparateAnnotationToolbar(strikeOutToolbar, strikeEnable, "\ue71a", true, (annotation as TextMarkupAnnotation).Settings.Color);
				this.Add(strikeOutToolbar);
			}
			toolbarBackbutton.RemoveFromSuperview();
			annotationToolbar.RemoveFromSuperview();
			colorToolbar.RemoveFromSuperview();
			isAnnotationToolbarVisible = true;
		}

		void PdfViewerControl_TextMarkupDeselected(object sender, TextMarkupDeselectedEventArgs args)
		{
			if (args.AnnotationType == TextMarkupAnnotationType.Highlight)
				highlightToolbar.RemoveFromSuperview();
			else if (args.AnnotationType == TextMarkupAnnotationType.Underline)
				underlineToolbar.RemoveFromSuperview();
			else
				strikeOutToolbar.RemoveFromSuperview();
			colorToolbar.RemoveFromSuperview();
			annotationToolbar.RemoveFromSuperview();
			isAnnotationToolbarVisible = false;
			annotation = null;
		}
		void PdfViewerControl_CanUndoModified(object sender, CanUndoModifedEventArgs args)
		{
			if (args.CanUndo)
			{
				undoButton.SetTitle("\ue714", UIControlState.Normal);
				undoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			}
			else
			{
				undoButton.SetTitle("\ue714", UIControlState.Normal);
				undoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
			}
		}

		void PdfViewerControl_CanRedoModified(object sender, CanRedoModifiedEventArgs args)
		{
			if (args.CanRedo)
			{
				redoButton.SetTitle("\ue71e", UIControlState.Normal);
				redoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			}
			else
			{
				redoButton.SetTitle("\ue71e", UIControlState.Normal);
				redoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
			}
		}

		void DeleteButton_TouchUpInside(object sender, EventArgs e)
		{
			pdfViewerControl.RemoveAnnotation(annotation);
			RemoveAllToolbars(false);
		}

		void SaveButton_TouchUpInside(object sender, EventArgs e)
		{
			Stream stream = new MemoryStream();
			stream = pdfViewerControl.SaveDocument();
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filepath = Path.Combine(path, "savedDocument.pdf");

			FileStream outputFillStream = File.Open(filepath, FileMode.Create);
			stream.Position = 0;
			stream.CopyTo(outputFillStream);
			outputFillStream.Close();

			UIAlertView alertview = new UIAlertView();
			alertview.Frame = new CGRect(20, 100, 200, 200);
			alertview.Message = filepath;
			alertview.Title = "The modified document is saved in the below location.";
			alertview.AddButton("Ok");
			alertview.Show();
			RemoveAllToolbars(false);
		}

		public void OnSingleTap(UITapGestureRecognizer gesture)
		{
			this.EndEditing(true);
			pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
		}

		private void ResetToolBar()
		{
			pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
			totalPageLabel.Text = "/  " + pdfViewerControl.PageCount.ToString();
			totalPageLabel.Frame = new CGRect(totalPageLabel.Frame.X, totalPageLabel.Frame.Y, totalPageLabel.IntrinsicContentSize.Width, totalPageLabel.Frame.Height);
		}

		private void PageNumberField_EditingDidBegin(object sender, EventArgs e)
		{
			pageNumberField.ResignFirstResponder();
			alertViewDelegate = new AlertViewDelegate(pdfViewerControl);
			pagePopupView.Frame = new CGRect(40, parentView.Frame.Height / 4, 400, 150);
			pagePopupView.BackgroundColor = UIColor.White;
			pagePopupView.Layer.BorderWidth = 1;
			pagePopupView.Layer.BorderColor = new CGColor(0.2f, 0.2f);
			pagePopupView.Layer.CornerRadius = 10;
			pagePopupView.Title = "Go To Page";
			pagePopupView.Message = "Enter Page Number (1 - " + pdfViewerControl.PageCount.ToString() + ")";
			pagePopupView.AddButton("Cancel");
			pagePopupView.AddButton("OK");
			pagePopupView.Delegate = alertViewDelegate;
			pagePopupView.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
			pagePopupView.GetTextField(0).KeyboardType = UIKeyboardType.NumberPad;
			pagePopupView.CancelButtonIndex = 0;
			pagePopupView.GetTextField(0).BecomeFirstResponder();
			pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
			pagePopupView.Show();
		}

		private void ViewerControl_PageChanged(object sender, PageChangedEventArgs args)
		{
			pageNumberField.Text = args.PageNumber.ToString();
		}

		protected virtual UIView CreateTopToolbar()
		{
			toolBarFrame = this.Frame;
			toolBarFrame.Height = DefaultToolbarHeight;
			toolBarFrame.Y = 0;
			toolBar.Frame = toolBarFrame;
			toolBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
			toolBar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				fileButton.Frame = new CGRect(10, 7, 35, 35);
			else
				fileButton.Frame = new CGRect(5, 7, 35, 35);
			fileButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			fileButton.TouchUpInside += (e, a) =>
			{
				if (dropDownMenu.IsOpened)
					dropDownMenu.Close();
				else
					dropDownMenu.Open();
			};
			fileButton.Font = highFont;
			fileButton.SetTitle("\ue715", UIControlState.Normal);
			fileButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			toolBar.Add(fileButton);

			saveButton.Frame = new CGRect(55, 7, 35, 35);
			saveButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			saveButton.TouchUpInside += SaveButton_TouchUpInside;
			saveButton.Font = highFont;
			saveButton.SetTitle("\ue70b", UIControlState.Normal);
			saveButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			toolBar.Add(saveButton);

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				undoButton.Frame = new CGRect(parentView.Frame.Width / 2 - 25, 7, 35, 35);
			else
				undoButton.Frame = new CGRect(130, 7, 35, 35);
			undoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			undoButton.TouchUpInside += UndoButton_TouchUpInside; ;
			undoButton.Font = highFont;
			undoButton.SetTitle("\ue714", UIControlState.Normal);
			undoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
			toolBar.Add(undoButton);

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				redoButton.Frame = new CGRect(parentView.Frame.Width / 2 + 10, 7, 35, 35);
			else
				redoButton.Frame = new CGRect(175, 7, 35, 35);
			redoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			redoButton.TouchUpInside += RedoButton_TouchUpInside; ;
			redoButton.Font = highFont;
			redoButton.SetTitle("\ue71e", UIControlState.Normal);
			redoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
			toolBar.Add(redoButton);

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				searchButton.Frame = new CGRect(parentView.Frame.Width - 50, 7, 35, 35);
			else
				searchButton.Frame = new CGRect(parentView.Frame.Width - 10, 7, 35, 35);
			searchButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			searchButton.TouchUpInside += SearchButtonClicked;
			searchButton.Font = highFont;
			searchButton.SetTitle("\ue701", UIControlState.Normal);
			searchButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			toolBar.Add(searchButton);
			return toolBar;
		}

		private UIView CreateBottomToolbar()
		{
			bottomToolbarFrame = this.Frame;
			bottomToolbarFrame.Height = DefaultToolbarHeight;
			bottomToolbarFrame.Y = 0;
			bottomToolBar.Frame = bottomToolbarFrame;
			bottomToolBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
			bottomToolBar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				pageNumberField.Frame = new CGRect(45, 7, 35, 35);
			else
				pageNumberField.Frame = new CGRect(45, 7, 35, 35);
			pageNumberField.EditingDidBegin += PageNumberField_EditingDidBegin;
			pageNumberField.BorderStyle = UITextBorderStyle.RoundedRect;
			pageNumberField.TextColor = UIColor.FromRGB(0, 118, 255);
			pageNumberField.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			pageNumberField.TextAlignment = UITextAlignment.Center;
			bottomToolBar.Add(pageNumberField);

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				totalPageLabel.Frame = new CGRect(90, 7, 35, 35);
			else
				totalPageLabel.Frame = new CGRect(90, 7, 35, 35);
			totalPageLabel.TextColor = UIColor.FromRGB(0, 118, 255);
			bottomToolBar.Add(totalPageLabel);

			textMarkupAnnotationButton.Frame = new CGRect(parentView.Frame.Width - 50, 7, 35, 35);
			textMarkupAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textMarkupAnnotationButton.TouchUpInside += TextMarkupAnnotationButton_TouchUpInside;
			textMarkupAnnotationButton.Font = highFont;
			textMarkupAnnotationButton.SetTitle("\ue708", UIControlState.Normal);
			textMarkupAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			bottomToolBar.Add(textMarkupAnnotationButton);
			bottomToolBar.Layer.BorderWidth = 1;
			bottomToolBar.Layer.BorderColor = new CGColor(0.2f, 0.2f);

			return bottomToolBar;
		}

		void TextMarkupAnnotationButton_TouchUpInside(object sender, EventArgs e)
		{
			if (!isAnnotationToolbarVisible)
			{
				searchToolBar.RemoveFromSuperview();
				annotationFrame = this.Frame;
				annotationFrame.Height = DefaultToolbarHeight;
				annotationFrame.Y = parentView.Frame.Height - annotationFrame.Height + 4;
				annotationToolbar.Frame = annotationFrame;
				annotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

				highlightAnnotationButton.Frame = new CGRect(15, 7, 35, 35);
				highlightAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				highlightAnnotationButton.TouchUpInside += HighlightAnnotationButton_TouchUpInside;
				highlightAnnotationButton.Font = highFont;
				highlightAnnotationButton.SetTitle("\ue70f", UIControlState.Normal);
				highlightAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
				annotationToolbar.Add(highlightAnnotationButton);

				underlineAnnotationButton.Frame = new CGRect(100, 7, 35, 35);
				underlineAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				underlineAnnotationButton.TouchUpInside += UnderlineAnnotationButton_TouchUpInside; ;
				underlineAnnotationButton.Font = highFont;
				underlineAnnotationButton.SetTitle("\ue711", UIControlState.Normal);
				underlineAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
				annotationToolbar.Add(underlineAnnotationButton);

				strikeOutAnnotationButton.Frame = new CGRect(185, 7, 35, 35);
				strikeOutAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				strikeOutAnnotationButton.TouchUpInside += StrikeOutAnnotationButton_TouchUpInside; ;
				strikeOutAnnotationButton.Font = highFont;
				strikeOutAnnotationButton.SetTitle("\ue71a", UIControlState.Normal);
				strikeOutAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
				annotationToolbar.Add(strikeOutAnnotationButton);

				annotationToolbar = UpdateToolbarBorder(annotationToolbar, annotationFrame);
				this.Add(annotationToolbar);
				isAnnotationToolbarVisible = true;
				highlightToolbar.RemoveFromSuperview();
				strikeOutToolbar.RemoveFromSuperview();
				underlineToolbar.RemoveFromSuperview();
				colorToolbar.RemoveFromSuperview();
			}
			else
			{
				RemoveAllToolbars(false);
				pdfViewerControl.AnnotationMode = AnnotationMode.None;
				isAnnotationToolbarVisible = false;
			}
		}

		UIView UpdateToolbarBorder(UIView updateToolbar, CGRect toolbarFrame)
		{
			updateToolbar.Layer.BorderWidth = 1;
			updateToolbar.Layer.BorderColor = new CGColor(0.2f, 0.2f);
			updateToolbar.Frame = new CGRect(toolbarFrame.X - 1, toolbarFrame.Y - 1, annotationToolbar.Frame.Width + 2, annotationToolbar.Frame.Height + 2);
			return updateToolbar;
		}

		void HighlightAnnotationButton_TouchUpInside(object sender, EventArgs e)
		{
			pdfViewerControl.AnnotationMode = AnnotationMode.Highlight;
			annotationToolbar.RemoveFromSuperview();
			isAnnotationToolbarVisible = true;
			deleteButton.RemoveFromSuperview();
			highlightToolbar = CreateSeparateAnnotationToolbar(highlightToolbar, highlightEnable, "\ue70f", false, pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
			this.Add(highlightToolbar);
		}
		private UIView CreateSeparateAnnotationToolbar(UIView separateToolbar, UIButton enableLabel, string imageName, bool isSelected, UIColor colorButtonColor)
		{
			separateAnnotationFrame = this.Frame;
			separateAnnotationFrame.Height = DefaultToolbarHeight;
			separateAnnotationFrame.Y = parentView.Frame.Height - separateAnnotationFrame.Height + 4;
			separateToolbar.Frame = separateAnnotationFrame;
			separateToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

			enableLabel.Frame = new CGRect(45, 7, 35, 35);
			enableLabel.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			enableLabel.Font = highFont;
			enableLabel.SetTitle(imageName, UIControlState.Normal);
			enableLabel.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			separateToolbar.Add(enableLabel);
			IsSelected = isSelected;
			if (!isSelected)
			{
				toolbarBackbutton.Frame = new CGRect(parentView.Frame.Width - 55, 7, 35, 35);
				toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				toolbarBackbutton.TouchUpInside += ToolbarBackbutton_TouchUpInside; ;
				toolbarBackbutton.Font = highFont;
				toolbarBackbutton.SetTitle("\ue706", UIControlState.Normal);
				toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
				separateToolbar.Add(toolbarBackbutton);
				colorButton.Frame = new CGRect(parentView.Frame.Width - 130, 7, 35, 35);
			}
			else
			{
				deleteButton.Frame = new CGRect(parentView.Frame.Width - 100, 7, 35, 35);
				deleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
				deleteButton.TouchUpInside += DeleteButton_TouchUpInside; ;
				deleteButton.Font = highFont;
				deleteButton.SetTitle("\ue70d", UIControlState.Normal);
				deleteButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
				separateToolbar.Add(deleteButton);
				colorButton.Frame = new CGRect(parentView.Frame.Width - 55, 7, 35, 35);
			}
			colorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			colorButton.TouchUpInside += ColorButton_TouchUpInside;
			colorButton.BackgroundColor = colorButtonColor;
			separateToolbar.Add(colorButton);
			separateToolbar = UpdateToolbarBorder(separateToolbar, separateAnnotationFrame);

			return separateToolbar;
		}

		void UnderlineAnnotationButton_TouchUpInside(object sender, EventArgs e)
		{
			pdfViewerControl.AnnotationMode = AnnotationMode.Underline;
			annotationToolbar.RemoveFromSuperview();
			isAnnotationToolbarVisible = true;
			deleteButton.RemoveFromSuperview();
			underlineToolbar = CreateSeparateAnnotationToolbar(underlineToolbar, underlineEnable, "\ue711", false, pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
			this.Add(underlineToolbar);
		}

		void StrikeOutAnnotationButton_TouchUpInside(object sender, EventArgs e)
		{
			pdfViewerControl.AnnotationMode = AnnotationMode.Strikethrough;
			annotationToolbar.RemoveFromSuperview();
			isAnnotationToolbarVisible = true;
			deleteButton.RemoveFromSuperview();
			strikeOutToolbar = CreateSeparateAnnotationToolbar(strikeOutToolbar, strikeEnable, "\ue71a", false, pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
			this.Add(strikeOutToolbar);
		}

		void ToolbarBackbutton_TouchUpInside(object sender, EventArgs e)
		{
			pdfViewerControl.AnnotationMode = AnnotationMode.None;
			RemoveAllToolbars(false);
			this.Add(annotationToolbar);
			isAnnotationToolbarVisible = true;
		}

		void ColorButton_TouchUpInside(object sender, EventArgs e)
		{
			colorFrame = this.Frame;
			colorFrame.Height = DefaultToolbarHeight;
			colorFrame.Y = parentView.Frame.Height - (DefaultToolbarHeight + colorFrame.Height - 4);
			colorToolbar.Frame = colorFrame;
			colorToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

			redButton.Frame = new CGRect(parentView.Frame.Width - 50, 7, 35, 35);
			redButton.BackgroundColor = UIColor.Red;
			redButton.TouchUpInside += AnnotationColor_TouchUpInside;
			colorToolbar.AddSubview(redButton);

			blueButton.Frame = new CGRect(parentView.Frame.Width - 95, 7, 35, 35);
			blueButton.BackgroundColor = UIColor.Blue;
			blueButton.TouchUpInside += AnnotationColor_TouchUpInside;
			colorToolbar.AddSubview(blueButton);

			greenButton.Frame = new CGRect(parentView.Frame.Width - 140, 7, 35, 35);
			greenButton.BackgroundColor = UIColor.Green;
			greenButton.TouchUpInside += AnnotationColor_TouchUpInside;
			colorToolbar.AddSubview(greenButton);

			grayButton.Frame = new CGRect(parentView.Frame.Width - 185, 7, 35, 35);
			grayButton.BackgroundColor = UIColor.Gray;
			grayButton.TouchUpInside += AnnotationColor_TouchUpInside;
			colorToolbar.AddSubview(grayButton);

			blackButton.Frame = new CGRect(parentView.Frame.Width - 230, 7, 35, 35);
			blackButton.BackgroundColor = UIColor.Black;
			blackButton.TouchUpInside += AnnotationColor_TouchUpInside;
			colorToolbar.AddSubview(blackButton);

			yellowButton.Frame = new CGRect(parentView.Frame.Width - 275, 7, 35, 35);
			yellowButton.BackgroundColor = UIColor.Yellow;
			yellowButton.TouchUpInside += AnnotationColor_TouchUpInside;
			colorToolbar.AddSubview(yellowButton);

			whiteButton.Frame = new CGRect(parentView.Frame.Width - 315, 7, 35, 35);
			whiteButton.BackgroundColor = UIColor.White;
			whiteButton.TouchUpInside += AnnotationColor_TouchUpInside;
			colorToolbar.AddSubview(whiteButton);
			colorToolbar = UpdateToolbarBorder(colorToolbar, colorFrame);
			this.Add(colorToolbar);
		}

		void AnnotationColor_TouchUpInside(object sender, EventArgs e)
		{
			if (annotation != null)
				((TextMarkupAnnotation)annotation).Settings.Color = (sender as UIButton).BackgroundColor;
			else
			{
				if (pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
					pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = (sender as UIButton).BackgroundColor;
				else if (pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
					pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = (sender as UIButton).BackgroundColor;
				else if (pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
					pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = (sender as UIButton).BackgroundColor;
			}
			colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
			colorToolbar.RemoveFromSuperview();
		}
		protected virtual UIView CreateSearchTopToolbar()
		{
			RemoveAllToolbars(false);
			toolBarFrame = Frame;
			toolBarFrame.Height = DefaultToolbarHeight;
			toolBarFrame.Y = 0;
			searchToolBar.Frame = toolBarFrame;
			searchToolBar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

			searchToolBar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				backButton.Frame = new CGRect(20, 2, 50, 50);
			else
				backButton.Frame = new CGRect(2, 5, 40, 40);
			backButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			backButton.TouchUpInside += BackButtonClicked;
			backButton.Font = highFont;
			backButton.SetTitle("\ue719", UIControlState.Normal);
			backButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
			searchToolBar.Add(backButton);

			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				searchBar.Frame = new CGRect(95, 5, 550, 40);
			else
				searchBar.Frame = new CGRect(40, 5, 210, 40);
			searchBar.Placeholder = "Enter text to search";
			searchBar.TextChanged += SearchBar_TextChanged;
			searchBar.SearchButtonClicked += SearchBar_SearchButtonClicked;
			searchToolBar.Add(searchBar);

			return searchToolBar;
		}
		private void SearchBar_TextChanged(object sender, UISearchBarTextChangedEventArgs e)
		{
			if ((sender as UISearchBar).Text == string.Empty)
			{
				pdfViewerControl.CancelSearch();
			}
		}

		private void SearchCancelClicked(object sender, EventArgs e)
		{
			pdfViewerControl.CancelSearch();
			searchBar.Text = String.Empty;
		}
		public void UpdateToolBarValues()
		{
			pageNumberField.Text = pdfViewerControl.PageNumber.ToString();
		}

		private void SearchBar_SearchButtonClicked(object sender, EventArgs e)
		{
			dropDownMenu.Close();
			searchBar.ResignFirstResponder();
			pdfViewerControl.SearchText(searchBar.Text);
		}

		void RedoButton_TouchUpInside(object sender, EventArgs e)
		{
			pdfViewerControl.PerformRedo();
			RemoveAllToolbars(false);
		}

		void UndoButton_TouchUpInside(object sender, EventArgs e)
		{
			pdfViewerControl.PerformUndo();
			RemoveAllToolbars(false);
		}
		void RemoveAllToolbars(bool isBackButton)
		{
			annotationToolbar.RemoveFromSuperview();
			if (!isBackButton)
			{
				colorToolbar.RemoveFromSuperview();
				highlightToolbar.RemoveFromSuperview();
				strikeOutToolbar.RemoveFromSuperview();
				underlineToolbar.RemoveFromSuperview();
			}
			isAnnotationToolbarVisible = false;
		}

		void SearchClicked(object sender, EventArgs ea)
		{
			pdfViewerControl.SearchText(searchBar.Text);
		}

		void SearchButtonClicked(object sender, EventArgs ea)
		{
			RemoveAllToolbars(false);
			toolbar.RemoveFromSuperview();
			backButton.Enabled = true;
			CreateSearchTopToolbar();
			toolbar = searchToolBar;
			searchBar.BecomeFirstResponder();
			AddSubview(toolbar);
			LayoutSubviews();
			dropDownMenu.Close();
		}

		void BackButtonClicked(object sender, EventArgs ea)
		{
			pdfViewerControl.CancelSearch();
			searchBar.Text = String.Empty;
			UpdateToolBarValues();
			searchToolBar.RemoveFromSuperview();
			toolBar.RemoveFromSuperview();
			toolbar = toolBar;
			toolBarFrame.Height = DefaultToolbarHeight;
			AddSubview(toolbar);
		}
		#region DropDown
		private List<DropDownMenuItem> GetResource()
		{

			var list = new List<DropDownMenuItem>();
			list.Add(new DropDownMenuItem()
			{
				DisplayText = "F# Succinctly",
			});
			list.Add(new DropDownMenuItem()
			{
				DisplayText = "GIS Succinctly",
				IsSelected = true
			});
			list.Add(new DropDownMenuItem()
			{
				DisplayText = "HTTP Succinctly",
			});
			list.Add(new DropDownMenuItem()
			{
				DisplayText = "JavaScript Succinctly",
			});
			return list;
		}

		private DropDownMenu CreateDropDownMenu()
		{
			var dropDownMenu = new DropDownMenu(this, GetResource().ToArray())
			{
				BackgroundColor = UIColor.Clear,
				TextColor = UIColor.Black,
				Opacity = 1,
				BorderWidth = 1,
				Frame = new CGRect(0, DefaultToolbarHeight + 20, 250, 200)
			};
			return dropDownMenu;
		}
		#endregion
	}
}