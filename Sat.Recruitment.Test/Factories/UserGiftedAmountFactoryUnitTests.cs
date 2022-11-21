using FluentAssertions;
using Sat.Recruitment.Api.Domain.Entities.Factories.UserGiftedAmount;
using Sat.Recruitment.Api.Domain.Enums;
using Xunit;

namespace Sat.Recruitment.Test.Factories;

public class UserGiftedAmountFactoryUnitTests
{
    [Fact]
    public void Should_Return_NormalUserGiftedAmount_When_UserType_Is_Normal()
    {
        var user = UserGiftedAmountFactory.Create(UserTypeEnum.Normal, 20);

        // Assert
        user.Should().BeOfType<NormalUserGiftedAmount>();
    }

    [Fact]
    public void Should_Return_SuperUserGiftedAmount_When_UserType_Is_SuperUser()
    {
        var user = UserGiftedAmountFactory.Create(UserTypeEnum.SuperUser, 200);

        // Assert
        user.Should().BeOfType<SuperUserGiftedAmount>();
    }

    [Fact]
    public void Should_Return_PremiumUserGiftedAmount_When_UserType_Is_PremiumUser()
    {
        var user = UserGiftedAmountFactory.Create(UserTypeEnum.Premium, 200);

        // Assert
        user.Should().BeOfType<PremiumUserGiftedAmount>();
    }
}