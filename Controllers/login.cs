using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaitlynsLedgerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpGet("google")]
    public IActionResult LoginGoogle(string returnUrl = "/")
    {
        return Challenge(new AuthenticationProperties
        {
            RedirectUri = returnUrl
        }, GoogleDefaults.AuthenticationScheme);
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
        return Ok(new { message = "Você está autenticado pelo Google!" });
    }
}