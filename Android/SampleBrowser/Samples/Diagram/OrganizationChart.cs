#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDiagram.Android;

namespace SampleBrowser
{
    public partial class OrganizationChart : SamplePage
    {
        SfDiagram diagram;
        DataModel dataModel;
        Dictionary<string, Color> FillColor;
        Dictionary<string, Color> StrokeColor;
        private Button horizontal;
        private Button vertical;
        private Syncfusion.SfDiagram.Android.Orientation selectedOrientationType;
        private ChartType selectedChartType;
        private string selectedType;
        private ExpandButton expanded;

        public override View GetSampleContent(Context context)
        {
            //Create SfDiagram.
            diagram = new SfDiagram(context);
            diagram.EnableSelection = false;

            FillColor = new Dictionary<string, Color>();
            FillColor.Add("Managing Director", Color.Rgb(239, 75, 93));
            FillColor.Add("Project Manager", Color.Rgb(49, 162, 255));
            FillColor.Add("Senior Manager", Color.Rgb(49, 162, 255));
            FillColor.Add("Project Lead", Color.Rgb(0, 194, 192));
            FillColor.Add("Senior S/W Engg", Color.Rgb(0, 194, 192));
            FillColor.Add("Team Manager", Color.Rgb(0, 194, 192));
            FillColor.Add("Project Trainee", Color.Rgb(255, 129, 0));

            StrokeColor = new Dictionary<string, Color>();
            StrokeColor.Add("Managing Director", Color.Rgb(201, 32, 61));
            StrokeColor.Add("Project Manager", Color.Rgb(23, 132, 206));
            StrokeColor.Add("Senior Manager", Color.Rgb(23, 132, 206));
            StrokeColor.Add("Project Lead", Color.Rgb(4, 142, 135));
            StrokeColor.Add("Senior S/W Engg", Color.Rgb(4, 142, 135));
            StrokeColor.Add("Team Manager", Color.Rgb(4, 142, 135));
            StrokeColor.Add("Project Trainee", Color.Rgb(206, 98, 9));

            dataModel = new DataModel();
            diagram.BackgroundColor = Color.White;
            diagram.BeginNodeRender += Dia_BeginNodeRender;
            diagram.BeginNodeLayout += Dia_GetLayoutInfo;

            dataModel.Data();

            //To Represent DataSourceSttings Properties
            DataSourceSettings settings = new DataSourceSettings();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            settings.DataSource = dataModel.employee;
            diagram.DataSourceSettings = settings;

            //To Represent LayoutManager Properties
            diagram.LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Organization,
                    HorizontalSpacing = 70 * MainActivity.factor,
                    VerticalSpacing = 70 * MainActivity.factor
                }
            };

            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(Color.Rgb(127, 132, 133));
            }
            diagram.NodeClicked += Diagram_NodeClicked;
            return diagram;
        }

        private void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            Node node = args.Item;

            if (node.IsExpanded)
            {
                node.IsExpanded = false;
                if ((node.Content as DiagramEmployee).HasChild)
                    (node.Template.GetChildAt(0) as Button).Text = "+";
            }
            else
            {
                node.IsExpanded = true;
                if ((node.Content as DiagramEmployee).HasChild)
                    (node.Template.GetChildAt(0) as Button).Text = "-";
            }
            expanded.Invalidate();
        }

        ViewGroup DrawTemplate(Node node)
        {
            //TEMPLATE
            var template = new Shape(this, diagram.Context, node, dataModel, FillColor, StrokeColor);
            //EMP IMAGE
            var img = new ImageView(diagram.Context);
            img.SetImageResource((node.Content as DiagramEmployee).ImageId);
            img.SetPadding(0, (int)(10 * MainActivity.factor), 0, 0);
            img.Layout((int)(10 * MainActivity.factor), (int)(10 * MainActivity.factor), (int)(100 * MainActivity.factor), (int)(100 * MainActivity.factor));
            //Name of the employee.
            var name = new TextView(diagram.Context);
            name.Text = (node.Content as DiagramEmployee).Name;
            name.SetTextSize(Android.Util.ComplexUnitType.Px, 28 * MainActivity.factor);
            name.SetTextColor(Color.White);
            name.SetPadding(0, (int)(10 * MainActivity.factor), 0, 0);
            name.Layout((int)(110 * MainActivity.factor), (int)(10 * MainActivity.factor), (int)node.Width, (int)node.Height);
            //Designation of the employee.
            var designation = new TextView(diagram.Context);
            designation.Text = (node.Content as DiagramEmployee).Designation;
            designation.SetTextSize(Android.Util.ComplexUnitType.Px, 28 * MainActivity.factor);
            designation.SetTextColor(Color.White);
            designation.SetPadding(0, (int)(10 * MainActivity.factor), 0, 0);
            designation.Layout((int)(110 * MainActivity.factor), (int)(50 * MainActivity.factor), (int)node.Width, (int)node.Height);

            if ((node.Content as DiagramEmployee).HasChild)
            {
                expanded = new ExpandButton(diagram.Context, node, FillColor);
                template.SetExpanded(expanded);
                expanded.Text = "-";
                expanded.Typeface = Typeface.Create("Times New Roman", TypefaceStyle.Bold);
                expanded.TextAlignment = TextAlignment.Center;
                expanded.Gravity = GravityFlags.Center;
                expanded.SetTextSize(Android.Util.ComplexUnitType.Px, 54 * MainActivity.factor);
                expanded.SetTextColor(Color.White);
                expanded.SetPadding(0, (int)(10 * MainActivity.factor), 0, 0);
                expanded.SetColor(template.m_color);
                expanded.SetStrokeColor(template.m_strokeColor);
                expanded.Layout((int)(350 * MainActivity.factor), 0, (int)(node.Width - 10 * MainActivity.factor), (int)node.Height);
                template.AddView(expanded);

            }
            //Add the view to the template instance.
            template.AddView(img);
            template.AddView(name);
            template.AddView(designation);

            return template;
        }

        internal class ExpandButton : Button
        {
            private Node m_node;
            private Color m_strokeColor;
            private Paint paint;
            private Dictionary<string, Color> m_fillColor;

            internal ExpandButton(Context context, Node node, Dictionary<string, Color> fillColor) : base(context)
            {
                m_node = node;
                SetWillNotDraw(false);
                SetBackgroundColor(Color.Transparent);
                m_fillColor = fillColor;
            }

            public override bool OnTouchEvent(MotionEvent e)
            {
                switch (e.Action)
                {
                    case MotionEventActions.Up:
                        ExpandNode();                        
                        break;
                }
                return true;
            }
            internal void ExpandNode()
            {
                if (m_node.IsExpanded)
                {
                    m_node.IsExpanded = false;
                    Text = "+";
                }
                else
                {
                    m_node.IsExpanded = true;
                    Text = "-";
                }
            }
            protected override void OnDraw(Canvas canvas)
            {
                paint = new Android.Graphics.Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Android.Graphics.Paint.Style.Stroke);
                paint.Color = m_strokeColor;
                paint.StrokeWidth = 2 * MainActivity.factor;
                canvas.DrawLine(0, 0, 0, m_node.Height, paint);
                base.OnDraw(canvas);
            }

            internal void SetColor(Color color)
            {
                SetBackgroundColor(color);
            }

            internal void SetStrokeColor(Color strokeColor)
            {
                m_strokeColor = strokeColor;
            }
        }

        void Dia_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
        {
            //Set the node size and its properties.
            var node = (args.Item as Node);
            if ((node.Content as DiagramEmployee).HasChild)
                node.Width = 470 * MainActivity.factor;
            else
                node.Width = 370 * MainActivity.factor;
            node.Height = 120 * MainActivity.factor;
            node.Style.StrokeWidth = 2 * MainActivity.factor;
            node.Style.StrokeBrush = new SolidBrush(Color.Black);
            node.ShapeType = ShapeType.RoundedRectangle;
            node.CornerRadius = 10 * MainActivity.factor;
            node.Template = DrawTemplate(node);
        }

        void Dia_GetLayoutInfo(object sender, BeginNodeLayoutEventArgs args)
        {
            //Layout the diagram according to the selected type and orientation.
            if ((diagram.LayoutManager.Layout as DirectedTreeLayout).Type == LayoutType.Organization)
            {
                switch (selectedType)
                {
                    case "VerticalAlternate":
                        if (!args.HasSubTree)
                        {
                            args.Type = ChartType.Alternate;
                            args.Orientation = Syncfusion.SfDiagram.Android.Orientation.Vertical;
                        }
                        break;
                    case "VerticalLeft":
                        if (!args.HasSubTree)
                        {
                            args.Type = ChartType.Left;
                            args.Orientation = Syncfusion.SfDiagram.Android.Orientation.Vertical;
                        }
                        break;
                    case "VerticalRight":
                        if (!args.HasSubTree)
                        {
                            args.Type = ChartType.Right;
                            args.Orientation = Syncfusion.SfDiagram.Android.Orientation.Vertical;
                        }
                        break;
                    case "HorizontalAlternate":
                        if (!args.HasSubTree)
                        {
                            args.Type = ChartType.Alternate;
                            args.Orientation = Syncfusion.SfDiagram.Android.Orientation.Horizontal;
                        }
                        break;
                    case "HorizontalLeft":
                        if (!args.HasSubTree)
                        {
                            args.Type = ChartType.Left;
                            args.Orientation = Syncfusion.SfDiagram.Android.Orientation.Horizontal;
                        }
                        break;
                    case "HorizontalRight":
                        if (!args.HasSubTree)
                        {
                            args.Type = ChartType.Right;
                            args.Orientation = Syncfusion.SfDiagram.Android.Orientation.Horizontal;
                        }
                        break;
                }
            }
        }

        public override void OnApplyChanges()
        {
            //Applies the changes to the layout.
            selectedType = selectedOrientationType.ToString() + selectedChartType.ToString();
            (diagram.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout();
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            LinearLayout gridLinearLayout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

            layoutParams.TopMargin = 25;
            gridLinearLayout.LayoutParameters = layoutParams;
            gridLinearLayout.SetBackgroundResource(Resource.Drawable.LinearLayout_Border);


            int width = (int)(context.Resources.DisplayMetrics.WidthPixels - context.Resources.DisplayMetrics.Density);
            LinearLayout linearLayout1 = new LinearLayout(context);

            linearLayout1.Orientation = Android.Widget.Orientation.Vertical;

            TextView titleText = new TextView(context)
            {
                Text = "Orientation and ChartType",
                TextAlignment = TextAlignment.Center,
                Gravity = GravityFlags.Center,
                TextSize = 30
            };
            titleText.SetTypeface(null, TypefaceStyle.Bold);
            titleText.SetWidth(width);

            TextView descText = new TextView(context)
            {
                Text = "Please select the orientation and chart type.",
                TextAlignment = TextAlignment.TextStart,
                Gravity = GravityFlags.FillHorizontal,
                TextSize = 12
            };

            descText.SetPadding(0, 10, 0, 0);
            descText.SetWidth(width);

            linearLayout1.AddView(titleText);
            linearLayout1.AddView(descText);

            LinearLayout linearLayout2 = new LinearLayout(context);
            linearLayout2.SetPadding(0, 5, 0, 0);

            horizontal = new Button(context);
            horizontal.Text = "Horizontal";
            horizontal.Click += ComputeHorizontal_Click;
            horizontal.SetWidth(width);
            linearLayout2.AddView(horizontal);

            LinearLayout linearLayout3 = new LinearLayout(context);
            linearLayout3.SetPadding(0, 5, 0, 0);

            vertical = new Button(context);
            vertical.Text = "Vertical";
            vertical.Click += ComputeVertical_Click;
            vertical.SetWidth(width);

            linearLayout3.AddView(vertical);

            LinearLayout linearLayout4 = new LinearLayout(context);

            linearLayout4.Orientation = Android.Widget.Orientation.Horizontal;
            linearLayout4.SetPadding(0, 10, 0, 0);

            TextView selectText = new TextView(context)
            {
                Text = "Select a chart type",
                Gravity = GravityFlags.Start,
                TextSize = 15
            };

            selectText.SetWidth((int)(width * 0.4));

            Spinner spinner = new Spinner(context, SpinnerMode.Dialog);
            spinner.SetMinimumHeight(60);
            spinner.SetBackgroundColor(Color.Gray);
            spinner.DropDownWidth = 600;

            List<String> list = new List<String>();
            list.Add("Alternate");
            list.Add("Right");
            list.Add("Left");
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = dataAdapter;
            spinner.ItemSelected += sType_spinner_ItemSelected;

            spinner.SetGravity(GravityFlags.Start);
            spinner.SetMinimumWidth(width - (int)(width * 0.4));

            linearLayout4.AddView(selectText);
            linearLayout4.AddView(spinner);

            gridLinearLayout.AddView(linearLayout1);
            gridLinearLayout.AddView(linearLayout2);
            gridLinearLayout.AddView(linearLayout3);
            gridLinearLayout.AddView(linearLayout4);

            return gridLinearLayout;

        }

        private void ComputeHorizontal_Click(object sender, EventArgs e)
        {
            //Set the text color.
            horizontal.SetTextColor(Color.Red);
            vertical.SetTextColor(Color.Black);
            selectedOrientationType = Syncfusion.SfDiagram.Android.Orientation.Horizontal;
        }

        private void ComputeVertical_Click(object sender, EventArgs e)
        {
            vertical.SetTextColor(Color.Red);
            horizontal.SetTextColor(Color.Black);
            selectedOrientationType = Syncfusion.SfDiagram.Android.Orientation.Vertical;
        }

        void sType_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();

            if (selectedItem.Equals("Alternate"))
            {
                selectedChartType = ChartType.Alternate;
            }
            else if (selectedItem.Equals("Right"))
            {
                selectedChartType = ChartType.Right;
            }
            else if (selectedItem.Equals("Left"))
            {
                selectedChartType = ChartType.Left;
            }
        }

        internal class Shape : ViewGroup
        {
            internal Color m_color;
            internal Color m_strokeColor;
            private ExpandButton m_expanded;
            private Node m_node;
            private Dictionary<string, Color> m_fillColor;
            private OrganizationChart m_chart;

            internal Shape(OrganizationChart chart, Context context, Node node, DataModel dataModel, Dictionary<string, Color> fillColor, Dictionary<string, Color> strokeColor) : base(context)
            {
                m_chart = chart;
                SetX(0);
                SetY(0);
                if (LayoutParameters == null)
                    LayoutParameters = new ViewGroup.LayoutParams((int)node.Width, (int)node.Height);
                else
                {
                    LayoutParameters.Height = (int)node.Width;
                    LayoutParameters.Width = (int)node.Height;
                }
                m_node = node;
                SetBackgroundColor(Color.Transparent);
                m_fillColor = fillColor;
                SetColor(fillColor[(node.Content as DiagramEmployee).Designation]);
                SetStrokeColor(strokeColor[(node.Content as DiagramEmployee).Designation]);
            }

            protected override void OnDraw(Canvas canvas)
            {
                float cornerRadius = 20 * MainActivity.factor;
                Paint paint = new Paint();
                paint.SetStyle(Paint.Style.Stroke);
                paint.StrokeWidth = 2 * MainActivity.factor;
                paint.Color = m_strokeColor;
                paint.AntiAlias = true;
                canvas.DrawRoundRect(Left, Top, Right, Bottom, cornerRadius, cornerRadius, paint);
                paint = new Paint();
                paint.SetStyle(Paint.Style.Fill);
                paint.AntiAlias = true;
                paint.Color = m_color;
                canvas.DrawRoundRect(Left, Top, Right, Bottom, cornerRadius, cornerRadius, paint);
                base.OnDraw(canvas);
            }

            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
            }

            internal void SetColor(Color color)
            {
                m_color = color;
            }

            internal void SetStrokeColor(Color color)
            {
                m_strokeColor = color;
            }

            internal void SetExpanded(ExpandButton expanded)
            {
                m_expanded = expanded;
            }
        }
    }
}