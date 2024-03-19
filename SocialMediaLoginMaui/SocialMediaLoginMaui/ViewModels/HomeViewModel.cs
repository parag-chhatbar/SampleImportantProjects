using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SocialMediaLoginMaui.Interfaces;
using SocialMediaLoginMaui.Services;
using SocialMediaLoginMaui.Views;

namespace SocialMediaLoginMaui.ViewModels
{
	public class HomeViewModel : INotifyPropertyChanged
	{
        #region Implemented
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region SetMethod
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region Readonly
        private readonly IAuthenticationService _authenticationService;
        private readonly IPersistanceService _persistanceService;
        #endregion

        #region Private Fields
        private string _userName;
        private string _profilePhoto;
        #endregion

        #region Field Declaration
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        public string ProfilePhoto
        {
            get { return _profilePhoto; }
            set { SetProperty(ref _profilePhoto, value); }
        }
        #endregion

        #region Command
        public ICommand SignoutCommand { get; set; }
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            //services initilization
            _authenticationService = new AuthenticationService();
            _persistanceService = new PersistanceService();

            //command initialization
            SignoutCommand = new Command(OnSignoutClick);

            UserName = _persistanceService.UserName;
            ProfilePhoto = _persistanceService.ProfilePicture;
        }
        #endregion

        #region Private
        private async void OnSignoutClick()
        {
            if (_persistanceService.SignupMethod == Enums.SignupMethodEnum.Google)
                _authenticationService.SignoutByGoogle();
            //else if (_persistanceService.SignupMethod == Enums.SignupMethodEnum.Facebook)
            //    _authenticationService.SignoutByFacebook();
            //else if (_persistanceService.SignupMethod == Enums.SignupMethodEnum.Microsoft)
            //    _authenticationService.SignoutByMicrosoft();

            await Shell.Current.GoToAsync("//SignUpPage");   
        }
        #endregion
    }
}

