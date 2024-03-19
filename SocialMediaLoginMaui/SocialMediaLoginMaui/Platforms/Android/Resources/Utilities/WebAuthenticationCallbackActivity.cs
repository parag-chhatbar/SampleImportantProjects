using Android.App;
using Android.Content;
using Android.Content.PM;

namespace SocialMediaLoginMaui.Platforms.Android.Resources.Utilities
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    [IntentFilter(new[] {Intent.ActionView},
				Categories = new[] {Intent.CategoryDefault, Intent.CategoryBrowsable },
				DataScheme = "xamarinessentials")]
	public class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {
	}
}

