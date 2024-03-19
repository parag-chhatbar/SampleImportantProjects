using System.Windows.Input;

namespace SocialMediaLoginMaui.CommonViews;

public partial class CommonSignupButton : Frame
{
    #region ReadOnly
    public static readonly BindableProperty IconImgSourceProperty = BindableProperty.Create(nameof(IconImgSource), typeof(ImageSource), typeof(CommonSignupButton), null, BindingMode.TwoWay);
    public static readonly BindableProperty SignUpLabelMessageProperty = BindableProperty.Create(nameof(SignUpLabelMessage), typeof(string), typeof(CommonSignupButton), null, BindingMode.TwoWay);
    public static readonly BindableProperty FrameBackColorProperty = BindableProperty.Create(nameof(FrameBackColor), typeof(Color), typeof(CommonSignupButton), Colors.White, BindingMode.TwoWay);
    public static readonly BindableProperty LabelMessageTextColorProperty = BindableProperty.Create(nameof(LabelMessageTextColor), typeof(Color), typeof(CommonSignupButton), Colors.Black, BindingMode.TwoWay);
    public static readonly BindableProperty FrameTappedCommandProperty = BindableProperty.Create(nameof(FrameTappedCommand), typeof(ICommand), typeof(CommonSignupButton), null, BindingMode.TwoWay);
    #endregion

    #region Public
    public ImageSource IconImgSource
    {
        get { return (ImageSource)GetValue(IconImgSourceProperty); }
        set { SetValue(IconImgSourceProperty, value); }
    }
    public string SignUpLabelMessage
    {
        get { return (string)GetValue(SignUpLabelMessageProperty); }
        set { SetValue(SignUpLabelMessageProperty, value); }
    }
    public Color FrameBackColor
    {
        get { return (Color)GetValue(FrameBackColorProperty); }
        set { SetValue(FrameBackColorProperty, value); }
    }
    public Color LabelMessageTextColor
    {
        get { return (Color)GetValue(LabelMessageTextColorProperty); }
        set { SetValue(LabelMessageTextColorProperty, value); }
    }
    #endregion

    #region Command
    public ICommand FrameTappedCommand
    {
        get { return (ICommand)GetValue(FrameTappedCommandProperty); }
        set { SetValue(FrameTappedCommandProperty, value); }
    }
    #endregion

    #region Constructor
    public CommonSignupButton()
    {
        InitializeComponent();
        //set binding
        this.BindingContext = this;
        ImgIcon.BindingContext = this;
        LblMessage.BindingContext = this;
    }
    #endregion
}
