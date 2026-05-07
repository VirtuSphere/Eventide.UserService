using System;
using System.Threading;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.Domain.Repositories.Abstractions.Base;
using UserService.ValueObjects;
namespace UserService.Domain.Repositories.Abstractions.Repositories;

public interface IUserProfileRepository : IRepository<UserProfile, Guid>
{
    Task<UserProfile?> GetByAuthUserIdAsync(Guid authUserId, CancellationToken cancellationToken = default);
    Task<UserProfile?> GetByUsernameAsync(Username username, CancellationToken cancellationToken = default);
}
