
using Microsoft.Maui.ApplicationModel;

namespace Route2;

public partial class PermissionLocationPage : ContentPage
{
    public PermissionLocationPage()
    {
        InitializeComponent();
    }

    private async void OnAllowClicked(object sender, EventArgs e)
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<
                Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<
                    Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                // Avança diretamente para a tela de permissão do microfone.
                await Shell.Current.GoToAsync(
                    nameof(PermissionMicrophonePage));
            }
            else
            {
                await DisplayAlert(
                    "Permissão necessária",
                    "Para continuar, permita o acesso à localização nas configurações do dispositivo.",
                    "OK");
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert(
                "Recurso indisponível",
                "A solicitação de localização não é suportada nesta plataforma.",
                "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert(
                "Erro de permissão",
                "Não foi possível solicitar a permissão de localização.",
                "OK");
        }
        catch (Exception)
        {
            await DisplayAlert(
                "Erro",
                "Ocorreu um problema ao solicitar a localização.",
                "OK");
        }
    }

    private async void OnDenyClicked(object sender, EventArgs e)
    {
        // Permanece na tela caso o usuário negue a permissão.
    }
}
