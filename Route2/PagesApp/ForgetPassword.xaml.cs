using Route2.Services;

namespace Route2.PagesApp;

public partial class ForgetPassword : ContentPage
{
    private readonly Services.AuthService _authService = new();
    public ForgetPassword(){
        InitializeComponent();
    }
    private async void OnRecoverButtonClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;

        if (string.IsNullOrWhiteSpace(email))
        {
            await DisplayAlert("Atenção", "Preencha o e-mail para recuperar a senha.", "OK");
            return;
        }

        string newPassword = await _authService.ForgotPasswordAsync(email);

        if (newPassword != null)
        {
            await DisplayAlert("Sucesso", $"A sua nova senha temporária é: {newPassword}", "OK");
            await Shell.Current.GoToAsync("SignIn");
        }
        else
        {
            await DisplayAlert("Erro", "E-mail não encontrado no sistema.", "OK");
        }
    }
}