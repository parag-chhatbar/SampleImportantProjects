using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.Provider;
using CustomGallery.Droid.DependencyImplementation;
using CustomGallery.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;
using Bitmap = Android.Graphics.Bitmap;

[assembly:Xamarin.Forms.Dependency(typeof(PhotoService))]
namespace CustomGallery.Droid.DependencyImplementation
{
    public class PhotoService : IPhotoService
    {
        /* Note: We must need to set the following property as false in AndroidManifest.xaml
         * <application ... android:hardwareAccelerated="false"></application>
	    */
        public List<ImageSource> GetPhotos()
        {
            List<ImageSource> imagesList = new List<ImageSource>();

            // Query the MediaStore for all images
            Android.Net.Uri uri = MediaStore.Images.Media.ExternalContentUri;
            string[] projection = { MediaStore.Images.Media.InterfaceConsts.Data };
            ContentResolver contentResolver = Android.App.Application.Context.ContentResolver;
            using (var cursor = contentResolver.Query(uri, projection, null, null, null))
            {
                if (cursor != null)
                {
                    while (cursor.MoveToNext())
                    {
                        string imagePath = cursor.GetString(cursor.GetColumnIndexOrThrow(MediaStore.Images.Media.InterfaceConsts.Data));
                        imagesList.Add(imagePath);
                    }

                    cursor.Close();
                }
            }
            return imagesList;
        }
    }
}

