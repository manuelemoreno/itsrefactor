using FluentAssertions;
using Sat.Recruitment.Domain.Entities;
using Xunit;

namespace Sat.Recruitment.UnitTests.Entities;

public class EmailUnitTests
{
    [Fact]
    public void Should_Return_Valid_Email()
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
    public void Should_Return_Normalize_Email_If_Contains_Dots_AndOr_Plus_Signs(string email)
    {
        const string assert = "manuelmoreno@test.com";
        var validEmail = Email.Create(email);

        // Assert
        validEmail.EmailAddress.Should().Be(assert);
    }
}