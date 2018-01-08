#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Syncfusion.SfImageEditor.Android;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Content;
using Android.Provider;
using Java.IO;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;

namespace SampleBrowser
{
	public class ImageEditor : SamplePage
	{
	    internal static Activity Activity { get; set; }
        public override Android.Views.View GetSampleContent (Android.Content.Context context)
        {
            Activity = context as Activity;
            Activity?.StartActivity(typeof(SfImageEditoMainActivity));
            LinearLayout layout = new LinearLayout(context);
            return layout;
		}
    }
    

    [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait,
        Theme = "@style/PropertyApp", Icon = "@drawable/icon")]
    public class SfImageEditoMainActivity : Activity
    {
        static Intent mainIntent;
        private Android.Net.Uri mImageCaptureUri;
        private static int SELECT_FROM_GALLERY = 0;
        private static int SELECT_FROM_CAMERA = 1;
        internal static string Path { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FrameLayout layout = new FrameLayout(this);
            Button photoPicker = new Button(this);
            photoPicker.Text = "Choose from photos";
            photoPicker.SetTextColor(Color.Blue);
            photoPicker.SetTextSize(Android.Util.ComplexUnitType.Dip, (int)(10 * Resources.DisplayMetrics.Density));
            
            photoPicker.SetBackgroundColor(Color.Transparent);
            photoPicker.LayoutParameters = new FrameLayout.LayoutParams(
                FrameLayout.LayoutParams.FillParent,
                FrameLayout.LayoutParams.WrapContent)
            {
                Gravity = GravityFlags.Center,
                BottomMargin =(int)(35* Resources.DisplayMetrics.Density)
        };
            photoPicker.Click += PhotoPicker_Click;

            Button takePhoto = new Button(this);
            takePhoto.Text = "Take a photo";
            takePhoto.SetBackgroundColor(Color.Transparent);
            takePhoto.SetTextColor(Color.Blue);
            takePhoto.SetTextSize(Android.Util.ComplexUnitType.Dip, (int)(10 * Resources.DisplayMetrics.Density));

            takePhoto.LayoutParameters = new FrameLayout.LayoutParams(
                FrameLayout.LayoutParams.FillParent,
                FrameLayout.LayoutParams.WrapContent)
            {
                Gravity = GravityFlags.Center,
                TopMargin = (int)(35 * Resources.DisplayMetrics.Density)
            };
            takePhoto.Click += TakePhoto_Click;

            layout.AddView(photoPicker);
            layout.AddView(takePhoto);

            SetContentView(layout);

            base.OnCreate(savedInstanceState);
        }


        private void TakePhoto_Click(object sender, EventArgs e)
        {
           InitializeCamera();
        }

        private void PhotoPicker_Click(object sender, EventArgs e)
        {
            InitializeMediaPicker();
        }


        public void InitializeMediaPicker()
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), SELECT_FROM_GALLERY);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (data == null) data = mainIntent;
            if ((resultCode != Result.Ok) || (data == null))
            {
                return;
            }
            if (resultCode == Result.Ok)
            {
                var uri = data.Data;
                if (requestCode == SELECT_FROM_GALLERY)
                {
                    try
                    {
                        Path = GetPathToImage(uri);
                        StartActivity(typeof(SfImageEditorActivity));
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (requestCode == SELECT_FROM_CAMERA)
                {
                    try
                    {
                        mainIntent.PutExtra("image-path", mImageCaptureUri.Path);
                        mainIntent.PutExtra("scale", true);
                        Path = mImageCaptureUri.Path;
                        StartActivity(typeof(SfImageEditorActivity));
                    }
                    catch (Exception e)
                    {

                    }
                }
                else return;
            }
        }

        public override void OnBackPressed()
        {
            ImageEditor.Activity.Finish();
            base.OnBackPressed();
        }

        private string GetPathToImage(Android.Net.Uri uri)
        {
            string imgId = "";
            using (var c1 = ContentResolver.Query(uri, null, null, null, null))
            {
                c1.MoveToFirst();
                string imageId = c1.GetString(0);
                imgId = imageId.Substring(imageId.LastIndexOf(":") + 1);
            }

            string path = null;

            string selection = MediaStore.Images.Media.InterfaceConsts.Id + " =? ";
            using (var cursor = ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri, null, selection, new string[] { imgId }, null))
            {
                if (cursor == null) return path;
                var columnIndex = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.Data);
                cursor.MoveToFirst();
                path = cursor.GetString(columnIndex);
            }
            return path;
        }

        private void InitializeCamera()
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            mImageCaptureUri = Android.Net.Uri.FromFile(new File(CreateDirectoryForPictures(), string.Format("ImageEditor_Photo_{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmssfff"))));

            intent.PutExtra(MediaStore.ExtraOutput, mImageCaptureUri);

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            mediaScanIntent.SetData(mImageCaptureUri);
            SendBroadcast(mediaScanIntent);

            try
            {
                mainIntent = intent;
                intent.PutExtra("return-data", false);
                StartActivityForResult(mainIntent, SELECT_FROM_CAMERA);
            }
            catch (ActivityNotFoundException e)
            {
                e.PrintStackTrace();
            }
        }

        private File CreateDirectoryForPictures()
        {
            var dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "ImageEditor");
            if (!dir.Exists())
            {
                dir.Mkdirs();
            }

            return dir;
        }

      
    }


    [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait, 
        Theme = "@style/PropertyApp", Icon = "@drawable/icon")]
    public class SfImageEditorActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SfImageEditor editor = new SfImageEditor(this);
            editor.Bitmap =BitmapFactory.DecodeFile(SfImageEditoMainActivity.Path);
            SetContentView(editor);

            base.OnCreate(savedInstanceState);
        }
       
    }
}

