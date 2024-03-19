using System;
using System.Collections.Generic;
using System.IO;
using CustomGallery.Interfaces;
using CustomGallery.iOS.DependencyImplementation;
using Foundation;
using Photos;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(PhotoService))]
namespace CustomGallery.iOS.DependencyImplementation
{
    public class PhotoService : IPhotoService
    {
        public List<ImageSource> GetPhotos()
        {
            PHImageManager manager = new PHImageManager();
            List<ImageSource> imagesList = new List<ImageSource>();

            //get all images
            PHFetchResult result = PHAsset.FetchAssets(PHAssetMediaType.Image, null);
            foreach(PHAsset asset in result)
            {
                manager.RequestImageForAsset(asset, PHImageManager.MaximumSize, PHImageContentMode.Default, null, (image,info) =>
                {
                    byte[] imageBytes;

                    //convert the UIImage tp NsData
                    using (NSData imageData = image.AsJPEG())
                    {
                        //Made array with size of NsData
                        imageBytes = new byte[imageData.Length];
                        //Make a physical place of byte array
                        System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, imageBytes, 0, Convert.ToInt32(imageData.Length));
                    }

                    //take source of byte array
                    ImageSource _mainImage = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                    imagesList.Add(_mainImage); 
                });
            }

            return imagesList;
        }
    }
}

