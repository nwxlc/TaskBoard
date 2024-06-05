using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Users.Commands;
using TaskBoard.Application.Users.Queries;
using TaskBoard.Infrastructure.Authentication;
using TaskBoard.Infrastructure.Contracts.User;

namespace TaskBoard.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    private readonly EmailSender _emailSender;

    public UserController(IMediator mediator, 
        EmailSender emailSender)
    {
        _mediator = mediator;
        _emailSender = emailSender;
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

        return Ok();
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUserRequest userRequest)
    {
        var command = new UserLoginCommand()
        {
            Email = userRequest.Email,
            Password = userRequest.Password
        };

        var token = await _mediator.Send(command);

        var query = new GetUserByEmailQuery()
        {
            Email = userRequest.Email
        };

        var user = await _mediator.Send(query);

        var response = new AuthenticateResponse(user.Id, token);

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Block(BlockUserRequest userRequest)
    {
        var query = new GetUserByIdQuery()
        {
            Id = userRequest.Id
        };

        var user = await _mediator.Send(query);

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddRole(AddRoleRequest roleRequest)
    {
        var command = new AddRoleToUserCommand()
        {
            RoleId = roleRequest.RoleId,
            UserId = roleRequest.UserId
        };

        await _mediator.Send(command);

        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddPermission(AddPermissionRequest permissionRequest)
    {
        var command = new AddPermissionToUserCommand()
        {
            PermissionId = permissionRequest.PermissionId,
            UserId = permissionRequest.UserId
        };

        await _mediator.Send(command);

        return Ok();
    }

    public async Task SendEmail(EmailSendRequest request)
    {
        var command = new SendEmailCommand()
        {
            Email = request.Email
        };

        var token = await _mediator.Send(command);

        var email = request.Email;

        await _emailSender.SendEmailAsync(email, "Восстановление пароля", token);
    }

    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var command = new ChangePasswordCommand()
        {
            Email = request.Email,
            Password = request.Password,
            Token = request.Token
        };

        await _mediator.Send(command);

        return Ok();
    }
}