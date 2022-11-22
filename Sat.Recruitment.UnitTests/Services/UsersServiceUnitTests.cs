using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Sat.Recruitment.Infrastructure.Dtos;
using Sat.Recruitment.Application.Infrastructure.Repositories.Interfaces;
using Sat.Recruitment.Application.Services.User;
using Sat.Recruitment.Domain.Enums;
using Xunit;

namespace Sat.Recruitment.UnitTests.Services;

public class UsersServiceUnitTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;

    public UsersServiceUnitTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
    }

    [Fact]
    public async Task Should_Return_Successful_UserServiceResponse()
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama 123";
        const string phone = "+50788889999";
        var money = Convert.ToDecimal(200.10);


        var userServiceRequestStub = new UserServiceRequest(name, email, address, phone, UserTypeEnum.SuperUser, money);

        var userList = new List<UserDto>();
        userList.Add(new UserDto("testname", "test@email", "4444444", "Panama12345", UserTypeEnum.Premium.ToString(),
            3999, 4444));
        userList.Add(new UserDto("testname2", "test2@email", "44444443", "Panama123455",
            UserTypeEnum.SuperUser.ToString(), 3999, 434));

        _userRepositoryMock.Setup(x => x.GetAll())
            .ReturnsAsync(userList);

        _userRepositoryMock.Setup(x => x.SaveUser(It.IsAny<UserDto>()));


        var userService = new UserService(_userRepositoryMock.Object);

        // Act
        var result = await userService.CreateUser(userServiceRequestStub);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Count().Should().Be(0);
        result.User.Name.Should().Be(name);
    }

    [Fact]
    public async Task Should_Return_FailedResult_When_Email_Exists()
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama 123";
        const string phone = "+50788889999";
        var money = Convert.ToDecimal(200.10);

        var userServiceRequestStub = new UserServiceRequest(name, email, address, phone, UserTypeEnum.SuperUser, money);

        var userList = new List<UserDto>();
        userList.Add(new UserDto("testname", "manuelmoreno@test.com", "4444444", "Panama12345",
            UserTypeEnum.Premium.ToString(), 3999, 4444));
        userList.Add(new UserDto("testname2", "test2@email", "44444443", "Panama123455",
            UserTypeEnum.SuperUser.ToString(), 3999, 434));

        _userRepositoryMock.Setup(x => x.GetAll())
            .ReturnsAsync(userList);

        _userRepositoryMock.Setup(x => x.SaveUser(It.IsAny<UserDto>()));


        var userService = new UserService(_userRepositoryMock.Object);

        // Act
        var result = await userService.CreateUser(userServiceRequestStub);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Count().Should().Be(1);
        result.User.Should().Be(null);
    }

    [Fact]
    public async Task Should_Return_FailedResult_When_Phone_Exists()
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama 123";
        const string phone = "+50788889999";
        var money = Convert.ToDecimal(200.10);


        var userServiceRequestStub = new UserServiceRequest(name, email, address, phone, UserTypeEnum.SuperUser, money);

        var userList = new List<UserDto>();
        userList.Add(new UserDto("testname", "manuelmoreno2@test.com", "4444444", "Panama12345",
            UserTypeEnum.Premium.ToString(), 3999, 4444));
        userList.Add(new UserDto("testname2", "test2@email", "+50788889999", "Panama123455",
            UserTypeEnum.SuperUser.ToString(), 3999, 434));

        _userRepositoryMock.Setup(x => x.GetAll())
            .ReturnsAsync(userList);

        _userRepositoryMock.Setup(x => x.SaveUser(It.IsAny<UserDto>()));


        var userService = new UserService(_userRepositoryMock.Object);

        // Act
        var result = await userService.CreateUser(userServiceRequestStub);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Count().Should().Be(1);
        result.User.Should().Be(null);
    }

    [Fact]
    public async Task Should_Return_FailedResult_When_Name_And_Address_Exists()
    {
        // Arrange
        const string name = "Manuel";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama 123";
        const string phone = "+50788889999";
        var money = Convert.ToDecimal(200.10);


        var userServiceRequestStub = new UserServiceRequest(name, email, address, phone, UserTypeEnum.SuperUser, money);

        var userList = new List<UserDto>();
        userList.Add(new UserDto("Manuel", "manuelmoreno2@test.com", "4444444", "Panama 123",
            UserTypeEnum.Premium.ToString(), 3999, 4444));
        userList.Add(new UserDto("testname2", "test2@email", "+5078888933", "Panama123455",
            UserTypeEnum.SuperUser.ToString(), 3999, 434));

        _userRepositoryMock.Setup(x => x.GetAll())
            .ReturnsAsync(userList);

        _userRepositoryMock.Setup(x => x.SaveUser(It.IsAny<UserDto>()));


        var userService = new UserService(_userRepositoryMock.Object);

        // Act
        var result = await userService.CreateUser(userServiceRequestStub);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Count().Should().Be(1);
        result.User.Should().Be(null);
    }

    [Fact]
    public async Task Should_Return_FailedResult_When_Name_Request_Name_Is_Empty()
    {
        // Arrange
        const string name = "";
        const string email = "manuelmoreno@test.com";
        const string address = "Panama 123";
        const string phone = "+50788889999";
        var money = Convert.ToDecimal(200.10);


        var userServiceRequestStub = new UserServiceRequest(name, email, address, phone, UserTypeEnum.SuperUser, money);

        var userList = new List<UserDto>();
        userList.Add(new UserDto("Manuel2", "manuelmoreno2@test.com", "4444444", "Panama 12344",
            UserTypeEnum.Premium.ToString(), 3999, 4444));
        userList.Add(new UserDto("testname2", "test2@email", "+5078888933", "Panama123455",
            UserTypeEnum.SuperUser.ToString(), 3999, 434));

        _userRepositoryMock.Setup(x => x.GetAll())
            .ReturnsAsync(userList);

        _userRepositoryMock.Setup(x => x.SaveUser(It.IsAny<UserDto>()));


        var userService = new UserService(_userRepositoryMock.Object);

        // Act
        var result = await userService.CreateUser(userServiceRequestStub);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Count().Should().Be(1);
        result.User.Should().Be(null);
    }
}