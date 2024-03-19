using SocialMediaLoginMaui.ViewModels;

namespace SocialMediaLoginMaui.Views;

public partial class SignUpPage : ContentPage
{
    #region ReadOnly
    private readonly SignUpViewModel _signUpViewModel;
    #endregion

    #region Constructor
    public SignUpPage()
	{
        _signUpViewModel = new SignUpViewModel();
		InitializeComponent();
        BindingContext = _signUpViewModel;
	}
    #endregion
}
