#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfDiagram.XForms;
using SampleBrowser.Core;

namespace SampleBrowser.SfDiagram
{
    public partial class FlowDiagram : SampleView
    {
        public FlowDiagram()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.Android)
                Xamarin.Forms.DependencyService.Get<IText>().GenerateFactor();
            diagram.PageSettings.PageBackGround = Color.White;
            diagram.IsReadOnly = true;
            diagram.EnableSelectors = false;
            if (Device.OS == TargetPlatform.Windows)
            {
                diagram.PageSettings.PageWidth = 1600;
                diagram.BackgroundColor = Color.White;
            }

            //For iOS
            int Y = 60;
            //Create Node
            Node n1 = DrawNode(130, 80, 160, 55, ShapeType.Ellipse, "New idea identified");
            n1.Style.Brush = new SolidBrush(Color.FromRgb(49, 162, 255));
            n1.Style.StrokeBrush = new SolidBrush(Color.FromRgb(23, 132, 206));

            Y += 120;
            Node n2 = DrawNode(130, Y, 160, 55, ShapeType.RoundedRectangle, "Meeting With Board");
            if (Device.OS == TargetPlatform.Windows)
            {
                n2.ShapeType = ShapeType.Rectangle;
            }
            n2.Style.Brush = new SolidBrush(Color.FromRgb(49, 162, 255));
            n2.Style.StrokeBrush = new SolidBrush(Color.FromRgb(23, 132, 206));

            Y += 120;
            Node n3 = DrawNode(135, Y, 150, 150, ShapeType.Diamond, "Board decides to proceed");
            n3.Style.Brush = new SolidBrush(Color.FromRgb(0, 194, 192));
            n3.Style.StrokeBrush = new SolidBrush(Color.FromRgb(4, 142, 135));

            Y += 150;
            Node n4 = DrawNode(135, Y + 50, 150, 150, ShapeType.Diamond, "Write specification document");
            n4.Style.Brush = new SolidBrush(Color.FromRgb(0, 194, 192));
            n4.Style.StrokeBrush = new SolidBrush(Color.FromRgb(14, 142, 135));

            Y += 150;
            Node n5 = DrawNode(130, Y + 100, 160, 55, ShapeType.Ellipse, "Implement and deliver");
            n5.Style.Brush = new SolidBrush(Color.FromRgb(49, 162, 255));
            n5.Style.StrokeBrush = new SolidBrush(Color.FromRgb(23, 132, 206));

            Y = (int)(n3.OffsetY / App.factor);
            int X = (int)(n3.OffsetX / App.factor) + 350;
            Node n6 = DrawNode(X - 100, Y + 48, 160, 55, ShapeType.RoundedRectangle, "Reject and report the reason");
            if (Device.OS == TargetPlatform.Windows)
            {
                n6.ShapeType = ShapeType.Rectangle;
            }
            n6.Style.Brush = new SolidBrush(Color.FromRgb(239, 75, 93));
            n6.Style.StrokeBrush = new SolidBrush(Color.FromRgb(201, 32, 61));

            Y = (int)(n6.OffsetY / App.factor) + 150;
            X = (int)(n6.OffsetX / App.factor);
            Node n7 = DrawNode(X, Y + 50, 160, 55, ShapeType.RoundedRectangle, "Hire new resources");
            if (Device.OS == TargetPlatform.Windows)
            {
                n7.ShapeType = ShapeType.Rectangle;
            }
            n7.Style.Brush = new SolidBrush(Color.FromRgb(239, 75, 93));
            n7.Style.StrokeBrush = new SolidBrush(Color.FromRgb(201, 32, 61));

            //Add node to the diagram
            diagram.AddNode(n1);
            diagram.AddNode(n2);
            diagram.AddNode(n3);
            diagram.AddNode(n4);
            diagram.AddNode(n5);
            diagram.AddNode(n6);
            diagram.AddNode(n7);

            //Create Connector
            Connector c1 = new Connector();
            c1.SourceNode = n1;
            c1.TargetNode = n2;
            diagram.AddConnector(c1);

            Connector c2 = new Connector();
            c2.SourceNode = n2;
            c2.TargetNode = n3;
            diagram.AddConnector(c2);

            Connector c3 = new Connector();
            c3.SourceNode = n3;
            c3.TargetNode = n4;
            Annotation annotation3 = new Annotation();
            

            annotation3.Content = "Yes";
            annotation3.HorizontalAlignment = HorizontalAlignment.Left;
            annotation3.FontSize = 10 * App.factor;
            annotation3.TextBrush = new SolidBrush(Color.FromRgb(127, 132, 133));
            c3.Annotations.Add(annotation3);

            diagram.AddConnector(c3);

            Connector c4 = new Connector();
            c4.SourceNode = n4;
            c4.TargetNode = n5;
            c4.Annotations.Add(new Annotation()
            {
                Content = "Yes",
                FontSize = 10 * App.factor,
                TextBrush = new SolidBrush(Color.FromRgb(127, 132, 133))
            });
            diagram.AddConnector(c4);

            Connector c5 = new Connector();
            c5.SourceNode = n3;
            c5.TargetNode = n6;
            c5.Annotations.Add(new Annotation()
            {
                Content = "No",
                FontSize = 10 * App.factor,
                TextBrush = new SolidBrush(Color.FromRgb(127, 132, 133))
            });
            diagram.AddConnector(c5);

            Connector c6 = new Connector();
            c6.SourceNode = n4;
            c6.TargetNode = n7;
            diagram.AddConnector(c6);
            c6.Annotations.Add(new Annotation()
            {
                Content = "No",
                FontSize = 10 * App.factor,
                TextBrush = new SolidBrush(Color.FromRgb(127, 132, 133))
            });

            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(Color.FromRgb(127, 132, 133));
                diagram.Connectors[i].TargetDecoratorStyle.Fill = (Color.FromRgb(127, 132, 133));
                diagram.Connectors[i].TargetDecoratorStyle.Stroke = (Color.FromRgb(127, 132, 133));
                diagram.Connectors[i].TargetDecoratorStyle.StrokeThickness = 3;
                diagram.Connectors[i].Style.StrokeWidth = 1;
            }

            Content = diagram;
        }

        //Creates the Node with Specified input
        private Node DrawNode(float x, float y, float w, float h, ShapeType shape, string annotation)
        {
            var node = new Node();
            node.Style.StrokeWidth = 1;
            if (Device.OS == TargetPlatform.Android)
            {
                node.OffsetX = x * App.factor;
                node.OffsetY = y * App.factor;
                node.Width = w * App.factor;
                node.Height = h * App.factor;
            }
            else
            {
                node.OffsetX = x;
                node.OffsetY = y;
                node.Width = w;
                node.Height = h;
            }
            node.ShapeType = shape;

            if (Device.OS == TargetPlatform.Android)
            {
                var textView = Xamarin.Forms.DependencyService.Get<IText>().GetTextView(annotation, node.Width);
                node.Annotations.Add(new Annotation()
                {
                    Content = textView,
                    TextBrush = new SolidBrush(Color.White),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 10 * App.factor
                });
            }
            else
            {
                node.Annotations.Add(new Annotation()
                {
                    Content = annotation,
                    TextBrush = new SolidBrush(Color.FromRgb(255, 255, 255)),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 10 * App.factor
                });
            }
            return node;
        }
    }
}