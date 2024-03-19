using System;
namespace SocialMediaLoginMaui.Constants
{
	public class AppConstants
	{
        #region Common
        public const string AuthenticationUrl = "https://xamarin-essentials-auth-sample.azurewebsites.net/mobileauth/";
        //public const string GoogleSchemeKey = "Google";
        //public const string FacebookSchemeKey = "Facebook";
        #endregion

        #region Google
        // For Google login, configure at https://console.developers.google.com/
        public static string GoogleiOSClientId = "251325787545-lnnmbd53t0bo2j5fvvr54lu443n5g4ch.apps.googleusercontent.com";
        public static string GoogleAndroidClientId = "251325787545-9633s30j3jsasr0bghu4qe7ih64q456m.apps.googleusercontent.com";

        // redirect url with /oauth2redirect appended
        public static string GoogleiOSRedirectUrl = "com.googleusercontent.apps.251325787545-lnnmbd53t0bo2j5fvvr54lu443n5g4ch:/oauth2redirect";
        public static string GoogleAndroidRedirectUrl = "com.googleusercontent.apps.251325787545-9633s30j3jsasr0bghu4qe7ih64q456m:/oauth2redirect";
        
        // These values do not need changing
        //public static string GoogleScope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
        public static string GoogleScope = "email profile";
        public static string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/v2/auth";
        public static string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string GoogleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";
        #endregion
    }
}

