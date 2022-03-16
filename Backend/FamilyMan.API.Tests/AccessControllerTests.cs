using FamilyMan.Application.Dto.Requests;
using Xunit;

namespace FamilyMan.API.Tests;

public class AccessControllerTests
{
    [Fact]
    public void Register_RegisterStandardUser_RegistersUser()
    {
        var registerBody = new CreateMemberDto()
        {
            Email = "Mock@test.com",
            Password = "123Qwe!",
            ConfirmPassword = "123Qwe!"
        };
    }
}