using CSharpFunctionalExtensions;

public interface IUserRepository
{
    Task<Result> AddAsync(User user, CancellationToken cancellationToken = default);

    Task<Maybe<User>> FindByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
}