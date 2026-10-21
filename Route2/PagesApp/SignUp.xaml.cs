
using Route2.Services;

namespace Route2.PagesApp;

public partial class SignUp : ContentPage
{
    private readonly AuthService _authService = new();

    public SignUp()
    {
        InitializeComponent();
    }

    // Volta para tela de login
    private async void OnSignInTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignIn));
    }

    // cadastro
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
            bool isSuccess = await _authService.RegisterAsync(
                name,
                email,
                password);

            if (isSuccess)
            {
                await DisplayAlert(
                    "Sucesso",
                    "Usuário cadastrado com sucesso! Faça login para continuar.",
                    "OK");

                await Shell.Current.GoToAsync(nameof(SignIn));
            }
            else
            {
                await DisplayAlert(
                    "Erro",
                    "Não foi possível realizar o cadastro. Verifique se o e-mail já está em uso.",
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
