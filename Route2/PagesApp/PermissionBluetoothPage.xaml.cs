using Microsoft.Maui.ApplicationModel;

#if ANDROID
using Android;
using Android.OS;
using Microsoft.Maui.ApplicationModel;
#endif

namespace Route2;

public partial class PermissionBluetoothPage : ContentPage
{
    public PermissionBluetoothPage()
    {
        InitializeComponent();
    }

    private async void OnAllowClicked(object sender, EventArgs e)
    {
        try
        {
#if ANDROID
            if (Build.VERSION.SdkInt >= BuildVersionCodes.S)
            {
                var status = await Permissions.CheckStatusAsync<BluetoothScanPermission>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<BluetoothScanPermission>();
                }

                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert(
                        "Permissão necessária",
                        "Para detectar os beacons de navegação, permita o acesso aos dispositivos Bluetooth.",
                        "OK");

                    return;
                }
            }
#endif

            // A etapa de Bluetooth foi concluída.
            // Defina aqui a próxima tela, se houver.
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert(
                "Indisponível",
                "A solicitação de Bluetooth não é suportada nesta plataforma.",
                "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert(
                "Erro de permissão",
                "Não foi possível solicitar a permissão Bluetooth.",
                "OK");
        }
        catch (Exception)
        {
            await DisplayAlert(
                "Erro",
                "Ocorreu um problema ao solicitar a permissão Bluetooth.",
                "OK");
        }
    }

    private async void OnDenyClicked(object sender, EventArgs e)
    {
        // Permanece na tela caso o usuário negue a permissão.
    }
}

#if ANDROID
public class BluetoothScanPermission : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        Build.VERSION.SdkInt >= BuildVersionCodes.S
            ? new[]
            {
                (Manifest.Permission.BluetoothScan, true)
            }
            : Array.Empty<(string, bool)>();
}
#endif