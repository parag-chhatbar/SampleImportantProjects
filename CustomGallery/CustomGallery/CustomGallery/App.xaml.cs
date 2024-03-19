using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CustomGallery.Views;

namespace CustomGallery
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new GalleryPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

