using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomGallery.Interfaces
{
    public interface IPhotoService
	{
        List<ImageSource> GetPhotos();
	}
}

