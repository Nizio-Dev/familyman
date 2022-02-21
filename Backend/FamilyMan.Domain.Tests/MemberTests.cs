using FamilyMan.Domain.Models;
using Xunit;

namespace FamilyMan.Domain.Tests
{
    public class MemberTests
    {
        [Fact]
        public void MemberCtor_CreateStandardMember_ReturnsNewMember()
        {
            var email = "mock@test.com";

            var member = new Member(email);

            Assert.NotNull(member);
            Assert.NotNull(member.Id);
            Assert.Equal(email, member.Email);
            Assert.Null(member.Families);
            Assert.Null(member.HeadOfamilies);
            Assert.Null(member.Todos);
            Assert.False(member.IsConfirmed);
        }

        [Fact]
        public void MemberConfirm_ConfirmStandardMember_SetsUserConfirmedToTrue()
        {
            var email = "mock@test.com";

            var member = new Member(email);

            member.Confirm();

            Assert.True(member.IsConfirmed);

        }


    }
}