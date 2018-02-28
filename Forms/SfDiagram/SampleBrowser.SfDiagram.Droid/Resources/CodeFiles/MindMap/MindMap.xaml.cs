#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using Syncfusion.SfDiagram.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfDiagram
{
	public partial class MindMap : SampleView
	{
		Node RootNode;
		UserHandleCollection DefaultHandles;
		UserHandleCollection RightSideHandle;
		UserHandleCollection LeftSideHandles;
		Node SelectedNode;
		Frame Notifier;
		Frame InfoNotifier;
		Entry textinput;
		UserHandlePosition CurrentHandle;
		Random rnd = new Random();
		DataTemplate ExpandTemplate;
		DataTemplate CollapseTemplate;
		String path;
        Editor CommentBoxEntry;
        List<Color> FColor = new List<Color>();
        List<Color> SColor = new List<Color>();
        int index;
        public MindMap()
		{
			InitializeComponent();
            if (Device.RuntimePlatform == Device.UWP)
            {
                var label = new Label();
                label.Text = "Sample Not Supported !";
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.VerticalTextAlignment = TextAlignment.Center;
                label.FontSize = 15;
                Parent.Children.Add(label);
                diagram.IsReadOnly = true;
            }
            else
            {
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    path = "Images/";
                    if (Device.RuntimePlatform == Device.Android)
                        path = "";
                }
                int width = 150;
                int height = 75;
                if (Device.RuntimePlatform == Device.Android)
                {
                    width = (int)(125 * App.factor);
                    height = (int)(60 * App.factor);
                }
                var node = AddNode(300, 400, width, height, "Goals");
                AddNodeStyle(node, Color.FromHex("#d0ebff"), Color.FromHex("#81bfea"));
                RootNode = node;
                diagram.AddNode(node);

                SColor.Add(Color.FromHex("#d1afdf"));
                SColor.Add(Color.FromHex("#90C8C2"));
                SColor.Add(Color.FromHex("#8BC1B7"));
                SColor.Add(Color.FromHex("#E2C180"));
                SColor.Add(Color.FromHex("#BBBFD6"));
                SColor.Add(Color.FromHex("#ACCBAA"));
                FColor.Add(Color.FromHex("#e9d4f1"));
                FColor.Add(Color.FromHex("#d4efed"));
                FColor.Add(Color.FromHex("#c4f2e8"));
                FColor.Add(Color.FromHex("#f7e0b3"));
                FColor.Add(Color.FromHex("#DEE2FF"));
                FColor.Add(Color.FromHex("#E5FEE4"));

                var ch1node =AddNode(100, 100, width, height, "Financial");
                index = rnd.Next(5);
                AddNodeStyle(ch1node, FColor[index], SColor[index]);
                diagram.AddNode(ch1node);

                var ch1childnode = AddNode(100, 100, width, height, "Investment");
                AddNodeStyle(ch1childnode, (ch1node.Style.Brush as SolidBrush).FillColor, (ch1node.Style.StrokeBrush as SolidBrush).FillColor);
                diagram.AddNode(ch1childnode);

                var ch2node = AddNode(100, 600, width, height, "Social");
                index = rnd.Next(5);
                AddNodeStyle(ch2node, FColor[index], SColor[index]);
                diagram.AddNode(ch2node);

                var ch2childnode1 = AddNode(100, 100, width, height, "Friends");
                AddNodeStyle(ch2childnode1, (ch2node.Style.Brush as SolidBrush).FillColor, (ch2node.Style.StrokeBrush as SolidBrush).FillColor);
                diagram.AddNode(ch2childnode1);

                var ch2childnode2 = AddNode(100, 100, width, height, "Family");
                AddNodeStyle(ch2childnode2, (ch2node.Style.Brush as SolidBrush).FillColor, (ch2node.Style.StrokeBrush as SolidBrush).FillColor);
                diagram.AddNode(ch2childnode2);

                var ch3node = AddNode(500, 100, width, height, "Personal");
                index = rnd.Next(5);
                AddNodeStyle(ch3node, FColor[index], SColor[index]);
                diagram.AddNode(ch3node);

                var ch3childnode1 = AddNode(500, 100, width, height, "Sports");
                AddNodeStyle(ch3childnode1, (ch3node.Style.Brush as SolidBrush).FillColor, (ch3node.Style.StrokeBrush as SolidBrush).FillColor);
                diagram.AddNode(ch3childnode1);

                var ch3childnode2 = AddNode(500, 100, width, height, "Food");
                AddNodeStyle(ch3childnode2, (ch3node.Style.Brush as SolidBrush).FillColor, (ch3node.Style.StrokeBrush as SolidBrush).FillColor);
                diagram.AddNode(ch3childnode2);

                var ch4node = AddNode(500, 600, width, height, "Work");
                index = rnd.Next(5);
                AddNodeStyle(ch4node, FColor[index], SColor[index]);
                diagram.AddNode(ch4node);

                var ch4childnode1 = AddNode(500, 100, width, height, "Project");
                AddNodeStyle(ch4childnode1, (ch4node.Style.Brush as SolidBrush).FillColor, (ch4node.Style.StrokeBrush as SolidBrush).FillColor);
                diagram.AddNode(ch4childnode1);

                var ch4childnode2 = AddNode(500, 100, width, height, "Career");
                AddNodeStyle(ch4childnode2, (ch4node.Style.Brush as SolidBrush).FillColor, (ch4node.Style.StrokeBrush as SolidBrush).FillColor);
                diagram.AddNode(ch4childnode2);

                diagram.AddConnector(AddConnector(node, ch1node));
                diagram.AddConnector(AddConnector(node, ch2node));
                diagram.AddConnector(AddConnector(node, ch3node));
                diagram.AddConnector(AddConnector(node, ch4node));
                diagram.AddConnector(AddConnector(ch1node, ch1childnode));
                diagram.AddConnector(AddConnector(ch2node, ch2childnode1));
                diagram.AddConnector(AddConnector(ch2node, ch2childnode2));
                diagram.AddConnector(AddConnector(ch3node, ch3childnode1));
                diagram.AddConnector(AddConnector(ch3node, ch3childnode2));
                diagram.AddConnector(AddConnector(ch4node, ch4childnode1));
                diagram.AddConnector(AddConnector(ch4node, ch4childnode2));

                diagram.UserHandleClicked += Diagram_UserHandleClicked;
                AddHandles();
                diagram.NodeClicked += Diagram_NodeClicked;

                diagram.DiagramClicked += Diagram_DiagramClicked;
                diagram.Loaded += Diagram_Loaded;
                SelectedNode = node;
                diagram.TextChanged += Diagram_TextChanged;
                diagram.ConnectorClicked+= Diagram_ConnectorClicked;
            }
		}

        private Connector AddConnector(Node node, Node ch1node)
        {
            var c1 = new Connector();
            c1.SourceNode = node;
            c1.TargetNode = ch1node;
            c1.Style.StrokeBrush = new SolidBrush((c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor);
            c1.Style.StrokeStyle = StrokeStyle.Dashed;
            c1.Style.StrokeWidth = 3;
            c1.TargetDecoratorStyle.Fill = (c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor;
            c1.TargetDecoratorStyle.Stroke = (c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor;
            c1.SegmentType = SegmentType.CurveSegment;
            return c1;
        }

        private void AddNodeStyle(Node node, Color fill, Color Stroke)
        {
            node.Style.Brush = new SolidBrush(fill);
            node.Style.StrokeBrush = new SolidBrush(Stroke);
        }

        Node AddNode(int x, int y, int w, int h, string text)
        {
            var node = new Node(x, y, w, h);
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 3;
            if (Device.RuntimePlatform == Device.Android)
                node.Annotations.Add(new Annotation() { Content = text, FontSize = 14 * App.factor, TextBrush = new SolidBrush(Color.Black) });
            else if (Device.RuntimePlatform == Device.iOS)
                node.Annotations.Add(new Annotation() { Content = text, FontSize = 15, TextBrush = new SolidBrush(Color.Black) });
            return node;
        }

		private void AddAnnotation(string headertext)
		{
			StackLayout root;
			root = new StackLayout();
			Label title = new Label();
			title.Margin = new Thickness(0, 2, 0, 0);
			title.Text = headertext;
			title.TextColor = Color.Black;
			title.FontSize = 15;
			title.FontAttributes = FontAttributes.Bold;
			title.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
			title.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
			root.Children.Add(title);

			textinput = new Entry();
			textinput.Margin = new Thickness(0, 25, 0, 0);
			textinput.WidthRequest = 300;
			textinput.HeightRequest = 50;
			textinput.Focused += Textinput_Focused;
			textinput.Focus();
			textinput.Placeholder = "Text";
			textinput.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
			textinput.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };

			Button ok = new Button();
			ok.Text = "OK";
			ok.Margin = new Thickness(0, 5, 0, 0);
			ok.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
			ok.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
			ok.Clicked += Ok_Clicked;
			root.Children.Add(textinput);
			root.Children.Add(ok);

			Notifier = new Frame();
			Notifier.WidthRequest = 300;
			Notifier.HeightRequest = 150;
			Notifier.Content = root;
			Notifier.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
			Notifier.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
			Notifier.CornerRadius = 5;
			Notifier.BackgroundColor = Color.White;
			Notifier.OutlineColor = Color.Black;
			diagram.PageSettings.PageBackGround = Color.DarkGray;
			diagram.Opacity = 0.2;
			Parent.Children.Add(Notifier);
		}
       

		private void AddHandles()
		{
			var template = new DataTemplate(() =>
			{
				var root = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.Transparent
				};
				Image image = new Image();
				image.WidthRequest = 25;
				image.HeightRequest = 25;
                if (Device.RuntimePlatform == Device.iOS)
                    image.Source = path + "plus.png";
                else if (Device.RuntimePlatform == Device.Android)
                    image.Source = path + "mindmapplus.png";
				root.Children.Add(image);
				return root;
			});
			var deltemplate = new DataTemplate(() =>
			{
				var root = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.Transparent
				};
				Image image = new Image();
				image.WidthRequest = 25;
				image.HeightRequest = 25;
                if (Device.RuntimePlatform == Device.iOS)
                    image.Source = path + "delete.png";
                else if (Device.RuntimePlatform == Device.Android)
                    image.Source = path + "mindmapdelete.png";
				root.Children.Add(image);
				return root;
			});
			ExpandTemplate = new DataTemplate(() =>
			{
				var root = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.Transparent
				};
				Image image = new Image();
				image.WidthRequest = 25;
				image.HeightRequest = 25;
                if (Device.RuntimePlatform == Device.iOS)
                    image.Source = path + "expand.png";
                else if (Device.RuntimePlatform == Device.Android)
                    image.Source = path + "mindmapexpand.png";
				root.Children.Add(image);
				return root;
			});
			CollapseTemplate = new DataTemplate(() =>
			{
				var root = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.Transparent
				};
				Image image = new Image();
				image.WidthRequest = 25;
				image.HeightRequest = 25;
                if (Device.RuntimePlatform == Device.iOS)
                    image.Source = path + "collpase.png";
                else if (Device.RuntimePlatform == Device.Android)
                    image.Source = path + "mindmapcollpase.png";
                root.Children.Add(image);
				return root;
			});
			var moretemplate = new DataTemplate(() =>
			{
				var root = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.Transparent
				};
				Image image = new Image();
				image.WidthRequest = 25;
				image.HeightRequest = 25;
                if (Device.RuntimePlatform == Device.iOS)
                    image.Source = path + "more.png";
                else if (Device.RuntimePlatform == Device.Android)
                    image.Source = path + "mindmapmore.png";
				root.Children.Add(image);
				return root;
			});

			DefaultHandles = new UserHandleCollection();
			DefaultHandles.Add(new UserHandle("Left", UserHandlePosition.Left, template));
			DefaultHandles.Add(new UserHandle("Right", UserHandlePosition.Right, template));
			DefaultHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, CollapseTemplate));
			DefaultHandles.Add(new UserHandle("info", UserHandlePosition.TopRight, moretemplate));
			diagram.UserHandles = DefaultHandles;

			RightSideHandle = new UserHandleCollection();
			RightSideHandle.Add(new UserHandle("Right", UserHandlePosition.Right, template));
			RightSideHandle.Add(new UserHandle("Delete", UserHandlePosition.Bottom, deltemplate));
			RightSideHandle.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, CollapseTemplate));
			RightSideHandle.Add(new UserHandle("info", UserHandlePosition.TopRight, moretemplate));

			LeftSideHandles = new UserHandleCollection();
			LeftSideHandles.Add(new UserHandle("Left", UserHandlePosition.Left, template));
			LeftSideHandles.Add(new UserHandle("Delete", UserHandlePosition.Bottom, deltemplate));
			LeftSideHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, CollapseTemplate));
			LeftSideHandles.Add(new UserHandle("info", UserHandlePosition.TopRight, moretemplate));
		}

		private void Diagram_TextChanged(object sender, Syncfusion.SfDiagram.XForms.TextChangedEventArgs args)
		{
			args.Item.TextBrush = new SolidBrush(Color.Black);
			if (Device.RuntimePlatform == Device.Android)
				args.Item.FontSize = 14 * App.factor;
			else
				args.Item.FontSize = 15;
		}

		private void Diagram_Loaded(object sender)
		{
			diagram.EnableDrag = false;
            diagram.ShowSelectorHandle(false,SelectorPosition.SourcePoint);
            diagram.ShowSelectorHandle(false, SelectorPosition.TargetPoint);
            diagram.ShowSelectorHandle(false, SelectorPosition.Rotator);
			diagram.ShowSelectorHandle(false, SelectorPosition.TopLeft);
			diagram.ShowSelectorHandle(false, SelectorPosition.TopRight);
			diagram.ShowSelectorHandle(false, SelectorPosition.MiddleLeft);
			diagram.ShowSelectorHandle(false, SelectorPosition.MiddleRight);
			diagram.ShowSelectorHandle(false, SelectorPosition.BottomCenter);
			diagram.ShowSelectorHandle(false, SelectorPosition.BottomLeft);
			diagram.ShowSelectorHandle(false, SelectorPosition.BottomRight);
			diagram.ShowSelectorHandle(false, SelectorPosition.TopCenter);
			diagram.LayoutManager = new LayoutManager()
			{
				Layout = new MindMapLayout()
				{
					MindMapOrientation = Orientation.Horizontal,
					HorizontalSpacing = 70,
				}
			};
			if (Device.RuntimePlatform == Device.Android)
			{
				(diagram.LayoutManager.Layout as MindMapLayout).HorizontalSpacing = 70 * App.factor;
			}
            diagram.LayoutManager.Layout.UpdateLayout();
            diagram.Select(RootNode);
            diagram.BringToView(RootNode);
        }

        private void Diagram_DiagramClicked(object sender, DiagramClickedEventArgs args)
		{
			diagram.Opacity = 1;
			diagram.PageSettings.PageBackGround = Color.White;
            if (Notifier != null && Parent.Children.Contains(Notifier))
			{
				textinput.Unfocus();
				Parent.Children.Remove(Notifier);
			}
            if (InfoNotifier != null && Parent.Children.Contains(InfoNotifier))
            {
                if (CommentBoxEntry.Text != null)
                {
                    SelectedNode.Content = CommentBoxEntry.Text;
                }
                Parent.Children.Remove(InfoNotifier);
            }
            SelectedNode = null;
		}

        private void Diagram_UserHandleClicked(object sender, UserHandleClickedEventArgs args)
        {
			if (Notifier != null && Parent.Children.Contains(Notifier))
			{
				Parent.Children.Remove(Notifier);
				diagram.Opacity = 1;
				diagram.PageSettings.PageBackGround = Color.White;
			}
			else if (InfoNotifier != null && Parent.Children.Contains(InfoNotifier))
			{
				Parent.Children.Remove(InfoNotifier);
			}
			else
			{
				if (args.Item.Name == "Delete")
				{
					diagram.RemoveNode(SelectedNode, true);
					(diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
				}
				else if (args.Item.Name == "ExpColl")
				{
					if (SelectedNode.IsExpanded)
					{
						SelectedNode.IsExpanded = false;
						args.Item.Content = CollapseTemplate;
						diagram.UserHandles[0].Visible = false;
						if (SelectedNode == RootNode)
							diagram.UserHandles[1].Visible = false;
					}
					else
					{
						SelectedNode.IsExpanded = true;
						args.Item.Content = ExpandTemplate;
						diagram.UserHandles[0].Visible = true;
						if (SelectedNode == RootNode)
							diagram.UserHandles[1].Visible = true;
					}
					(diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
					diagram.Select(SelectedNode);
				}
				else if (args.Item.Name == "info")
				{
					ShowInfo();
				}
				else
				{
					if (args.Item.Name == "Left")
					{
						CurrentHandle = UserHandlePosition.Left;
						AddAnnotation("Add Topic");
					}
					else if (args.Item.Name == "Right")
					{
						CurrentHandle = UserHandlePosition.Right;
						AddAnnotation("Add Topic");
					}
				}
			}
        }

		void ShowInfo()
		{
			StackLayout root;
			root = new StackLayout();

			Label title = new Label();
			title.Margin = new Thickness(0, 2, 0, 0);
			title.Text = " Add Comments";
			title.TextColor = Color.Black;
			title.FontSize = 15;
			title.FontAttributes = FontAttributes.Bold;
			title.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
            title.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
			root.Children.Add(title);
            
            CommentBoxEntry = new Editor();
            CommentBoxEntry.HeightRequest = 120;
            if (SelectedNode.Content == null)
            {
                CommentBoxEntry.Text = "";
            }
            CommentBoxEntry.Text = (SelectedNode.Content as String);
            CommentBoxEntry.Margin = new Thickness(0, 8, 0, 0);
            CommentBoxEntry.VerticalOptions = LayoutOptions.Start;
            root.Children.Add(CommentBoxEntry);

			Button ok = new Button();
			ok.Text = "OK";
			ok.Margin = new Thickness(0, 5, 0, 0);
			ok.Clicked += Ok_Clicked1;
			ok.WidthRequest = 300;
			ok.HeightRequest = 50;
			ok.VerticalOptions = LayoutOptions.CenterAndExpand;
			ok.HorizontalOptions = LayoutOptions.EndAndExpand;
			root.Children.Add(ok);

			InfoNotifier = new Frame();
			InfoNotifier.WidthRequest = 300;
			InfoNotifier.HeightRequest = 250;
			InfoNotifier.Content = root;
			InfoNotifier.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
			InfoNotifier.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
			InfoNotifier.CornerRadius = 5;
			InfoNotifier.BackgroundColor = Color.White;
			InfoNotifier.OutlineColor = (SelectedNode.Style.Brush as SolidBrush).FillColor;
			Parent.Children.Add(InfoNotifier);
		}
        
        private void Textinput_Focused(object sender, FocusEventArgs e)
		{
			Notifier.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
			Notifier.Margin = new Thickness(0, 50, 0, 0);
			if (Device.RuntimePlatform == Device.iOS)
				Notifier.Margin = new Thickness(0, 200, 0, 0);
		}

        private void Ok_Clicked(object sender, EventArgs e)
        {
            diagram.Opacity = 1;
            diagram.PageSettings.PageBackGround = Color.White;
            Parent.Children.Remove(Notifier);
            if (textinput.Text == null)
            {
                textinput.Text = "";
            }
            var node = new Node();
            if (CurrentHandle == UserHandlePosition.Left)
            {
                node.OffsetX = SelectedNode.OffsetX - SelectedNode.Width - 100;
                node.OffsetY = SelectedNode.OffsetY;
            }
            else if (CurrentHandle == UserHandlePosition.Right)
            {
                node.OffsetX = SelectedNode.OffsetX + SelectedNode.Width + 100;
                node.OffsetY = SelectedNode.OffsetY;
            }
            node.Width = SelectedNode.Width;
            node.Height = SelectedNode.Height;
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 3;
            if (SelectedNode == RootNode)
            {
                index = rnd.Next(5);
                node.Style.Brush = new SolidBrush(FColor[index]);
                node.Style.StrokeBrush = new SolidBrush(SColor[index]);
            }
            else
            {
                node.Style = SelectedNode.Style;
            }
            if (Device.RuntimePlatform == Device.Android)
                node.Annotations.Add(new Annotation() { Content = textinput.Text, FontSize = 14 * App.factor, TextBrush = new SolidBrush(Color.Black) });
            else if (Device.RuntimePlatform == Device.iOS)
                node.Annotations.Add(new Annotation() { Content = textinput.Text, FontSize = 15, TextBrush = new SolidBrush(Color.Black) });
            diagram.AddNode(node);
            var c1 = new Connector();
            c1.SourceNode = SelectedNode;
            c1.TargetNode = node;
            c1.Style.StrokeBrush = node.Style.StrokeBrush;
            c1.Style.StrokeWidth = 3;
            c1.TargetDecoratorStyle.Fill = (node.Style.StrokeBrush as SolidBrush).FillColor;
            c1.TargetDecoratorStyle.Stroke= (node.Style.StrokeBrush as SolidBrush).FillColor;
            c1.SegmentType = SegmentType.CurveSegment;
            c1.Style.StrokeStyle = StrokeStyle.Dashed;
            diagram.AddConnector(c1);
            if (CurrentHandle == UserHandlePosition.Left)
            {
                diagram.UserHandles = LeftSideHandles;
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLeftOrTop();
            }
            else if (CurrentHandle == UserHandlePosition.Right)
            {
                diagram.UserHandles = RightSideHandle;
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateRightOrBottom();
            }
            diagram.Select(node);
            SelectedNode = node;
            diagram.BringToView(node);
        }

        private void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            SelectedNode = args.Item;
            diagram.Opacity = 1;
			diagram.PageSettings.PageBackGround = Color.White;

			if (Notifier != null && Parent.Children.Contains(Notifier))
			{
				Parent.Children.Remove(Notifier);
			}
			else if (InfoNotifier != null && Parent.Children.Contains(InfoNotifier))
			{
				Parent.Children.Remove(InfoNotifier);
			}
			else
			{
				if (args.Item != RootNode && args.Item.OffsetX > RootNode.OffsetX)
				{
					diagram.UserHandles = RightSideHandle;
				}
				else if (args.Item != RootNode && args.Item.OffsetX < RootNode.OffsetX)
				{
					diagram.UserHandles = LeftSideHandles;
				}
				else if (args.Item == RootNode)
				{
					diagram.UserHandles = DefaultHandles;
				}

				if (SelectedNode.IsExpanded)
				{
					diagram.UserHandles[0].Visible = true;
					if (SelectedNode == RootNode)
						diagram.UserHandles[1].Visible = true;
					diagram.UserHandles[2].Content = ExpandTemplate;
				}
				else
				{
					diagram.UserHandles[0].Visible = false;
					if (SelectedNode == RootNode)
						diagram.UserHandles[1].Visible = false;
					diagram.UserHandles[2].Content = CollapseTemplate;
				}
			}
        }

		void Diagram_ConnectorClicked(object sender, ConnectorClickedEventArgs args)
		{
			diagram.ClearSelection();
			if (Notifier != null && Parent.Children.Contains(Notifier))
			{
				Parent.Children.Remove(Notifier);
			}
			else if (InfoNotifier != null && Parent.Children.Contains(InfoNotifier))
			{
				Parent.Children.Remove(InfoNotifier);
			}
		}

        void Ok_Clicked1(object sender, EventArgs e)
		{
            if(CommentBoxEntry.Text!=null)
            {
                SelectedNode.Content = CommentBoxEntry.Text;
            }
			Parent.Children.Remove(InfoNotifier);
		}
	}
}