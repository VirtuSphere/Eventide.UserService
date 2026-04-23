using Eventide.UserService.Application.Common;
using MediatR;

namespace Eventide.UserService.Application.Commands.UpdateProfile;

public class UpdateProfileCommand : IRequest<Result>
{
    public Guid UserId { get; init; }
    public string? DisplayName { get; init; }
    public string? AvatarUrl { get; init; }
    public string? Bio { get; init; }
}