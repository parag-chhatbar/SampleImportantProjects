using SocialMediaLoginMaui.ViewModels;

namespace SocialMediaLoginMaui.Views;

public partial class HomePage : ContentPage
{
    #region ReadOnly
    private readonly HomeViewModel _homeViewModel;
    #endregion

    #region Constructor
    public HomePage()
	{
        _homeViewModel = new HomeViewModel();
		InitializeComponent();
        BindingContext = _homeViewModel;
	}
    #endregion
}
