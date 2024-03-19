using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomGallery.Interfaces;
using CustomGallery.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CustomGallery.ViewModels
{
    public class GalleryViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        #region Implemented
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            if (changed == null)
                return;

            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region ReadOnly
        private readonly IPermissionService _permissionService;
        #endregion

        #region Private Properties
        private IList<ImageSource> _galleryImages;
        private bool _isPermissionAsked;
        #endregion

        #region Public Properties
        public IList<ImageSource> GalleryImages
        {
            get { return _galleryImages; }
            set
            {
                _galleryImages = value;
                OnPropertyChanged(nameof(GalleryImages));
            }
        }
        public bool IsPermissionAsked
        {
            get { return _isPermissionAsked; }
            set
            {
                _isPermissionAsked = value;
                OnPropertyChanged(nameof(IsPermissionAsked));
            }
        }
        #endregion

        #region Constructor
        public GalleryViewModel()
		{
            _permissionService = new PermissionService();
		}
        #endregion

        #region Public Method
        public async System.Threading.Tasks.Task OnGalleryAppear()
        {
            if (!IsPermissionAsked)
            {
                IsPermissionAsked = true;
                PermissionStatus StorageStatus = await _permissionService.GetStoragePermission();
                if (StorageStatus == PermissionStatus.Granted)
                {
                    GalleryImages = DependencyService.Get<IPhotoService>().GetPhotos();
                }
            }
        }
        #endregion
    }
}

