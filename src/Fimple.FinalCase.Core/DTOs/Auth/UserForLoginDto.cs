namespace Fimple.FinalCase.Core.DTOs.Auth;

public class UserForLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserForLoginDto()
    {
        Email = string.Empty;
        Password = string.Empty;
    }

    public UserForLoginDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
}