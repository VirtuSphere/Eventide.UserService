using System;

namespace UserService.Domain.Exceptions;

public class UsernameNullException : ArgumentNullException
{
    public Guid EntityId { get; }

    public UsernameNullException(string paramName, Guid entityId)
        : base(paramName, "Username must be specified for UserProfile.")
    {
        EntityId = entityId;
    }
}
