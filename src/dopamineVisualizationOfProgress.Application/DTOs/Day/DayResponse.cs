public sealed record DayResponse(
    DateOnly Date,
    float HardWork,
    float UncontrolledWork,
    float StrengthTraining,
    float CardioTraining,
    float DopamineProcrastination,
    bool DietInfo);     