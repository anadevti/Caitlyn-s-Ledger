using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaitlynsLedgerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;
    private readonly IConfiguration _configuration;
    public LoginController(ILogger<LoginController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    
    
    [HttpGet("google")]
    public IActionResult LoginGoogle()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action("GoogleCallback"),
            // Importante: depois definir uma URL de retorno específica e fixa
            Items =
            {
                { "scheme", GoogleDefaults.AuthenticationScheme },
            }
        };
        
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }
    
    [HttpGet("google-callback")]
    public async Task<IActionResult> GoogleCallback()
    {
        var result = await HttpContext.AuthenticateAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        if (!result.Succeeded)
            return BadRequest("Falha na autenticação com o Google");

        var swaggerUrl = Url.Content("~/swagger/index.html");

        var html = $@"
<!DOCTYPE html>
<html lang=""pt-br"">
<head>
    <meta charset=""utf-8"">
    <title>Autenticação</title>
    <script>
        setTimeout(function() {{
            window.location.href = '{swaggerUrl}';
        }}, 2000);
    </script>
</head>
<body style=""font-family: sans-serif;"">
    <h2>Autenticação bem-sucedida ✅</h2>
    <p>Redirecionando para a documentação do swagger em segundos...</p>
</body>
</html>";

        return Content(html, "text/html");
    }

    
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Logout realizado com sucesso" });
    }
}

[ApiController]
[Route("api/[controller]")]
public class TesteAuthController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { 
            message = "Você está autenticado pelo Google!",
            username = User.Identity?.Name,
            claims = User.Claims.Select(c => new { c.Type, c.Value })
        });
    }
}