using CSharpFunctionalExtensions;

public interface IAccauntSevice
{
    Task<Result> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken = default);
}