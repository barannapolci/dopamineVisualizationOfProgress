using System.Data.Common;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

public class DayRepository : IDayRepository
{
    private readonly ApplicationDbContext _context;

    public DayRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Maybe<Day>> FindByUserIdAsync(Guid id, DateOnly date, CancellationToken cancellationToken = default)
    {
        var res = await _context.Days.FirstOrDefaultAsync(d => d.UserId == id && d.Date == date,cancellationToken );

        return Maybe.From(res);
    }

    public async Task AddAsync(Day day, CancellationToken ct = default)
    {
        _context.Days.Add(day);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Day day, CancellationToken ct = default)
    {
        await _context.SaveChangesAsync(ct);   // день вже відстежується, Update не потрібен
    }


}