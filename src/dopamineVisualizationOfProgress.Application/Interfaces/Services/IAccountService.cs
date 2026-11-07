using CSharpFunctionalExtensions;

public interface IAccauntSevice
{
    Task<Result> RegisterAsync(AccountForm accountForm, CancellationToken cancellationToken = default);

    Task<Result<AuthResponse>> LoginAsync(AccountForm accountForm, CancellationToken cancellationToken = default);
}