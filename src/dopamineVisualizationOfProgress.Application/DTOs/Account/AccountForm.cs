using System.ComponentModel.DataAnnotations;

public class AccountForm
{
    [Required, MaxLength(User.MaxNameLength)]
    public required string Name {get; init;}

    [Required, StringLength(72,MinimumLength = 8)]
    public required string password {get; init;}
}