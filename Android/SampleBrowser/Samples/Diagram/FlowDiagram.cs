#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDiagram.Android;

namespace SampleBrowser
{
    public partial class FlowDiagram : SamplePage
    {

        public override View GetSampleContent(Context context)
        {
            //Initialize the SfDiagram instance and set background.
            SfDiagram Diagram = new SfDiagram(context);
            Diagram.BackgroundColor = Color.White;

            //Create nodes and set the offset, size and other properties.
            Node n1 = new Node(context);
            n1.ShapeType = ShapeType.RoundedRectangle;
            n1.CornerRadius = 90 * MainActivity.factor;
            n1.OffsetX = 185 * MainActivity.factor;
            n1.OffsetY = 80 * MainActivity.factor;
            n1.Width = 320 * MainActivity.factor;
            n1.Height = 110 * MainActivity.factor;
            n1.Style.Brush = new SolidBrush(Color.Rgb(49, 162, 255));
            n1.Style.StrokeBrush = new SolidBrush(Color.Rgb(23, 132, 206));
            TextView content1 = CreateLabel(context, "New idea identified", (int)n1.Width, Color.Rgb(255, 255, 255));
            n1.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content1 });
            Diagram.AddNode(n1);

            Node n2 = new Node(context);
            n2.OffsetX = 185 * MainActivity.factor;
            n2.OffsetY = 280 * MainActivity.factor;
            n2.Width = 320 * MainActivity.factor;
            n2.Height = 110 * MainActivity.factor;
            n2.ShapeType = ShapeType.RoundedRectangle;
            n2.CornerRadius = 15 * MainActivity.factor;
            n2.Style.Brush = new SolidBrush(Color.Rgb(49, 162, 255));
            n2.Style.StrokeBrush = new SolidBrush(Color.Rgb(23, 132, 206));
            TextView content2 = CreateLabel(context, "Meeting With Boards", (int)n2.Width, Color.Rgb(255, 255, 255));
            n2.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content2 });
            Diagram.AddNode(n2);

            Node n3 = new Node(context);
            n3.ShapeType = ShapeType.Diamond;
            n3.OffsetX = 195 * MainActivity.factor;
            n3.OffsetY = 480 * MainActivity.factor;
            n3.Width = 300 * MainActivity.factor;
            n3.Height = 300 * MainActivity.factor;
            n3.Style.Brush = new SolidBrush(Color.Rgb(0, 194, 192));
            n3.Style.StrokeBrush = new SolidBrush(Color.Rgb(4, 142, 135));
            TextView content3 = CreateLabel(context, "Board decides" + "\n" + "whether to" + "\n" + "proceed", (int)n3.Width, Color.Rgb(255, 255, 255));
            n3.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content3 });
            Diagram.AddNode(n3);

            Node n4 = new Node(context);
            n4.ShapeType = ShapeType.Diamond;
            n4.OffsetX = 195 * MainActivity.factor;
            n4.OffsetY = 870 * MainActivity.factor;
            n4.Width = 300 * MainActivity.factor;
            n4.Height = 300 * MainActivity.factor;
            n4.Style.Brush = new SolidBrush(Color.Rgb(0, 194, 192));
            n4.Style.StrokeBrush = new SolidBrush(Color.Rgb(4, 142, 135));
            TextView content4 = CreateLabel(context, "Find Project" + "\n" + "Manager, write" + "\n" + "specification", (int)n4.Width, Color.Rgb(255, 255, 255));
            n4.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content4 });
            Diagram.AddNode(n4);

            Node n5 = new Node(context);
            n5.Style.Brush = new SolidBrush(Color.Rgb(49, 162, 255));
            n5.Style.StrokeBrush = new SolidBrush(Color.Rgb(23, 132, 206));
            n5.OffsetX = 185 * MainActivity.factor;
            n5.OffsetY = 1260 * MainActivity.factor;
            n5.Width = 320 * MainActivity.factor;
            n5.Height = 110 * MainActivity.factor;
            n5.ShapeType = ShapeType.RoundedRectangle;
            n5.CornerRadius = 90 * MainActivity.factor;
            TextView content5 = CreateLabel(context, "Implement and deliver", (int)n5.Width, Color.Rgb(255, 255, 255));
            n5.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content5 });
            Diagram.AddNode(n5);

            Node n6 = new Node(context);
            n6.Style.Brush = new SolidBrush(Color.Rgb(239, 75, 93));
            n6.Style.StrokeBrush = new SolidBrush(Color.Rgb(201, 32, 61));
            n6.OffsetX = 674 * MainActivity.factor;
            n6.OffsetY = 575 * MainActivity.factor;
            n6.Width = 320 * MainActivity.factor;
            n6.Height = 110 * MainActivity.factor;
            n6.ShapeType = ShapeType.RoundedRectangle;
            n6.CornerRadius = 15 * MainActivity.factor;
            TextView content6 = CreateLabel(context, "Reject and report the reason", (int)n6.Width, Color.Rgb(255, 255, 255));
            n6.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content6 });
            Diagram.AddNode(n6);

            Node n7 = new Node(context);
            n7.Style.Brush = new SolidBrush(Color.Rgb(239, 75, 93));
            n7.Style.StrokeBrush = new SolidBrush(Color.Rgb(201, 32, 61));
            n7.OffsetX = 674 * MainActivity.factor;
            n7.OffsetY = 965.599f * MainActivity.factor;
            n7.Width = 320 * MainActivity.factor;
            n7.Height = 110 * MainActivity.factor;
            n7.ShapeType = ShapeType.RoundedRectangle;
            n7.CornerRadius = 15 * MainActivity.factor;
            TextView content7 = CreateLabel(context, "Hire new resources", (int)n7.Width, Color.Rgb(255, 255, 255));
            n7.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content7 });
            Diagram.AddNode(n7);

            //Create connector with its source and target node.
            Connector c1 = new Connector(context, n1, n2);
            Diagram.AddConnector(c1);

            Connector c2 = new Connector(context, n2, n3);
            Diagram.AddConnector(c2);

            Connector c3 = new Connector(context, n3, n4);
            //Create label for the connector.
            TextView label = CreateConnectorLabel(context, "Yes", 35, 10, 100, 50, GravityFlags.Right);
            label.SetPadding((int)(10 * MainActivity.factor), 0, (int)(10 * MainActivity.factor), (int)(10 * MainActivity.factor));
            c3.Annotations.Add(new Annotation() { Content = label, HorizontalAlignment = HorizontalAlignment.Left });
            Diagram.AddConnector(c3);

            Connector c4 = new Connector(context, n4, n5);
            TextView label2 = CreateConnectorLabel(context, "Yes", 35, 10, 100, 50, GravityFlags.Right);
            label2.SetPadding((int)(10 * MainActivity.factor), 0, (int)(10 * MainActivity.factor), (int)(10 * MainActivity.factor));
            c4.Annotations.Add(new Annotation() { Content = label2, HorizontalAlignment = HorizontalAlignment.Left });
            Diagram.AddConnector(c4);
            Diagram.EnableSelection = false;
            Connector c5 = new Connector(context, n3, n6);
            TextView label3 = CreateConnectorLabel(context, "No", 67, 10, 100, 50, GravityFlags.Bottom);
            //label3.SetPadding(0, (int)(10 * MainActivity.factor), (int)(10 * MainActivity.factor), 0);
            c5.Annotations.Add(new Annotation() { Content = label3 });
            Diagram.AddConnector(c5);

            Connector c6 = new Connector(context, n4, n7);
            TextView label4 = CreateConnectorLabel(context, "No", 67, 10, 100, 50, GravityFlags.Bottom);
            //label4.SetPadding(0, 0,(int)( 10* MainActivity.factor), (int)(10 * MainActivity.factor));
            c6.Annotations.Add(new Annotation() { Content = label4 });
            Diagram.AddConnector(c6);

            //Set the stroke color for the connector.
            for (int i = 0; i < Diagram.Connectors.Count; i++)
            {
                //Diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                Diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(Color.Rgb(127, 132, 133));
                Diagram.Connectors[i].TargetDecoratorStyle.Fill = (Color.Rgb(127, 132, 133));
                Diagram.Connectors[i].TargetDecoratorStyle.StrokeColor = (Color.Rgb(127, 132, 133));
                Diagram.Connectors[i].TargetDecoratorStyle.StrokeWidth = 4 * MainActivity.factor;
                Diagram.Connectors[i].TargetDecoratorStyle.Size = 14 * MainActivity.factor;
                Diagram.Connectors[i].Style.StrokeWidth = 1 * MainActivity.factor;
            }
            //Set the stroke size for node.
            for (int i = 0; i < Diagram.Nodes.Count; i++)
            {
                Diagram.Nodes[i].Style.StrokeWidth = 1;
            }
            return Diagram;
        }

        private TextView CreateConnectorLabel(Context context, string text, int l, int t, int r, int b, GravityFlags gravityFlags)
        {
            //Create a textview and set its properties.
            TextView label = new TextView(context);
            label.Text = text;
            label.SetTextSize(ComplexUnitType.Px, 18 * MainActivity.factor);
            label.Gravity = gravityFlags;
            label.SetTextColor(Color.Rgb(127, 132, 133));
            label.Typeface = Typeface.Create("Times New Roman", TypefaceStyle.Normal);
            label.Layout((int)(l * MainActivity.factor), (int)(t * MainActivity.factor), (int)(r * MainActivity.factor), (int)(b * MainActivity.factor));
            return label;
        }

        internal static TextView CreateLabel(Context context, string text, int width, Color color)
        {
            //Create a text view and assign its properties.
            TextView label = new TextView(context);
            label.Typeface = Typeface.Create(".SF UI Text", TypefaceStyle.Normal);
            label.SetText(text, TextView.BufferType.Normal);
            label.SetTextSize(ComplexUnitType.Px, 28 * MainActivity.factor);
            label.Gravity = GravityFlags.Center;
            int widthMeasureSpec = View.MeasureSpec.MakeMeasureSpec(
                (int)width, MeasureSpecMode.AtMost);
            int heightMeasureSpec = View.MeasureSpec.MakeMeasureSpec(
            0, MeasureSpecMode.Unspecified);

            label.Measure(widthMeasureSpec, heightMeasureSpec);
            label.Left = label.Top = 0;
            label.Bottom = label.MeasuredHeight;
            label.Right = label.MeasuredWidth;
            label.SetTextColor(color);
            return label;
        }
    }
}