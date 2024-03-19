using SocialMediaLoginMaui.Enums;

namespace SocialMediaLoginMaui.Interfaces
{
    public interface IPersistanceService
	{
        string AccessToken { get; set; }
        string RefreshToken { get; set; }
        string UserName { get; set; }
        string ProfilePicture { get; set; }
        double ExpireIn { get; set; }
        SignupMethodEnum SignupMethod { get; set; }
        //bool IsLoggedIn { get; set; }
    }
}

