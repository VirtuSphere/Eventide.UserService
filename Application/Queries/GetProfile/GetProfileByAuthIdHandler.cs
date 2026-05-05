using Eventide.UserService.Application.Common;
using Eventide.UserService.Application.DTOs;
using Eventide.UserService.Domain.Interfaces;
using MediatR;

namespace Eventide.UserService.Application.Queries.GetProfile;

public class GetProfileByAuthIdHandler : IRequestHandler<GetProfileByAuthIdQuery, Result<UserProfileDto>>
{
    private readonly IUserProfileRepository _repo;

    public GetProfileByAuthIdHandler(IUserProfileRepository repo) => _repo = repo;

    public async Task<Result<UserProfileDto>> Handle(GetProfileByAuthIdQuery req, CancellationToken ct)
    {
        var profile = await _repo.GetByAuthUserIdAsync(req.AuthUserId, ct);
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