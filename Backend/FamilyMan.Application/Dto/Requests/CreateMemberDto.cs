namespace FamilyMan.Application.Dto.Requests;

public class CreateMemberDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}