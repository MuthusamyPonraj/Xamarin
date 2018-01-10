#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	public class HomeScreenAdapter : BaseAdapter<SampleBase> {
    List<SampleBase> items;
    Activity context;
    public HomeScreenAdapter(Activity context, List<SampleBase> items)
        : base()
    {
        this.context = context;
        this.items = items;
    }
    public override long GetItemId(int position)
    {
        return position;
    }
		public override SampleBase this[int position]
    {
        get { return items[position]; }
    }
    public override int Count
    {
        get { return items.Count; }
    }
    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        var item = items[position];

        View view = convertView;
        if (view == null) // no view to re-use, create new
            view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Title;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Description;
			int resourceid = context.Resources.GetIdentifier("drawable/" + item.ImageId, null, context.PackageName);
			if (resourceid == 0)
				resourceid = context.Resources.GetIdentifier("drawable/rangenavigator", null, context.PackageName);
			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(resourceid);
			TextView textView = (TextView)view.FindViewById(Resource.Id.tagText);
			if (!item.Type.Equals(""))
			{
				textView.Visibility = ViewStates.Visible;
				if (item.Type.ToLower().Equals("new"))
				{
					textView.Text = "New";
					textView.SetBackgroundResource(Resource.Drawable.newtagbackground);

				}
				else if (item.Type.ToLower().Equals("updated"))
				{
					textView.Text = "Updated";
					textView.SetBackgroundResource(Resource.Drawable.updatetagbackground);
				}
				else if (item.Type.ToLower().Equals("preview"))
				{
					textView.Text = "Preview";
					textView.SetBackgroundResource(Resource.Drawable.previewtagbackground);
				}
			}
			else
			{
				textView.Visibility = ViewStates.Invisible;
			}
        return view;
    }
}



	public class FeatureControlsAdapter : BaseAdapter<SampleBase>
	{
		List<SampleBase> items;
		Activity context;
		internal View SelectedView;
		internal SampleBase SelectedSample;
		internal string SelectedText = "";

		public FeatureControlsAdapter(Activity context, List<SampleBase> items,bool isfeature)
			: base()
		{
			this.context = context;
			this.items = items;
			isFeatureView = isfeature;
		}
		bool isFeatureView;
		public override long GetItemId(int position)
		{
			return position;
		}
		public override SampleBase this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];

			View view = convertView;
		
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.FeatureView, null);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Title;
			if (!isFeatureView)
			{
				view.SetPadding(0, 10, 0, 10);

			}
			int resourceid = context.Resources.GetIdentifier("drawable/" + item.ImageId, null, context.PackageName);
			if(resourceid==0)
				resourceid = context.Resources.GetIdentifier("drawable/rangenavigator", null, context.PackageName);
			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(resourceid);
			if (!isFeatureView)
			{

				if (position == 0 && SelectedView == null)
				{

					SelectedView = view;
					SelectedSample = item;
					SelectedText = item.Title;
					SelectedView.FindViewById<TextView>(Resource.Id.Text1).SetTextColor(Color.Blue);
					int id = context.Resources.GetIdentifier("drawable/" + item.ImageId+"_selected", null, context.PackageName);
					SelectedView.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(id);
				}
				else if (SelectedText == item.Title)
				{
					view.FindViewById<TextView>(Resource.Id.Text1).SetTextColor(Color.Blue);
					int id = context.Resources.GetIdentifier("drawable/" + item.ImageId+"_selected", null, context.PackageName);
					view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(id);
				}
				else
				{
					view.FindViewById<TextView>(Resource.Id.Text1).SetTextColor(Color.White);
					int id = context.Resources.GetIdentifier("drawable/" + item.ImageId, null, context.PackageName);
					view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(id);
				}
			}
			return view;
		}
	}

	public class ListViewAdapter : BaseAdapter<SampleBase>
	{
		List<SampleBase> items;
		Activity context;
		int CurrentIndex;
		internal View SelectedView;
		public ListViewAdapter(Activity context, List<SampleBase> items,int index)
			: base()
		{
			this.context = context;
			this.items = items;
			CurrentIndex = index;
		}

		internal string SelectedText = "";


		public override long GetItemId(int position)
		{
			return position;
		}
		public override SampleBase this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];

			View view = convertView;

			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.ScrollTextView, null);
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Title;
			if (CurrentIndex == position && SelectedView == null)
			{

				SelectedView = view;
				SelectedText = item.Title;
				SelectedView.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Blue);
			}
			else if (SelectedText == item.Title)
			{
				view.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Blue);
			}
			else
			{
				view.FindViewById<TextView>(Resource.Id.Text2).SetTextColor(Color.Black);
			}
			TextView textView = (TextView)view.FindViewById(Resource.Id.tagText);
			if (!item.Type.Equals(""))
			{
				textView.Visibility = ViewStates.Visible;

				if (item.Type.ToLower().Equals("new"))
				{
					textView.Text = "N";
					textView.SetBackgroundResource(Resource.Drawable.newtagcircle);

				}
				else if (item.Type.ToLower().Equals("updated"))
				{
					textView.Text = "U";
					textView.SetBackgroundResource(Resource.Drawable.updatetagcircle);
				}
				else if (item.Type.ToLower().Equals("preview"))
				{
					textView.Text = "P";
					textView.SetBackgroundResource(Resource.Drawable.previewtagcircle);
				}

			}
			else
			{
				textView.Visibility = ViewStates.Invisible;
			}

			return view;
		}
	}



}