using Eventide.UserService.Application.Commands.CreateProfile;
using Eventide.UserService.Application.Commands.UpdateProfile;
using Eventide.UserService.Application.Queries.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eventide.UserService.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfile(Guid id, [FromBody] UpdateProfileCommand command)
    {
        var result = await _mediator.Send(command with { UserId = id });
        return result.IsSuccess ? Ok() : BadRequest(result.ErrorMessage);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfile(Guid id)
    {
        var result = await _mediator.Send(new GetProfileQuery { UserId = id });
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.ErrorMessage);
    }
}