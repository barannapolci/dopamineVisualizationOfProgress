using System.ComponentModel.DataAnnotations;

public sealed class DayForm
{
    [Range(0, 15)] public float HardWork { get; init; }
    [Range(0, 15)] public float UncontrolledWork { get; init; }
    [Range(0, 15)] public float StrengthTraining { get; init; }
    [Range(0, 15)] public float CardioTraining { get; init; }
    [Range(0, 15)] public float DopamineProcrastination { get; init; }
    public bool DietInfo { get; init; }
}