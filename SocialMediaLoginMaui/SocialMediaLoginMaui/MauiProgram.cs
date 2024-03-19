using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace SocialMediaLoginMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Font_Awesome_6_Regular.otf", "FontAwesomeRegular");
				fonts.AddFont("Font_Awesome_6_Solid.otf", "FontAwesomeSolid");
				fonts.AddFont("Font_Awesome_6_Brands.otf", "FontAwesomeBrands");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

