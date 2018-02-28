#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Java.IO;
using Java.Lang;
using Syncfusion.SfImageEditor.XForms.Droid;
using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SampleBrowser.Core.Android;

[assembly: Dependency(typeof(SampleBrowser.SfImageEditor.Droid.ImageEditorDependencyService))]
namespace SampleBrowser.SfImageEditor.Droid
{
    public class ImageEditorDependencyService : IImageEditorDependencyService
    {
        private static int SELECT_FROM_GALLERY = 0;
        private static int SELECT_FROM_CAMERA = 1;
        static Intent mainIntent;
        private Android.Net.Uri mImageCaptureUri;
        SampleBrowserActivity activity;
        bool isCamera = false;
        private ImageModel _model;

        public void InitializeMediaPicker(ImageModel model)
        {
            _model = model;
            activity = Xamarin.Forms.Forms.Context as SampleBrowserActivity;
            activity.ActivityResult -= LoadImage;
            activity.ActivityResult += LoadImage;
            activity.Intent = new Intent();
            activity.Intent.SetType("image/*");
            activity.Intent.SetAction(Intent.ActionGetContent);
            activity.StartActivityForResult(Intent.CreateChooser(activity.Intent, "Select Picture"), SELECT_FROM_GALLERY);
        }

        void LoadImage(object sender, ActivityResultEventArgs e)
        {
            if (!isCamera)
            {
                var imagePath = GetPathToImage(e.Intent.Data);
                _model.SwitchView(imagePath, Navigation);
            }
            else
            {
                mainIntent.PutExtra("image-path", mImageCaptureUri.Path);
                mainIntent.PutExtra("scale", true);
                _model.SwitchView(mImageCaptureUri.Path,Navigation);
            }
        }

        void LoadCamera(object sender, ActivityResultEventArgs e)
        {
            if (!isCamera)
            {
                var imagePath = GetPathToImage(e.Intent.Data);
                _model.SwitchView(imagePath, Navigation);
            }
            else
            {
                mainIntent.PutExtra("image-path", mImageCaptureUri.Path);
                mainIntent.PutExtra("scale", true);
                _model.SwitchView(mImageCaptureUri.Path, Navigation);
            }
        }

        private void InitializeCamera(ImageModel model)
        {
            _model = model;
            activity = Xamarin.Forms.Forms.Context as SampleBrowserActivity;

            activity.ActivityResult -= LoadCamera;
            activity.ActivityResult += LoadCamera;

            var intent = new Intent(MediaStore.ActionImageCapture);
            mImageCaptureUri = Android.Net.Uri.FromFile(new File(CreateDirectoryForPictures(),
                string.Format("ImageEditor_Photo_{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmssfff"))));

            intent.PutExtra(MediaStore.ExtraOutput, mImageCaptureUri);

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            mediaScanIntent.SetData(mImageCaptureUri);
            activity.SendBroadcast(mediaScanIntent);

            try
            {
                mainIntent = intent;
                intent.PutExtra("return-data", false);
                activity.StartActivityForResult(mainIntent, SELECT_FROM_CAMERA);
            }
            catch (ActivityNotFoundException e)
            {
                Toast.MakeText(activity, "Unable to Load Image", ToastLength.Short);
            }
        }

        private string GetPathToImage(Android.Net.Uri uri)
        {
            string imgId = "";
            string[] proj = { MediaStore.Images.Media.InterfaceConsts.Data };
            using (var c1 = activity.ContentResolver.Query(uri, null, null, null, null))
            {
                try
                {
                    if (c1 == null) return "";
                    c1.MoveToFirst();
                    string imageId = c1.GetString(0);
                    imgId = imageId.Substring(imageId.LastIndexOf(":") + 1);
                }
                catch (System.Exception e)
                {
                    Toast.MakeText(Xamarin.Forms.Forms.Context, "Unable To Load Image", ToastLength.Short);
                }
            }

            string path = null;

            string selection = MediaStore.Images.Media.InterfaceConsts.Id + " =? ";
            using (var cursor = activity.ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri, null, selection, new string[] { imgId }, null))
            {
                try
                {
                    if (cursor == null) return path;
                    var columnIndex = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.Data);
                    cursor.MoveToFirst();
                    path = cursor.GetString(columnIndex);
                }
                catch (System.Exception e)
                {
                    Toast.MakeText(Xamarin.Forms.Forms.Context, "Unable To Load Image", ToastLength.Short);
                    return "";
                }
            }
            return path;

        }

        string GetPathFromFile(Android.Net.Uri contentUri)
        {
            string res = null;
            string[] proj = { MediaStore.Images.Media.InterfaceConsts.Data };
            var cursor = activity.ContentResolver.Query(contentUri, null, null, null, null);
            if (cursor == null) return contentUri.ToString();
            if (cursor.MoveToFirst())
            {
                int column_index = cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.Data);
                res = cursor.GetString(column_index);
            }
            cursor.Close();
            return res;
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


        void IImageEditorDependencyService.UploadFromCamera(ImageModel model)
        {
            isCamera = true;
            InitializeCamera(model);
        }


        void IImageEditorDependencyService.UploadFromGallery(ImageModel model)
        {
            isCamera = false;
            InitializeMediaPicker(model);

        }

        public INavigation Navigation { get; set; }
    }
}