using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Controllers.Requests;
using Sat.Recruitment.Api.Domain.Entities;
using Sat.Recruitment.Api.Domain.Enums;
using Sat.Recruitment.Api.Services.User;
using Xunit;

namespace Sat.Recruitment.Test.Controllers;

public class UsersControllerUnitTests
{
    private readonly Mock<IUserService> _userServiceMock;

    public UsersControllerUnitTests()
    {
        _userServiceMock = new Mock<IUserService>();
    }

    [Fact]
    public async Task Should_Return_OkObjectResult()
    {
        // Arrange
        var name = "Manuel";
        var email = "manuelmoreno@test.com";
        var address = "Panama";
        var phone = "+50788889999";
        var userTypeId = 1;
        var money = Convert.ToDecimal(200.10);


        var userRequestStub = new CreateUserRequest
        {
            Name = name,
            Email = email,
            Address = address,
            Phone = phone,
            Money = money,
            UserType = (UserTypeEnum) userTypeId
        };

        var user = User.Create(name, email, address, phone, UserTypeEnum.SuperUser, money);


        _userServiceMock.Setup(x => x.CreateUser(It.IsAny<UserServiceRequest>()))
            .ReturnsAsync(new UserServiceResponse(true, null, user));

        var userController = new UsersController(_userServiceMock.Object);

        // Act
        var result = await userController.Post(userRequestStub);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task Should_Return_BadRequestObjectResult()
    {
        // Arrange
        var name = "Manuel";
        var email = "manuelmoreno@test.com";
        var address = "Panama";
        var phone = "+50788889999";
        var userTypeId = 1;
        var money = Convert.ToDecimal(200.10);


        var userRequestStub = new CreateUserRequest
        {
            Name = name,
            Email = email,
            Address = address,
            Phone = phone,
            Money = money,
            UserType = (UserTypeEnum) userTypeId
        };

        var user = User.Create(name, email, address, phone, UserTypeEnum.SuperUser, money);

        var errors = new List<string>();
        errors.Add("Duplicate User");

        _userServiceMock.Setup(x => x.CreateUser(It.IsAny<UserServiceRequest>()))
            .ReturnsAsync(new UserServiceResponse(false, errors, null));

        var userController = new UsersController(_userServiceMock.Object);

        // Act
        var result = await userController.Post(userRequestStub);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }
}