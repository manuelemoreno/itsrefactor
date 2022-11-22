using System;
using FluentAssertions;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
using Xunit;

namespace Sat.Recruitment.UnitTests.Entities;

public class UserUnitTests
{
    [Fact]
    public void Should_Return_ValidUser()
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama";
        const string phone = "+50788889999";
        const UserTypeEnum userType = UserTypeEnum.SuperUser;
        var money = Convert.ToDecimal(200.10);

        //Act
        var user = User.Create(name, email, address, phone, userType, money);

        // Assert
        user.Name.Should().Be(name);
        user.Email.EmailAddress.Should().Be(email);
        user.OriginalMoney.Should().Be(money);
    }

    [Fact]
    public void Should_Return_NormalizeUser_Email()
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuel.moreno@test.com";
        const string address = "Panama";
        const string phone = "+50788889999";
        const UserTypeEnum userType = UserTypeEnum.SuperUser;
        var money = Convert.ToDecimal(200.10);

        //Act
        var user = User.Create(name, email, address, phone, userType, money);

        // Assert
        user.Name.Should().Be(name);
        user.Email.EmailAddress.Should().Be("manuelmoreno@test.com");
        user.OriginalMoney.Should().Be(money);
    }

    [Theory]
    [InlineData(20)]
    [InlineData(99)]
    [InlineData(11)]
    [InlineData(50)]
    public void
        Should_Return_User_With_Correct_Gifted_Amount_If_UserType_Is_Normal_And_Original_Amount_Greater_Than_10_And_Lower_Than_100(
            double amount)
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama";
        const string phone = "+50788889999";
        const UserTypeEnum userType = UserTypeEnum.Normal;
        var money = Convert.ToDecimal(amount);

        var user = User.Create(name, email, address, phone, userType, money);

        // Assert
        user.Name.Should().Be(name);
        user.Email.EmailAddress.Should().Be("manuelmoreno@test.com");
        user.OriginalMoney.Should().Be(money);
        user.GiftedAmount.Should().Be(money * Convert.ToDecimal(0.8));
    }

    [Theory]
    [InlineData(101)]
    [InlineData(200)]
    [InlineData(999)]
    public void
        Should_Return_User_With_Correct_Gifted_Amount_If_UserType_Is_Normal_And_Original_Amount_Greater_Than_100(
            double amount)
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama";
        const string phone = "+50788889999";
        const UserTypeEnum userType = UserTypeEnum.Normal;
        var money = Convert.ToDecimal(amount);

        var user = User.Create(name, email, address, phone, userType, money);

        // Assert
        user.Name.Should().Be(name);
        user.Email.EmailAddress.Should().Be("manuelmoreno@test.com");
        user.OriginalMoney.Should().Be(money);
        user.GiftedAmount.Should().Be(money * Convert.ToDecimal(0.12));
    }

    [Theory]
    [InlineData(101)]
    [InlineData(200)]
    [InlineData(999)]
    public void
        Should_Return_User_With_Correct_Gifted_Amount_If_UserType_Is_SuperUser_And_Original_Amount_Greater_Than_100(
            double amount)
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama";
        const string phone = "+50788889999";
        const UserTypeEnum userType = UserTypeEnum.SuperUser;
        var money = Convert.ToDecimal(amount);

        var user = User.Create(name, email, address, phone, userType, money);

        // Assert
        user.Name.Should().Be(name);
        user.Email.EmailAddress.Should().Be("manuelmoreno@test.com");
        user.OriginalMoney.Should().Be(money);
        user.GiftedAmount.Should().Be(money * Convert.ToDecimal(0.2));
    }

    [Theory]
    [InlineData(101)]
    [InlineData(200)]
    [InlineData(999)]
    public void
        Should_Return_User_With_Correct_Gifted_Amount_If_UserType_Is_PremiumUser_And_Original_Amount_Greater_Than_100(
            double amount)
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama";
        const string phone = "+50788889999";
        const UserTypeEnum userType = UserTypeEnum.Premium;
        var money = Convert.ToDecimal(amount);

        var user = User.Create(name, email, address, phone, userType, money);

        // Assert
        user.Name.Should().Be(name);
        user.Email.EmailAddress.Should().Be("manuelmoreno@test.com");
        user.OriginalMoney.Should().Be(money);
        user.GiftedAmount.Should().Be(money * Convert.ToDecimal(2));
    }
}