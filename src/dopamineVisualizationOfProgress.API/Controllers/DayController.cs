using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api")]
[Authorize]
public class DayController : ControllerBase
{
    private readonly IDayService _dayService;

    public DayController(IDayService dayService)
    {
        _dayService = dayService;
    }

    [HttpPut("days/{date}")]
    public async Task<IActionResult> Upsert(DateOnly date, DayForm form, CancellationToken ct)
    {
        var res = await _dayService.UpsertAsync(Guid.Parse(User.FindFirstValue("sub")!), date, form, ct);
        if (res.IsFailure) return BadRequest(res.Error);

        return NoContent();
    }

    [HttpGet("days/{date}")]
    public async Task<IActionResult> GetDay(DateOnly date, CancellationToken ct)
    {
        var res = await _dayService.GetAsync(Guid.Parse(User.FindFirstValue("sub")!), date, ct);
        if (res.IsFailure) return NotFound(res.Error);

        return Ok(res.Value);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats(StatsPeriod period, DateOnly date, CancellationToken ct)
    {
        var res = await _dayService.GetStatsAsync(Guid.Parse(User.FindFirstValue("sub")!), period, date, ct);
        if (res.IsFailure) return NotFound(res.Error);

        return Ok(res.Value);
    }
}