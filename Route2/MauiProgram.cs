using Microsoft.Extensions.Logging;
using Route2.Services;
using Route2.PagesApp; 

namespace Route2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(new HttpClient());

            builder.Services.AddTransient<AuthService>();

            builder.Services.AddTransient<SignIn>();
            builder.Services.AddTransient<SignUp>();

            return builder.Build();
        }
    }
}