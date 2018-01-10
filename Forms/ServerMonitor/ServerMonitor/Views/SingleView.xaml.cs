#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServerMonitor.Views
{

    # region SingleView

    public partial class SingleView
    {
        #region Properties and Fields

        SfCircularGauge circularGaugeCPU;

        SfCircularGauge circularGaugeMemory;

        SfChart chartCPU;

        SfChart chartMemory;

        SfChart chartNetwork;

        int i = 40;

        Random rand = new Random();
        
        #endregion

        # region Methods

        public SingleView()
        {
            InitializeComponent();
            this.CPULayoutLabel.Padding = this.MemoryLayoutLabel.Padding = Device.OnPlatform(iOS: new Thickness(0, 0, 0, 0), Android: new Thickness(-25, 0, 0, 0), WinPhone: new Thickness(0));
            this.CPULayout.Padding = this.MemoryLayout.Padding = Device.OnPlatform(iOS: new Thickness(0, 0, 0, 0), Android: new Thickness(35,0,0,0), WinPhone: new Thickness(0));
            this.BackgroundColor = Device.OnPlatform(iOS: Color.White, Android: Color.Black, WinPhone: Color.Black);
            this.TitleLabel.Font = Font.OfSize("Normal", 35);
            this.CPULayout.Children.Add(getCPUGauge());
            this.MemoryLayout.Children.Add(getMemoryGauge());
            this.CPUChartLayout.Children.Add(GetCPUChart());
            this.MemoryChartLayout.Children.Add(GetMemoryChart());
            this.NetworkLayout.Children.Add(GetNetworkChart());
            this.MemoryPieLayout.Children.Add(getPieChart());            
        }

        public SfCircularGauge getMemoryGauge()
        {
            circularGaugeMemory = new SfCircularGauge();
            //circularGaugeMemory.GaugeHeight = Device.OnPlatform(iOS: 250, Android: 300, WinPhone: 200);
            //circularGaugeMemory.GaugeWidth = 300;
            //circularGaugeMemory.BackColor = Device.OnPlatform(iOS: Color.White, Android: Color.Black, WinPhone: Color.Black);
            //List<Scale> Scales = new List<Scale>();
            //Scale scale = new Scale();
            //scale.StartValue = 0;
            //scale.EndValue = 100;
            //scale.StartAngle = 180;
            //scale.SweepAngle = 180;
            //scale.Interval = 110;
            //scale.MinorTicksPerInterval = 0;
            //scale.LabelColor = Color.Transparent;
            //scale.MajorTickColor = Color.Transparent;
            //scale.LabelSize = 1;
            //scale.RimThickness = 40;
            //scale.MajorTicksHeight = 0;
            //scale.MinorTicksHeight = 0;
            //scale.RimColor = Color.FromHex("#FF565656");
            //Pointer pointer = new Pointer();
            //pointer.Value = 70;
            //pointer.NeedlePointerThickness = 10;
            //pointer.NeedlePointerColor = Color.FromHex("#FFE2E2E2");
            //pointer.NeedlePointerFactor = 1.2;
            //pointer.PointerKnobColor = Color.FromHex("#FFE2E2E2");
            //pointer.PointerKnobRadius = 30;
            //Pointer rPointer = new Pointer();
            //rPointer.Value = 70;
            //rPointer.IsNeedlePointer = false;
            //rPointer.RangePointerColor = Color.FromHex("#FF00B2DB");
            //rPointer.RangePointerThickness = 40;
            //rPointer.NeedlePointerFactor = 0;
            //Pointer dot = new Pointer();
            //dot.Value = 60;
            //dot.NeedlePointerThickness = 0;
            //dot.PointerKnobColor = Color.Black;
            //dot.PointerKnobRadius = 10;
            //dot.NeedlePointerFactor = 0;
            //List<Pointer> pointers = new List<Pointer>();
            //pointers.Add(rPointer);
            //pointers.Add(pointer);
            //pointers.Add(dot);
            //scale.Pointers = pointers;
            //Scales.Add(scale);
            //circularGaugeMemory.Scales = Scales;
            return circularGaugeMemory;
        }

        public SfCircularGauge getCPUGauge()
        {
            circularGaugeCPU = new SfCircularGauge();
            //circularGaugeCPU.GaugeHeight = Device.OnPlatform(iOS: 250, Android: 300, WinPhone: 200);
            //circularGaugeCPU.GaugeWidth = 300;
            //circularGaugeCPU.BackColor = Device.OnPlatform(iOS: Color.White, Android: Color.Black, WinPhone: Color.Black);
            //List<Scale> Scales = new List<Scale>();
            //Scale scale = new Scale();
            //scale.StartValue = 0;
            //scale.EndValue = 100;
            //scale.StartAngle = 180;
            //scale.SweepAngle = 180;
            //scale.Interval = 110;
            //scale.MinorTicksPerInterval = 0;
            //scale.LabelColor = Color.Transparent;
            //scale.MajorTickColor = Color.Transparent;
            //scale.LabelSize = 1;
            //scale.RimThickness = 40;
            //scale.MajorTicksHeight = 0;
            //scale.MinorTicksHeight = 0;
            //scale.RimColor = Color.FromHex("#FF565656");
            //Pointer pointer = new Pointer();
            //pointer.Value = 70;
            //pointer.NeedlePointerThickness = 10;
            //pointer.NeedlePointerColor = Color.FromHex("#FFE2E2E2");
            //pointer.NeedlePointerFactor = 1.2;
            //pointer.PointerKnobColor = Color.FromHex("#FFE2E2E2");
            //pointer.PointerKnobRadius = 30;
            //Pointer rPointer = new Pointer();
            //rPointer.Value = 70;
            //rPointer.IsNeedlePointer = false;
            //rPointer.RangePointerColor = Color.FromHex("#FFF47F30");
            //rPointer.RangePointerThickness = 40;
            //rPointer.NeedlePointerFactor = 0;
            //Pointer dot = new Pointer();
            //dot.Value = 60;
            //dot.NeedlePointerThickness = 0;
            //dot.PointerKnobColor = Color.Black;
            //dot.PointerKnobRadius = 10;
            //dot.NeedlePointerFactor = 0;
            //List<Pointer> pointers = new List<Pointer>();
            //pointers.Add(rPointer);
            //pointers.Add(pointer);
            //pointers.Add(dot);
            //scale.Pointers = pointers;
            //Scales.Add(scale);
            //circularGaugeCPU.Scales = Scales;
            return circularGaugeCPU;
        }

        private SfChart getPieChart()
        {
            SfChart Piechart = new SfChart();
            Piechart.BackgroundColor = Device.OnPlatform(iOS: Color.White, Android: Color.Black, WinPhone: Color.Black);
            Piechart.HeightRequest = Device.OnPlatform(iOS: 150, Android: 100, WinPhone: 200);
            PieSeries lineSeries = new PieSeries();
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint("54 % Used", 54));
            datas.Add(new ChartDataPoint("46 % Free", 46));
            lineSeries.ItemsSource = datas;
            lineSeries.DataMarker.ShowLabel = true;
            lineSeries.Label = "DataPoints";
            Piechart.Series.Add(lineSeries);
            Piechart.Legend = new ChartLegend();
            Piechart.Legend.LabelStyle.TextColor = Color.White;
            Piechart.Legend.IsVisible = true;
            
            return Piechart;
        }

        public SfChart GetCPUChart()
        {
            chartCPU = new SfChart();
            chartCPU.BackgroundColor = Device.OnPlatform(iOS: Color.White, Android: Color.Black, WinPhone: Color.Black);
            chartCPU.HeightRequest = Device.OnPlatform(iOS: 150, Android: 110, WinPhone: 250);
            chartCPU.WidthRequest = 200;
            chartCPU.PrimaryAxis = new NumericalAxis() ;
            chartCPU.PrimaryAxis.MajorTickStyle.TickSize = 10;
            chartCPU.SecondaryAxis = new NumericalAxis();
            LineSeries lineSeries = new LineSeries();
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 34));
            datas.Add(new ChartDataPoint(2, 24));
            datas.Add(new ChartDataPoint(3, 19));
            datas.Add(new ChartDataPoint(4, 21));
            datas.Add(new ChartDataPoint(5, 25));
            datas.Add(new ChartDataPoint(6, 5));
            datas.Add(new ChartDataPoint(7, 34));
            datas.Add(new ChartDataPoint(8, 24));
            datas.Add(new ChartDataPoint(9, 19));
            datas.Add(new ChartDataPoint(10, 21));
            datas.Add(new ChartDataPoint(11, 25));
            datas.Add(new ChartDataPoint(12, 76));
            datas.Add(new ChartDataPoint(13, 34));
            datas.Add(new ChartDataPoint(14, 24));
            datas.Add(new ChartDataPoint(15, 19));
            datas.Add(new ChartDataPoint(16, 21));
            datas.Add(new ChartDataPoint(17, 25));
            datas.Add(new ChartDataPoint(18, 32));
            datas.Add(new ChartDataPoint(19, 0));
            datas.Add(new ChartDataPoint(20, 32));
            datas.Add(new ChartDataPoint(21, 25));
            datas.Add(new ChartDataPoint(22, 32));
            datas.Add(new ChartDataPoint(23, 34));
            datas.Add(new ChartDataPoint(24, 24));
            datas.Add(new ChartDataPoint(25, 19));
            datas.Add(new ChartDataPoint(26, 21));
            datas.Add(new ChartDataPoint(27, 25));
            datas.Add(new ChartDataPoint(28, 32));
            datas.Add(new ChartDataPoint(29, 25));
            datas.Add(new ChartDataPoint(30, 32));
            datas.Add(new ChartDataPoint(31, 74));
            datas.Add(new ChartDataPoint(32, 32));
            datas.Add(new ChartDataPoint(33, 34));
            datas.Add(new ChartDataPoint(34, 24));
            datas.Add(new ChartDataPoint(35, 19));
            datas.Add(new ChartDataPoint(36, 21));
            datas.Add(new ChartDataPoint(37, 25));
            datas.Add(new ChartDataPoint(38, 32));
            datas.Add(new ChartDataPoint(39, 25));
            datas.Add(new ChartDataPoint(40, 32));
            lineSeries.ItemsSource = datas;
            lineSeries.DataMarker.ShowLabel = true;
            lineSeries.Label = "DataPoints";
            chartCPU.Series.Add(lineSeries);
            chartCPU.BackgroundColor = Color.Black;
            Device.StartTimer(new TimeSpan(0, 0, 0, 1), AddData);
            return chartCPU;
        }

        public SfChart GetMemoryChart()
        {
            chartMemory = new SfChart();
            chartMemory.BackgroundColor = Device.OnPlatform(iOS: Color.White, Android: Color.Black, WinPhone: Color.Black);
            chartMemory.HeightRequest = Device.OnPlatform(iOS: 150, Android: 110, WinPhone: 250);
            chartMemory.WidthRequest = 650;
            chartMemory.PrimaryAxis = new NumericalAxis();
            chartMemory.PrimaryAxis.MajorTickStyle.TickSize = 10;
            chartMemory.SecondaryAxis = new NumericalAxis();
            LineSeries lineSeries = new LineSeries();
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 59));
            datas.Add(new ChartDataPoint(2, 59));
            datas.Add(new ChartDataPoint(3, 59));
            datas.Add(new ChartDataPoint(4, 59));
            datas.Add(new ChartDataPoint(5, 59));
            datas.Add(new ChartDataPoint(6, 59));
            datas.Add(new ChartDataPoint(7, 60));
            datas.Add(new ChartDataPoint(8, 59));
            datas.Add(new ChartDataPoint(9, 56));
            datas.Add(new ChartDataPoint(10, 56));
            datas.Add(new ChartDataPoint(11, 56));
            datas.Add(new ChartDataPoint(12, 56));
            datas.Add(new ChartDataPoint(13, 56));
            datas.Add(new ChartDataPoint(14, 59));
            datas.Add(new ChartDataPoint(15, 59));
            datas.Add(new ChartDataPoint(16, 59));
            datas.Add(new ChartDataPoint(17, 59));
            datas.Add(new ChartDataPoint(18, 59));
            datas.Add(new ChartDataPoint(19, 59));
            datas.Add(new ChartDataPoint(20, 59));
            datas.Add(new ChartDataPoint(21, 59));
            datas.Add(new ChartDataPoint(22, 59));
            datas.Add(new ChartDataPoint(23, 59));
            datas.Add(new ChartDataPoint(24, 59));
            datas.Add(new ChartDataPoint(25, 58));
            datas.Add(new ChartDataPoint(26, 58));
            datas.Add(new ChartDataPoint(27, 58));
            datas.Add(new ChartDataPoint(28, 58));
            datas.Add(new ChartDataPoint(29, 58));
            datas.Add(new ChartDataPoint(30, 59));
            datas.Add(new ChartDataPoint(31, 59));
            datas.Add(new ChartDataPoint(32, 59));
            datas.Add(new ChartDataPoint(33, 59));
            datas.Add(new ChartDataPoint(34, 55));
            datas.Add(new ChartDataPoint(35, 55));
            datas.Add(new ChartDataPoint(36, 55));
            datas.Add(new ChartDataPoint(37, 55));
            datas.Add(new ChartDataPoint(38, 59));
            datas.Add(new ChartDataPoint(39, 62));
            datas.Add(new ChartDataPoint(40, 62));
            lineSeries.ItemsSource = datas;
            lineSeries.DataMarker.ShowLabel = true;
            lineSeries.Label = "DataPoints";
            lineSeries.Color = Color.Purple;
            chartMemory.Series.Add(lineSeries);
            chartMemory.BackgroundColor = Color.Black;
            return chartMemory;
        }

        public SfChart GetNetworkChart()
        {
            chartNetwork = new SfChart();
            chartNetwork.BackgroundColor = Device.OnPlatform(iOS: Color.White, Android: Color.Black, WinPhone: Color.Black);
            chartNetwork.HeightRequest = Device.OnPlatform(iOS: 150, Android: 110, WinPhone: 250);
            chartNetwork.WidthRequest = 650;
            chartNetwork.PrimaryAxis = new CategoryAxis() ;
            chartNetwork.PrimaryAxis.MajorTickStyle.TickSize = 10;
            chartNetwork.SecondaryAxis = new NumericalAxis();
            LineSeries lineSeries = new LineSeries();
            lineSeries.Color = Color.FromHex("#FFF4A460");
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 8));
            datas.Add(new ChartDataPoint(2, 8));
            datas.Add(new ChartDataPoint(3, 64));
            datas.Add(new ChartDataPoint(4, 64));
            datas.Add(new ChartDataPoint(5, 256));
            datas.Add(new ChartDataPoint(6, 0));
            datas.Add(new ChartDataPoint(7, 0));
            datas.Add(new ChartDataPoint(8, 64));
            datas.Add(new ChartDataPoint(9, 256));
            datas.Add(new ChartDataPoint(10, 8));
            datas.Add(new ChartDataPoint(11, 8));
            datas.Add(new ChartDataPoint(12, 8));
            datas.Add(new ChartDataPoint(13, 64));
            datas.Add(new ChartDataPoint(14, 64));
            datas.Add(new ChartDataPoint(15, 256));
            datas.Add(new ChartDataPoint(16, 0));
            datas.Add(new ChartDataPoint(17, 0));
            datas.Add(new ChartDataPoint(18, 64));
            datas.Add(new ChartDataPoint(19, 256));
            datas.Add(new ChartDataPoint(20, 8));
            datas.Add(new ChartDataPoint(21, 8));
            datas.Add(new ChartDataPoint(22, 8));
            datas.Add(new ChartDataPoint(23, 64));
            datas.Add(new ChartDataPoint(24, 64));
            datas.Add(new ChartDataPoint(25, 256));
            datas.Add(new ChartDataPoint(26, 0));
            datas.Add(new ChartDataPoint(27, 0));
            datas.Add(new ChartDataPoint(28, 64));
            datas.Add(new ChartDataPoint(29, 256));
            datas.Add(new ChartDataPoint(30, 8));
            datas.Add(new ChartDataPoint(31, 8));
            datas.Add(new ChartDataPoint(32, 8));
            datas.Add(new ChartDataPoint(33, 64));
            datas.Add(new ChartDataPoint(34, 64));
            datas.Add(new ChartDataPoint(35, 256));
            datas.Add(new ChartDataPoint(36, 0));
            datas.Add(new ChartDataPoint(37, 0));
            datas.Add(new ChartDataPoint(38, 64));
            datas.Add(new ChartDataPoint(39, 256));
            datas.Add(new ChartDataPoint(40, 8));
            lineSeries.ItemsSource = datas;
            lineSeries.DataMarker.ShowLabel = true;
            lineSeries.Label = "DataPoints";
            chartNetwork.Series.Add(lineSeries);
            chartNetwork.BackgroundColor = Color.Black;
            return chartNetwork;
        }

        private bool AddData()
        {
            i = i + 1;
            circularGaugeCPU.Scales[0].Pointers[0].Value = DataGenerator.CPUUnits;
            circularGaugeCPU.Scales[0].Pointers[1].Value = DataGenerator.CPUUnits;
            circularGaugeMemory.Scales[0].Pointers[0].Value = DataGenerator.MemoryUnits;
            circularGaugeMemory.Scales[0].Pointers[1].Value = DataGenerator.MemoryUnits;
            this.CPUUtilizationValue.Text =" "+ DataGenerator.CPUUnits + "%";
            this.MemoryUsageValue.Text = " " +DataGenerator.MemoryUnits + "%";
            this.MemoryUsedValue.Text = " " +DataGenerator.UsedSpace + "%";
            (chartCPU.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            (chartCPU.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, DataGenerator.CPUUnits));
            (chartMemory.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            (chartMemory.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, DataGenerator.MemoryUnits));
            (chartNetwork.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            (chartNetwork.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, DataGenerator.DownLoadRate));
            return true;
        }

        # endregion
    }

    #endregion

}
