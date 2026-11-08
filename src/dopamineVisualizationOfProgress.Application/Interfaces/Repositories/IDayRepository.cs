using CSharpFunctionalExtensions;

public interface IDayRepository
{
    Task<Maybe<Day>> FindByUserIdAsync(Guid id, DateOnly date, CancellationToken cancellationToken = default);

    Task AddAsync(Day day,  CancellationToken cancellationToken = default);

    Task UpdateAsync(Day day, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Day>> GetRangeAsync(Guid userId,DateOnly from, DateOnly to, CancellationToken ct = default);

}