#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SampleBrowser.XlsIO
{
    public partial class FiltersPage : SampleView
    {
        public FiltersPage()
        {
            InitializeComponent();

            this.picker.Items.Add("Custom Filter");
            this.picker.Items.Add("Text Filter");
            this.picker.Items.Add("DateTime Filter");
            this.picker.Items.Add("Dynamic Filter");
            this.picker.Items.Add("Advanced Filter");
            this.Advanced.Items.Add("Filter In Place");
            this.Advanced.Items.Add("Filter Copy");
            this.picker.SelectedIndex = 0;
            this.Advanced.SelectedIndex = 0;

            if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGetInputTemplate.HorizontalOptions = LayoutOptions.Start;

                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                if (!SampleBrowser.XlsIO.App.isUWP)
                {
                    this.Content_1.FontSize = 18.5;
                    this.Content_3.FontSize = 18.5;
                    this.Label1.FontSize = 18.5;
                    this.Label2.FontSize = 18.5;
                }
                else
                {
                    this.Content_1.FontSize = 13.5;
                    this.Content_3.FontSize = 13.5;
                    this.Label1.FontSize = 13.5;
                    this.Label2.FontSize = 13.5;
                }
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
            int FilterType = this.picker.SelectedIndex;
            if (FilterType != 4)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.FilterData.xlsx");
            else
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.AdvancedFilterData.xlsx");            
            IWorkbook workbook = application.Workbooks.Open(fileStream);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            #endregion                       
            if (FilterType != 4)
                sheet.AutoFilters.FilterRange = sheet.Range[1, 1, 49, 3];

            switch (FilterType)
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
                    if (Advanced.SelectedIndex == 0)
                    {
                        sheet.AdvancedFilter(ExcelFilterAction.FilterInPlace, filterRange, criteriaRange, null, Switch1.IsToggled);
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
                        sheet.AdvancedFilter(ExcelFilterAction.FilterCopy, filterRange, criteriaRange, copyRange, Switch1.IsToggled);
                    }
                    #endregion
                    break;
            }

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Filters.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Filters.xlsx", "application/msexcel", stream);

        }
         void OnButtonClicked1(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
            int FilterType = this.picker.SelectedIndex;
            if (FilterType != 4)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.FilterData.xlsx");
            else
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.AdvancedFilterData.xlsx");            
            IWorkbook workbook = application.Workbooks.Open(fileStream);
            #endregion
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.xlsx", "application/msexcel", stream);

        }
        void OnItemSelected(object sender, EventArgs e)
        {
            if (this.picker.SelectedIndex == 4)
                this.DynamicGrid.IsVisible = true;
            else
                this.DynamicGrid.IsVisible = false;            
        }               
    }
}

