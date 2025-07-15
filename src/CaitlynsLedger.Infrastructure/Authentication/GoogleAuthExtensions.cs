using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace CaitlynsLedgerAPI.Infra.Authentication;

public static class GoogleAuthExtensions
{
    public static IServiceCollection AddGoogleAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Busca as credenciais primeiro nas variáveis de ambiente, depois no appsettings
        var clientId = Environment.GetEnvironmentVariable("Google__ClientId") ?? 
                      configuration["Google:ClientId"];
                      
        var clientSecret = Environment.GetEnvironmentVariable("Google__ClientSecret") ?? 
                          configuration["Google:ClientSecret"];

        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
        {
            throw new InvalidOperationException(
                "Credenciais do Google OAuth não encontradas. Configure as variáveis de ambiente Google__ClientId e Google__ClientSecret " +
                "ou defina Google:ClientId e Google:ClientSecret no arquivo appsettings.json");
        }

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie(options => 
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax; // Importante para OAuth
                options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            })
            .AddGoogle(opts =>
            {
                opts.ClientId = clientId;
                opts.ClientSecret = clientSecret;
                opts.CallbackPath = "/signin-google";
                opts.Scope.Add("email");
                opts.Scope.Add("profile");
                opts.SaveTokens = true;
                
                // Configurações adicionais para lidar com o estado OAuth
                opts.CorrelationCookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                opts.CorrelationCookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
            });

        return services;
    }
}