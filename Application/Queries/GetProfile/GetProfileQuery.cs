using Eventide.UserService.Application.Common;
using Eventide.UserService.Application.DTOs;
using MediatR;

namespace Eventide.UserService.Application.Queries.GetProfile;

public class GetProfileQuery : IRequest<Result<UserProfileDto>>
{
    public Guid UserId { get; init; }
}