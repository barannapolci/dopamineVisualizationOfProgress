public interface IJwtTokenGenerator
{
    JwtToken Generate(User user);
}