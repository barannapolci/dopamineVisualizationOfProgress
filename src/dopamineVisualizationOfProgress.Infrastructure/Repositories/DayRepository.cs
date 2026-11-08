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
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Day>> GetRangeAsync(Guid userId, DateOnly from, DateOnly to, CancellationToken ct = default)
    {
        return await _context.Days
                .AsNoTracking()
                .Where(d => d.UserId == userId && d.Date >= from && d.Date <= to)
                .OrderBy(d => d.Date)
                .ToListAsync(ct);
    }
}