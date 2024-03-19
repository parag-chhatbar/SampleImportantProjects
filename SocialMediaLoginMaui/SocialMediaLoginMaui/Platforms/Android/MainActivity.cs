using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.OS;

namespace SocialMediaLoginMaui;

[Activity(Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { Intent.ActionView },
            Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
            DataSchemes = new[] { "com.googleusercontent.apps.251325787545-9633s30j3jsasr0bghu4qe7ih64q456m" },
            DataPath = "/oauth2redirect")]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        try
        {
            base.OnCreate(savedInstanceState);
            System.Diagnostics.Debug.WriteLine($"In OnCreate() savedInstanceState: {savedInstanceState}");
        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"Exception In OnCreate(): {e.Message} stackTrace: {e.StackTrace}");
        }
    }
    
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
    {
        try
        {
            base.OnActivityResult(requestCode, resultCode, data);
            System.Diagnostics.Debug.WriteLine("In OnActivityResult()");
        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"Exception In OnActivityResult(): {e.Message} stackTrace: {e.StackTrace}");
        }
    }
    

    protected override void OnNewIntent(Intent? intent)
    {
        System.Diagnostics.Debug.WriteLine($"In OnNewIntent() intent: {intent}");
        base.OnNewIntent(intent);
    }
}

