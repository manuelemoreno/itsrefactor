using FluentAssertions;
using Sat.Recruitment.Api.Domain.Entities;
using Xunit;

namespace Sat.Recruitment.Test.Entities;

public class EmailUnitTests
{
    [Fact]
    public void Should_Return_ValidEmail()
    {
        const string email = "manuelmoreno@test.com";
        var validEmail = Email.Create(email);

        // Assert
        validEmail.EmailAddress.Should().Be(email);
    }

    [Theory]
    [InlineData("manuel.moreno@test.com")]
    [InlineData("manuel.more.no@test.com")]
    [InlineData("manuel.more.no+@test.com")]
    [InlineData("manuel+.more.no+@test.com")]
    public void Should_Return_NormalizeEmail_If_Contains_Dots_And_Plus_Sign(string email)
    {
        const string assert = "manuelmoreno@test.com";
        var validEmail = Email.Create(email);

        // Assert
        validEmail.EmailAddress.Should().Be(assert);
    }


}