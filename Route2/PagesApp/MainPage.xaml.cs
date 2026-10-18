
namespace Route2;

public partial class MainPage : ContentPage
{
    private bool _transitionStarted;

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_transitionStarted)
            return;

        _transitionStarted = true;

        await Task.Delay(2000);

        await this.FadeTo(0, 450);

        await Shell.Current.GoToAsync(
            nameof(StartPage),
            animate: false);
    }
}
