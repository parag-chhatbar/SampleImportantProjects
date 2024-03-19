using SocialMediaLoginMaui.Constants;
using SocialMediaLoginMaui.Enums;
using SocialMediaLoginMaui.Interfaces;
using SocialMediaLoginMaui.Models;
using SocialMediaLoginMaui.Services;
using static System.Formats.Asn1.AsnWriter;

namespace SocialMediaLoginMaui;

public partial class App : Application
{
    #region ReadOnly
    private readonly IPersistanceService _persistanceService;
    private readonly BaseAPIService _baseAPIService;
    #endregion

    #region Public Members
    public static SignupMethodEnum CurrentSignUpMethod { get; set; }
    #endregion

    #region Constructor
    public App()
	{
        _baseAPIService = new BaseAPIService();
        _persistanceService = new PersistanceService();

		InitializeComponent();

		MainPage = new AppShell();

        CheckLoginStatus();
	}
    #endregion

    #region Private Method
    private async void CheckLoginStatus()
    {
        if (!string.IsNullOrEmpty(_persistanceService.AccessToken))
            await Shell.Current.GoToAsync("//HomePage");
        else
            await Shell.Current.GoToAsync("//SignUpPage");
    }
    #endregion

    #region Override Methods
    protected async override void OnAppLinkRequestReceived(Uri uri)
    {
        System.Diagnostics.Debug.WriteLine($"In OnAppLinkRequestReceived() in App.cs uri: {uri}");
        base.OnAppLinkRequestReceived(uri);
        string stringUri = uri?.ToString();
        if (CurrentSignUpMethod == SignupMethodEnum.Google && !string.IsNullOrEmpty(stringUri))
        {
            try
            {
                string[] headAndParameters = stringUri.Split("?");

                if (headAndParameters == null)
                    throw new Exception("Not getting required parameters from server");

                string[] parameters = headAndParameters[1].Split("&");
                string accessCode = parameters?.FirstOrDefault(x => x.StartsWith("code=")).Replace("code=", "");
                System.Diagnostics.Debug.WriteLine($"accessToken: {accessCode}");

                if (string.IsNullOrEmpty(accessCode))
                {
                    string error = parameters?.FirstOrDefault(x => x.StartsWith("error=")).Replace("error=", "");
                    throw new Exception(error);
                }

                string clientId = DeviceInfo.Platform == DevicePlatform.Android ? AppConstants.GoogleAndroidClientId : AppConstants.GoogleiOSClientId;
                string redirectUrl = DeviceInfo.Platform == DevicePlatform.Android ? AppConstants.GoogleAndroidRedirectUrl : AppConstants.GoogleiOSRedirectUrl;
                string scope = AppConstants.GoogleScope;
                string mainUri = $"{AppConstants.GoogleAccessTokenUrl}?scope={scope}&client_id={clientId}&client_secret={string.Empty}&code={accessCode}&grant_type=authorization_code&redirect_uri={redirectUrl}";
                //System.Diagnostics.Debug.WriteLine($"Going for accesstoken mainUri: {mainUri}");

                GoogleTokenModel googleTokenModel = await _baseAPIService.PostRequest<GoogleTokenModel>(mainUri);
                if (googleTokenModel == null)
                    throw new Exception("Not able to retrieve token for given account");
                
                string profileUrl = $"{AppConstants.GoogleUserInfoUrl}?access_token={googleTokenModel.AccessToken}";
                System.Diagnostics.Debug.WriteLine($"profileUrl: {profileUrl}");

                GoogleProfileModel googleProfileModel = await _baseAPIService.GetRequest<GoogleProfileModel>(profileUrl);
                if (googleProfileModel == null)
                    throw new Exception("Not able to get profile of given account");

                _persistanceService.AccessToken = googleTokenModel.AccessToken;
                _persistanceService.RefreshToken = googleTokenModel.RefreshToken;
                _persistanceService.ExpireIn = googleTokenModel.ExpiresIn;
                _persistanceService.UserName = googleProfileModel.FullName;
                _persistanceService.ProfilePicture = googleProfileModel.ProfilePicture;
                _persistanceService.SignupMethod = SignupMethodEnum.Google;

                CheckLoginStatus();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
    #endregion

    #region Private Methods

    #endregion
}

