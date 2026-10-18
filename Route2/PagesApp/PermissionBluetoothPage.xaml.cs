using Microsoft.Maui.ApplicationModel;
using Route2.PagesApp;
namespace Route2;

public partial class PermissionBluetoothPage : ContentPage
{
    public PermissionBluetoothPage()
    {
        InitializeComponent();
    }

    private async void OnAllowClicked(object sender, EventArgs e)
    {
        //try
        //{
            //var status = await Permissions.CheckStatusAsync<
            //    Permissions.Bluetooth>();

            //if (status != PermissionStatus.Granted)
            //{
            //    status = await Permissions.RequestAsync<
            //        Permissions.Bluetooth>();
            //}

            //if (status == PermissionStatus.Granted)
            //{
                // Avança diretamente para a tela de permissão Bluetooth.
                await Shell.Current.GoToAsync(
                    nameof(SignUp));
        //    }
        //    else
        //    {
        //        await DisplayAlert(
        //            "Permissão necessária",
        //            "Para utilizar os comandos de voz do Route, permita o acesso ao microfone nas configurações do dispositivo.",
        //            "OK");
        //    }
        //}
        //catch (FeatureNotSupportedException)
        //{
        //    await DisplayAlert(
        //        "Recurso indisponível",
        //        "O acesso ao BLUETOOTH não é suportado nesta plataforma.",
        //        "OK");
        //}
        //catch (PermissionException)
        //{
        //    await DisplayAlert(
        //        "Erro de permissão",
        //        "Não foi possível solicitar o acesso ao BLUETOOTH.",
        //        "OK");
        //}
        //catch (Exception)
        //{
        //    await DisplayAlert(
        //        "Erro",
        //        "Ocorreu um problema ao solicitar o BLUETOOTH.",
        //        "OK");
        //}
    }

}