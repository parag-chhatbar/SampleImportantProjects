using Foundation;
using UIKit;

namespace SocialMediaLoginMaui;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool OpenUrl(UIApplication application, NSUrl url, NSDictionary options)
    {
        System.Diagnostics.Debug.WriteLine($"In Open uri in AppDelegate Url: {url}");
        if(App.CurrentSignUpMethod == Enums.SignupMethodEnum.Google)
        {
            Uri mainUrl = new Uri(url?.AbsoluteString);
            Microsoft.Maui.Controls.Application.Current.SendOnAppLinkRequestReceived(mainUrl);
            //string accessCode = string.Empty;
            //var parametersArray = mainUrl.
            /*
            if(url.TryGetResource((NSString)"code",out ))
            {
                accessCode = value?.ToString();
            }
            */
            //accessCode = url.ValueForKey((NSString)"code").ToString();
            //System.Diagnostics.Debug.WriteLine($"In Open uri in AppDelegate Url: {accessCode}");

        }
        return base.OpenUrl(application, url, options);
    }
}