using Eventide.UserService.Application.Common;
using Eventide.UserService.Domain.Entities;
using Eventide.UserService.Domain.Interfaces;
using MediatR;

namespace Eventide.UserService.Application.Commands.CreateProfile;

public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, Result<Guid>>
{
    private readonly IUserProfileRepository _repo;

    public CreateProfileHandler(IUserProfileRepository repo) => _repo = repo;

    public async Task<Result<Guid>> Handle(CreateProfileCommand req, CancellationToken ct)
    {
        if (await _repo.ExistsByUsernameAsync(req.Username, ct))
            return Result<Guid>.Failure("Username already taken");

        var profile = UserProfile.Create(req.AuthUserId, req.Username, req.DisplayName);
        await _repo.AddAsync(profile, ct);
        await _repo.SaveChangesAsync(ct);

        return Result<Guid>.Success(profile.Id);
    }
}