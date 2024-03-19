using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CustomGallery.Interfaces;
using Xamarin.Essentials;

namespace CustomGallery.Services
{
    public class PermissionService : IPermissionService
    {
        public async Task<PermissionStatus> GetStoragePermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if(status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageRead>();
                //if(status != PermissionStatus.Granted && !Permissions.ShouldShowRationale<Permissions.StorageRead>())
                if(status != PermissionStatus.Granted)
                {
                    bool UserChoice = await App.Current.MainPage.DisplayAlert("Permission Needed", "Allow storage permission from settings", "Open Settings", "Exit");
                    if (UserChoice)
                        Xamarin.Essentials.AppInfo.ShowSettingsUI();
                    else
                        System.Environment.Exit(0);
                }
            }

            return status;
        }
    }
}

