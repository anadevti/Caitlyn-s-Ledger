using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaitlynsLedgerAPI.Infra.Authentication;

public static class GoogleAuthExtensions
{
    public static IServiceCollection AddGoogleAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultScheme          = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(opts =>
            {
                opts.ClientId     = configuration["Google:ClientId"];
                opts.ClientSecret = configuration["Google:ClientSecret"];
                opts.CallbackPath = "/signin-google";
                opts.Scope.Add("email");
                opts.Scope.Add("profile");
                opts.SaveTokens   = true; // se precisar acessar id_token depois
            });

        return services;
    }
}