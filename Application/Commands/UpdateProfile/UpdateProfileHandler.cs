using Eventide.UserService.Application.Common;
using Eventide.UserService.Domain.Interfaces;
using MediatR;

namespace Eventide.UserService.Application.Commands.UpdateProfile;

public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, Result>
{
    private readonly IUserProfileRepository _repo;

    public UpdateProfileHandler(IUserProfileRepository repo) => _repo = repo;

    public async Task<Result> Handle(UpdateProfileCommand req, CancellationToken ct)
    {
        var profile = await _repo.GetByIdAsync(req.UserId, ct);
        if (profile is null) return Result.Failure("Profile not found");

        profile.UpdateProfile(req.DisplayName, req.AvatarUrl, req.Bio);
        await _repo.SaveChangesAsync(ct);

        return Result.Success();
    }
}