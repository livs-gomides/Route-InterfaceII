
namespace Route2;

public partial class StartPage : ContentPage
{
    private bool _isNavigating;

    public StartPage()
    {
        InitializeComponent();
    }

    private async void OnStartTapped(
        object sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        try
        {
            await Navigation.PushAsync(new PermissionLocationPage());
        }
        catch
        {
            _isNavigating = false;
            throw;
        }
    }
}
