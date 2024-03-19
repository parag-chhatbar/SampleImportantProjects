namespace SocialMediaLoginMaui.Interfaces
{
	public interface IAuthenticationService
	{
        event EventHandler OnAuthenticatedUser;
        void AuthenticationByGoogle();
        void SignoutByGoogle();

        //void AuthenticationByFacebook();
        //void SignoutByFacebook();
	}
}

