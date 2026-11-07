using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccauntSevice _accauntService;
    public AccountController(IAccauntSevice accauntSevice)
    {
        _accauntService = accauntSevice;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AccountForm accountForm, CancellationToken cancellationToken = default)
    {
        var res = await _accauntService.RegisterAsync(accountForm,cancellationToken);
        if(res.IsFailure){return Unauthorized(res.Error);}

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AccountForm accountForm, CancellationToken cancellationToken = default)
    {
        var res = await _accauntService.LoginAsync(accountForm,cancellationToken);
        if(res.IsFailure){return Unauthorized(res.Error);}


        return Ok(res.Value);
    }
}