using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task<Result> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Maybe<User>> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var res = await _context.Users.FirstOrDefaultAsync(u => u.Name == name, cancellationToken);
        return Maybe.From(res);
    }

    public async Task<bool> ExistsByNameAsync(string name,CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(u => u.Name == name, cancellationToken);
    }
}