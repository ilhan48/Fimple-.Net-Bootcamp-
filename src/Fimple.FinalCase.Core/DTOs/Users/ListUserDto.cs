namespace Fimple.FinalCase.Core.DTOs;

public class ListUserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool Status { get; set; }
}