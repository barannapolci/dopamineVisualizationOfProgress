using CSharpFunctionalExtensions;

public interface IDayRepository
{
    Task<Maybe<Day>> FindByUserIdAsync(Guid id, DateOnly date, CancellationToken cancellationToken = default);

    Task AddAsync(Day day,  CancellationToken cancellationToken = default);

    Task UpdateAsync(Day day, CancellationToken cancellationToken = default);
}