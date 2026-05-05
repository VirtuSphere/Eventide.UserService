using Eventide.UserService.Application.Common;
using Eventide.UserService.Application.DTOs;
using MediatR;

namespace Eventide.UserService.Application.Queries.GetProfile;

public class GetProfileByAuthIdQuery : IRequest<Result<UserProfileDto>>
{
    public Guid AuthUserId { get; init; }
}