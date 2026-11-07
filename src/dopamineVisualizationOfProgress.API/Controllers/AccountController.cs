using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/account")]
public class AccountController : Controller
{
    private readonly IAccauntSevice _accauntService;
    public AccountController(IAccauntSevice accauntSevice)
    {
        _accauntService = accauntSevice;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest, CancellationToken cancellationToken = default)
    {
        var res = await _accauntService.RegisterAsync(registerRequest,cancellationToken);
        if(res.IsFailure){return Unauthorized(res.Error);}

        return Ok();
    }
}