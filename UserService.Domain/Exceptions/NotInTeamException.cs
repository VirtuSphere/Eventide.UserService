using System;

namespace UserService.Domain.Exceptions;

public class NotInTeamException : InvalidOperationException
{
    public Guid UserId { get; }
    public Guid TeamId { get; }

    public NotInTeamException(Guid userId, Guid teamId)
        : base($"User {userId} is not a member of team {teamId}.")
    {
        UserId = userId;
        TeamId = teamId;
    }
}
