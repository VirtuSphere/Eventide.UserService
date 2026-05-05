using Eventide.UserService.Domain.Entities;
using Eventide.UserService.Domain.Interfaces;
using Eventide.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eventide.UserService.Infrastructure.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly UserDbContext _context;

    public UserProfileRepository(UserDbContext context) => _context = context;

    public async Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken ct)
        => await _context.Profiles.FindAsync(new object[] { id }, ct);

    public async Task<UserProfile?> GetByAuthUserIdAsync(Guid authUserId, CancellationToken ct)
        => await _context.Profiles.FirstOrDefaultAsync(p => p.AuthUserId == authUserId, ct);

    public async Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct)
        => await _context.Profiles.FirstOrDefaultAsync(p => p.Username == username.ToLower(), ct);

    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct)
        => await _context.Profiles.AnyAsync(p => p.Username == username.ToLower(), ct);

    public async Task AddAsync(UserProfile profile, CancellationToken ct)
        => await _context.Profiles.AddAsync(profile, ct);

    public Task UpdateAsync(UserProfile profile, CancellationToken ct)
    {
        _context.Profiles.Update(profile);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync(CancellationToken ct) => await _context.SaveChangesAsync(ct);
}