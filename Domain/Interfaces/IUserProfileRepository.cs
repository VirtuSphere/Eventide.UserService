using Eventide.UserService.Domain.Entities;

namespace Eventide.UserService.Domain.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<UserProfile?> GetByAuthUserIdAsync(Guid authUserId, CancellationToken ct = default);
    Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct = default);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct = default);
    Task AddAsync(UserProfile profile, CancellationToken ct = default);
    Task UpdateAsync(UserProfile profile, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}