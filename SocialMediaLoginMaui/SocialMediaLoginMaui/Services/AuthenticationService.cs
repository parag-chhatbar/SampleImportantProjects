using SocialMediaLoginMaui.Constants;
using SocialMediaLoginMaui.Enums;
using SocialMediaLoginMaui.Interfaces;

namespace SocialMediaLoginMaui.Services
{
    public class AuthenticationService : IAuthenticationService
	{
        #region Private Members
        private readonly IPersistanceService _persistanceService;
        #endregion

        #region Implemented Properties
        public event EventHandler OnAuthenticatedUser;
        #endregion

        #region Constructor
        public AuthenticationService()
        {
            _persistanceService = new PersistanceService();
        }
        #endregion

        #region Common Method
        public void ClearPersistanceService()
        {
            _persistanceService.SignupMethod = SignupMethodEnum.None;
            _persistanceService.AccessToken = string.Empty;
            _persistanceService.RefreshToken = string.Empty;
            _persistanceService.UserName = string.Empty;
            System.Diagnostics.Debug.WriteLine("Everything is cleared");
        }
        /*
        public async Task<WebAuthenticatorResult> MakeAuthentication(string scheme)
        {
            //using web authenticator
            string authenticationUrl = AppConstants.AuthenticationUrl;
            WebAuthenticatorResult webAuthenticatorResult = null;
            try
            {
                var authUrl = new Uri(authenticationUrl + scheme);
                var callbackUrl = new Uri("xamarinessentials://");

                System.Diagnostics.Debug.WriteLine($"authUrl: {authUrl}");
                System.Diagnostics.Debug.WriteLine($"callBrl: {callbackUrl}");

                webAuthenticatorResult = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in AuthenticationByGoogle(): {e.Message}");
            }
            return webAuthenticatorResult;
        }
        */
        #endregion

        #region Google
        public async void AuthenticationByGoogle()
        {
            string clientId = DeviceInfo.Platform == DevicePlatform.Android ? AppConstants.GoogleAndroidClientId : AppConstants.GoogleiOSClientId;
            string scope = AppConstants.GoogleScope;
            string authorizeUrl = AppConstants.GoogleAuthorizeUrl;
            string redirectUrl = DeviceInfo.Platform == DevicePlatform.Android? AppConstants.GoogleAndroidRedirectUrl : AppConstants.GoogleiOSRedirectUrl;
            string accessTokenUrl = AppConstants.GoogleAccessTokenUrl;
            System.Diagnostics.Debug.WriteLine($"Google ClientId: {clientId}");
            System.Diagnostics.Debug.WriteLine($"Google Scope: {scope}");
            System.Diagnostics.Debug.WriteLine($"Google Authorize URL: {authorizeUrl}");
            System.Diagnostics.Debug.WriteLine($"Google Redirect URL: {redirectUrl}");
            System.Diagnostics.Debug.WriteLine($"Google Accesstoken URL: {accessTokenUrl}");

            string mainUri = $"{authorizeUrl}?scope={scope}&response_type=code&redirect_uri={redirectUrl}&client_id={clientId}";
            System.Diagnostics.Debug.WriteLine($"Google Main URL: {mainUri}");
            //bool result = await Browser.Default.OpenAsync(mainUri);
            await Launcher.OpenAsync(mainUri);
        }
        public void SignoutByGoogle()
        {
            ClearPersistanceService();
        }
        #endregion
        


        /*
        #region Google
        public async void AuthenticationByGoogle()
        {
            WebAuthenticatorResult webAuthenticatorResult = await MakeAuthentication(AppConstants.GoogleSchemeKey);

            if (webAuthenticatorResult == null)
                return;
            string accessToken = string.Empty;
            string expire_in = string.Empty;
            
            //if (webAuthenticatorResult.Properties.TryGetValue("access_token", out var token) && !string.IsNullOrEmpty(token))
              //  accessToken = token;

            //if (webAuthenticatorResult.Properties.TryGetValue("expires", out var expire) && !string.IsNullOrEmpty(expire))
              //  expire_in = expire;
            
            accessToken = webAuthenticatorResult.Get("access_token");
            expire_in = webAuthenticatorResult.Get("expires");
            System.Diagnostics.Debug.WriteLine($"Google Access Token:  {accessToken}");
            System.Diagnostics.Debug.WriteLine($"Google Token Expire In:  {expire_in}");

            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(expire_in))
            {
                _persistanceService.AccessToken = accessToken;
                _persistanceService.ExpireIn = double.Parse(expire_in);
                _persistanceService.SignupMethod = SignupMethodEnum.Google;
                OnAuthenticatedUser?.Invoke(this, new EventArgs());
            }
        }
        public void SignoutByGoogle()
        {
            ClearPersistanceService();
        }
        #endregion
        */
        /*
        #region Facebook
        public async void AuthenticationByFacebook()
        {
            WebAuthenticatorResult webAuthenticatorResult = await MakeAuthentication(AppConstants.FacebookSchemeKey);

            if (webAuthenticatorResult == null)
                return;

            string accessToken = string.Empty;
            string expire_in = string.Empty;
            
            accessToken = webAuthenticatorResult.Get("access_token");
            expire_in = webAuthenticatorResult.Get("expires");

            System.Diagnostics.Debug.WriteLine($"Google Access Token:  {accessToken}");
            System.Diagnostics.Debug.WriteLine($"Google Token Expire In:  {expire_in}");

            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(expire_in))
            {
                _persistanceService.AccessToken = accessToken;
                _persistanceService.ExpireIn = double.Parse(expire_in);
                _persistanceService.SignupMethod = SignupMethodEnum.Google;
                OnAuthenticatedUser?.Invoke(this, new EventArgs());
            }   
        }
        public void SignoutByFacebook()
        {
            ClearPersistanceService();
        }
        #endregion
        */
    }
}