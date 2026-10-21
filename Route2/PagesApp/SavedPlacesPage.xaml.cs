
namespace Route2.PagesApp;

public partial class SavedPlacesPage : ContentPage
{
    public SavedPlacesPage()
    {
        InitializeComponent();
    }

    // Retornar à página anterior
    private async void OnBackTapped(
        object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
