using System;
using System.Collections.Generic;
using CustomGallery.ViewModels;
using Xamarin.Forms;

namespace CustomGallery.Views
{	
	public partial class GalleryPage : ContentPage
	{
		#region ReadOnly
		private readonly GalleryViewModel _galleryViewModel;
        #endregion

        #region Constructor
        public GalleryPage ()
		{
			_galleryViewModel = new GalleryViewModel();
			InitializeComponent ();
			BindingContext = _galleryViewModel;
		}
        #endregion

        #region Override
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _galleryViewModel.OnGalleryAppear();
        }
        #endregion
    }
}

