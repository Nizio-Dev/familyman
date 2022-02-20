using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using Xunit;

namespace FamilyMan.Application.Tests;

public class CurrentUserServiceTests
{
    [Fact]
    public void GetMember_StandardUser_ReturnsUser()
    {
        var mockHttpContextAccesor = new Mock<IHttpContextAccessor>();
        mockHttpContextAccesor.Setup(o => o.HttpContext.User).Returns(It.IsAny<ClaimsPrincipal>());



    }


}

