
using Microsoft.Maui.ApplicationModel;

namespace Route2;

public partial class PermissionMicrophonePage : ContentPage
{
    public PermissionMicrophonePage()
    {
        InitializeComponent();
    }

    private async void OnAllowClicked(object sender, EventArgs e)
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<
                Permissions.Microphone>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<
                    Permissions.Microphone>();
            }

            if (status == PermissionStatus.Granted)
            {
                // Avança diretamente para a tela de permissão Bluetooth.
                await Shell.Current.GoToAsync(
                    nameof(PermissionBluetoothPage));
            }
            else
            {
                await DisplayAlert(
                    "Permissão necessária",
                    "Para utilizar os comandos de voz do Route, permita o acesso ao microfone nas configurações do dispositivo.",
                    "OK");
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert(
                "Recurso indisponível",
                "O acesso ao microfone não é suportado nesta plataforma.",
                "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert(
                "Erro de permissão",
                "Não foi possível solicitar o acesso ao microfone.",
                "OK");
        }
        catch (Exception)
        {
            await DisplayAlert(
                "Erro",
                "Ocorreu um problema ao solicitar o microfone.",
                "OK");
        }
    }

    private async void OnDenyClicked(object sender, EventArgs e)
    {
        // Permanece na tela caso o usuário negue a permissão.
    }
}
