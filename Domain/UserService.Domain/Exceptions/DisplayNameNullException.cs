using System;

namespace UserService.Domain.Exceptions;

public class DisplayNameNullException : ArgumentNullException
{
    public Guid EntityId { get; }

    public DisplayNameNullException(string paramName, Guid entityId)
        : base(paramName, "Display name must be specified for UserProfile.")
    {
        EntityId = entityId;
    }
}
