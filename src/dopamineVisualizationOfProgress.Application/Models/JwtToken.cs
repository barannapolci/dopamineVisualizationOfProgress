public sealed class JwtToken
{
    public JwtToken(string token, DateTime expiresAt)
    {
        Token = token;
        ExpiresAt = expiresAt;
    }

    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
}