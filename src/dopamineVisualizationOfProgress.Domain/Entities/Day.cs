using CSharpFunctionalExtensions;

public class Day
{
    private const float MaxProductiveHours = 15f;

    private Day() { }

    private Day(Guid id, DateOnly date, float hardWork, float uncontrolledWork,
        float strengthTraining, float cardioTraining, float dopamineProcrastination, bool dietInfo)
    {
        Id = id;
        Date = date;
        HardWork = hardWork;
        UncontrolledWork = uncontrolledWork;
        StrengthTraining = strengthTraining;
        CardioTraining = cardioTraining;
        DopamineProcrastination = dopamineProcrastination;
        DietInfo = dietInfo;
    }

    public Guid Id { get; private set; }
    public DateOnly Date { get; private set; }
    public float HardWork { get; private set; }
    public float UncontrolledWork { get; private set; }
    public float StrengthTraining { get; private set; }
    public float CardioTraining { get; private set; }
    public float DopamineProcrastination { get; private set; }
    public bool DietInfo { get; private set; }

    private static Result Validate(float hardWork, float uncontrolledWork,
        float strengthTraining, float cardioTraining, float dopamineProcrastination)
    {
        var values = new[] { hardWork, uncontrolledWork, strengthTraining,
                             cardioTraining, dopamineProcrastination };

        if (values.Any(v => v < 0 || float.IsNaN(v)))
            return Result.Failure("Hours cannot be negative");

        if (values.Sum() > MaxProductiveHours)
            return Result.Failure($"You have only {MaxProductiveHours} hours on productive days");

        return Result.Success();
    }

    public static Result<Day> Create(DateOnly date, float hardWork, float uncontrolledWork,
        float strengthTraining, float cardioTraining, float dopamineProcrastination, bool dietInfo)
    {
        var validation = Validate(hardWork, uncontrolledWork, strengthTraining,
                                  cardioTraining, dopamineProcrastination);
        if (validation.IsFailure)
            return Result.Failure<Day>(validation.Error);

        return Result.Success(new Day(Guid.NewGuid(), date, hardWork, uncontrolledWork,
            strengthTraining, cardioTraining, dopamineProcrastination, dietInfo));
    }

    public Result Update(float hardWork, float uncontrolledWork, float strengthTraining,
        float cardioTraining, float dopamineProcrastination, bool dietInfo)
    {
        var validation = Validate(hardWork, uncontrolledWork, strengthTraining,
                                  cardioTraining, dopamineProcrastination);
        if (validation.IsFailure)
            return validation;

        HardWork = hardWork;
        UncontrolledWork = uncontrolledWork;
        StrengthTraining = strengthTraining;
        CardioTraining = cardioTraining;
        DopamineProcrastination = dopamineProcrastination;
        DietInfo = dietInfo;

        return Result.Success();
    }
}