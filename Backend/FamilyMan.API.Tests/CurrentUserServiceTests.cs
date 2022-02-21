using FamilyMan.API.Services;
using FamilyMan.Application.Interfaces;
using FamilyMan.Domain.Models;
using FamilyMan.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace FamilyMan.API.Tests;
public class CurrentUserServiceTests
{
   
    [Fact]
    public void Member_MemberModelTest_ReturnsUsersMember()
    {

        var options = new DbContextOptionsBuilder<FamilyManDbContext>()
            .UseInMemoryDatabase(databaseName: "in-memory")
            .Options;

        var newMember = new Member("mock@test1.com");

        using (var context = new FamilyManDbContext(options))
        {
            context.Members.Add(newMember);
            context.SaveChanges();
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, newMember.Id.ToString())
        };

        var identity = new ClaimsPrincipal(new ClaimsIdentity(claims));

        var httpContextAccessor = new Mock<IHttpContextAccessor>();

        httpContextAccessor.Setup(x => x.HttpContext.User).Returns(identity);

        using (var context = new FamilyManDbContext(options))
        {
            var currentUserService = new CurrentUserService(httpContextAccessor.Object, context);

            Assert.NotNull(currentUserService.MemberIdentity);
            Assert.Same(identity, currentUserService.MemberIdentity);
        }
    }

    [Fact]
    public void MemberIdentity_MemberIdentityTest_ReturnsUsersIdentity()
    {
        var options = new DbContextOptionsBuilder<FamilyManDbContext>()
            .UseInMemoryDatabase(databaseName: "in-memory")
            .Options;

        var newMember = new Member("mock@test2.com");

        using (var context = new FamilyManDbContext(options))
        {
            context.Members.Add(newMember);
            context.SaveChanges();
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, newMember.Id.ToString())
        };

        var identity = new ClaimsPrincipal(new ClaimsIdentity(claims));

        var httpContextAccessor = new Mock<IHttpContextAccessor>();

        httpContextAccessor.Setup(x => x.HttpContext.User).Returns(identity);

        using (var context = new FamilyManDbContext(options))
        {
            var currentUserService = new CurrentUserService(httpContextAccessor.Object, context);

            Assert.NotNull(currentUserService.Member);
            Assert.True(currentUserService.Member.Id.ToString() == "22222222-2222-2222-2222-222222222222");
        }
    }

}
