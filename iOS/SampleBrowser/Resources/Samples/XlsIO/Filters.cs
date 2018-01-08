#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using System.Collections.Generic;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
	public partial class Filters : SampleView
	{
		public Filters ()
		{
			this.filterList.Add((NSString)"Custom Filter");
			this.filterList.Add((NSString)"Text Filter");
			this.filterList.Add((NSString)"DateTime Filter");
			this.filterList.Add((NSString)"Dynamic Filter");
			this.filterList.Add((NSString)"Advanced Filter");
			this.filterActionList.Add((NSString)"Filter In Place");
			this.filterActionList.Add((NSString)"Filter Copy");
			selectedFilterType = "Custom Filter";
			selectedFilterActionType = "Filter In Place";
		}

		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
        private readonly IList<string> filterList = new List<string>();
        private readonly IList<string> filterActionList = new List<string>();
        UILabel filterLabel;
        UIButton filterDoneButton;
        UIButton filterButton;
        UIPickerView filterPicker;
        UILabel filterActionLabel;
        UIButton filterActionDoneButton;
        UIButton filterActionButton;
        UIPickerView filterActionPicker;
        string selectedFilterType;
        string selectedFilterActionType;
        UILabel uniqueRecordsLabel;
        UISwitch uniqueRecordsSwitch;
        UIButton button;
		bool isLoaded = false;
        
        void LoadAllowedTextsLabel()
		{
            

            #region Description Label
                  
            UILabel label = new UILabel ();
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to filter data within a range of Excel worksheet.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect (5, 5,frameRect.Location.X + frameRect.Size.Width  ,35);
			} 
			else {
				label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width  ,50);

			}
			this.AddSubview (label);
            #endregion

            #region Filter Region
            filterLabel = new UILabel();
            filterDoneButton = new UIButton();
            filterButton = new UIButton();
            filterPicker = new UIPickerView();
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                filterLabel.Font = UIFont.SystemFontOfSize(18);
                filterLabel.Frame = new CGRect(10, 45, frameRect.Location.X + frameRect.Size.Width-20, 50);
                filterButton.Frame = new CGRect(10, 95, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }
            else
            {
                filterLabel.Frame = new CGRect(10, 50, frameRect.Location.X + frameRect.Size.Width-20, 50);
				filterButton.Frame = new CGRect(10, 100, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }

            //filter Label
            filterLabel.TextColor = UIColor.Black;
            filterLabel.BackgroundColor = UIColor.Clear;
            filterLabel.Text = @"Filter Type";
            filterLabel.TextAlignment = UITextAlignment.Left;
            filterLabel.Font = UIFont.FromName("Helvetica", 16f);
            this.AddSubview(filterLabel);
			
            //filter button
            filterButton.SetTitle("Custom Filter", UIControlState.Normal);
            filterButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            filterButton.BackgroundColor = UIColor.Clear;
            filterButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterButton.Hidden = false;
            filterButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            filterButton.Layer.BorderWidth = 4;
            filterButton.Layer.CornerRadius = 8;
			filterButton.Font = UIFont.FromName("Helvetica", 16f);
            filterButton.TouchUpInside += ShowFilterPicker;
            this.AddSubview(filterButton);
		

            //filterpicker
            PickerModel filterPickermodel = new PickerModel(this.filterList);
            filterPickermodel.PickerChanged += (sender, e) =>
            {
                this.selectedFilterType = e.SelectedValue;
                filterButton.SetTitle(selectedFilterType, UIControlState.Normal);
            };
            filterPicker = new UIPickerView();
            filterPicker.ShowSelectionIndicator = true;
            filterPicker.Hidden = true;
            filterPicker.Model = filterPickermodel;
            filterPicker.BackgroundColor = UIColor.White;

            //filterDoneButtonn
            filterDoneButton = new UIButton();
            filterDoneButton.SetTitle("Done\t", UIControlState.Normal);
            filterDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            filterDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            filterDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterDoneButton.Hidden = true;
            filterDoneButton.TouchUpInside += HideFilterPicker;

			filterPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 20, this.Frame.Size.Width, this.Frame.Size.Height / 3);
			filterDoneButton.Frame = new CGRect(0, this.Frame.Size.Height / 4 - 20, this.Frame.Size.Width, 40);
			this.AddSubview(filterPicker);
			this.AddSubview(filterDoneButton);
            #endregion

            #region Filter Action Region
            filterActionLabel = new UILabel();
            filterActionDoneButton = new UIButton();
            filterActionButton = new UIButton();
            filterActionPicker = new UIPickerView();
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                filterActionLabel.Font = UIFont.SystemFontOfSize(18);
                filterActionLabel.Frame = new CGRect(10, 140, frameRect.Location.X + frameRect.Size.Width - 20, 50);
                filterActionButton.Frame = new CGRect(10, 190, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }
            else
            {
                filterActionLabel.Frame = new CGRect(10, 145, frameRect.Location.X + frameRect.Size.Width - 20, 50);
 				filterActionButton.Frame = new CGRect(10, 195, frameRect.Location.X + frameRect.Size.Width - 20, 40);
            }

            //filterActionLabel
            filterActionLabel.TextColor = UIColor.Black;
            filterActionLabel.BackgroundColor = UIColor.Clear;
            filterActionLabel.Text = @"Filter Action";
            filterActionLabel.TextAlignment = UITextAlignment.Left;
            filterActionLabel.Font = UIFont.FromName("Helvetica", 16f);           

            //filterActionButton
            filterActionButton.SetTitle("Filter In Place", UIControlState.Normal);
            filterActionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            filterActionButton.BackgroundColor = UIColor.Clear;
            filterActionButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterActionButton.Hidden = false;
            filterActionButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
            filterActionButton.Layer.BorderWidth = 4;
            filterActionButton.Layer.CornerRadius = 8;
            filterActionButton.Font = UIFont.FromName("Helvetica", 16f);
            filterActionButton.TouchUpInside += ShowFilterActionPicker;           


            //filterActionPickermodel
            PickerModel filterActionPickermodel = new PickerModel(this.filterActionList);
            filterActionPickermodel.PickerChanged += (sender, e) =>
            {
                this.selectedFilterActionType = e.SelectedValue;
                filterActionButton.SetTitle(selectedFilterActionType, UIControlState.Normal);                
            };
            filterActionPicker = new UIPickerView();
            filterActionPicker.ShowSelectionIndicator = true;
            filterActionPicker.Hidden = true;
            filterActionPicker.Model = filterActionPickermodel;
            filterActionPicker.BackgroundColor = UIColor.White;

            //filterActionDoneButton
            filterActionDoneButton = new UIButton();
            filterActionDoneButton.SetTitle("Done\t", UIControlState.Normal);
            filterActionDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            filterActionDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            filterActionDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            filterActionDoneButton.Hidden = true;
            filterActionDoneButton.TouchUpInside += HideFilterActionPicker;            

            filterActionPicker.Frame = new CGRect(0, this.Frame.Size.Height / 4 + 30, this.Frame.Size.Width, this.Frame.Size.Height / 3);
            filterActionDoneButton.Frame = new CGRect(0,  this.Frame.Size.Height / 4 - 30,this.Frame.Size.Width, 40);
            this.AddSubview(filterActionPicker);
            this.AddSubview(filterActionDoneButton);

            //unique records label
            uniqueRecordsLabel = new UILabel();
            uniqueRecordsLabel.TextColor = UIColor.Black;
            uniqueRecordsLabel.BackgroundColor = UIColor.Clear;
            uniqueRecordsLabel.Text = @"Unique Records";
            uniqueRecordsLabel.TextAlignment = UITextAlignment.Left;
            uniqueRecordsLabel.Font = UIFont.FromName("Helvetica", 16f);
            uniqueRecordsLabel.Frame = new CGRect(10, 240, this.Frame.Size.Width - 20, 40);

            //unique records switch
            uniqueRecordsSwitch = new UISwitch();            
            uniqueRecordsSwitch.On = false;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			    uniqueRecordsSwitch.Frame=new CGRect(330,240,  this.Frame.Size.Width - 220, 40);
			else
				uniqueRecordsSwitch.Frame=new CGRect(250,240, this.Frame.Size.Width - 20, 40);
			#endregion


			this.AddSubview(filterActionLabel);
			this.AddSubview(filterActionButton);
			this.AddSubview(uniqueRecordsLabel);
			this.AddSubview(uniqueRecordsSwitch);
			filterActionLabel.Hidden = true;
			filterActionButton.Hidden = true;
			uniqueRecordsLabel.Hidden = true;
			uniqueRecordsSwitch.Hidden = true;
            //button
            button = new UIButton (UIButtonType.System);
			button.SetTitle("Generate Excel", UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				button.Frame = new CGRect(0, 150, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			else
			{
				button.Frame = new CGRect(0, 155, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			button.TouchUpInside += OnButtonClicked;
			this.AddSubview (button);
			isLoaded = true;
		}


       

        void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;

			application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            string resourcePath = null;
            int index = filterList.IndexOf(selectedFilterType);
            if(index != 4)
             resourcePath = "SampleBrowser.Samples.XlsIO.Template.FilterData.xlsx";
            else
             resourcePath = "SampleBrowser.Samples.XlsIO.Template.AdvancedFilterData.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly ();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			IWorksheet sheet = workbook.Worksheets[0];
			#endregion
            if(index !=4)
                sheet.AutoFilters.FilterRange = sheet.Range[1, 1, 49, 3];

            switch (index)
            {
                case 0:                   
                    IAutoFilter filter1 = sheet.AutoFilters[0];
                    filter1.IsAnd = false;
                    filter1.FirstCondition.ConditionOperator = ExcelFilterCondition.Equal;
                    filter1.FirstCondition.DataType = ExcelFilterDataType.String;
                    filter1.FirstCondition.String = "Owner";

                    filter1.SecondCondition.ConditionOperator = ExcelFilterCondition.Equal;
                    filter1.SecondCondition.DataType = ExcelFilterDataType.String;
                    filter1.SecondCondition.String = "Sales Representative";
                    break;

                case 1:                    
                    IAutoFilter filter2 = sheet.AutoFilters[0];
                    filter2.AddTextFilter(new string[] { "Owner", "Sales Representative", "Sales Associate" });
                    break;

                case 2:                    
                    IAutoFilter filter3 = sheet.AutoFilters[1];
                    filter3.AddDateFilter(new DateTime(2004, 9, 1, 1, 0, 0, 0), DateTimeGroupingType.month);
                    filter3.AddDateFilter(new DateTime(2011, 1, 1, 1, 0, 0, 0), DateTimeGroupingType.year);
                    break;

                case 3:                   
                    IAutoFilter filter4 = sheet.AutoFilters[1];
                    filter4.AddDynamicFilter(DynamicFilterType.Quarter1);
                    break;
                case 4:
                    #region AdvancedFilter                   
                    IRange filterRange = sheet.Range["A8:G51"];
                    IRange criteriaRange = sheet.Range["A2:B5"];
                    if (selectedFilterActionType == "Filter In Place")
                    {
                        sheet.AdvancedFilter(ExcelFilterAction.FilterInPlace, filterRange, criteriaRange, null, uniqueRecordsSwitch.On);
                    }
                    else
                    {
                        IRange range = sheet.Range["I7:O7"];
                        range.Merge();
                        range.Text = "FilterCopy";
                        range.CellStyle.Font.RGBColor = Syncfusion.Drawing.Color.FromArgb(0, 112, 192);
                        range.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                        range.CellStyle.Font.Bold = true;
                        IRange copyRange = sheet.Range["I8"];
                        sheet.AdvancedFilter(ExcelFilterAction.FilterCopy, filterRange, criteriaRange, copyRange, uniqueRecordsSwitch.On);
                    }
                    #endregion
                    break;
            }

            workbook.Version = ExcelVersion.Excel2013;


			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("Filters.xlsx", "application/msexcel", stream);
			}

		}

		public override void LayoutSubviews ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				frameMargin = 0.0f;
			}
			frameRect = Bounds;
			frameRect.Location = new CGPoint (frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));
			if(!isLoaded)
			LoadAllowedTextsLabel ();            
            base.LayoutSubviews();         
		}

        void ShowFilterPicker(object sender, EventArgs e)
        {
			
            filterDoneButton.Hidden = false;
            filterPicker.Hidden = false;
			button.Hidden = true;
			filterActionLabel.Hidden = true;
			filterActionButton.Hidden = true;
			uniqueRecordsLabel.Hidden = true;
			uniqueRecordsSwitch.Hidden = true;
            this.BecomeFirstResponder();
        }

        void HideFilterPicker(object sender, EventArgs e)
        {
            filterDoneButton.Hidden = true;
            filterPicker.Hidden = true;
			button.Hidden = false;
            this.BecomeFirstResponder();
			if (selectedFilterType == "Advanced Filter")
			{
				filterActionLabel.Hidden = false;
				filterActionButton.Hidden = false;
				uniqueRecordsLabel.Hidden = false;
				uniqueRecordsSwitch.Hidden = false;
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					button.Frame = new CGRect(0, 290, frameRect.Location.X + frameRect.Size.Width, 10);
				}
				else
				{
					button.Frame = new CGRect(0, 295, frameRect.Location.X + frameRect.Size.Width, 10);

				}
			}
			else
			{
				filterActionLabel.Hidden = true;
				filterActionButton.Hidden = true;
				uniqueRecordsLabel.Hidden = true;
				uniqueRecordsSwitch.Hidden = true;
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					button.Frame = new CGRect(0, 150, frameRect.Location.X + frameRect.Size.Width, 10);
				}
				else
				{
					button.Frame = new CGRect(0, 155, frameRect.Location.X + frameRect.Size.Width, 10);

				}
			}
        }

        void ShowFilterActionPicker(object sender, EventArgs e)
		{
			filterActionLabel.Hidden = true;
			filterActionButton.Hidden = true;
			filterActionDoneButton.Hidden = false;
			filterActionPicker.Hidden = false;
			uniqueRecordsLabel.Hidden = true;
			uniqueRecordsSwitch.Hidden = true;
            button.Hidden = true;
			filterButton.Hidden = true;
            this.BecomeFirstResponder();
        }

        void HideFilterActionPicker(object sender, EventArgs e)
        {
			filterActionLabel.Hidden = false;
			filterActionButton.Hidden = false;
			filterActionDoneButton.Hidden = true;
			filterActionPicker.Hidden = true;
			uniqueRecordsLabel.Hidden = false;
			uniqueRecordsSwitch.Hidden = false;
            button.Hidden = false;
			filterButton.Hidden = false;
			this.BecomeFirstResponder();
        }
    }
}

