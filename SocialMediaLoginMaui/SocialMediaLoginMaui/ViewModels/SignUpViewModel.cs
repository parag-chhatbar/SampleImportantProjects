using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SocialMediaLoginMaui.Enums;
using SocialMediaLoginMaui.Interfaces;
using SocialMediaLoginMaui.Services;

namespace SocialMediaLoginMaui.ViewModels
{
	public class SignUpViewModel : INotifyPropertyChanged
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

        #region ReadOnly
        private readonly IAuthenticationService _authenticationService;
        private readonly IPersistanceService _persistanceService;
        #endregion

        #region Commands
        public ICommand GoogleClickedCommand { get; set; }
        public ICommand FacebookClickedCommand { get; set; }
        //public ICommand MicrosoftClickedCommand { get; set; }
        //public ICommand LinkedinClickedCommand { get; set; }
        //public ICommand InstagramClickedCommand { get; set; }
        public ICommand AppleClickedCommand { get; set; }
        #endregion

        #region Constructor
        public SignUpViewModel()
		{
            _authenticationService = new AuthenticationService();
            _authenticationService.OnAuthenticatedUser += _authenticationService_OnAuthenticatedUser;
            _persistanceService = new PersistanceService();
            /*
            GoogleClickedCommand = new Command(OnGoolgleClick);
            FacebookClickedCommand = new Command(OnFacebookClick);
            MicrosoftClickedCommand = new Command(OnMicrosoftClick);
            LinkedinClickedCommand = new Command(OnLinkedinClick);
            InstagramClickedCommand = new Command(OnInstagramClick);
            AppleClickedCommand = new Command(OnAppleClick);
            */
            GoogleClickedCommand = new Command(OnGoogleClick);
            AppleClickedCommand = new Command(OnAppleClick);
            FacebookClickedCommand = new Command(OnFacebookClick);
        }
        #endregion

        #region Private
        private async void _authenticationService_OnAuthenticatedUser(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
        private void OnGoogleClick()
        {
            App.CurrentSignUpMethod = SignupMethodEnum.Google;
            _authenticationService.AuthenticationByGoogle();
        }
        private void OnFacebookClick()
        {
            //_authenticationService.AuthenticationByFacebook();
        }
        /*
        private async void OnMicrosoftClick()
        {
            PracticeService.App.CurrentSignupMethod = Enums.SignupMethodEnum.Microsoft;
            var authenticationToken = await _authenticationService.GetAuthenticationTokenOfMicrosoft();
            if (!string.IsNullOrEmpty(authenticationToken.Token))
            {
                _persistanceService.SignupMethod = Enums.SignupMethodEnum.Microsoft;
                _persistanceService.AccessToken = authenticationToken.Token;
                _persistanceService.UserName = authenticationToken.DisplayName;
                _persistanceService.ExpireIn = (authenticationToken.ExpiresOn - DateTime.Now).TotalMinutes;
                Application.Current.MainPage = new HomePage();
            }
        }
        private void OnLinkedinClick()
        {
            //await ShowAlert("Linkedin Clicked");
            PracticeService.App.CurrentSignupMethod = Enums.SignupMethodEnum.LinkedIn;
            _authenticationService.AuthenticationByLinkedIn();
        }
        private void OnInstagramClick()
        {
            PracticeService.App.CurrentSignupMethod = Enums.SignupMethodEnum.Instagram;
            _authenticationService.AuthenticationByInstagram();
        }
        */
        private async void OnAppleClick()
        {
            await ShowAlert("Apple Clicked");
        }
        private async Task ShowAlert(string Message)
        {
            await Application.Current.MainPage.DisplayAlert("Tap", Message, "OK");
        }
        #endregion
    }
}

