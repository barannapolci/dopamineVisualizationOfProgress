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

    public async Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var userResult = User.Create(
            request.Name,
            _passwordHasher.Hash(request.password)
        );

        if (userResult.IsFailure)
        {
            return Result.Failure(userResult.Error);
        }

        var user = userResult.Value;
        return await _userRepository.AddAsync(user,cancellationToken);
    }
    
}