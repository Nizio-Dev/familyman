using FamilyMan.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace FamilyMan.Domain.Tests;

public class FamilyTests
{
    [Fact]
    public void FamilyCtor_CreateStandardFamily_ReturnsNewFamily()
    {
        var name = "mocktest";
        var member = new Member("test@user.com");
        var family = new Family(name, member);

        Assert.NotNull(family);
        Assert.Equal(name, family.Name);
        Assert.Same(member, family.Head);
        Assert.Collection(family.Members, item => Assert.Same(member, item));
    }

    [Fact]
    public void AddMember_AddStandardMemberToFamily_AddsMemberToMembersList()
    {
        var owner = new Member("test@owner.com");
        var newMember = new Member("test@user.com");
        var family = new Family("mocktest", owner);

        family.AddMember(newMember);

        Assert.Contains(newMember, family.Members);
    }

    [Fact]
    public void MakeHead_MakeStandardUserNewHead_MakesStandardUserNewHead()
    {
        var owner = new Member("test@owner.com");
        var newMember = new Member("test@user.com");
        var family = new Family("mocktest", owner);

        family.Members = new List<Member>{owner, newMember};

        family.MakeHead(newMember);

        Assert.Same(newMember, family.Head);
    }

    [Fact]
    public void MakeHead_MakeInvalidUserNewHead_MakesStandardUserNewHead()
    {
        var owner = new Member("test@owner.com");
        var memberNotInFamily = new Member("test@user.com");
        var family = new Family("mocktest", owner);

        family.Members = new List<Member>{owner};

        Assert.Throws<InvalidOperationException>(() => family.MakeHead(memberNotInFamily));
    }
}
