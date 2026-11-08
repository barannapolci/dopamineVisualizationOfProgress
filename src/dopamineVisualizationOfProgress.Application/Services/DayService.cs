using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using CSharpFunctionalExtensions;
using Microsoft.VisualBasic;

public class DayService : IDayService
{
    private readonly IDayRepository _dayRepository;

    private static DateOnly StartOfWeek(DateOnly date)
    {
        return date.AddDays(-(((int)date.DayOfWeek + 6) % 7));
    }
    public DayService(IDayRepository dayRepository)
    {
        _dayRepository = dayRepository;
    }
    
    
    public async Task<Result> UpsertAsync(Guid userId,DateOnly date,DayForm dayForm, CancellationToken ct = default)
    {
        var res = await _dayRepository.FindByUserIdAsync(userId,date,ct);
        
        if(res.HasNoValue)
        {
            var day = Day.Create(userId,date, dayForm.HardWork,dayForm.UncontrolledWork,
                dayForm.StrengthTraining,dayForm.CardioTraining,dayForm.DopamineProcrastination,dayForm.DietInfo);
            
            if(day.IsFailure){return Result.Failure(day.Error);}
            
            await _dayRepository.AddAsync(day.Value,ct);
            
            return Result.Success();
        }

        var dayValue = res.Value;
        var update = dayValue.Update(dayForm.HardWork, dayForm.UncontrolledWork,
            dayForm.StrengthTraining, dayForm.CardioTraining, dayForm.DopamineProcrastination, dayForm.DietInfo);

        if(update.IsFailure) { return update;}
        
        await _dayRepository.UpdateAsync(dayValue,ct);

        return Result.Success();
    }

    public async Task<Result<DayResponse>> GetAsync(Guid userId,DateOnly date, CancellationToken ct = default)
    {
        var res = await _dayRepository.FindByUserIdAsync(userId,date,ct);
        
        if(res.HasNoValue){return Result.Failure<DayResponse>("day was not found");}

        var day = res.Value;

        var response = new DayResponse(day.Date,day.HardWork,day.UncontrolledWork,day.StrengthTraining,
            day.CardioTraining,day.DopamineProcrastination,day.DietInfo);

        return Result.Success(response);
    }

    public async Task<Result<StatsResponse>> GetStatsAsync(Guid userId, StatsPeriod period, DateOnly date, 
                                                            CancellationToken ct = default)
    {
        var (from, to) = period switch
        {
            StatsPeriod.Day => (date,date),
            StatsPeriod.Week => (StartOfWeek(date),StartOfWeek(date).AddDays(6)),
            StatsPeriod.Month => (new DateOnly(date.Year,date.Month,1),
                                new DateOnly(date.Year,date.Month,1).AddMonths(1).AddDays(-1)),
            StatsPeriod.Year => (new DateOnly(date.Year,1,1),new DateOnly(date.Year,12,31)),
            _ => throw new ArgumentException(nameof(period))
        };

        var days = await _dayRepository.GetRangeAsync(userId,from,to,ct);

        if(days.Count == 0) return Result.Failure<StatsResponse>("days for current period have not been written down");

        var response = new StatsResponse(
        from, to,
        days.Sum(d => d.HardWork),
        days.Sum(d => d.UncontrolledWork),
        days.Sum(d => d.StrengthTraining),
        days.Sum(d => d.CardioTraining),
        days.Sum(d => d.DopamineProcrastination),
        days.Count,
        days.Count(d => d.DietInfo));

        return Result.Success(response);
    }

}