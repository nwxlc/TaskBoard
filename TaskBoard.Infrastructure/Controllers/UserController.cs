using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Commands.Users;
using TaskBoard.Application.Service;
using TaskBoard.Infrastructure.Contracts;
using TaskBoard.Infrastructure.Contracts.User;

namespace TaskBoard.Infrastructure.Controllers;

public class UserController : Controller
{
    private readonly RegisterService _registerService;

    public UserController(RegisterService registerService)
    {
        _registerService = registerService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserRequest userRequest)
    {
        var command = new UserRegisterCommand()
        {
            UserName = userRequest.UserName,
            Email = userRequest.Email,
            Password = userRequest.Password
        };

        var okString = await _registerService.Register(command);
        return Ok("");
    }
}