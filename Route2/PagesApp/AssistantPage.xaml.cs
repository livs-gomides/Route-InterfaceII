using Microsoft.Maui.Controls;
using System;

namespace Route2.PagesApp;

public partial class AssistantPage : ContentPage
{
    // Estado atual do assistente (0: Pronto, 1: Ouvindo, 2: Processando, 3: Iniciando Rota)
    private int currentState = 0;

    public AssistantPage()
    {
        InitializeComponent();
    }

    // Alternar estados sequenciais do assistente
    private void OnAssistantTapped(object sender, EventArgs e)
    {
        // Incrementa o estado de 0 a 3, e volta para 0 no final
        currentState = (currentState + 1) % 4;

        switch (currentState)
        {
            case 0: // Pronto
                AssistantTitle.Text = "Pronto";
                AssistantButton.Source = "assistant_button.png";
                AssistantActionText.Text = "Toque para Falar";
                break;

            case 1: // Ouvindo
                AssistantTitle.Text = "Ouvindo";
                AssistantButton.Source = "assistant_button_listening.png";
                AssistantActionText.Text = "";
                break;

            case 2: // Processando (Calculando Rota)
                AssistantTitle.Text = "Processando";
                AssistantButton.Source = "assistant_button_make_route.png"; // Usando a imagem sugerida no pack
                AssistantActionText.Text = "Calculando Rota";
                break;

            case 3: // Iniciando Navegação
                AssistantTitle.Text = "Iniciando Navegação";
                AssistantButton.Source = "assistant_button_ready.png"; // O ícone com "check" pode ser este ou outro específico
                AssistantActionText.Text = "";
                break;
        }
    }

    // Navegar para Locais Salvos
    private async void OnSavedPlacesTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SavedPlacesPage));
    }
}