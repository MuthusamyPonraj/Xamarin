#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfChart
{
	public partial class TechnicalIndicator : SampleView
	{
        Picker animationPicker;
        public TechnicalIndicator()
        {
            InitializeComponent();
            animationPicker = new Picker();
            animationPicker.Items.Add("Accumulation Distribution");
            animationPicker.Items.Add("Average True");
            animationPicker.Items.Add("Exponential Moving Average");
            animationPicker.Items.Add("Momentum");
            animationPicker.Items.Add("Simple Moving Average");
            animationPicker.Items.Add("RSI Indicator");
            animationPicker.Items.Add("Triangular Moving Average");
            animationPicker.Items.Add("MACD Indicator");
            animationPicker.Items.Add("Stochastic");
            animationPicker.Items.Add("Bollinger Band");
            
            animationPicker.SelectedIndex = 4;
            animationPicker.Title = "Technical Indicator Type";

            SimpleMovingAverageIndicator sma4 = new SimpleMovingAverageIndicator();
            NumericalAxis numericalAxis4 = new NumericalAxis();
            numericalAxis4.OpposedPosition = true;
            numericalAxis4.ShowMajorGridLines = false;
            sma4.YAxis = numericalAxis4;
            sma4.SeriesName = "Series";
            sma4.Period = 14;
            Chart.TechnicalIndicators.Add(sma4);
            animationPickerLabel.Text = "Simple Moving Average";

            rootLayout.Children.Add(animationPicker);

            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
                animationPicker.IsVisible = false;
            else
            {
                WinPhonePickerLayout.Margin = new Thickness(5);
                WinPhonePickerLayout.Children.Add(animationPicker);
            }

            animationPicker.SelectedIndexChanged += labelDisplayMode_SelectedIndexChanged;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Command = new Command(TapGestureRecognizer_Tapped);
            tapGestureRecognizer.NumberOfTapsRequired = 1;

            pickerLayout.GestureRecognizers.Add(tapGestureRecognizer);

            animationPickerTitle.Margin = new Thickness(10, 5, 10, 0);
            animationPickerLabel.Margin = new Thickness(10, 5, 10, 5);
        }

        private void TapGestureRecognizer_Tapped()
        {
            animationPicker.Focus();
        }

        void labelDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
		{
            animationPickerLabel.Text = animationPicker.Items[animationPicker.SelectedIndex];

            switch (animationPicker.SelectedIndex)
			{
				case 0:
					Chart.TechnicalIndicators.RemoveAt(0);
					AccumulationDistributionIndicator sma = new AccumulationDistributionIndicator();
					sma.SeriesName = "Series";
					NumericalAxis numericalAxis = new NumericalAxis();
					numericalAxis.OpposedPosition = true;
					numericalAxis.ShowMajorGridLines = false;
					sma.YAxis = numericalAxis;
					Chart.TechnicalIndicators.Add(sma);
					break;
				case 1:
					Chart.TechnicalIndicators.RemoveAt(0);
					AverageTrueIndicator sma1 = new AverageTrueIndicator();
					sma1.SeriesName = "Series";
					sma1.Period = 14;
					NumericalAxis numericalAxis1 = new NumericalAxis();
					numericalAxis1.OpposedPosition = true;
					numericalAxis1.ShowMajorGridLines = false;
					sma1.YAxis = numericalAxis1;
					Chart.TechnicalIndicators.Add(sma1);
					break;
				case 2:
					Chart.TechnicalIndicators.RemoveAt(0);
					ExponentialMovingAverageIndicator sma2 = new ExponentialMovingAverageIndicator();
					sma2.SeriesName = "Series";
					sma2.Period = 14;
					NumericalAxis numericalAxis2 = new NumericalAxis();
					numericalAxis2.OpposedPosition = true;
					numericalAxis2.ShowMajorGridLines = false;
					sma2.YAxis = numericalAxis2;
					Chart.TechnicalIndicators.Add(sma2);
					break;
				case 3:
					Chart.TechnicalIndicators.RemoveAt(0);
					MomentumIndicator sma3 = new MomentumIndicator();
					sma3.SeriesName = "Series";
					sma3.Period = 14;
					NumericalAxis numericalAxis3 = new NumericalAxis();
					numericalAxis3.OpposedPosition = true;
					numericalAxis3.ShowMajorGridLines = false;
					sma3.YAxis = numericalAxis3;
					Chart.TechnicalIndicators.Add(sma3);
					break;
				case 4:
					if (Chart.TechnicalIndicators.Count > 0)
						Chart.TechnicalIndicators.RemoveAt(0);
					SimpleMovingAverageIndicator sma4 = new SimpleMovingAverageIndicator();
					NumericalAxis numericalAxis4 = new NumericalAxis();
					numericalAxis4.OpposedPosition = true;
					numericalAxis4.ShowMajorGridLines = false;
					sma4.YAxis = numericalAxis4;
					sma4.SeriesName = "Series";
					sma4.Period = 14;
					Chart.TechnicalIndicators.Add(sma4);
					break;
				case 5:
					Chart.TechnicalIndicators.RemoveAt(0);
					RSIIndicator sma5 = new RSIIndicator();
					sma5.SeriesName = "Series";
					sma5.Period = 14;
					NumericalAxis numericalAxis5 = new NumericalAxis();
					numericalAxis5.OpposedPosition = true;
					numericalAxis5.ShowMajorGridLines = false;
					sma5.YAxis = numericalAxis5;
					Chart.TechnicalIndicators.Add(sma5);
					break;
				case 6:
					Chart.TechnicalIndicators.RemoveAt(0);
					TriangularMovingAverageIndicator sma6 = new TriangularMovingAverageIndicator();
					sma6.SeriesName = "Series";
					sma6.Period = 14;
					NumericalAxis numericalAxis6 = new NumericalAxis();
					numericalAxis6.OpposedPosition = true;
					numericalAxis6.ShowMajorGridLines = false;
					sma6.YAxis = numericalAxis6;
					Chart.TechnicalIndicators.Add(sma6);
					break;
				case 7:
					Chart.TechnicalIndicators.RemoveAt(0);
					MACDIndicator sma7 = new MACDIndicator();
					sma7.ItemsSource = (Chart.BindingContext as TechnicalIndicatorViewModel).TechnicalIndicatorData;
					sma7.SeriesName = "Series";
					sma7.LongPeriod = 10;
					sma7.ShortPeriod = 2;
					sma7.Trigger = 14;
					NumericalAxis numericalAxis7 = new NumericalAxis();
					numericalAxis7.OpposedPosition = true;
					numericalAxis7.ShowMajorGridLines = false;
					sma7.YAxis = numericalAxis7;
					Chart.TechnicalIndicators.Add(sma7);
					break;
				case 8:
					Chart.TechnicalIndicators.RemoveAt(0);
					StochasticIndicator sma8 = new StochasticIndicator();
					sma8.SeriesName = "Series";
					sma8.Period = 14;
					sma8.KPeriod = 5;
					sma8.DPeriod = 6;
					NumericalAxis numericalAxis8 = new NumericalAxis();
					numericalAxis8.OpposedPosition = true;
					numericalAxis8.ShowMajorGridLines = false;
					sma8.YAxis = numericalAxis8;
					Chart.TechnicalIndicators.Add(sma8);
					break;
				case 9:
					Chart.TechnicalIndicators.RemoveAt(0);
					BollingerBandIndicator sma9 = new BollingerBandIndicator();
					sma9.Period = 14;
					sma9.SeriesName = "Series";
					NumericalAxis numericalAxis9 = new NumericalAxis();
					numericalAxis9.OpposedPosition = true;
					numericalAxis9.ShowMajorGridLines = false;
					sma9.YAxis = numericalAxis9;
					Chart.TechnicalIndicators.Add(sma9);
					break;
			}
		}
	}
}