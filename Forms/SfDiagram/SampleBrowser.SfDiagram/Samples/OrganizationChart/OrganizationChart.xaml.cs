#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDiagram.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfDiagram
{
    public partial class OrganizationChart : SampleView
    {
        Dictionary<string, Color> FillColor;
        Dictionary<string, Color> StrokeColor;
        Frame Notifier;
        public OrganizationChart()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.Android)
                Xamarin.Forms.DependencyService.Get<IText>().GenerateFactor();
            if (Device.OS == TargetPlatform.Windows)
            {
                diagram.IsReadOnly = true;
                diagram.BackgroundColor = Color.White;
            }
            diagram.IsReadOnly = true;
            diagram.EnableSelectors = false;
            diagram.PageSettings.PageBackGround = Color.White;
            diagram.NodeClicked += Diagram_NodeClicked;
            diagram.DiagramClicked += Diagram_DiagramClicked;
            FillColor = new Dictionary<string, Color>();
            FillColor.Add("Managing Director", Color.FromRgb(239, 75, 93));
            FillColor.Add("Project Manager", Color.FromRgb(49, 162, 255));
            FillColor.Add("Senior Manager", Color.FromRgb(49, 162, 255));
            FillColor.Add("Project Lead", Color.FromRgb(0, 194, 192));
            FillColor.Add("Senior S/W Engg", Color.FromRgb(0, 194, 192));
            FillColor.Add("Software Engg", Color.FromRgb(0, 194, 192));
            FillColor.Add("Team Lead", Color.FromRgb(0, 194, 192));
            FillColor.Add("Project Trainee", Color.FromRgb(255, 129, 0));

            StrokeColor = new Dictionary<string, Color>();
            StrokeColor.Add("Managing Director", Color.FromRgb(201, 32, 61));
            StrokeColor.Add("Project Manager", Color.FromRgb(23, 132, 206));
            StrokeColor.Add("Senior Manager", Color.FromRgb(23, 132, 206));
            StrokeColor.Add("Project Lead", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Senior S/W Engg", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Software Engg", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Team Lead", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Project Trainee", Color.FromRgb(206, 98, 9));
            DataModel datamodel = new DataModel();
            DataSourceSettings settings = new DataSourceSettings();
            datamodel.Data();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            settings.DataSource = datamodel.employee;
            diagram.DataSourceSettings = settings;

            //To Represent LayoutManager Properties
            if (Device.OS == TargetPlatform.Windows)
            {
                diagram.LayoutManager = new LayoutManager()
                {
                    Layout = new DirectedTreeLayout()
                    {
                        Type = LayoutType.Hierarchical,
                        HorizontalSpacing = 35,
                    }
                };
            }
            else
            {
                diagram.LayoutManager = new LayoutManager()
                {
                    Layout = new DirectedTreeLayout()
                    {
                        Type = LayoutType.Organization,
                        HorizontalSpacing = 35,
                    }
                };
            }
            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(Color.FromRgb(127, 132, 133));
                diagram.Connectors[i].Style.StrokeWidth = 1;
            }
            diagram.BeginNodeRender += Diagram_BeginNodeRender;
            diagram.BeginNodeLayout += Diagram_BeginNodeLayout;
            diagram.ItemLongPressed += Diagram_ItemLongPressed;
            diagram.Loaded += Diagram_Loaded;
        }

        private void Diagram_Loaded(object sender)
        {
            var RootNode = diagram.Nodes[0];
            diagram.BringToView(RootNode);
        }

        private void Diagram_ItemLongPressed(object sender, ItemLongPressedEventArgs args)
        {
            if (args.Item is Node)
                DisplayInfo(args.Item as Node);
        }

        void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            if ((args.Item.Content as DiagramEmployee).HasChild && args.Item.IsExpanded)
            {
                UpdateTemplate(args.Item, "+");
                args.Item.IsExpanded = false;
            }
            else if ((args.Item.Content as DiagramEmployee).HasChild && !args.Item.IsExpanded)
            {
                UpdateTemplate(args.Item, "-");
                args.Item.IsExpanded = true;
            }
        }

        private void Diagram_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
        {
            var node = (args.Item as Node);
            UpdateTemplate(node, "-");
        }

        private void Diagram_BeginNodeLayout(object sender, BeginNodeLayoutEventArgs args)
        {
            if (!args.HasChildNodes)
            {
                args.Type = ChartType.Left;
                args.Orientation = Orientation.Vertical;
            }
        }

        private void UpdateTemplate(Node node, string state)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                node.Width = 150;
                node.Height = 50;
            }
            node.Style.StrokeWidth = 1;
            StackLayout root;
            var NodeTemplate = new DataTemplate(() =>
            {
                root = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.Transparent
                };
                Image image = new Image();
                image.WidthRequest = 35;
                image.HeightRequest = 35;
                image.Margin = new Thickness(8);
                if (Device.OS == TargetPlatform.Windows)
                {
                    image.Source = ImagePathConverter.GetImageSource((node.Content as DiagramEmployee).ImageUrl);
                }
                else
                {
                    image.Source = (node.Content as DiagramEmployee).ImageUrl;
                }
                root.Children.Add(image);
                StackLayout content = new StackLayout()
                {
                    WidthRequest = 100,
                    HeightRequest = 40,
                    Orientation = StackOrientation.Vertical
                };
                Label name = new Label()
                {
                    TextColor = Color.FromRgb(255, 255, 255),
                    Margin = new Thickness(0, 8, 0, 0),
                    Text = (node.Content as DiagramEmployee).Name,
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };
                // name.SetBinding(Label.TextProperty, new Binding((node.Content as Employee).Name));
                Label designation = new Label()
                {
                    Text = (node.Content as DiagramEmployee).Designation,
                    TextColor = Color.FromRgb(255, 255, 255),
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };
                // designation.SetBinding(Label.TextProperty, new Binding((node.Content as Employee).Designation));
                content.Children.Add(name);
                content.Children.Add(designation);
                root.Children.Add(content);
                if (Device.OS != TargetPlatform.Windows)
                    if ((node.Content as DiagramEmployee).HasChild)
                    {
                        root.WidthRequest = 180;
                        Label Expand = new Label()
                        {
                            TextColor = Color.White,
                            Text = state,
                            FontSize = 35,
                            VerticalOptions = LayoutOptions.Center
                        };
                        Expand.Margin = new Thickness(0, 0, 5, 3);
                        root.Children.Add(Expand);
                    }
                if (Device.OS == TargetPlatform.Android)
                    return root;
                else
                {
                    Frame style = new Frame();
                    style.Content = root;
                    style.Padding = new Thickness(0);
                    style.CornerRadius = 5;
                    style.BackgroundColor = FillColor[(node.Content as DiagramEmployee).Designation];
                    style.OutlineColor = StrokeColor[((node.Content as DiagramEmployee).Designation)];
                    style.HasShadow = false;
                    return style;
                }
            });
            if (Device.OS == TargetPlatform.Android)
            {
                node.Style.Brush = new SolidBrush(FillColor[(node.Content as DiagramEmployee).Designation]);
                node.Style.StrokeBrush = new SolidBrush(StrokeColor[((node.Content as DiagramEmployee).Designation)]);
            }
            node.Template = NodeTemplate;
        }

        void Diagram_DiagramClicked(object sender, DiagramClickedEventArgs args)
        {
            if (Notifier != null)
            {
                Parent.Children.Remove(Notifier);
                Notifier = null;
                diagram.EnableZoomAndPan = true;
                diagram.NodeClicked += Diagram_NodeClicked;
                diagram.ItemLongPressed += Diagram_ItemLongPressed;
            }
        }

        void Ok_Clicked(object sender, EventArgs e)
        {
            Parent.Children.Remove(Notifier);
            Notifier = null;
            diagram.EnableZoomAndPan = true;
            diagram.NodeClicked += Diagram_NodeClicked;
            diagram.ItemLongPressed += Diagram_ItemLongPressed;
        }
        void DisplayInfo(Node node)
        {
            diagram.EnableZoomAndPan = false;
            diagram.NodeClicked -= Diagram_NodeClicked;
            diagram.ItemLongPressed -= Diagram_ItemLongPressed;
            StackLayout root;
            root = new StackLayout();

            Image image = new Image();
            image.WidthRequest = 120;
            image.HeightRequest = 120;
            image.VerticalOptions = LayoutOptions.Start;
            image.HorizontalOptions = LayoutOptions.Center;
            image.Source = (node.Content as DiagramEmployee).ImageUrl;
            root.Children.Add(image);

            TableView table = new TableView();
            table.Intent = TableIntent.Data;
            table.HeightRequest = 350;
            TableRoot src = new TableRoot();
            TableSection titlename = new TableSection("Name" + "\t\t\t" + ": " + (node.Content as DiagramEmployee).Name);
            TableSection titledesign = new TableSection("Designation" + "\t" + ": " + (node.Content as DiagramEmployee).Designation);
            TableSection titleid = new TableSection("ID" + "\t\t\t\t" + ": " + (node.Content as DiagramEmployee).ID);
            TableSection titledoj = new TableSection("DOJ" + "\t\t\t" + ": " + (node.Content as DiagramEmployee).DOJ);
            TableSection titleemail = new TableSection("Email ID" + "\t" + ": " + (node.Content as DiagramEmployee).EmailId);
            src.Add(titlename);
            src.Add(titledesign);
            src.Add(titleid);
            src.Add(titledoj);
            //src.Add(titleemail);
            if ((node.Content as DiagramEmployee).ReportingPerson != null)
            {
                TableSection titlereport = new TableSection("Supervisor" + "\t" + ": " + (node.Content as DiagramEmployee).ReportingPerson);
                src.Add(titlereport);
            }
            table.Margin = new Thickness(0, 5, 0, 0);
            table.Root = src;
            root.Children.Add(table);

            Button ok = new Button();
            ok.Text = "OK";
            ok.Margin = new Thickness(0, 15, 0, 0);
            ok.Clicked += Ok_Clicked;
            ok.WidthRequest = 300;
            ok.HeightRequest = 50;
            ok.VerticalOptions = LayoutOptions.CenterAndExpand;
            ok.HorizontalOptions = LayoutOptions.EndAndExpand;
            root.Children.Add(ok);

            Notifier = new Frame();
            Notifier.WidthRequest = 300;
            if (Device.OS == TargetPlatform.Android)
                Notifier.HeightRequest = 450;
            else
                Notifier.HeightRequest = 350;
            Notifier.Content = root;
            Notifier.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            Notifier.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            Notifier.CornerRadius = 5;
            Notifier.BackgroundColor = Color.White;
            Notifier.OutlineColor = FillColor[(node.Content as DiagramEmployee).Designation];
            Parent.Children.Add(Notifier);
        }
    }
}