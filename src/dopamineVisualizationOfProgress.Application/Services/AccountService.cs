using CSharpFunctionalExtensions;

public class AccountService : IAccauntSevice
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AccountService(IUserRepository userRepository,IPasswordHasher passwordHasher,
                            IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<Result> RegisterAsync(AccountForm accountForm, CancellationToken cancellationToken = default)
    {
        var userResult = User.Create(
            accountForm.Name,
            _passwordHasher.Hash(accountForm.password)
        );

        if (userResult.IsFailure)
        {
            return Result.Failure(userResult.Error);
        }

        var user = userResult.Value;
        return await _userRepository.AddAsync(user,cancellationToken);
    }
    
    public async Task<Result<AuthResponse>> LoginAsync(AccountForm accountForm, CancellationToken cancellationToken = default)
    {
        var res = await _userRepository.FindByNameAsync(User.NormalName(accountForm.Name), cancellationToken);
        if (res.HasNoValue)
        {
            return Result.Failure<AuthResponse>("incorrect login or password");
        }

        var user = res.Value;
        if (!_passwordHasher.Verify(accountForm.password, user.PasswordHash))
        {
            return Result.Failure<AuthResponse>("incorrect login or password");
        }

        var token = _jwtTokenGenerator.Generate(user);

        return Result.Success(new AuthResponse(token.Token ,token.ExpiresAt)); 
    } 
}