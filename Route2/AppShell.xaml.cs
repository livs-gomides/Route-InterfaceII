
using Route2.PagesApp;

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

        Routing.RegisterRoute(
            nameof(SignUp),
            typeof(SignUp));

        Routing.RegisterRoute(
            nameof(SignIn),
            typeof(SignIn));

        Routing.RegisterRoute(
            nameof(ForgetPassword),
            typeof(ForgetPassword));

        Routing.RegisterRoute(
            nameof(AssistantPage),
            typeof(AssistantPage));

        Routing.RegisterRoute(
            nameof(SavedPlacesPage),
            typeof(SavedPlacesPage));
    }
}
