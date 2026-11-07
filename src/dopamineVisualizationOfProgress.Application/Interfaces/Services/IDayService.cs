using CSharpFunctionalExtensions;

public interface IDayService
{
    Task<Result> UpsertAsync(Guid userId,DayForm dayForm, CancellationToken ct = default);

    Task<Result<DayResponse>> GetAsync(Guid userId, DateOnly date, CancellationToken ct = default);

    Task<Result<StatsResponse>> GetStatsAsync(Guid userId, StatsPeriod period, DateOnly date, CancellationToken ct = default);
}