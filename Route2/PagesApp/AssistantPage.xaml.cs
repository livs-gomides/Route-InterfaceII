
namespace Route2.PagesApp;

public partial class AssistantPage : ContentPage
{
    private bool isListening = false;

    public AssistantPage()
    {
        InitializeComponent();
    }

    // Alternar estado do assistente
    private void OnAssistantTapped(
        object sender, TappedEventArgs e)
    {
        isListening = !isListening;

        if (isListening)
        {
            AssistantStatus.Text = "OUVINDO...";
        }
        else
        {
            AssistantStatus.Text = "TOQUE PARA FALAR";
        }
    }

    // Navegar para Locais Salvos
    private async void OnSavedPlacesTapped(
        object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(SavedPlacesPage));
    }
}
