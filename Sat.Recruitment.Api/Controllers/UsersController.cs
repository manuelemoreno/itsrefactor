using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers.Requests;
using Sat.Recruitment.Api.Filters;
using Sat.Recruitment.Api.Services.User;

namespace Sat.Recruitment.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiAuthorization]
public class UsersController : ControllerBase
{
    public readonly IUserService UserService;

    public UsersController(IUserService userService)
    {
        UserService = userService;
    }

    [HttpPost]
    [Route("/create-user")]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest createUserRequest)
    {
        var userServiceRequest = new UserServiceRequest(createUserRequest.Name,
            createUserRequest.Email, createUserRequest.Address, createUserRequest.Phone, createUserRequest.UserType,
            createUserRequest.Money);

        try
        {
            var createUser = await UserService.CreateUser(userServiceRequest);

            if (!createUser.IsSuccess)
                return new BadRequestObjectResult(createUser);

            return new OkObjectResult(createUser);
        }
        catch
        {
            return new BadRequestResult();
        }
    }
}