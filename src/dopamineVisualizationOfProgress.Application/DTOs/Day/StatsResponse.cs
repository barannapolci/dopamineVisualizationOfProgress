public sealed record StatsResponse(
    DateOnly From,
    DateOnly To,
    float HardWork,
    float UncontrolledWork,
    float StrengthTraining,
    float CardioTraining,
    float DopamineProcrastination,
    int DaysCount);