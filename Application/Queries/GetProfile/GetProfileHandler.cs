using Eventide.UserService.Application.Common;
using Eventide.UserService.Application.DTOs;
using Eventide.UserService.Domain.Interfaces;
using MediatR;

namespace Eventide.UserService.Application.Queries.GetProfile;

public class GetProfileHandler : IRequestHandler<GetProfileQuery, Result<UserProfileDto>>
{
    private readonly IUserProfileRepository _repo;

    public GetProfileHandler(IUserProfileRepository repo) => _repo = repo;

    public async Task<Result<UserProfileDto>> Handle(GetProfileQuery req, CancellationToken ct)
    {
        var profile = await _repo.GetByIdAsync(req.UserId, ct);
        if (profile is null) return Result<UserProfileDto>.Failure("Profile not found");

        return Result<UserProfileDto>.Success(new UserProfileDto
        {
            Id = profile.Id,
            AuthUserId = profile.AuthUserId,
            Username = profile.Username,
            DisplayName = profile.DisplayName,
            AvatarUrl = profile.AvatarUrl,
            Bio = profile.Bio,
            Reputation = profile.Reputation,
            GameRanks = profile.GameRanks
        });
    }
}