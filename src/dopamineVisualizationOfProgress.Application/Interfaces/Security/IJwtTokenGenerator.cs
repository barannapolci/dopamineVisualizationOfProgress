public interface IJwtTokenGenerator
{
    JwtToken GenerateToken(string userId, string email);
}