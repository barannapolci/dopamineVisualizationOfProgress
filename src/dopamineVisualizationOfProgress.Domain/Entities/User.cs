using CSharpFunctionalExtensions;

public class User
{
    public const int MaxNameLength = 50;

    private User() { }

    private User(Guid id, string name, string passwordHash, DateTime registerDate)
    {
        Id = id;
        Name = name;
        PasswordHash = passwordHash;
        RegisterDate = registerDate;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public DateTime RegisterDate { get; private set; }

    public static Result<User> Create(string name, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<User>("Name cannot be empty");

        var normalizedName = name.Trim().ToLowerInvariant();

        if (normalizedName.Length > MaxNameLength)
            return Result.Failure<User>($"Name cannot be longer than {MaxNameLength} characters");

        if (string.IsNullOrWhiteSpace(passwordHash))
            return Result.Failure<User>("Password hash cannot be empty");

        return Result.Success(new User(Guid.NewGuid(), normalizedName, passwordHash, DateTime.UtcNow));
    }
}