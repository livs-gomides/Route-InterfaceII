namespace Route2.PagesApp;

public partial class ForgetPassword : ContentPage
{
    public ForgetPassword(){
        InitializeComponent();
    }
    private async void OnAllowClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(PermissionMicrophonePage));
    }
}