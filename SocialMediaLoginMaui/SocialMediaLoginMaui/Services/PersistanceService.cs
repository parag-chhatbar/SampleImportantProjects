using SocialMediaLoginMaui.Enums;
using SocialMediaLoginMaui.Interfaces;

namespace SocialMediaLoginMaui.Services
{
    public class PersistanceService : IPersistanceService
    {
        #region Constant
        private const string AccessTokenKey = "AccessToken";
        private const string RefreshTokenKey = "RefreshToken";
        private const string UserNameKey = "UserName";
        private const string ExpireInKey = "ExpireIn";
        private const string ProfilePictureKey = "ProfilePicture";
        //private const string IsLoggedInKey = "IsLoggedIn";
        private const string SignupMethodKey = "SignupMethod";
        #endregion

        #region Public
        public string AccessToken
        {
            get => Preferences.Get(AccessTokenKey, string.Empty);
            set => Preferences.Set(AccessTokenKey, value);
        }
        public string RefreshToken
        {
            get => Preferences.Get(RefreshTokenKey, string.Empty);
            set => Preferences.Set(RefreshTokenKey, value);
        }
        public string UserName
        {
            get => Preferences.Get(UserNameKey, string.Empty);
            set => Preferences.Set(UserNameKey, value);
        }
        public string ProfilePicture
        {
            get => Preferences.Get(ProfilePictureKey, string.Empty);
            set => Preferences.Set(ProfilePictureKey, value);
        }
        public double ExpireIn
        {
            get => Preferences.Get(ExpireInKey, 0);
            set => Preferences.Set(ExpireInKey, value);
        }
        public SignupMethodEnum SignupMethod
        {
            get => (SignupMethodEnum)Preferences.Get(SignupMethodKey, 0);
            set => Preferences.Set(SignupMethodKey, ((int)value));
        }
        /*
        public bool IsLoggedIn
        {
            get => Preferences.Get(IsLoggedInKey, false);
            set => Preferences.Set(IsLoggedInKey, value);
        }
        */
        #endregion
    }
}

