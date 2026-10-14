
namespace Route2;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(StartPage),
            typeof(StartPage));

        Routing.RegisterRoute(
            nameof(PermissionLocationPage),
            typeof(PermissionLocationPage));

        Routing.RegisterRoute(
            nameof(PermissionMicrophonePage),
            typeof(PermissionMicrophonePage));

        Routing.RegisterRoute(
            nameof(PermissionBluetoothPage),
            typeof(PermissionBluetoothPage));
    }
}
