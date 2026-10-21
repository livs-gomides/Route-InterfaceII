namespace Route2.PagesApp;

using Route2.Services;


public partial class SignUp : ContentPage
{
    private readonly Services.AuthService _authService = new();
    public SignUp()
	{
		InitializeComponent();
	}
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(name) || 
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos antes de prosseguir.", "OK");
            return;
        }
        bool isSuccess = await _authService.RegisterAsync(name, email, password);

        if (isSuccess)
        {
            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");
            await Shell.Current.GoToAsync("SignIn");
        }
        else
        {
            await DisplayAlert("Erro", "Não foi possível realizar o cadastro. Verifique se o e-mail já está em uso.", "OK");
        }
    }

    
}