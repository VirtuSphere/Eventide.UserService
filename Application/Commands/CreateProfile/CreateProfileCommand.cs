using Eventide.UserService.Application.Common;
using MediatR;

namespace Eventide.UserService.Application.Commands.CreateProfile;

public class CreateProfileCommand : IRequest<Result<Guid>>
{
    public Guid AuthUserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
}