using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Net.Cache;

public class RegisterRequest
{
    [Required, MaxLength(User.MaxNameLength)]
    public required string Name {get; init;}

    [Required, StringLength(72,MinimumLength = 8)]
    public required string password {get; init;}
}