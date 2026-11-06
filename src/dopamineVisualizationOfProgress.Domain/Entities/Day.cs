using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CSharpFunctionalExtensions;


public class Day
{
    public Day(){}

    private Day(Guid id, float hardwork, float uncontroledWork, float strengthTraining, 
    float cardioTraining, float dopamineeProcrastination, bool dietInfo)
    {
        Id = id;
        HardWork = hardwork;
        UncontroledWork = uncontroledWork;
        StrengthTraining = strengthTraining;
        CardioTraining = cardioTraining;
        DopamineProcrastination = dopamineeProcrastination;
        DietInfo = dietInfo;
    }
    public Guid Id {get; private set;}
    public float HardWork {get;private set;} = 0.0f;

    public float UncontroledWork {get;private set;} = 0.0f;
    
    public float StrengthTraining {get;private set;} = 0.0f;
    
    public float CardioTraining {get; private set;} = 0.0f;

    public float DopamineProcrastination {get;private set;} = 0.0f;

    public bool DietInfo {get;private set;} = false;

    public static Result<Day> Create(float hardwork, float uncontroledWork, float strengthTraining, 
    float cardioTraining, float dopamineeProcrastination, bool dietInfo)
    {
        float sum = hardwork + uncontroledWork + strengthTraining + cardioTraining + dopamineeProcrastination;
        if(sum > 15.0){return Result.Failure<Day>("you have only 15hours on productive days");}

        return Result.Success<Day>(new Day(Guid.NewGuid(),hardwork,uncontroledWork,strengthTraining,cardioTraining,dopamineeProcrastination,dietInfo));
    }
}

