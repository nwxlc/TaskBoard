using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Users.Commands;
using TaskBoard.Infrastructure.Contracts.User;

namespace TaskBoard.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Registration")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterUserRequest userRequest)
    {
        var command = new UserRegisterCommand()
        {
            UserName = userRequest.UserName,
            Email = userRequest.Email,
            Password = userRequest.Password
        };
    
        var token = await _mediator.Send(command);
        return Ok(token);
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUserRequest userRequest)//, HttpContext context)
    {
        var command = new UserLoginCommand()
        {
            Email = userRequest.Email,
            Password = userRequest.Password
        };

        var token = await _mediator.Send(command);
        
        //context.Response.Cookies.Append("cookieshahaha", token);

        return Ok(token);
    }
}