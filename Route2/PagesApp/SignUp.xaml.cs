using Route2.Services;

namespace Route2.PagesApp;

public partial class SignUp : ContentPage
{
    private readonly AuthService _authService;

    public SignUp(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void OnSignInTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignIn));
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text?.Trim() ?? string.Empty;
        string email = EmailEntry.Text?.Trim() ?? string.Empty;
        string password = PasswordEntry.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert(
                "Atenção",
                "Preencha todos os campos antes de prosseguir.",
                "OK");
            return;
        }

        try
        {
            var result = await _authService.RegisterAsync(
                name,
                email,
                password);

            if (result.IsSuccess)
            {
                await DisplayAlert(
                    "Sucesso",
                    result.Message,
                    "OK");

                await Shell.Current.GoToAsync(nameof(SignIn));
            }
            else
            {
                await DisplayAlert(
                    "Erro",
                    result.Message,
                    "OK");
            }
        }
        catch (Exception)
        {
            await DisplayAlert(
                "Erro",
                "Não foi possível concluir o cadastro. Verifique sua conexão e tente novamente.",
                "OK");
        }
    }
}